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
    public class BLLDiary
    {
        public DataTable GetAll()
        {
            List<Diary> lstDiary = new List<Diary>();
            using (var db = new DBContext())
            {
                lstDiary = db.Diaries
                    .Select(d => d)
                    .OrderByDescending(d=>d.Date)
                    .ToList<Diary>();
            }
            return ToDataTable(lstDiary);
        }

        public void Insert(Diary diary)
        {
            using (var db = new DBContext())
            {
                db.Entry(diary).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Insert(string EmployeeID, string Action, string Status,bool Auto)
        {
            using (var db = new DBContext())
            {
                Diary diary = new Diary();
                diary.EmployeeID = EmployeeID;
                diary.Action = Action;
                diary.Date = DateTime.Now;
                diary.Status = Status;
                diary.Auto = Auto;

                db.Entry(diary).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Update(Diary diary)
        {
            using (var db = new DBContext())
            {
                db.Entry(diary).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int DiaryID)
        {
            using (var db = new DBContext())
            {
                Diary diary = new Diary();
                diary = db.Diaries.Find(DiaryID);
                if (diary == null) return;

                db.Entry(diary).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        private DataTable ToDataTable(List<Diary> lstDiary)
        {
            DataTable dtDiary = new DataTable();

            dtDiary.Columns.Add("DiaryID", typeof(int));
            dtDiary.Columns.Add("EmployeeID", typeof(string));
            dtDiary.Columns.Add("Action", typeof(string));
            dtDiary.Columns.Add("Date", typeof(DateTime));
            dtDiary.Columns.Add("Status", typeof(string));
            dtDiary.Columns.Add("Auto", typeof(bool));

            foreach (Diary diary in lstDiary)
            {
                dtDiary.Rows.Add(diary.DiaryID, diary.EmployeeID, diary.Action, diary.Date, diary.Status,diary.Auto);
            }
            return dtDiary;
        }
    }
}
