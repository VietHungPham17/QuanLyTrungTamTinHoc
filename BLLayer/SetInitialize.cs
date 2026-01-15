using DALayer;
using DTLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer
{
    public class SetInitialize
    {
        public SetInitialize()
        {

        }

        public void Init(bool value)
        {
            using (var db = new DBContext())
            {
                db.Database.Initialize(value);

                //db.Database.CreateIfNotExists();
                if (value == true)
                {
                    try
                    {
                        Employee employee = new Employee();

                        Major majorAdmin = new Major();
                        Major majorTeach = new Major();

                        Account account = new Account();
                        Center center = new Center();

                        majorAdmin.MajorID = "MJO00000";
                        majorAdmin.MajorName = "Quản Trị";

                        majorTeach.MajorID = "MJO00001";
                        majorTeach.MajorName = "Giáo viên";

                        employee.EmployeeID = "Admin";
                        employee.EmployeeName = "Administrator";
                        employee.MajorID = "MJO00000";
                        employee.BirthDay = DateTime.Now;

                        account.Username = "Admin";
                        account.Password = "Admin";
                        account.Status = false;

                        center.CenterID = "CTR00001";
                        center.CenterName = "HC Software Corporation";

                        db.Entry(majorAdmin).State = System.Data.Entity.EntityState.Added;
                        db.Entry(majorTeach).State = System.Data.Entity.EntityState.Added;
                        db.Entry(employee).State = System.Data.Entity.EntityState.Added;
                        db.Entry(account).State = System.Data.Entity.EntityState.Added;
                        db.Entry(center).State = System.Data.Entity.EntityState.Added;
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}
