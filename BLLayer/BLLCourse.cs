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
    public class BLLCourse
    {
        public List<Course> GetAll()
        {
            List<Course> lstCourse = new List<Course>();
            using (var db = new DBContext())
            {
                lstCourse = db.Courses
                    .ToList<Course>();
            }
            return lstCourse;
        }

        public Course Get(string CourseID)
        {
            Course course = new Course();
            using (var db = new DBContext())
            {
                course = db.Courses
                    .Where(p => p.CourseID == CourseID)
                    .Select(p => p)
                    .FirstOrDefault<Course>();
            }
            return course;
        }

        public List<Course> GetByLevel(string LevelID)
        {
            List<Course> lstCourse = new List<Course>();
            using (var db = new DBContext())
            {
                lstCourse = db.Courses
                    .Where(p => p.LevelID == LevelID)
                    .Select(p => p).ToList<Course>();
            }
            return lstCourse;
        }

        public List<Course> GetByLevel(string LevelID,bool Status)
        {
            List<Course> lstCourse = new List<Course>();
            using (var db = new DBContext())
            {
                lstCourse = db.Courses
                    .Where(p => p.LevelID == LevelID)
                    .Where(p=>p.Status==Status)
                    .Select(p => p).ToList<Course>();
            }
            return lstCourse;
        }

        public void Insert(Course course)
        {
            using (var db = new DBContext())
            {
                db.Courses.Add(course);
                db.SaveChanges();
            }
        }

        public void Update(Course course)
        {
            using (var db = new DBContext())
            {
                db.Entry(course).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(string CourseID)
        {
            using (var db = new DBContext())
            {
                Course course = new Course();
                course = db.Courses.Find(CourseID);
                if (course == null) return;

                db.Entry(course).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public string NextID()
        {
            string nxtid = string.Empty;

            using (var db = new DBContext())
            {
                nxtid = db.Courses.Max(p => p.CourseID);
            }

            if (nxtid == null) nxtid = "CSE00000";
            string tmp = nxtid.Replace("CSE", "");

            nxtid = "CSE" + (double.Parse(tmp) + 1).ToString("00000");

            return nxtid;
        }
    }
}
