
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class BillLogic : BaseLogic, IBillLogic
    {


        public static IBillLogic Create()
        {

            var bill = new BillLogic();
            var proxy = DispatchProxy.Create<IBillLogic, Proxy<IBillLogic>>();
            ((Proxy<IBillLogic>)proxy).Target = bill;
            ((Proxy<IBillLogic>)proxy).BeforeAction = () => Console.WriteLine("Before method call");
            ((Proxy<IBillLogic>)proxy).AfterAction = () => Console.WriteLine("After method call");

            //proxy.PerformAction();
            return proxy;
        }

        public  List<Bill> select()
        {
            Console.WriteLine("Processing BillLogic select List");

            List<Bill> bills = new List<Bill>();

            void billCallback(System.Data.Common.DbDataReader rdr)
            {
                Bill bill = new Bill();

                DBPersist.autoAssign(rdr, bill);

                bills.Add(bill);
            };

            DBPersist.select(billCallback, $"select * from app.bill");

            return bills;
        }

        public  Bill get(long id)
        {
            Console.WriteLine($"Processing BillLogic get ID={id}");

            Bill bill = new Bill();
            bill.id = id;

            DBPersist.get(bill);

            return bill;
        }

        public  void insert(Bill bill)
        {
            Console.WriteLine($"Processing BillLogic insert: {bill}");

            bill.is_active = 1;

            DBPersist.insert(bill);
        }

        public  void update(long id, Bill bill)
        {
            Console.WriteLine($"Processing BillLogic update: ID = {id}\n{bill}");

            bill.id = id;
            DBPersist.update(bill);
        }

        public  void delete(long id)
        {
            Bill bill = get(id);
            bill.is_active = 0;
            DBPersist.update(bill);
        }
    }
}
