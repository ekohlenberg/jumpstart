using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class TransactionLogic : Logic
    {
    
        public static List<Transaction> select()
        {
            Console.WriteLine("Processing TransactionLogic select List" );

            List<Transaction> transactions = [];

            void transactionCallback(System.Data.Common.DbDataReader rdr) 
            {
                Transaction transaction = [];

                DBPersist.autoAssign(rdr, transaction);

                transactions.Add(transaction);
            };

            DBPersist.select(transactionCallback, "select * from app.transaction");

            return transactions;
        }

        
        public static Transaction get(long id)
        {
            Console.WriteLine("Processing TransactionLogic get ID=" + id.ToString());

            Transaction transaction = [];
            transaction.id = id;

            DBPersist.get(transaction);

            return transaction;
        }

        
        public static void insert( Transaction transaction)
        {
            Console.WriteLine("Processing TransactionLogic insert: " + transaction.ToString()  );

            transaction.is_active = "Y";

            DBPersist.insert(transaction);
        }

       
        public static void update(long id,  Transaction transaction)
        {
            Console.WriteLine("Processing TransactionLogic update: ID = " + id.ToString() + "\n" + transaction.ToString()  );

            transaction.id = id;
            DBPersist.update(transaction);
        }

        
        public static void delete(long id)
        {
            Transaction transaction = get(id);
            transaction.is_active = "N";
             DBPersist.update(transaction);
        }
    }
}
