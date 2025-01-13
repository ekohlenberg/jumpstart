
using System;


namespace legr3
{
    public interface ITransactionCategoryLogic
    {
        List<TransactionCategory> select();
        TransactionCategory get(long id);
        void insert(TransactionCategory transactioncategory);
        void update(long id, TransactionCategory transactioncategory);
        void delete( long id );
    }


    public partial class TransactionCategoryLogic
    {
        public TransactionCategoryLogic()
        {
           
        }
        
    }
}

