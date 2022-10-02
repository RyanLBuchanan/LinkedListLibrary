namespace LinkedListLibrary
{
    // Class to represent one node in list
    class ListNode
    {
        // Automatic read-only property Data
        public object Data { get; private set; }

        // Automatic property Next
        public ListNode Next { get; set; }

        // Constructor to create ListNode that refers to dataValue
        // and is the last node in the list
        public ListNode(object dataValue) : this(dataValue, null) { }

        // Constructor to create ListNode that refers to dataValue
        // and refers to the next ListNode in the List
        public ListNode(object dataValue, ListNode nextNode) 
        {
            Data = dataValue;
            Next = nextNode;
        }
    }

    // Class List declaration
    public class List
    {
        private ListNode firstNode;
        private ListNode lastNode;
        private string name;  // String like "list" to display

        // Construct empty List with specified name
        public List(string listName)
        {
            name = listName;
            firstNode = lastNode = null;
        }

        // Construct empty List with "list" as its own name
        public List() : this("list") { }

        // Insert object at front of List. If List is empty
        // firstNode and lastNode will refer to the same object.
        // Otherwise, firstNode refers to a new node.
        public void InsertAtFront(object insertItem)
        {
            if (IsEmpty())
            {
                firstNode = lastNode = new ListNode(insertItem);
            }
            else
            {
                firstNode = new ListNode(insertItem, firstNode);
            }
        }

        // Insert object at the end of the list.  If List is empty,
        // firstNode and lastNode will refer to the same object.
        // Otherwise, lastNode's Next property refers to new node.
        public void InsertAtBack(object insertItem)
        {
            if (IsEmpty())
            {
                firstNode = lastNode = new ListNode(insertItem);
            }
            else
            {
                lastNode = lastNode.Next = new ListNode(insertItem);
            }
        }

        // Remove first node from List
        public object RemoveFromFront()
        {
            if (IsEmpty())
            {
                throw new EmptyListException(name);
            }

            object removeItem = firstNode.Data;  // Retrieve data

            // Reset firstNode and lastNode references
            if(firstNode == lastNode)
            {
                firstNode = lastNode = null;
            }
            else
            {
                firstNode = firstNode.Next;
            }

            return removeItem;  // Return removed data
        }

        // Remove last node from List
        public object RemoveFromBack()
        {
            if (IsEmpty())
            {
                throw new EmptyListException(name);
            }

            object removedItem = lastNode.Data;  // Retrieve data

            // Reset firstNode and lastNode references
            if (firstNode == lastNode)
            {
                firstNode = lastNode = null;
            }
            else
            {
                ListNode current = firstNode;

                // Loop while current.Next is not the lastNode
                while (current.Next != lastNode)
                {
                    current = current.Next;  // Move to the next node
                }

                // Current is new lastNode
                lastNode = current;
                current.Next = null;
            }

            return removedItem;
        }

        // Return true if list is empty
        public bool IsEmpty()
        {
            return firstNode == null;
        }

        // Output List contents
        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine($"Empty {name}");
            }
            else
            {
                Console.WriteLine($"The {name} is: ");

                ListNode current = firstNode;

                // Output current node data while not at end of list
                while(current != null)
                {
                    Console.WriteLine($"{current.Data} ");
                    current = current.Next;
                }

                Console.WriteLine("\n");
            }
        }
    }

    // Class EmptyListException declaration
    public class EmptyListException : Exception
    {
        // Parameterless constructor
        public EmptyListException() : base("The list is empty") { }

        // One-parameter constructor
        public EmptyListException(string name) : base($"The {name} is empty") { }

        // Two-parameter constructor
        public EmptyListException(string exception, Exception inner) : base(exception, inner) { }
    }
}