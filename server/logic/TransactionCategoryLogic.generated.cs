using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class TransactionCategoryLogic : Logic
    {
    
        public static List<TransactionCategory> select()
        {
            Console.WriteLine("Processing TransactionCategoryLogic select List" );

            List<TransactionCategory> transactioncategorys = [];

            void transactioncategoryCallback(System.Data.Common.DbDataReader rdr) 
            {
                TransactionCategory transactioncategory = [];

                DBPersist.autoAssign(rdr, transactioncategory);

                transactioncategorys.Add(transactioncategory);
            };

            DBPersist.select(transactioncategoryCallback, "select * from app.transaction_category");

            return transactioncategorys;
        }

        
        public static TransactionCategory get(long id)
        {
            Console.WriteLine("Processing TransactionCategoryLogic get ID=" + id.ToString());

            TransactionCategory transactioncategory = [];
            transactioncategory.id = id;

            DBPersist.get(transactioncategory);

            return transactioncategory;
        }

        
        public static void insert( TransactionCategory transactioncategory)
        {
            Console.WriteLine("Processing TransactionCategoryLogic insert: " + transactioncategory.ToString()  );

            transactioncategory.is_active = "Y";

            DBPersist.insert(transactioncategory);
        }

       
        public static void update(long id,  TransactionCategory transactioncategory)
        {
            Console.WriteLine("Processing TransactionCategoryLogic update: ID = " + id.ToString() + "\n" + transactioncategory.ToString()  );

            transactioncategory.id = id;
            DBPersist.update(transactioncategory);
        }

        
        public static void delete(long id)
        {
            TransactionCategory transactioncategory = get(id);
            transactioncategory.is_active = "N";
             DBPersist.update(transactioncategory);
        }
    }
}
