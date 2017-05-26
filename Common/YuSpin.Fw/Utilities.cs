using System;

namespace YuSpin.Fw
{
    public class Utilities
    {
        public static TObject CreateInstance<TObject>() where TObject : class
        {
            return Activator.CreateInstance<TObject>();
        }
        public static TObject CreateInstance<TObject, TParam>(TParam parameter) where TObject : class
        {
            return Activator.CreateInstance(typeof(TObject), new object[] { parameter }) as TObject;
        }
        //public static TObject CreateInstance<TObject, TParam>(TParam[] parameters) where TObject : class
        //{
        //    return Activator.CreateInstance(typeof(TObject), parameters) as TObject;
        //}
        public static TObject CreateInstance<TObject>(object[] parameters) where TObject : class
        {
            return Activator.CreateInstance(typeof(TObject), parameters) as TObject;
        }
    }
}
