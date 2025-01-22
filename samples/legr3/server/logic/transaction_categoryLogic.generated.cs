
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class TransactionCategoryLogic : ITransactionCategoryLogic
    {


        public static ITransactionCategoryLogic Create()
        {
            var transactioncategory = new TransactionCategoryLogic();

            var proxy = DispatchProxy.Create<ITransactionCategoryLogic, Proxy<ITransactionCategoryLogic>>();
            ((Proxy<ITransactionCategoryLogic>)proxy).Initialize();
            ((Proxy<ITransactionCategoryLogic>)proxy).Target = transactioncategory;
            ((Proxy<ITransactionCategoryLogic>)proxy).DomainObj = "TransactionCategory";

            return proxy;
        }



        public  List<TransactionCategory> select()
        {
            Console.WriteLine("Processing TransactionCategoryLogic select List");

            List<TransactionCategory> transactioncategorys = new List<TransactionCategory>();

            void transactioncategoryCallback(System.Data.Common.DbDataReader rdr)
            {
                TransactionCategory transactioncategory = new TransactionCategory();

                DBPersist.autoAssign(rdr, transactioncategory);

                transactioncategorys.Add(transactioncategory);
            };

            DBPersist.select(transactioncategoryCallback, $"select * from app.transaction_category");

            return transactioncategorys;
        }

        public  TransactionCategory get(long id)
        {
            Console.WriteLine($"Processing TransactionCategoryLogic get ID={id}");

            TransactionCategory transactioncategory = new TransactionCategory();
            transactioncategory.id = id;

            DBPersist.get(transactioncategory);

            return transactioncategory;
        }

        public  void insert(TransactionCategory transactioncategory)
        {
            Console.WriteLine($"Processing TransactionCategoryLogic insert: {transactioncategory}");

            transactioncategory.is_active = 1;

            DBPersist.insert(transactioncategory);
        }

        public  void update(long id, TransactionCategory transactioncategory)
        {
            Console.WriteLine($"Processing TransactionCategoryLogic update: ID = {id}\n{transactioncategory}");

            transactioncategory.id = id;
            DBPersist.update(transactioncategory);
        }

        public  void delete(long id)
        {
            TransactionCategory transactioncategory = get(id);
            transactioncategory.is_active = 0;
            DBPersist.update(transactioncategory);
        }
    }
}
