
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class BillItemLogic : BaseLogic, IBillItemLogic
    {


        public static IBillItemLogic Create()
        {
            var billitem = new BillItemLogic();

            var proxy = DispatchProxy.Create<IBillItemLogic, Proxy<IBillItemLogic>>();
            ((Proxy<IBillItemLogic>)proxy).Initialize();
            ((Proxy<IBillItemLogic>)proxy).Target = billitem;

            return proxy;
        }



        public  List<BillItem> select()
        {
            Console.WriteLine("Processing BillItemLogic select List");

            List<BillItem> billitems = new List<BillItem>();

            void billitemCallback(System.Data.Common.DbDataReader rdr)
            {
                BillItem billitem = new BillItem();

                DBPersist.autoAssign(rdr, billitem);

                billitems.Add(billitem);
            };

            DBPersist.select(billitemCallback, $"select * from app.bill_item");

            return billitems;
        }

        public  BillItem get(long id)
        {
            Console.WriteLine($"Processing BillItemLogic get ID={id}");

            BillItem billitem = new BillItem();
            billitem.id = id;

            DBPersist.get(billitem);

            return billitem;
        }

        public  void insert(BillItem billitem)
        {
            Console.WriteLine($"Processing BillItemLogic insert: {billitem}");

            billitem.is_active = 1;

            DBPersist.insert(billitem);
        }

        public  void update(long id, BillItem billitem)
        {
            Console.WriteLine($"Processing BillItemLogic update: ID = {id}\n{billitem}");

            billitem.id = id;
            DBPersist.update(billitem);
        }

        public  void delete(long id)
        {
            BillItem billitem = get(id);
            billitem.is_active = 0;
            DBPersist.update(billitem);
        }
    }
}
