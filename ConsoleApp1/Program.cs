using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WpfApp-s00254071;


namespace DataManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create DataBase 
            ClubData db = new ClubData();

            using (db) {

                Console.WriteLine("Adding to Database");
                // Members
                Member member1 = new Member
                {
                    FirstName = "Niamh",
                    Surname = "Kelly",
                    DateOfBirth = new DateTime(1998, 3, 14),
                    ContactNumber = "087 333 4455",
                    MembershipType = "Senior"
                };

                Member member2 = new Member
                {
                    FirstName = "Ciarán",
                    Surname = "Murphy",
                    DateOfBirth = new DateTime(2005, 7, 22),
                    ContactNumber = "083 444 5566",
                    MembershipType = "Junior"
                };

                Member member3 = new Member
                {
                    FirstName = "Fiona",
                    Surname = "Walsh",
                    DateOfBirth = new DateTime(1975, 11, 5),
                    ContactNumber = "089 555 6677",
                    MembershipType = "Veteran"
                };
                //Traning sessionsd 
                TrainingSession session1 = new TrainingSession
                {
                    SessionDate = new DateTime(2026, 3, 24, 18, 30, 0),
                    SessionType = "Strength",
                    DurationMinutes = 60,
                    CoachNotes = "Good session – strong progress on squat depth. Monitor left knee.",
                    MemberId = member1.MemberId
                };

                TrainingSession session2 = new TrainingSession
                {
                    SessionDate = new DateTime(2026, 3, 26, 7, 0, 0),
                    SessionType = "Cardio",
                    DurationMinutes = 45,
                    CoachNotes = "5km time trial followed by interval work. Best 5km time to date.",
                    MemberId = member1.MemberId
                };


                // Sessions for Ciarán Murphy
                TrainingSession session3 = new TrainingSession
                {
                    SessionDate = new DateTime(2026, 3, 25, 17, 0, 0),
                    SessionType = "Skills",
                    DurationMinutes = 75,
                    CoachNotes = "First session back after injury. Took it easy – good attitude.",
                    MemberId = member2.MemberId
                };

                TrainingSession session4 = new TrainingSession
                {
                    SessionDate = new DateTime(2026, 3, 27, 17, 0, 0),
                    SessionType = "Strength",
                    DurationMinutes = 45,
                    CoachNotes = "Light weights, focus on form. Progress from last session.",
                    MemberId = member2.MemberId
                };

                // Sessions for Fiona Walsh
                TrainingSession session5 = new TrainingSession
                {
                    SessionDate = new DateTime(2026, 3, 23, 9, 0, 0),
                    SessionType = "Recovery",
                    DurationMinutes = 30,
                    CoachNotes = "Stretching and mobility work. Essential after Sunday's match.",
                    MemberId = member3.MemberId
                };

                TrainingSession session6 = new TrainingSession
                {
                    SessionDate = new DateTime(2026, 3, 29, 10, 0, 0),
                    SessionType = "Match",
                    DurationMinutes = 90,
                    CoachNotes = "Strong performance throughout. Led by example in the second half.",
                    MemberId = member3.MemberId
                };

                 db.Members.Add(m1);
                 db.Members.Add(m2);
                 db.TrainingSessions.Add(s1);
                 db.TrainingSessions.Add(s2);
                 db.TrainingSessions.Add(s3);

                 db.SaveChanges();

                Console.WriteLine("DataBase saved");
            }
        }
    }
}
//Couldnt add Refrence becaues 
// keep getting this problem Project '..\WpfApp-s00254071\WpfApp-s00254071.csproj'
// targets 'net8.0-windows'. It cannot be referenced by a project that targets
// '.NETFramework,Version=v4.8'.