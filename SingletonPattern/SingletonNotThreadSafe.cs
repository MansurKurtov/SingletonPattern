using System;
using System.Threading;

namespace SingletonPattern
{
    /// <summary>
    /// Not thread safe singleton
    /// </summary>
    public sealed class SingletonNotThreadSafe
    {
        private int CheckValue;
        public void Test()
        {
            CheckValue++;
            Console.WriteLine(CheckValue);
            Thread.Sleep(100);
        }
        private static SingletonNotThreadSafe instnace = null;

        /// <summary>
        /// A single constructor, which is private and parameterless
        /// </summary>
        private SingletonNotThreadSafe()
        {

        }

        public static SingletonNotThreadSafe Instance
        {
            get
            {
                if (instnace == null)
                    instnace = new SingletonNotThreadSafe();
                return instnace;
            }
        }
    }
}
