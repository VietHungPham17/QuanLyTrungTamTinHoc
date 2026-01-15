using DALayer;
using DTLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer
{
    public class BLLAccount
    {
        public void Insert(Account account)
        {
            using (var db = new DBContext())
            {
                db.Entry(account).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Update(Account account)
        {
            using (var db = new DBContext())
            {
                db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(string Username)
        {
            using (var db = new DBContext())
            {
                Account account = db.Accounts.Find(Username);

                if (account == null) return;

                db.Entry(account).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Account Get(string Username)
        {
            Account account = new Account();
            using (var db = new DBContext())
            {
                account = db.Accounts.Find(Username);
            }
            return account;
        }

        public List<Account> GetAll()
        {
            List<Account> lstAccount = new List<Account>();
            using (var db = new DBContext())
            {
                lstAccount = db.Accounts.Select(a=>a).ToList<Account>();
            }
            return lstAccount;
        }
    }
}
