using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Check
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                User_service user_Service = new User_service();
                foreach (string item in args)
                {
                    switch (item)
                    {
                        case "1":
                            using (App_contex contex = new App_contex()) //!
                            {
                                var names = typeof(User).GetProperties()
                                    .Select(property => property.Name)
                                    .ToArray();
                                foreach (string name in names)
                                {
                                    Console.Write(name + "\t");
                                }
                                Console.WriteLine();
                                var all_user = contex.Users.ToList();
                                foreach (var people in all_user)
                                {
                                    Console.Write(people.Id + "\t" + people.Fio + "\t" + people.dateOnly + "\t" + people.Sex);
                                    Console.WriteLine();
                                }
                            }
                            break;
                        case "2":
                            user_Service.addUser(args[1], args[2], args[3]);
                            break;
                        case "3": //!
                            using (App_contex contex = new App_contex())
                            {
                                var people = contex.Users.Select(m => new {m.Fio, m.dateOnly, m.Sex}).Distinct()
                                    .OrderBy(m => m.Fio)
                                    .ToList();
                                foreach (var k in people)
                                {
                                    Console.Write("\t" + k.Fio + "\t" + k.dateOnly + "\t" + k.Sex + "\t");
                                    user_Service.printAge(k.dateOnly);
                                    Console.WriteLine();
                                }
                            }
                            break;
                        case "4":
                            List<User> users = user_Service.generateUser();
                            user_Service.addUser(users);
                            List<User> users_100 = user_Service.generateUsersF_100();
                            user_Service.addUser(users_100);
                            break;
                        case "5":
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            var peoplep = user_Service.searchUsersSurnameFM();
                            foreach (var k in peoplep)
                            {
                                Console.Write(k.Id + "\t" + k.Fio + "\t" + k.dateOnly + "\t" + k.Sex + "\t");
                                //user_Service.printAge(k.dateOnly);
                                Console.WriteLine();
                            }
                            stopwatch.Stop();
                            Console.WriteLine(stopwatch.Elapsed.TotalSeconds.ToString());
                            break;
                        default:
                            //Console.WriteLine("---");
                            break;
                    }
                }
                //закрытие контекста
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }
    }
}
