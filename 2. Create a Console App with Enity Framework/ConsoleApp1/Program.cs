using ConsoleApp1.Entities;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ActorDbContext db = new ActorDbContext())
            {
                // Seed
                db.Actors.AddRange(
                    new Actor 
                    {
                        Name = "Bruce Lee",
                        Age = 75,
                        AcademyWinner = false
                    }, 
                    new Actor
                    {
                        Name = "Madonna",
                        Age = 55,
                        AcademyWinner = true
                    });

                var count = db.SaveChanges();

                // Fetch data
                Console.WriteLine($"{count} records added");

                foreach ( var actor in db.Actors ) {
                    Console.WriteLine($"Name - {actor.Name},\t\t" +
                        $"Age: {actor.Age},\t\t" +
                        $"Academy Winner: {actor.AcademyWinner}");
                }

                Console.ReadLine();

            }


        }
    }
}
