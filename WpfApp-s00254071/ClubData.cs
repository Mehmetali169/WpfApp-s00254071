using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfApp_s00254071
{
    public class ClubData : DbContext
    {
     public ClubData() : base("OOPExam_MehemtAliBuk")
        { }

     public DbSet<Member> Members { get; set; }
     public DbSet<TrainingSession> TrainingSessions { get; set; }
    }
}
