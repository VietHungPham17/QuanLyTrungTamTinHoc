using DALayer;
using DTLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer
{
    public class BLLMajor
    {
        public void Insert(Major major)
        {
            using (var db = new DBContext())
            {
                db.Entry(major).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Update(Major major)
        {
            using (var db = new DBContext())
            {
                db.Entry(major).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Major Get(string MajorID)
        {
            Major major = new Major();

            using (var db = new DBContext())
            {
                major = db.Majors.Find(MajorID);
                db.SaveChanges();
            }
            return major;
        }

        public void Delete(string MajorID)
        {
            using (var db = new DBContext())
            {
                Major major = db.Majors.Find(MajorID);
                if (major == null) return;

                db.Entry(major).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<Major> GetAll()
        {
            List<Major> lstMajor = new List<Major>();

            using (var db = new DBContext())
            {
                lstMajor = db.Majors
                    .Select(m => m)
                    .ToList<Major>();
            }
            return lstMajor;
        }

        public string NextID()
        {
            string nxtid = string.Empty;

            using (var db = new DBContext())
            {
                nxtid = db.Majors.Max(p => p.MajorID);
            }

            if (nxtid == null) nxtid = "MJO00000";
            string tmp = nxtid.Replace("MJO", "");

            nxtid = "MJO" + (double.Parse(tmp) + 1).ToString("00000");

            return nxtid;
        }

        private DataTable GetTable(List<Major> lstMajor)
        {
            DataTable dtMajor = new DataTable();

            dtMajor.Columns.Add("MajorID", typeof(string));
            dtMajor.Columns.Add("MajorName", typeof(string));
            dtMajor.Columns.Add("JobFunction", typeof(string));

            foreach (Major major in lstMajor)
            {
                dtMajor.Rows.Add(major.MajorID, major.MajorName, major.JobFunction);
            }
            return dtMajor;
        }
    }
}
