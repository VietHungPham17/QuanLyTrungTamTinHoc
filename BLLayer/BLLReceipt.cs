using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTLayer;
using DALayer;

namespace BLLayer
{
    public class BLLReceipt
    {
        public List<Receipt> Get(string StudentID, string CourseID)
        {
            List<Receipt> lstReceipt = new List<Receipt>();

            using (var db = new DBContext())
            {
                lstReceipt = db.Receipts
                    .Where(r => r.StudentID == StudentID)
                    .Where(r => r.CourseID == CourseID)
                    .Select(r => r)
                    .ToList<Receipt>();
            }
            return lstReceipt;
        }

        public Receipt Get(string ReceiptID)
        {
            Receipt receipt = new Receipt();
            using (var db = new DBContext())
            {
                receipt = db.Receipts
                    .Where(r => r.ReceiptID == ReceiptID)
                    .Select(r => r)
                    .FirstOrDefault<Receipt>();
            }
            return receipt;
        }
        public string NextID()
        {
            string nxtid = string.Empty;
            using (var db = new DBContext())
            {
                nxtid = db.Receipts.Max(p => p.ReceiptID);
            }

            if (nxtid == null) nxtid = "RCP00000";
            string tmp = nxtid.Replace("RCP", "");

            nxtid = "RCP" + (double.Parse(tmp) + 1).ToString("00000");

            return nxtid;
        }

        public void Insert(Receipt receipt)
        {
            using (var db = new DBContext())
            {
                db.Receipts.Add(receipt);
                db.SaveChanges();
            }
        }

        public void Update(Receipt receipt)
        {
            using (var db = new DBContext())
            {
                db.Entry(receipt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(string ReceiptID)
        {
            using (var db = new DBContext())
            {
                Receipt receipt = new Receipt();

                receipt = db.Receipts.Find(ReceiptID);

                if (receipt == null) return;

                db.Entry(receipt).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
