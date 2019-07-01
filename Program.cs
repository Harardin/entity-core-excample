using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace CoreEntityTesting
{
    class Program
    {
        public class Data
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }
        public class AnnotationsDB : DbContext
        {
            public DbSet<Data> QData { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TestDatabaseConsole;Trusted_Connection=True");
            }

        }

        static void Main(string[] args)
        {
            // Excample of Saving some data to SqlDataBase
            AnnotationsDB context = new AnnotationsDB();
            /*
            for (int i = 0; i < 50; i++)
            {
                context.QData.Add(new Data { Name = "Sir " + i, Surname = "Wiliam " + i });
            }
            context.SaveChanges();*/

            // Excample of showing data from SqlTable
            Data dt = context.QData.Find(1);
            

            Console.WriteLine(dt.Name + dt.Surname);

        }
    }
}
