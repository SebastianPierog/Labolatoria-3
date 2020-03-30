using System;
using System.Linq;
using Labolatoria3.Models;

namespace Labolatoria3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            using var context = new AppDbContext();

            context.Database.EnsureCreated();
            context.Students.Add(new Student()
            {
                FirstName = "Jan",
                LastName = "Kowalski"
            });
            context.SaveChanges();

            var students = context.Students;
            foreach (var item in students)
            {
                System.Console.WriteLine($"{item.Id}: {item.FirstName} {item.LastName}");
            }

            var student = context.Students.Where(x => x.Id == 1).First();
            student.FirstName = "Marek";
            context.Students.Update(student);
            context.SaveChanges();
            */

            using var northContext = new NorthwindContext();

            var result = (from o in northContext.Orders
                          join c in northContext.Customers.Take(5) on o.CustomerId equals c.CustomerId
                          select new { o.OrderId, o.ShipName, c.City, c.Country, c.CompanyName })
                         .OrderBy(x => x.CompanyName)
                         .ToList();

            foreach (var item in result)
            {
                System.Console.WriteLine($"{item.CompanyName}:");
                System.Console.WriteLine($"{item.OrderId} || {item.ShipName} || {item.City} || {item.Country}");
                System.Console.ReadLine();
            }
        }
    }
}