using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SingletonPattern
{
    public sealed class SingletonThreadSafe
    {
        private static readonly object padlock = new object();
        private static SingletonThreadSafe instnace = null;

        /// <summary>
        /// A single constructor, which is private and parameterless
        /// </summary>
        private SingletonThreadSafe()
        {

        }

        private int CheckValue;
        public void Test()
        {
            CheckValue++;
            Console.WriteLine(CheckValue);
            Thread.Sleep(100);
        }

        public static SingletonThreadSafe Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instnace == null)
                        instnace = new SingletonThreadSafe();

                    return instnace;
                }
            }
        }
    }
}
