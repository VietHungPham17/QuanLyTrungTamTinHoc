using DALayer;
using DTLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer
{
    public class BLLCenter
    {
        public void Insert(Center center)
        {
            using (var db = new DBContext())
            {
                db.Entry(center).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Update(Center center)
        {
            using (var db = new DBContext())
            {
                db.Entry(center).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Center Get()
        {
            Center center = new Center();
            using (var db = new DBContext())
            {
                center = db.Centers
                    .FirstOrDefault<Center>();
            }
            return center;
        }

        public string NextID()
        {
            string nxtid = string.Empty;

            using (var db = new DBContext())
            {
                nxtid = db.Centers.Max(p => p.CenterID);
            }

            if (nxtid == null) nxtid = "CTR00000";
            string tmp = nxtid.Replace("CTR", "");

            nxtid = "CTR" + (double.Parse(tmp) + 1).ToString("00000");

            return nxtid;
        }
    }
}
