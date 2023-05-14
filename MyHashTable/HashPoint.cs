using ChallengeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHashTable
{
    public class HashPoint<T> where T: class, IComparable<T>, IComparer<T>, IInit, ICloneable
    {
        public object? key;//ключ
        public T? data;//значение
        public HashPoint(T data)
        {
            this.data = data;
            data.ToBase(ref key);
        }

        public override string ToString()
        {
            return key.ToString() + ":\n    " + data.ToString();
        }

        public override int GetHashCode()
        {            
            return data.GetHashCode();
        }

    }
}
