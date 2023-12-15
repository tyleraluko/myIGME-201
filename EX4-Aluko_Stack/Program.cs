using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




/*
 * Tyler Aluko
 * IGME.201 - Unit Test #4 (Final)
 * This console application is a stack class, using a List<int> to implement push, pop, and peek methods.
 */
namespace EX4_Aluko_Stack
{
    
    
    //stack class, implementing three stack methods
    class MyStack
    {
        
        private List<int> stackList = new List<int>(); //List<int> usage

        //push method - push item onto stack
        public void Push(int n)
        {
            stackList.Add(n);
        }

        //pop method - remove/return item at top of stack
        public int Pop()
        {
            
            if (stackList.Count == 0)
            { //if stack is empty
                throw new InvalidOperationException("Stack is empty."); //send error message
            }

            //removes top stack item
            int lastIndex = stackList.Count - 1;
            int topItem = stackList[lastIndex];
            stackList.RemoveAt(lastIndex);
            return topItem; //then returns

        }

        //peek method - return item at top of stack w/o removal
        public int Peek()
        {
            
            if (stackList.Count == 0)
            { //if stack is empty
                throw new InvalidOperationException("Stack is empty."); //send error message
            }

            return stackList[stackList.Count - 1]; //return top stack item w/o removing item from stack

        }

    }

    class Program
    {
        
        static void Main()
        {
            
            MyStack myStack = new MyStack(); //creates new stack class instance

            //push elements onto stack
            myStack.Push(10);
            myStack.Push(20);
            myStack.Push(30);

            //peek at top element
            Console.WriteLine("Peek: " + myStack.Peek());

            //pop elements from stack
            Console.WriteLine("Pop: " + myStack.Pop());
            Console.WriteLine("Pop: " + myStack.Pop());

            //peeking after pops
            Console.WriteLine("Peek: " + myStack.Peek());

            //pop from empty stack (throws exception)
            //Console.WriteLine("Pop: " + myStack.Pop());

            Console.ReadLine();

        }

    }


}
