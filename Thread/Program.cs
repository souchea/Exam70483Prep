using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Exam70483Prep.ThreadClass
{
    public static class Program
    {


        [ThreadStatic]
        public static int _field;

        public static void Main()
        {
            // Example1
            //Examples.SimpleThread();

            // Thread that get stopped
            //Examples.StoppedThread();

            // Thread with static attributes
            Examples.ThreadStaticAttributes();
        }
    }


}
