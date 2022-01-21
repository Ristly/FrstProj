using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace FrstProj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //using (TestContext db = new TestContext())
            //{
            ////     ������� ��� ������� User
            //    User user1 = new User { UserName = "Tom", UserAge = 33 };
            //    User user2 = new User { UserName = "Alice", UserAge = 26 };

            ////     ��������� �� � ��
            //    db.Users.AddRange(user1, user2);
            //    db.SaveChanges();
            //}
            //// ��������� ������
            //using (TestContext db = new TestContext())
            //{
            ////     ������� ��� ������� User
            //    City city1 = new City { NameCity = "Baikonur" };
            //    City city2 = new City { NameCity = "Saint Petersburg" };

            ////     ��������� �� � ��
            //    db.Cities.AddRange(city1, city2);
            //    db.SaveChanges();
            //}

        }

        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    
                    webBuilder.UseStartup<Startup>();
                });
        


    }
}
