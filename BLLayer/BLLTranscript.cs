using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTLayer;
using DALayer;

namespace BLLayer
{
    public class BLLTranscript
    {
        public List<Transcript> Get(string CourseID)
        {
            List<Transcript> lstTranscript = new List<Transcript>();

            using (var db = new DBContext())
            {
                lstTranscript = db.Transcripts
                    .Where(t => t.CourseID == CourseID)
                    .Select(t => t)
                    .ToList<Transcript>();
            }
            return lstTranscript;
        }

        public List<Transcript> Get(DateTime TestDate, string CourseID)
        {
            List<Transcript> lstTranscript = new List<Transcript>();
            using (var db = new DBContext())
            {
                lstTranscript = db.Transcripts
                    .Where(a => a.TestDate == TestDate)
                    .Where(a => a.CourseID == CourseID)
                    .Select(a => a)
                    .ToList<Transcript>();
            }
            return lstTranscript;
        }

        public Transcript Get(DateTime TestDate, string CourseID, string StudentID)
        {
            Transcript transcript = new Transcript();
            using (var db = new DBContext())
            {
                transcript = db.Transcripts
                    .Where(a => a.TestDate == TestDate)
                    .Where(a => a.CourseID == CourseID)
                    .Where(a => a.StudentID == StudentID)
                    .Select(a => a)
                    .FirstOrDefault<Transcript>();
            }
            return transcript;
        }

        public void Insert(Transcript transcript)
        {
            using (var db = new DBContext())
            {
                db.Entry(transcript).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Update(Transcript transcript)
        {
            using (var db = new DBContext())
            {
                db.Entry(transcript).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(DateTime Date,string CourseID,string StudentID)
        {
            using (var db = new DBContext())
            {
                Transcript transcript = new Transcript();
                transcript = db.Transcripts
                    .Where(t => t.TestDate == Date)
                    .Where(t => t.StudentID == StudentID)
                    .Where(t => t.CourseID == CourseID)
                    .Select(t => t)
                    .FirstOrDefault<Transcript>();

                if (transcript == null) return;

                db.Entry(transcript).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
