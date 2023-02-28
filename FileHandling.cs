using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeAssignments
{
    static class FileHandling
    {
        public static async void WriteFile()
        {
            //string? name, phoneNumber, email;

            //using StreamWriter file1 = new("User Details", true);
            //{
            //        Console.Write("Enter your Name:");
            //        name = Console.ReadLine();
            //        Console.Write("Enter your Email:");
            //        email = Console.ReadLine();
            //        Console.Write("Enter your Phone Number:");
            //        phoneNumber = Console.ReadLine();

            //        file1.WriteLine();

            //        file1.WriteLine($"Name : {name}");
            //        file1.WriteLine($"Email : {email}");
            //        file1.WriteLine($"Phone Number : {phoneNumber}");
            //}

            Task<int> task = ReadFile();

            Console.WriteLine("before.....");
            Console.WriteLine("before.....");
            Console.WriteLine("before.....");

            int length = await task;
            Console.WriteLine("After....");
            for (int i = 2; i < length; i=i*i*i*i)
            {
                Console.WriteLine("Await Success");
            }
        }

        public static async Task<int> ReadFile()
        {
            int length;
            using StreamReader readFile = new("User Details");
            {
                string userDetails = await readFile.ReadToEndAsync();
                Console.WriteLine(userDetails);
                length = userDetails.Length;
            }
            return length;
        }
    }
}
