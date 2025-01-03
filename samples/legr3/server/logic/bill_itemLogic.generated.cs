
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class BillItemLogic : BaseLogic
    {
        public static List<BillItem> select()
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

        public static BillItem get(long id)
        {
            Console.WriteLine($"Processing BillItemLogic get ID={id}");

            BillItem billitem = new BillItem();
            billitem.id = id;

            DBPersist.get(billitem);

            return billitem;
        }

        public static void insert(BillItem billitem)
        {
            Console.WriteLine($"Processing BillItemLogic insert: {billitem}");

            billitem.is_active = 1;

            DBPersist.insert(billitem);
        }

        public static void update(long id, BillItem billitem)
        {
            Console.WriteLine($"Processing BillItemLogic update: ID = {id}\n{billitem}");

            billitem.id = id;
            DBPersist.update(billitem);
        }

        public static void delete(long id)
        {
            BillItem billitem = get(id);
            billitem.is_active = 0;
            DBPersist.update(billitem);
        }
    }
}