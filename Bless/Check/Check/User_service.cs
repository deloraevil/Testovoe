using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Faker;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;

namespace Check
{
    internal class User_service
    {
        public void addUser(string fio, string date, string sex)
        {
            using (App_contex contex = new App_contex())
            {
                User user = new User { Fio = fio, dateOnly = DateOnly.Parse(date), Sex = sex.ToUpper() };
                contex.Users.Add(user);
                contex.SaveChanges();
                Console.WriteLine("Added");
            }
        }


        public void printAge(User user)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - user.dateOnly.Year;
            DateTime test = user.dateOnly.ToDateTime(TimeOnly.Parse("12:00 PM"));
            if (test.AddYears(age) > now)
                age--;
            Console.WriteLine($"Age: {age}");
        }

        public void printAge(DateOnly date)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - date.Year;
            DateTime test = date.ToDateTime(TimeOnly.Parse("12:00 PM"));
            if (test.AddYears(age) > now)
                age--;
            Console.WriteLine($"Age: {age}");
        }

        public List<User> generateUser()
        {
            List<User> users_add = new List<User>();
            DateOnly startDate = new DateOnly(1945, 1, 1);
            DateOnly endDate = new DateOnly(2021, 12, 31);
            for (int i = 0; i < 1000000; i++)
            {
                Random random = new Random();
                User user = new User();
                user.Fio = Faker.NameFaker.FirstName() + " " + Faker.NameFaker.LastName() + " " + Faker.NameFaker.MaleFirstName();
                int range = (endDate.ToDateTime(TimeOnly.MinValue) - startDate.ToDateTime(TimeOnly.MinValue)).Days;
                user.dateOnly = startDate.AddDays(random.Next(range));
                if (random.Next()%2==0)
                {
                    user.Sex = "F";
                }
                else
                {
                    user.Sex = "M";
                }
                users_add.Add(user);
            }
            return users_add;
        }

        public void addUser(List<User> users)
        {
            using (App_contex contex = new App_contex())
            {
                for (int i = 0; i < users.Count; i++)
                {
                    contex.Users.Add(users[i]);
                    //Console.WriteLine("Added");
                }
                contex.SaveChanges();
                Console.WriteLine($"{users.Count} users added");
            }

        }

        public List<User> generateUsersF_100()
        {
            List<User> users_add = new List<User>();
            DateOnly startDate = new DateOnly(1945, 1, 1);
            DateOnly endDate = new DateOnly(2021, 12, 31);
            for (int i = 0; i < 100; i++)
            {
                Random random = new Random();
                User user = new User();
                string lastname = Faker.NameFaker.LastName();
                lastname = 'F' + lastname.Remove(0, 1);
                user.Fio = Faker.NameFaker.FirstName() + " " + lastname + " " + Faker.NameFaker.MaleFirstName();
                int range = (endDate.ToDateTime(TimeOnly.MinValue) - startDate.ToDateTime(TimeOnly.MinValue)).Days;
                user.dateOnly = startDate.AddDays(random.Next(range));
                user.Sex = "M";
                users_add.Add(user);
            }
            return users_add;
        }

        public List<User> searchUsersSurnameFM()
        {
            /*List<User> users_add = new List<User>();
            string[] a;
            //int count = 0;
            foreach (User user in users)
            {
                a = user.Fio.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (a[1][0] == 'F')
                {
                    if (user.Sex == "M")
                    {
                        users_add.Add(user);
                    }
                }
            }
            return users_add;*/
            List<User> people;
            using (App_contex app_Contex = new App_contex())
            {
                people = app_Contex.Users.Where(p => p.Sex == "M" && p.Fio.Contains(" F")).ToList();
            }
            return people;
        }
    }
}
