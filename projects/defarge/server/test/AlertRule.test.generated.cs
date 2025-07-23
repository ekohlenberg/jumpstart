using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class AlertRuleTest : BaseTest
    {
        public static void testInsert()
        {
            var alertrule = new AlertRule();


                    alertrule.metric_id = BaseTest.getLastId("metric");
                    
                    alertrule.name = Convert.ToString(BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random));
                    
                    alertrule.condition = Convert.ToString(BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random));
                    
                    alertrule.threshold = Convert.ToDecimal(BaseTest.getTestData(alertrule, "NUMERIC(18,4)", TestDataType.random));
                    
                    alertrule.recipients = Convert.ToString(BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing AlertRuleLogic insert: " + alertrule.ToString());
                AlertRuleLogic.Create().insert(alertrule);
                BaseTest.addLastId("alert_rule", alertrule.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("AlertRule");
            var alertrule = AlertRuleLogic.Create().get(lastId);


                            alertrule.metric_id = BaseTest.getLastId("metric");
                        
                        alertrule.name = (string) BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random);
                    
                        alertrule.condition = (string) BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random);
                    
                        alertrule.threshold = (object) BaseTest.getTestData(alertrule, "NUMERIC(18,4)", TestDataType.random);
                    
                        alertrule.recipients = (string) BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing AlertRuleLogic update: " + alertrule.ToString());
                AlertRuleLogic.Create().update(lastId, alertrule);
                    }
    }
}
