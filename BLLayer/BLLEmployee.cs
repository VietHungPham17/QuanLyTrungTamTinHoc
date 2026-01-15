using DALayer;
using DTLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer
{
    public class BLLEmployee
    {
        public List<Employee> GetAll()
        {
            List<Employee> lstEmployee = new List<Employee>();
            using (var db = new DBContext())
            {
                lstEmployee = db.Employees
                    .ToList<Employee>();
            }
            return lstEmployee;
        }

        public List<Employee> GetTeach()
        {
            List<Employee> lstEmployee = new List<Employee>();
            using (var db = new DBContext())
            {
                lstEmployee = db.Employees
                    .Where(t=>t.MajorID== "MJO00001")
                    .ToList<Employee>();
            }
            return lstEmployee;
        }

        public List<Employee> GetByMajor(string MajorID)
        {
            List<Employee> lstEmployee = new List<Employee>();
            using (var db = new DBContext())
            {
                lstEmployee = db.Employees
                    .Where(e => e.MajorID == MajorID)
                    .Select(e => e)
                    .ToList<Employee>();
            }
            return lstEmployee;
        }

        public Employee Get(string EmployeeID)
        {
            Employee employee = new Employee();
            using (var db = new DBContext())
            {
                employee = db.Employees.Where(p => p.EmployeeID == EmployeeID).FirstOrDefault<Employee>();
            }
            return employee;
        }

        public void Insert(Employee employee)
        {
            using (var db = new DBContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public void Update(Employee employee)
        {
            using (var db = new DBContext())
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(string EmployeeID)
        {
            using (var db = new DBContext())
            {
                Employee trainer = db.Employees.Find(EmployeeID);
                if (trainer == null) return;

                db.Entry(trainer).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public string NextID()
        {
            string nxtid = string.Empty;

            using (var db = new DBContext())
            {
                nxtid = db.Employees.Max(p => p.EmployeeID);
            }

            if (nxtid == null) nxtid = "EPL00000";
            string tmp = nxtid.Replace("EPL", "");

            if (tmp == "Admin") tmp = "00000";
            nxtid = "EPL" + (double.Parse(tmp) + 1).ToString("00000");

            return nxtid;
        }
    }
}
