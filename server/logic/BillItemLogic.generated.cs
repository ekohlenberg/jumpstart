using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class BillItemLogic : Logic
    {
    
        public static List<BillItem> select()
        {
            Console.WriteLine("Processing BillItemLogic select List" );

            List<BillItem> billitems = [];

            void billitemCallback(System.Data.Common.DbDataReader rdr) 
            {
                BillItem billitem = [];

                DBPersist.autoAssign(rdr, billitem);

                billitems.Add(billitem);
            };

            DBPersist.select(billitemCallback, "select * from app.bill_item");

            return billitems;
        }

        
        public static BillItem get(long id)
        {
            Console.WriteLine("Processing BillItemLogic get ID=" + id.ToString());

            BillItem billitem = [];
            billitem.id = id;

            DBPersist.get(billitem);

            return billitem;
        }

        
        public static void insert( BillItem billitem)
        {
            Console.WriteLine("Processing BillItemLogic insert: " + billitem.ToString()  );

            billitem.is_active = "Y";

            DBPersist.insert(billitem);
        }

       
        public static void update(long id,  BillItem billitem)
        {
            Console.WriteLine("Processing BillItemLogic update: ID = " + id.ToString() + "\n" + billitem.ToString()  );

            billitem.id = id;
            DBPersist.update(billitem);
        }

        
        public static void delete(long id)
        {
            BillItem billitem = get(id);
            billitem.is_active = "N";
             DBPersist.update(billitem);
        }
    }
}
