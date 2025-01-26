using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
 

namespace legr3 
{

  

    public class Proxy<T> : DispatchProxy 
    {   
        public T Target { get; set; }
        public string DomainObj { get; set; }
        public List<Action<MethodInfo, object[]>> BeforeActions = new();
        public List<Action<MethodInfo, object, object[]>> AfterActions = new();

        public void AddBeforeAction(Action<MethodInfo, object[]> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            BeforeActions.Add(action);
        }



        public void AddAfterAction(Action<MethodInfo, object, object[]> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            AfterActions.Add(action);
        }

        
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {

            foreach (var action in BeforeActions)
            {
                action.Invoke(targetMethod, args);
            }

            var result = targetMethod.Invoke(Target, args);

             foreach (var action in AfterActions)
            {
                action.Invoke(targetMethod, result, args);
            }


            return result;
        }

        public virtual void Initialize()
        {

            AddBeforeAction((method, args) =>
            {
                // Log the method name and arguments
                Logger.Info($"Invoking {DomainObj}.{method.Name}."/* with arguments: {string.Join(", ", args)}"*/);
            });

            AddBeforeAction((method, args) =>
            {
                // Log the method name and arguments
                

                Logger.Debug($"Checking {Environment.UserName} authorization for {DomainObj}.{method.Name}."/*" with arguments: {string.Join(", ", args)}"*/);

                bool authorized = OpRoleMemberLogic.Authorized( DomainObj, method.Name );

                if (authorized)
                {
                    Logger.Debug($"{Environment.UserName} is authorized for {DomainObj}.{method.Name}."/* with arguments: {string.Join(", ", args)}"*/);
                } 
                else
                { 
                    throw new Exception($"User {Environment.UserName} is not authorized for {DomainObj}.{method.Name}.");
                }

            });

            

           AddBeforeAction((method, args) =>
            {
                // Log the method name and arguments
                Logger.Info($"invoking pre event service for {DomainObj}.{method.Name}." /*with arguments: {string.Join(", ", args)}"*/);

                EventContext ctx = new EventContext("post", DomainObj, method.Name, args);

                EventServiceLogic.Invoke( ctx ); 

                if (ctx.EventException != null) throw ctx.EventException;
                
            });


            AddAfterAction((method, result, args) =>
            {
                // Log the method name and arguments
                Logger.Info($"After invoking {method.Name}."/* with arguments: {string.Join(", ", args)}"*/);
            });

            AddAfterAction((method, result, args) =>
            {
                // Log the method name and arguments
                Logger.Info($"invoking post event service for or {DomainObj}.{method.Name}." /* with arguments: {string.Join(", ", args)}"*/);

                EventContext ctx = new EventContext("post", DomainObj, method.Name, args, result);

                EventServiceLogic.Invoke( ctx ); 
               
               if (ctx.EventException != null) throw ctx.EventException;
            });
        }


       

    }


}
