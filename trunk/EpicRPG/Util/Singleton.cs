using System;
using System.Collections.Generic;
using System.Text;

namespace EpicRPG.Util
{
    public class Singleton<T>
    {
        protected static T instance;
        public static T getInstance(){
            return instance;
        }
    }
}
