using ChallengeLibrary;

namespace lab
{
    public class LinkedNode<T> where T : class
    {
        public LinkedNode<T>? Previous { get; set; }
        public LinkedNode<T>? Next { get; set; }

        public T Data { get; set; }

        public LinkedNode (T data) 
        { 
            Data = data;
        }
    }
}
