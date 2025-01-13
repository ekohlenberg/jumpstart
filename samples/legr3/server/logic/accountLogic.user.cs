
using System;


namespace legr3
{
    public interface IAccountLogic
    {
        List<Account> select();
        Account get(long id);
        void insert(Account account);
        void update(long id, Account account);
        void delete( long id );
    }


    public partial class AccountLogic
    {
        public AccountLogic()
        {
           
        }
        
    }
}

