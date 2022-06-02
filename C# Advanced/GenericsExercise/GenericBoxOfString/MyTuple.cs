using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    class MyTuple<T1, T2, T3>
    {
        public MyTuple(T1 itam1, T2 itam2, T3 itam3)
        {
            Itam1 = itam1;
            Itam2 = itam2;
            Itam3 = itam3;
        }
        public T1 Itam1 { get; set; }
        public T2 Itam2 { get; set; }
        public T3 Itam3 { get; set; }
        public override string ToString()
        {
            return $"{Itam1} -> {Itam2} -> {Itam3}";
        }
    }
}
