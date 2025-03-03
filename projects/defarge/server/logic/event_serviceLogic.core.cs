
using System;


namespace defarge
{
    

    public class EventContext
    {
        public string EventType { get; private set;}
        public string ObjectName { get; private set;}
        public string MethodName{ get; private set;}
        public object[] Args {get; private set;} 
        public object? EventResult { get; private set;} = null;
        public object? MethodResult{ get; private set;} = null;
        public Exception? EventException{ get; set;} = null;

        public EventContext(string eventType, string objectName, string methodName, object[] args)
        {
            EventType = eventType;
            ObjectName = objectName;
            MethodName = methodName;
            Args = args;
        }

        public EventContext(string eventType, string objectName, string methodName, object[] args, object methodResult)
        {
            EventType = eventType;
            ObjectName = objectName;
            MethodName = methodName;
            Args = args;
            MethodResult = methodResult;
        }
    }
    public partial class EventServiceLogic
    {

        protected static Dictionary< string, List<Script> > scriptCache = new();
        protected static object cacheLock = new object();

        public static void Invoke( EventContext eventContext )
        {
            string[] keyArray = new  string[] { eventContext.ObjectName, eventContext.MethodName};

            string key = string.Join(":", keyArray);

            List<Script> scripts = new();

            lock(cacheLock)
            {
                if (scriptCache.ContainsKey(key))
                {
                    scripts = scriptCache[key];
                }
                else
                {
                    string sql = @"SELECT s.id, s.name, s.source, s.is_active, s.created_by, s.last_updated, s.last_updated_by, s.version
    FROM core.event_service e
inner join core.script s on
    s.id=e.script_id
where
e.event_type='^(eventtype)' and
'^(objectname)' like e.objectname_filter and
'^(methodname)' like e.methodname_filter";

                    BaseObject filter = new();
                    filter["eventtype"] = eventContext.EventType;
                    filter["objectname"] = eventContext.ObjectName;
                    filter["methodname"] = eventContext.MethodName;
                    

                    void  scriptCallback(System.Data.Common.DbDataReader rdr)
                    {
                        
                        Script s = new Script();

                        DBPersist.autoAssign(rdr, s);

                        scripts.Add(s);
                    };
                    
                    DBPersist.select( scriptCallback, sql, filter);

                    scriptCache[key] = scripts;
                }
            } 

            if (scripts.Count > 0)
            {
                foreach ( Script s in scripts)
                {   // TODO - add a queued cache to contain a fixed number of script hosts
                    ScriptHost sh = new ScriptHost();
                    sh.Invoke<EventContext>(eventContext, s);
                }
            }


            
        }
        
    }
}

