using DALayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer
{
    public class BLLStatistics
    {
        public DataTable Revenue(DateTime FromDate, DateTime ToDate)
        {
            DataTable dtRevenue = new DataTable();
            using (var db = new DBContext())
            {
                var Revenues = (from c in db.Courses
                                where c.Opening >= FromDate && c.Opening <= ToDate
                                from r in c.Registers
                                group r by c.CourseID into g
                                select new
                                {
                                    CourseID = g.FirstOrDefault().CourseID,
                                    CourseName = g.FirstOrDefault().Course.CourseName,
                                    Number = g.Count(),
                                    Tuition = g.Sum(t => t.Course.Tuition),
                                    Exemption = g.Average(t => t.Exemption),
                                    Total = g.Sum(t => t.Total)
                                });

                dtRevenue.Columns.Add("CourseID", typeof(string));
                dtRevenue.Columns.Add("CourseName", typeof(string));
                dtRevenue.Columns.Add("Number", typeof(int));
                dtRevenue.Columns.Add("Tuition", typeof(decimal));
                dtRevenue.Columns.Add("Exemption", typeof(float));
                dtRevenue.Columns.Add("Total", typeof(decimal));

                try
                {
                    foreach (var it in Revenues)
                    {
                        dtRevenue.Rows.Add(it.CourseID, it.CourseName, it.Number, it.Tuition, it.Exemption, it.Total);
                    }
                }
                catch (Exception)
                {
                }
            }

            return dtRevenue;
        }

        public DataTable EducationQuality(DateTime FromDate, DateTime ToDate)
        {
            DataTable dtRevenue = new DataTable();
            using (var db = new DBContext())
            {

                var EducationQuality = (from c in db.Courses
                                        where c.Opening >= FromDate && c.Opening <= ToDate
                                        group c by c.CourseID into g
                                        select new
                                        {
                                            CourseID = g.FirstOrDefault().CourseID,
                                            CourseName = g.FirstOrDefault().CourseName,

                                            Number = g.FirstOrDefault().Number,
                                            ScoreAVG = (float)g.FirstOrDefault().Transcripts.
                                                        Where(t=>t.Status==true)
                                                        .Average(t => t.Score),

                                            Fail = (from t in (from f in db.Courses
                                                               where f.CourseID == g.FirstOrDefault().CourseID
                                                               from r in f.Transcripts
                                                               group r by r.StudentID into fg
                                                               select new
                                                               {
                                                                   StudentID = fg.FirstOrDefault().Student.StudentID,
                                                                   Score = fg.Average(c => c.Score)
                                                               }
                                                    )
                                                    where t.Score < 5
                                                    select t).Count(),

                                            Done = (from t in (from f in db.Courses
                                                               where f.CourseID == g.FirstOrDefault().CourseID
                                                               from r in f.Transcripts
                                                               group r by r.StudentID into fg
                                                               select new
                                                               {
                                                                   StudentID = fg.FirstOrDefault().Student.StudentID,
                                                                   Score = fg.Average(c => c.Score)
                                                               }
                                                   )
                                                    where t.Score >= 5
                                                    select t).Count()//g.Where(t => t.Score >= 5).Count()
                                        });

                dtRevenue.Columns.Add("CourseID", typeof(string));
                dtRevenue.Columns.Add("CourseName", typeof(string));
                dtRevenue.Columns.Add("Number", typeof(int));
                dtRevenue.Columns.Add("Fail", typeof(int));
                dtRevenue.Columns.Add("Done", typeof(int));
                dtRevenue.Columns.Add("ScoreAVG", typeof(float));

                try
                {
                    foreach (var it in EducationQuality)
                    {
                        dtRevenue.Rows.Add(it.CourseID, it.CourseName, it.Fail + it.Done, it.Fail, it.Done, it.ScoreAVG);
                    }
                }
                catch (Exception)
                {
                }
            }

            return dtRevenue;
        }
    }
}
