
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class AlertRuleLogic : IAlertRuleLogic
    {


        public static IAlertRuleLogic Create()
        {
            var alertrule = new AlertRuleLogic();

            var proxy = DispatchProxy.Create<IAlertRuleLogic, Proxy<IAlertRuleLogic>>();
            ((Proxy<IAlertRuleLogic>)proxy).Initialize();
            ((Proxy<IAlertRuleLogic>)proxy).Target = alertrule;
            ((Proxy<IAlertRuleLogic>)proxy).DomainObj = "AlertRule";

            return proxy;
        }



        public  List<AlertRule> select()
        {
            Console.WriteLine("Processing AlertRuleLogic select List");

            List<AlertRule> alertrules = new List<AlertRule>();

            void alertruleCallback(System.Data.Common.DbDataReader rdr)
            {
                AlertRule alertrule = new AlertRule();

                DBPersist.autoAssign(rdr, alertrule);

                alertrules.Add(alertrule);
            };

            DBPersist.select(alertruleCallback, $"select * from app.alert_rule");

            return alertrules;
        }

        public  AlertRule get(long id)
        {
            Console.WriteLine($"Processing AlertRuleLogic get ID={id}");

            AlertRule alertrule = new AlertRule();
            alertrule.id = id;

            DBPersist.get(alertrule);

            return alertrule;
        }

        public  void insert(AlertRule alertrule)
        {
            Console.WriteLine($"Processing AlertRuleLogic insert: {alertrule}");

            alertrule.is_active = 1;

            DBPersist.insert(alertrule);
        }

        public  void update(long id, AlertRule alertrule)
        {
            Console.WriteLine($"Processing AlertRuleLogic update: ID = {id}\n{alertrule}");

            alertrule.id = id;
            DBPersist.update(alertrule);
        }

        public  void delete(long id)
        {
            AlertRule alertrule = get(id);
            alertrule.is_active = 0;
            DBPersist.update(alertrule);
        }
    }
}
