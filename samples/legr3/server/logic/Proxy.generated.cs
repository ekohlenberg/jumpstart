using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
 

namespace legr3 
{

    public class Proxy<T> : DispatchProxy
    {
        public T Target { get; set; }
        public List<Action<MethodInfo, object[]>> BeforeActions = new();
        public List<Action<MethodInfo, object, object[]>> AfterActions = new();
        
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
//            BeforeAction?.Invoke();

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

        public void Initialize()
        {

            AddBeforeAction((method, args) =>
            {
                // Log the method name and arguments
                Logger.Info($"Before invoking {method.Name} with arguments: {string.Join(", ", args)}");
            });

            AddAfterAction((method, result, args) =>
            {
                // Log the method name and arguments
                Logger.Info($"After invoking {method.Name} with arguments: {string.Join(", ", args)}");
            });
        }


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


    }

/*
    #nullable enable

    public class Proxy2<T> : DispatchProxy
    {
        private readonly List<Action<MethodInfo, object[]>> _beforeActions = new();
        private readonly List<Action<MethodInfo, object, object[]>> _afterActions = new();

        public T Target { get; set; }

        public static T Create<T>(
            IEnumerable<Action<MethodInfo, object[]>> beforeActions = null,
            IEnumerable<Action<MethodInfo, object, object[]>> afterActions = null)
            where T : class
        {
            var proxy = DispatchProxy.Create<T, Proxy2<T>>() as Proxy2<T>;

            proxy.Initialize(beforeActions, afterActions);

            return proxy as T;
        }

        public void Initialize(
            IEnumerable<Action<MethodInfo, object[]>> beforeActions = null,
            IEnumerable<Action<MethodInfo, object, object[]>> afterActions = null)
        {
            if (beforeActions != null)
            {
                _beforeActions.AddRange(beforeActions);
            }

            if (afterActions != null)
            {
                _afterActions.AddRange(afterActions);
            }

            AddBeforeAction((method, args) =>
            {
                // Log the method name and arguments
                Logger.Info($"Before invoking {method.Name} with arguments: {string.Join(", ", args)}");
            });
        }

        public void AddBeforeAction(Action<MethodInfo, object[]> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            _beforeActions.Add(action);
        }

        public void AddAfterAction(Action<MethodInfo, object, object[]> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            _afterActions.Add(action);
        }

        public void RemoveBeforeAction(Action<MethodInfo, object[]> action)
        {
            _beforeActions.Remove(action);
        }

        public void RemoveAfterAction(Action<MethodInfo, object, object[]> action)
        {
            _afterActions.Remove(action);
        }

        protected override object Invoke(MethodInfo? targetMethod, object[]? args)
        {
            if (targetMethod == null) throw new ArgumentNullException(nameof(targetMethod));
            args = Array.Empty<object>();

            foreach (var action in _beforeActions)
            {
                action.Invoke(targetMethod, args);
            }

            var result = targetMethod.Invoke(Target, args);
            
            foreach (var action in _afterActions)
            {
                action.Invoke(targetMethod, result, args);
            }

            return result;
        }
    }

    #nullable disable
    */
}
