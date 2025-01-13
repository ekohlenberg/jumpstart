using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace legr3
{
    public class BaseLogic
    {
        public BaseLogic()
        {

        }
    }



    public class Proxy<T> : DispatchProxy
    {
        public T Target { get; set; }
        public Action BeforeAction { get; set; }
        public Action AfterAction { get; set; }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            BeforeAction?.Invoke();

            var result = targetMethod.Invoke(Target, args);

            AfterAction?.Invoke();

            return result;
        }
    }

    
   
}
