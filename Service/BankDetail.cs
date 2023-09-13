using EvaluationTest.Models;

namespace EvaluationTest.Service
{
    public class BankDetail
    {
        private readonly BankDetailsContext _context = new BankDetailsContext();

        public List<BankAccount> GetActiveAccounts(string UserId)
        {
            var res = (from a in _context.BankAccounts.Where(x => x.UserId == UserId)
                       select new BankAccount
                       {

                           Id = a.Id,
                           UserId = a.UserId,
                       }).ToList();

            return res;
            //  return _context.Advertisements.Where(x => x.Active == true).ToList();
        }

        public int CreateAccount(BankAccount activity)
        {
            _context.Add(activity);
            return _context.SaveChanges();
        }

        public bool CheckExistsActivity(string AccId)
        {
            return _context.BankAccounts.Any(e => e.AccId == AccId);
        }
        public bool CheckExistsUpdateActivity(string AccId, int id)
        {
            return _context.BankAccounts.Any(e => e.AccId == AccId && e.Id != id);
        }

        public bool CheckAmount(string AccId, decimal Amount)
        {
            return _context.BankAccounts.Any(e => e.AccId == AccId && (e.BankAmount- Amount) <=0);
        }


        public BankAccount GetActivity(int id)
        {
            return _context.BankAccount.Find(id);
        }


    

        public void UpdateActivity(BankAccount activity)
        {
            _context.SaveChanges();
        }
    }
}
