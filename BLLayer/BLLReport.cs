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
    public class BLLReport
    {
        public List<TuitionDebt> TuitionDebt(string CourseID)
        {
            List<TuitionDebt> lstTuitionDebt = new List<DTLayer.TuitionDebt>();

            using (var db = new DBContext())
            {
                var tuitionDebts = from c in db.Courses
                                   where c.CourseID == CourseID
                                   from r in c.Registers
                                   from ct in db.Centers
                                   where r.Debt > 0
                                   select new
                                   {
                                       StudentID = r.Student.StudentID,
                                       StudentName = r.Student.StudentName,
                                       Gender = r.Student.Gender,
                                       BirthDay = r.Student.BirthDay,
                                       PhoneNumber = r.Student.PhoneNumber,
                                       CourseID = c.CourseID,
                                       CourseName = c.CourseName,
                                       Debt = r.Debt,
                                       //
                                       //CenterID = ct.CenterID,
                                       //CenterName = ct.CenterName,
                                       //Address = ct.Address,
                                       //CenterPhone = ct.PhoneNumber,
                                       //Fax = ct.Fax,
                                       //Email = ct.Email,
                                       //Website = ct.Website
                                   };

                foreach (var item in tuitionDebts)
                {
                    lstTuitionDebt.Add(
                        new DTLayer.TuitionDebt
                        {
                            StudentID = item.StudentID,
                            StudentName = item.StudentName,
                            Gender = item.Gender,
                            BirthDay = item.BirthDay,
                            PhoneNumber = item.PhoneNumber,
                            CourseID = item.CourseID,
                            CourseName = item.CourseName,
                            Debt = item.Debt,
                            //
                            //CenterID=item.CenterID,
                            //CenterName=item.CenterName,
                            //Address=item.Address,
                            //CenterPhone=item.CenterPhone,
                            //Fax=item.Fax,
                            //Email=item.Email,
                            //Website=item.Website
                        });
                }

            }
            return lstTuitionDebt;
        }

        public List<TranscriptSummary> Transcript(string CourseID)
        {
            DataTable dtTranscript = new DataTable();
            List<TranscriptSummary> lstTranscriptSummary =
                new List<TranscriptSummary>();
            using (var db = new DBContext())
            {
                var Transcripts = from c in db.Courses
                                  where c.CourseID == CourseID
                                  from r in c.Transcripts
                                  where r.Status == true
                                  group r by r.StudentID into g
                                  select new
                                  {
                                      StudentID = g.FirstOrDefault().Student.StudentID,
                                      StudentName = g.FirstOrDefault().Student.StudentName,
                                      Gender = g.FirstOrDefault().Student.Gender,
                                      BirthDay = g.FirstOrDefault().Student.BirthDay,
                                      PhoneNumber = g.FirstOrDefault().Student.PhoneNumber,
                                      Score = g.Average(c => c.Score),
                                      CourseName = g.FirstOrDefault().Course.CourseName
                                  };

                foreach (var item in Transcripts)
                {
                    string result = "Giỏi";
                    if (item.Score >= 6.5 && item.Score < 8) result = "Khá";
                    else
                    if (item.Score >= 5 && item.Score < 6.5) result = "Trung bình";
                    else
                    if (item.Score >= 3.5 && item.Score < 5) result = "Yếu";
                    else
                    if (item.Score >= 0 && item.Score < 3.5) result = "Kém";

                    lstTranscriptSummary.Add(
                        new TranscriptSummary
                        {
                            StudentID = item.StudentID,
                            StudentName = item.StudentName,
                            BirthDay = item.BirthDay,
                            Gender = item.Gender,
                            PhoneNumber = item.PhoneNumber,
                            Score = item.Score,
                            Result = result,
                            CourseName = item.CourseName
                        });
                }

                return lstTranscriptSummary;
            }
        }

        public List<TuitionSummary> TuitionSummary(string LevelID)
        {
            List<TuitionSummary> lstTuitionSummary =
                new List<TuitionSummary>();
            using (var db = new DBContext())
            {
                var TuitionSummaries = from c in db.Courses
                                       where c.LevelID == LevelID
                                       from r in c.Registers
                                       group r by r.CourseID into g
                                       select new
                                       {
                                           CourseID = g.FirstOrDefault().Course.CourseID,
                                           CourseName = g.FirstOrDefault().Course.CourseName,
                                           Number = g.FirstOrDefault().Course.Number,
                                           Tuition = g.Sum(c => c.Total)
                                       };

                foreach (var item in TuitionSummaries)
                {
                    lstTuitionSummary.Add(
                        new TuitionSummary
                        {
                            CourseID = item.CourseID,
                            CourseName = item.CourseName,
                            Number = item.Number,
                            Tuition = item.Tuition
                        });
                }

                return lstTuitionSummary;
            }
        }
    }
}
