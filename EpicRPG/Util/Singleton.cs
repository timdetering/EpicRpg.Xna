using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EpicRPG.Util
{
    public class Singleton<T> where T : new()
    {
        static Mutex mutex = new Mutex();
        static T instance;

        public static T getInstance(){
            mutex.WaitOne();
            if (instance == null){
                instance = new T();
            }
            mutex.ReleaseMutex();
            return instance;
        }
    }
}
