using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class BillLogic : Logic
    {
    
        public static List<Bill> select()
        {
            Console.WriteLine("Processing BillLogic select List" );

            List<Bill> bills = [];

            void billCallback(System.Data.Common.DbDataReader rdr) 
            {
                Bill bill = [];

                DBPersist.autoAssign(rdr, bill);

                bills.Add(bill);
            };

            DBPersist.select(billCallback, "select * from app.bill");

            return bills;
        }

        
        public static Bill get(long id)
        {
            Console.WriteLine("Processing BillLogic get ID=" + id.ToString());

            Bill bill = [];
            bill.id = id;

            DBPersist.get(bill);

            return bill;
        }

        
        public static void insert( Bill bill)
        {
            Console.WriteLine("Processing BillLogic insert: " + bill.ToString()  );

            bill.is_active = "Y";

            DBPersist.insert(bill);
        }

       
        public static void update(long id,  Bill bill)
        {
            Console.WriteLine("Processing BillLogic update: ID = " + id.ToString() + "\n" + bill.ToString()  );

            bill.id = id;
            DBPersist.update(bill);
        }

        
        public static void delete(long id)
        {
            Bill bill = get(id);
            bill.is_active = "N";
             DBPersist.update(bill);
        }
    }
}
