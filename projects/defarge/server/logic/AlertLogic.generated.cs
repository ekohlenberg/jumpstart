
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class AlertLogic : IAlertLogic
    {


        public static IAlertLogic Create()
        {
            var alert = new AlertLogic();

            var proxy = DispatchProxy.Create<IAlertLogic, Proxy<IAlertLogic>>();
            ((Proxy<IAlertLogic>)proxy).Initialize();
            ((Proxy<IAlertLogic>)proxy).Target = alert;
            ((Proxy<IAlertLogic>)proxy).DomainObj = "Alert";

            return proxy;
        }



        public  List<Alert> select()
        {
            Console.WriteLine("Processing AlertLogic select List");

            List<Alert> alerts = new List<Alert>();

            void alertCallback(System.Data.Common.DbDataReader rdr)
            {
                Alert alert = new Alert();

                DBPersist.autoAssign(rdr, alert);

                alerts.Add(alert);
            };

            DBPersist.select(alertCallback, $"select * from app.alert");

            return alerts;
        }

        public  Alert get(long id)
        {
            Console.WriteLine($"Processing AlertLogic get ID={id}");

            Alert alert = new Alert();
            alert.id = id;

            DBPersist.get(alert);

            return alert;
        }

        public  void insert(Alert alert)
        {
            Console.WriteLine($"Processing AlertLogic insert: {alert}");

            alert.is_active = 1;

            DBPersist.insert(alert);
        }

        public  void update(long id, Alert alert)
        {
            Console.WriteLine($"Processing AlertLogic update: ID = {id}\n{alert}");

            alert.id = id;
            DBPersist.update(alert);
        }

        public  void delete(long id)
        {
            Alert alert = get(id);
            alert.is_active = 0;
            DBPersist.update(alert);
        }
    }
}
