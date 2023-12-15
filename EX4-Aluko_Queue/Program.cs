using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




/*
 * Tyler Aluko
 * IGME.201 - Unit Test #4 (Final)
 * This console application is a queue class, using a List<int> to implement enqueue, dequeue, and peek methods.
 */
namespace EX4_Aluko_Queue
{


    //queue class, implementing three queue methods
    class MyQueue
    {

        private List<int> queueList = new List<int>(); //List<int> usage

        //enqueue method - add item to queue end
        public void Enqueue(int n)
        {
            queueList.Add(n);
        }

        //dequeue method - remove/return item at front of queue
        public int Dequeue()
        {

            if (queueList.Count == 0)
            { //if queue is empty
                throw new InvalidOperationException("Queue is empty."); //send error message
            }

            //remove item
            int frontItem = queueList[0];
            queueList.RemoveAt(0);
            return frontItem; //then return

        }

        //peek method - return item at front of queue w/o removal
        public int Peek()
        {

            if (queueList.Count == 0)
            { //if queue is empty
                throw new InvalidOperationException("Queue is empty."); //send error message
            }

            return queueList[0]; ; //return front queue item w/o removing item from queue

        }

    }

    class Program
    {

        static void Main()
        {

            MyQueue myQueue = new MyQueue(); //creates new stack class instance

            //add elements into queue
            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.Enqueue(30);

            //peek at front element
            Console.WriteLine("Peek: " + myQueue.Peek());

            //dequeue elements from queue
            Console.WriteLine("Dequeue: " + myQueue.Dequeue());
            Console.WriteLine("Dequeue: " + myQueue.Dequeue());

            //peeking after dequeues
            Console.WriteLine("Peek: " + myQueue.Peek());

            //dequeue from empty queue (throws exception)
            //Console.WriteLine("Dequeue: " + myQueue.Dequeue());

            Console.ReadLine();

        }

    }


}
