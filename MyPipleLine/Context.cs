using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace MyPipleLine
{
   public  class Context
    {
        public  void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
