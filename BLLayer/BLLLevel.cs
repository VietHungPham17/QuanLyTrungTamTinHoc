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
    public class BLLLevel
    {
        public List<Level> GetAll()
        {
            List<Level> lstLevel = new List<Level>();
            using (var db = new DBContext())
            {
                lstLevel = db.Levels.ToList<Level>();
            }
            return lstLevel;
            //return (new DataTableConverter()).ConvertToDataTable<Level>(lstLevel);
        }

        public Level Get(string LevelID)
        {
            Level level = new Level();

            using (var db = new DBContext())
            {
                level = db.Levels
                    .Where(l => l.LevelID == LevelID)
                    .Select(l => l).FirstOrDefault<Level>();
            }
            return level;
        }
        public void Insert(Level level)
        {
            using (var db = new DBContext())
            {
                db.Levels.Add(level);
                db.SaveChanges();
            }
        }

        public void Update(Level Level)
        {
            using (var db = new DBContext())
            {
                db.Entry(Level).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(string LevelID)
        {
            using (var db = new DBContext())
            {
                Level level = db.Levels.Find(LevelID);
                if (level == null) return;
                db.Entry(level).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public string NextID()
        {
            string nxtid = string.Empty;

            using (var db = new DBContext())
            {
                nxtid = db.Levels.Max(p => p.LevelID);
            }

            if (nxtid == null) nxtid = "LVL00000";
            string tmp = nxtid.Replace("LVL", "");

            nxtid = "LVL" + (double.Parse(tmp) + 1).ToString("00000");

            return nxtid;
        }

    }
}
