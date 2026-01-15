using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTLayer;
using DALayer;
using System.Data.Entity;

namespace BLLayer
{
    public class BLLRegister
    {
        public List<Register> Get(string StudentID)
        {
            List<Register> lstRegister = new List<Register>();

            using (var db = new DBContext())
            {
                lstRegister = db.Registers
                    .Where(r => r.StudentID == StudentID)
                    .Select(r => r)
                    .ToList<Register>();
            }
            return lstRegister;
        }

        public List<Register> GetByCourse(string CourseID)
        {
            List<Register> lstRegister = new List<Register>();

            using (var db = new DBContext())
            {
                lstRegister = db.Registers
                    .Where(r => r.CourseID == CourseID)
                    .Select(r => r)
                    .ToList<Register>();
            }
            return lstRegister;
        }


        public Register Get(string StudentID, string CourseID)
        {
            Register register = new Register();

            using (var db = new DBContext())
            {
                register = db.Registers
                    .Where(r => r.StudentID == StudentID)
                    .Where(r => r.CourseID == CourseID)
                    .Select(r => r)
                    .FirstOrDefault<Register>();
            }
            return register;
        }

        public void Insert(Register register)
        {
            using (var db = new DBContext())
            {
                db.Registers.Add(register);
                db.SaveChanges();
            }
        }

        public void Update(Register register)
        {
            using (var db = new DBContext())
            {
                db.Entry(register).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(string StudentID, string CourseID)
        {
            using (var db = new DBContext())
            {
                Register register = db.Registers.Find(StudentID, CourseID);
                if (register == null) return;

                db.Entry(register).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

    }
}
