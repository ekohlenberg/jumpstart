using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class OnEventTest : BaseTest
    {
        public static void testInsert()
        {
            var onevent = new OnEvent();


                    onevent.objectname = Convert.ToString(BaseTest.getTestData(onevent, "VARCHAR", TestDataType.random));
                    
                    onevent.methodname = Convert.ToString(BaseTest.getTestData(onevent, "VARCHAR", TestDataType.random));
                    
                    onevent.script_id = BaseTest.getLastId("script");
                    
                Console.WriteLine("Testing OnEventLogic insert: " + onevent.ToString());
                OnEventLogic.Create().insert(onevent);
                BaseTest.addLastId("OnEvent", onevent.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("OnEvent");
            var onevent = OnEventLogic.Create().get(lastId);


                        onevent.objectname = (string) BaseTest.getTestData(onevent, "VARCHAR", TestDataType.random);
                    
                        onevent.methodname = (string) BaseTest.getTestData(onevent, "VARCHAR", TestDataType.random);
                    
                            onevent.script_id = BaseTest.getLastId("script");
                        
                Console.WriteLine("Testing OnEventLogic update: " + onevent.ToString());
                OnEventLogic.Create().update(lastId, onevent);
                    }
    }
}
