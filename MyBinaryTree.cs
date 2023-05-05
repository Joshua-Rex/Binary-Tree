using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    //Class MyNode to hold one integer item
    //Left child leftChild 
    //Right child rightChild
    //Parent myParent (for root node myParent is NULL

    class MyNode
    {
        public int item;
        public MyNode leftChild;
        public MyNode rightChild;


        //Default Constructor
        public MyNode()
        {
            item = 0;
            leftChild = null;
            rightChild = null;
        }
        //Constructor with value parameter
        public MyNode(int value)
        {
            item = value;
            leftChild = null;
            rightChild = null;
        }
    }
    class MyBinaryTree
    {
        private MyNode root;

        //Default Constructor
        public MyBinaryTree()
        {
            root = null;
        }
        public MyNode ReturnRoot()
        {
            return root;
        }
        public void InsertNode(int id)
        {
            MyNode newNode = new MyNode(id);

            if (root == null)
            {
                //First element and it should be the root
                root = newNode;
            }
            else
            {
                //Assign the new node to the appropriate parent by comparing the item.
                //For example, if the given item is less then root's item then it goes to leftChild 
                //else go to the rightChild. Continue until you find a situation where

                MyNode current = root;
                while (true)
                {
                    //Add your code for building Binary tree
                    if (id < current.item)  //if id is less than the current item
                    {
                        if (current.leftChild == null)  //if left child is null
                        {
                            current.leftChild = newNode; //set the leftt child as the new node
                            break;
                        }
                        else //if not null                    
                            current = current.leftChild; //go to the left child
                    }
                    else //else the id is greater than or equal to the current item
                    {
                        if (current.rightChild == null) //if right child is null
                        {
                            current.rightChild = newNode; //set the right child as the new node
                            break;
                        }
                        else //if not null
                        {
                            current = current.rightChild; //go to the right child
                        }
                    }
                }
            }
        }

        //NOTE: USE RECURSION FOR ALL THE BELOW TRAVERSAL ALGORITHM
        // Preorder Function
        public void Preorder(MyNode tmpNode)
        {
            if (tmpNode == null)
                return;
            else
            {
                //Add your code for Pre-order traversal
                //Look at the lecture slides for pseudocode
                Console.WriteLine(tmpNode.item);
                Preorder(tmpNode.leftChild);
                Preorder(tmpNode.rightChild);
                
                /* This function checks if the node passed through it is null, if so it breaks the function
                *  if not it goes to the else statement. In the else statement, the node is printed out and then
                *  the current function is called on the left child. After this function is ran, the current function
                *  is called on the right child */
            }
        }

        // Inorder Function
        public void Inorder(MyNode tmpNode)
        {
            if (tmpNode == null)
                return;
            else
            {
                //Add your code for In-order traversal
                //Look at the lecture slides for pseudocode
                Inorder(tmpNode.leftChild);
                Console.WriteLine(tmpNode.item);
                Inorder(tmpNode.rightChild);

                /* This function checks if the node passed through it is null, if so it breaks the function
                 * if not it goes to the else statement. In the else statement, the current function is called on the
                 * left child. After that function has ran, the node is printed out and then the current function is called
                 * on the right child. */
            }
        }

        // Postorder Function
        public void Postorder(MyNode tmpNode)
        {
            //Start from the Root
            if (tmpNode == null)
                return;
            else
            {
                //Add your code for Post-order traversal
                //Look at the lecture slides for pseudocode
                Postorder(tmpNode.leftChild);
                Postorder(tmpNode.rightChild);
                Console.WriteLine(tmpNode.item);

                /* This function checks if the node passed through it is null, if so it breaks the function
                 * if not it goes to the else statement. In the else statement, the current function is called on the
                 * left child. After that function has ran, the current function is then ran on the right child. After
                 * that function ends, the node is printed out. */
            }
        }

        // Search Function
        public void search(MyNode tmpNode, int num)
        {
            if(tmpNode.item == num)
            {
                Console.WriteLine(tmpNode.item);
                return;
            }
            else if (tmpNode.item < num)
            {
                Console.WriteLine(tmpNode.item);
                tmpNode = tmpNode.rightChild;
                search(tmpNode, num);
            }
            else
            {
                Console.WriteLine(tmpNode.item);
                tmpNode = tmpNode.leftChild;
                search(tmpNode, num);
            }
            /* This function checks if the node passed through the parameters is equal to the number passed through
             * the parameters. If they are, the number is printed and the function ends. If node is less than the number
             * passed through the parameters, then the node is printed out and then moves to the right child before called
             * the current function again with the new node and the same number.*/
        }
        // Errors: Trying to close find a way to close the recursion after finding the correct number

        // Create a Depth-First-Search using Stacks
        // Depth-First Inorder with Stack
        public void DFInorder(MyNode node, int num)
        {
            Stack<MyNode> stack = new Stack<MyNode>();
            while (node != null)
            {
                while (node.leftChild != null)
                {
                    stack.Push(node);
                    node = node.leftChild;
                }
                Console.WriteLine(node.item);
                /* This function creates a new stack named 'stack' and then enters a while loop for as long as the node passed through the parameters isn't null
                *  Another while loop is then created that happens when the left child of the node isn't null, if the node isn't null, then the node is pushed onto
                *  the stack and the node moves to the left child. The loop checks if the new node has a left child and proceeds until there isn't.
                *  After the loop is broken the node is printed out. */
                if (node.item == num)
                {
                    Console.WriteLine();
                    Console.WriteLine("Path to Node: ");
                    Console.WriteLine(node.item);
                    foreach(MyNode trace in stack)
                    {
                        Console.WriteLine(trace.item);
                    }
                    return;
                    /* The function then uses a if statement to see if the node is equal to the number passed through the parameters, if it is then the function
                     * prints out the node again and then prints the path from the node to the root. After the path has been printed, the function ends. */
                }
                while (node.rightChild == null && stack.Count > 0)
                {
                    node = stack.Pop();
                    Console.WriteLine(node.item);
                    if (node.item == num)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Path to Node: ");
                        Console.WriteLine(node.item);
                        foreach(MyNode trace in stack)
                        {
                            Console.WriteLine(trace.item);
                        }
                        return;
                    }

                }
                node = node.rightChild;
                /* Another while loop is entered which checks if the node doesn't have a right child and if the stack count if above 0, if both are true then
                 * the while loop starts and doesn't break until one of the two conditions are broken. The node then becomes the last node pushed and the
                 * function prints out the node, if the node is the number passed through the parameters, then the node is printed again and the path to
                 * the node is printed out. After the path has been printed the function ends. If the node wasn't the same as the number passed through the
                 * parameters, then the node moves to the right child. */
            }
        }
        // Errors : Break - didn't break far enough; If statement - weren't in the correct spots so that they could catch the node.
        // Fixes : Return - Instead of using 2 break statements, I used 1 return

        // Depth-First Postorder with Stack
        public void DFPostorder(MyNode node, int num)
        {
            Stack<MyNode> stack = new Stack<MyNode>();
            MyNode lastNode = null;
            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.leftChild;
                }
                /* The function creates a new stack and creates a new node called 'lastNode' with a null value. After they have been created
                 * a while loop starts while the stack count is above 0 or if the node passed through the parameters isn't null. After the while
                 * loop, there is a if statement that checks if the node passed through the parameters is null or not, if it isn't then the node
                 * is pushed into the stack and it moves to the left child. */
                else
                {
                    MyNode peekNode = stack.Peek();
                    if (peekNode.rightChild != null && lastNode != peekNode.rightChild)
                        node = peekNode.rightChild;
                    else
                    {
                        Console.WriteLine(peekNode.item);
                        lastNode = stack.Pop();
                        /* If the node is null, then a new node is created with the name 'peekNode' which becomes the last node pushed onto the stack
                         * the function then runs a if statement to see if the peek node has a right child and if the last node isn't equal to that child
                         * if both the conditions are true, then the node moves to the right child of the peek node. If one or more of the conditions are
                         * false, then the else statement runs where the peek node is printed and the last node becomes the node last stored in the stack */
                        if (lastNode.item == num)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Path to Node: ");
                            Console.WriteLine(lastNode.item);
                            foreach (MyNode trace in stack)
                            {
                                Console.WriteLine(trace.item);
                            }
                            return;
                            /* An if statement is then run checking if the last node is equal to the number passed through the parameters, if they are the same
                             * the last node is printed again and then the path from that node to the root node is printed. After printing the function ends. */
                        }
                    }
                }
            }
        }

        // Create a Breadth-First-Search using Queue
        // Breadth-First Preorder with Queue
        public void BFPreorder(MyNode root, int num)
        {
            Queue<MyNode> q = new Queue<MyNode>();
            q.Enqueue(root);
            while(q.Count > 0)
            {
                MyNode node = q.Dequeue();
                Console.WriteLine(node.item);
                /* When the function runs a new queue is made named 'q' which then enqueue's the root before entering a
                *  while loop which loops while the queue is bigger than 0. The queued item is then stored within
                *  a new node called 'node' before printing the item of that node*/
                if (node.item == num)
                {
                    Console.WriteLine();
                    Console.WriteLine("Path to Node: ");
                    Console.WriteLine(node.item);
                    foreach(MyNode trace in q)
                    {
                        Console.WriteLine(trace.item);
                    }
                    return;
                    /* The node is then checked if it is equal to the number passed through the parameters, if it is then
                     * the node is then reprinted after some white space and then the node to the root is printed, then the
                     * function ends*/
                }

                if (node.leftChild != null)
                    q.Enqueue(node.leftChild);

                if (node.rightChild != null)
                    q.Enqueue(node.rightChild);
                /* If the node isn't equal to the number then the function checks if the node has a left child
                 * if so, then that child is enqueued. The function then checks if the node has a right child
                 * if so, then that child is also enqueued. */

            }
        }
    }

    class Program
    {
        public static MyNode root;

        static void Main(string[] args)
        {
            MyBinaryTree theTree = new MyBinaryTree();
            //Insert the following number to the tree and keep the order
            //25,15,26,13,22,30,20,23,28,33,16,17
            theTree.InsertNode(25);
            theTree.InsertNode(15);
            theTree.InsertNode(26);
            theTree.InsertNode(13);
            theTree.InsertNode(22);
            theTree.InsertNode(30);
            theTree.InsertNode(20);
            theTree.InsertNode(23);
            theTree.InsertNode(28);
            theTree.InsertNode(33);
            theTree.InsertNode(16);
            theTree.InsertNode(17);

            /*   ADD YOUR CODE HERE */
            root = theTree.ReturnRoot();

            //Do In-order traversal of this tree and print the items

            /*   ADD YOUR CODE HERE */
            Console.WriteLine("Inorder Traversal: ");
            theTree.Inorder(root);
            Console.WriteLine();

            //Do Pre-order traversal of this tree and print the items

            /*   ADD YOUR CODE HERE */
            Console.WriteLine("Preorder Traversal: ");
            theTree.Preorder(root);
            Console.WriteLine();

            //Do Post-order traversal of this tree and print the items

            /*   ADD YOUR CODE HERE */
            Console.WriteLine("Postorder Traversal: ");
            theTree.Postorder(root);
            Console.WriteLine();

            //Do Depth-First-Search for the item 20

            Console.WriteLine("Depth-First Inorder Search for 20: ");
            theTree.DFInorder(root, 20);
            Console.WriteLine();

            Console.WriteLine("Depth-First Postorder Search for 20: ");
            theTree.DFPostorder(root, 20);
            Console.WriteLine();

            //Do Breath-First-Search for the item 30

            Console.WriteLine("Breath-First Preorder Search for 30: ");
            theTree.BFPreorder(root, 30);
            Console.WriteLine();

            //Do Recursion to find both 20 and 30

            Console.WriteLine("Recursion Search for 20: ");
            theTree.search(root, 20);
            Console.WriteLine();

            Console.WriteLine("Recursion Search for 30: ");
            theTree.search(root, 30);
            Console.WriteLine();


        }
    }
}
