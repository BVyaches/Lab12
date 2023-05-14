using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinTree
{
    public class BinNode<T> where T : class
    {
        public T Data { get; set; }
        public BinNode<T>? Left { get; set; }
        public BinNode<T>? Right { get; set; }
        

        public BinNode(T data)
        {
            Data = data;
        }
    }
}
