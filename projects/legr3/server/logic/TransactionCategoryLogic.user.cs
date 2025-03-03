
using System;


namespace legr3
{
    public interface ITransactionCategoryLogic
    {  
        // Generated methods
        List<TransactionCategory> select();
        TransactionCategory get(long id);
        void insert(TransactionCategory transactioncategory);
        void update(long id, TransactionCategory transactioncategory);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class TransactionCategoryLogic
    {
        public TransactionCategoryLogic()
        {
           
        }
        
    }
}

