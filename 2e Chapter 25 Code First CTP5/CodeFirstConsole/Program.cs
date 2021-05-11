using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CodeFirstClasses;
//using Microsoft.Data.Objects;
using CodeFirst.Persistence;
using System.Data.Entity.Database; //for database initializer

namespace CodeFirstConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            runCodeFirst();
        }

        private static void runCodeFirst()
        {
            DbDatabase.SetInitializer<ConferenceModel>(new DropCreateDatabaseAlways<ConferenceModel>());
            using (var context = new ConferenceModel())
            {

                var speaker = new Speaker { FirstName = "Julie", LastName = "Lerman" };
                var session = new Session
                                {
                                    Title = "Code First Design",
                                    ConferenceTrack =
                                      new ConferenceTrack { TrackName = "Data", TrackChair = "Damien Guard", MinSessions = 5 },
                                    Abstract = "tbd",
                                };
                var session2 = new Session
                                 {
                                     Title = "From Sap to Syrup",
                                     ConferenceTrack =
                                       new ConferenceTrack { TrackName = "Vermont", TrackChair = "Ethan Allen" },
                                     Abstract = "How maple syrup is made",
                                 };
                var speaker2 = new Speaker { FirstName = "Suzanne", LastName = "Shushereba" };
                context.Speakers.Add(speaker);
                context.Speakers.Add(speaker2);
                speaker.Sessions = new List<Session>();
                speaker.Sessions.Add(session);
                speaker.Sessions.Add(session2);
                speaker2.Sessions = new List<Session>();
                speaker2.Sessions.Add(session2);
                context.SaveChanges();
            }
            using (var context = new ConferenceModel())
            {
                foreach (var dbSession in context.Sessions.Include("Speakers"))
                {
                    Console.WriteLine();
                    Console.WriteLine(dbSession.Title);
                    Console.WriteLine("Speakers:");

                    foreach (var sessionSpeaker in dbSession.Speakers)
                    {
                        Console.WriteLine(".... {0}", sessionSpeaker.Name);
                    }

                }
                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
            }
        }
    }
}
