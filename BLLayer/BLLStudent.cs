using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using DTLayer;
using DALayer;

namespace BLLayer
{
    public class BLLStudent
    {
        public List<Student> GetAll()
        {
            List<Student> lstStudent = new List<Student>();
            using (var db = new DBContext())
            {
                lstStudent = db.Students
                    .ToList<Student>();
            }
            return lstStudent;
        }

        public Student Get(string StudentID)
        {
            Student student = new Student();
            using (var db = new DBContext())
            {
                student = db.Students.Where(p => p.StudentID == StudentID).FirstOrDefault<Student>();
            }
            return student;
        }

        public void Insert(Student student)
        {
            using (var db = new DBContext())
            {
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

        public void Update(Student student)
        {
            using (var db = new DBContext())
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(string StudentID)
        {
            using (var db = new DBContext())
            {
                Student student = db.Students.Find(StudentID);
                if (student == null) return;

                db.Entry(student).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public string NextID()
        {
            string nxtid = string.Empty;

            using (var db = new DBContext())
            {
                nxtid = db.Students.Max(p => p.StudentID);
            }

            if (nxtid == null) nxtid = "STD00000";
            string tmp = nxtid.Replace("STD", "");

            nxtid = "STD" + (double.Parse(tmp) + 1).ToString("00000");

            return nxtid;
        }

        // Get by course
        public List<Student> GetByCourse(string CourseID)
        {
            List<Student> lstStudent = new List<Student>();
            using (var db = new DBContext())
            {
                lstStudent = (from stu in db.Students
                              from reg in stu.Registers
                              where reg.CourseID == CourseID
                              select stu)
                              .ToList<Student>();
            }
            return lstStudent;
        }

        // get by not reg 
        public List<Student> GetNotRegister()
        {
            List<Student> lstStudent = new List<Student>();
            using (var db = new DBContext())
            {
                lstStudent = (from stu in db.Students
                              where stu.Status == false
                              orderby stu.StudentID descending
                              select stu).ToList<Student>();
            }
            return lstStudent;
        }

        public void SetNotActive(string studentID)
        {
            using (var db = new DBContext())
            {
               
                var register = (from r in db.Registers
                                where r.StudentID == studentID
                                select r)
                                .FirstOrDefault<Register>();

                if (register != null) return;


                Student student = new Student();
                student = db.Students.Find(studentID);
                if (student == null) return;

                student.Status = false;
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
