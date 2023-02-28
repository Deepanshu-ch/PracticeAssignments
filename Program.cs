using CountNegative;
using InheritStudent;
using Errorhandling;
using System.Text;
using EventHandler;
using Reflection;
using System.Reflection;
using AreaOfCircle;
using EncryptionDecryption;
using System.Security.Cryptography;

#pragma warning disable S125  // Sections of code should not be commented out

namespace PracticeAssignments
{
    public delegate int square(int num);
    static class Program
    {
        public static void Main()
        {
            string? continuationChoice;

            do
            {
                Console.Clear();
                Console.WriteLine("Assignments:");
                Console.WriteLine("01. Assignment 1:    Area of Circle");
                Console.WriteLine("02. Assignment 2:    Name of Operator");
                Console.WriteLine("03. Assignment 3:    Count Negative Elements in an Array");
                Console.WriteLine("04. Assignment 4:    Inheritance");
                Console.WriteLine("05. Assignment 5:    Divide by Zero Exception");
                Console.WriteLine("06. Assignment 6:    File Handling");
                Console.WriteLine("07. Assignment 7:    Square of Number using Lambda function");
                Console.WriteLine("08. Assignment 8:    Event to Detect Temperature Change");
                Console.WriteLine("09. Assignment 9:    Call Method Using Reflection");
                Console.WriteLine("10. Assignment 10:   Generic Class");
                Console.WriteLine("11. Assignment 11:   Truncate String after 20 Words");
                Console.WriteLine("12. Assignment 12:   Remove spaces from string");
                Console.WriteLine("13. Assignment 13:   Ticket Booking system");
                Console.WriteLine("14. Assignment 14:   Async - Await");
                Console.WriteLine("15. Assignment 15:   Encryption");
                Console.Write("Choose Assignment(Press 0 to Exit):");

                //Exceptions<int>.TryParse(Console.ReadLine(), out int choice);

                if (int.TryParse(Console.ReadLine(), out int choice)) //This will give 0 if entered value is not of integer type
                {
                    switch (choice)
                    {
                        case 0:

                            Environment.Exit(1);
                            break;

                        case 1:

                            Console.Clear();

                            //double radius;
                            //Console.Write("Enter Radius:"); 
                            //radius = Convert.ToDouble(Console.ReadLine());

                            //// Function to find Radius
                            //static double Area(double radius) => Math.Pow(radius, 2) * Math.PI;

                            //Console.WriteLine("Area of Circle: "+Area(radius));

                            //Using Class Executing Above Code

                            CircleArea circle1 = new();
                            CircleArea circle2 = new(5.5);

                            Console.Write("Area of First Circle: ");
                            Console.WriteLine(circle1.Area());
                            Console.WriteLine();
                            Console.Write("Area of Second Circle: ");
                            Console.WriteLine(circle2.Area());

                            break;

                        case 2:

                            Console.Clear();
                            string[] ops = { "+", "-", "*", "/" };
                            string[] eng = { "Addition", "Subtraction", "Multiplication", "Division" };
                            string? Operator;

                            int i;
                            Console.Write("Enter a Operator(+,-,*,/):");
                            Operator = Console.ReadLine();

                            for (i = 0; i < ops.Length; i++)
                            {
                                if (ops[i] == Operator)
                                {
                                    Console.WriteLine(eng[i]);
                                    break;
                                }
                            }
                            if (i == ops.Length)
                            {
                                Console.WriteLine("\nInvalid Operator!!\nTry Again");
                            }

                            break;

                        case 3:

                            Console.Clear();

                            int count, arraySize;

                            Console.Write("Enter the size of an array:");
                            arraySize = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Negative elements found in Array:" + CountNegativeElements.CountNegativeValues(out count, Array.MakeArray.CreateArray(arraySize)) + "\nTotal number of negative elements are:" + count);


                            // if You don't want to use string builder
                            var arr = Array.MakeArray.CreateArray(arraySize);

                            var negElements = from a in arr
                                              where a < 0
                                              select a;

                            Console.Write("Negative Elements: ");
                            foreach (var neg in negElements)
                            {
                                Console.Write(neg + " ");
                            }

                            Console.WriteLine();

                            Console.WriteLine("Number of negative Elements are: " + arr.Count(count => count < 0));

                            break;

                        case 4:

                            Console.Clear();

                            ShowDetails student1 = new("Deepanshu", "Chauhan");
                            ShowDetails student2 = new("Ajay", "Rajput");

                            Console.WriteLine();
                            Console.WriteLine("Calling Method of base class Student from derived class ShowDetails:");
                            Console.WriteLine(student1.GetName());
                            Console.WriteLine(student2.GetName());

                            break;

                        case 5:

                            Console.Clear();

                            try
                            {
                                Console.WriteLine("Parameterized Constructor for size of 3:");
                                Quotient result = new(3, 3);

                                result.CreateDividendArray();
                                result.ShowDividendArray();
                                result.CreateDivisorArray();
                                result.ShowDivisorArray();
                                result.Divide();
                                result.ShowResult();

                                Console.WriteLine("Passing array in constructor:");
                                Quotient result3 = new(new int[] { 10, 20, 50, 30 }, new int[] { 2, 0, 5, 6 });

                                result3.ShowDividendArray();
                                result3.ShowDivisorArray();
                                result3.Divide();
                                result3.ShowResult();

                                Console.WriteLine("Calling Parameterless Constructor:");
                                Quotient result2 = new();

                                result2.CreateDividendArray();
                                result2.ShowDividendArray();
                                result2.CreateDivisorArray();
                                result2.ShowDivisorArray();
                                result2.Divide();
                                result2.ShowResult();

                            }
                            catch (DivideByZeroException)
                            {
                                Console.WriteLine("Cannot Divide by Zero");
                            }
                            catch (IndexOutOfRangeException) { Console.WriteLine("Index out of Range!! \n Fatal Error terminating Program!!!"); }


                            break;

                        case 6:

                            Console.Clear();

                            var directoryName = "User Details";
                            string? fileName;
                            string? name, phoneNumber;

                            DirectoryInfo directory = new(directoryName);

                            directory.Create();   // this will create folder name MyDirectory at specified path

                            Console.Write("Enter a file name:");

                            fileName = Console.ReadLine();

                            var filePath = $@"{directoryName}\{fileName}";  // Setting path to create file with user defined name

                            // Check if file exist or not

                            if (!File.Exists(filePath))
                            {
                                //Creating a file if don't exist you can also directly open file in append mode to avoid this step

                                using FileStream fin = new(filePath, FileMode.Create, FileAccess.Write);  // using statement helps in auto closing of file
                                string data = "\nUser Details:\n";
                                byte[] write_data = Encoding.UTF8.GetBytes(data);  // One way of writing data in file
                                fin.Write(write_data, 0, data.Length);
                                // here file will close automatically no need to use fin.close
                            }

                            FileStream fout;

                            try  // this step can also be ignored file can directly be opened with help of stream writer class.
                            {
                                fout = new FileStream(filePath, FileMode.Append, FileAccess.Write);
                            }
                            catch (IOException exc)
                            {
                                Console.WriteLine(exc.Message);
                                return;
                            }

                            // Now, lets open Stream writer to write user details in our program

                            StreamWriter? file = null;

                            try
                            {
                                file = new StreamWriter(fout);

                                do
                                {
                                    Console.Write("Enter your Name:");
                                    name = Console.ReadLine();
                                    Console.Write("Enter your Phone Number:");
                                    phoneNumber = Console.ReadLine();

                                    file.WriteLine();

                                    //file.WriteLine($"User {userCount}");
                                    file.WriteLine($"Name : {name}");
                                    file.WriteLine($"Phone Number : {phoneNumber}");

                                    //userCount++;

                                    Console.Write("Do you want to add more details:");
                                } while (Console.ReadLine() == "yes");

                            }
                            catch (IOException exc)
                            {
                                Console.WriteLine(exc.Message);
                            }
                            finally
                            {
                                file?.Close();
                            }

                            // Now lets read the content of the file
                            // We can directly open a file with stream Reader
                            // or like we did above first open it with fileStream and
                            // then with stream reader both are correct way of witting a code.

                            using (StreamReader readFile = new(filePath))
                            {
                                string userDetails = readFile.ReadToEnd();
                                Console.WriteLine(userDetails);
                            }// here using will automatically close the file.

                            Console.WriteLine("Press Enter key to Continue......");
                            Console.ReadLine();
                            break;

                        case 7:

                            Console.Clear();

                            // Lambda function that returns square of given Number

                            Console.Write("Enter a Number:");

                            if (int.TryParse(Console.ReadLine(), out int num))
                            {
                                // With the help of Delegate
                                //square sqr = num => num * num;

                                // direct function
                                static int sqr(int num) => num * num;

                                Console.WriteLine(sqr(num));
                            }
                            else
                                Console.WriteLine("Enter Valid Input");


                            break;

                        case 8:

                            Console.Clear();

                            // Call Event whenever temperature is less than 30.

                            Temprature[] temp = {
                    new Temprature() { ChangeTempratureTo = 28 },
                    new Temprature() { ChangeTempratureTo = 38 },
                    new Temprature() { ChangeTempratureTo = 25 },
                    new Temprature() { ChangeTempratureTo = 48 },
                    new Temprature(5)
                    };

                            var temp4 = new Temprature() { ChangeTempratureTo = 0 };

                            DetectTempratureChange detect = new();  // publisher

                            User1 deepanshu = new(); // subscriber
                            User2 ajay = new(); //subscriber

                            detect.ChangeDetected += deepanshu.OnChangeDetected;
                            detect.ChangeDetected += ajay.OnChangeDetected;

                            for (i = 0; i < temp.Length; i++)
                            {
                                detect.Detect(temp[i]);
                            }
                            detect.Detect(temp4);

                            Console.WriteLine("Press Enter key to Continue......");
                            Console.ReadLine();
                            break;

                        case 9:

                            Console.Clear();

                            //Type t = typeof(Student);  //getting Student Type

                            //Console.WriteLine(t.Name);

                            //object obj = Activator.CreateInstance(t); // creating object for current class

                            //object[] args = { false };

                            // Methods Array
                            //MethodInfo[] methods = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public); //Find Method
                            //for (int i = 0; i < methods.Length; i++)  // Loop through methods
                            //{
                            //    ParameterInfo[] param = methods[i].GetParameters();
                            //    if (param.Length>0)
                            //    {
                            //        Console.WriteLine("-- Invoking Method: " + methods[i].Name);
                            //        methods[i].Invoke(obj, args);
                            //    }
                            //}


                            // Using Different Method
                            var studentClass = from t in Assembly.GetExecutingAssembly().GetTypes()
                                               where t.GetCustomAttributes(false).Any(a => a is ResultAttribute)
                                               select t;

                            Console.WriteLine(studentClass);

                            //object[] args = { true };
                            object[] arg = { false };

                            foreach (var t in studentClass)
                            {
                                Console.WriteLine(t.Name);
                                var methods = from m in t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                                              where m.GetCustomAttributes(false).Any(a => a is ResultTypeAttribute)
                                              select m;

                                object? student = Activator.CreateInstance(t); // To pass parameters in constructor use CreateInstance(t,args); here args is object array of parameters
                                foreach (var method in methods)
                                {
                                    Console.WriteLine("--Invoking Method:" + method.Name);
                                    method.Invoke(student, arg);
                                }
                            }

                            //if (studentClass!=null)
                            //    Console.WriteLine("No class Found");

                            break;

                        case 10:

                            Console.Clear();

                            string[] websites = { "hsNameA.com", "hsNameB.net", "hsNameC.net", "hsNameD.com", "hsNameE.org", "hsNameF.org", "hsNameG.tv", "hsNameH.net", "hsNameI.tv" };
                            // Use query methods to group websites by top-level domain name.
                            var webAddrs = websites.Where(w => w.LastIndexOf('.') != -1).GroupBy(x => x[x.LastIndexOf(".")..]);//x => x.Substring(x.LastIndexOf("."))

                            // Execute the query and display the results.
                            foreach (var sites in webAddrs)
                            {
                                Console.WriteLine("Web sites grouped by " + sites.Key);
                                foreach (var site in sites)
                                    Console.WriteLine(" " + site);
                                Console.WriteLine();

                            }

                            break;

                        case 11:

                            Console.Clear();

                            string? str;

                            Console.WriteLine("Enter a String:");
                            str = Console.ReadLine();
                            if (str != null)
                                Console.WriteLine(str.Truncate());

                            Console.WriteLine("Another String");
                            Console.WriteLine("Hello this is Deepanshu Chauhan, I'm 21 years old. I hope this has become 20 letters long cause I'm not in mood of writing anymore See ya Have a Good Day!!".Truncate());

                            break;

                        case 12:

                            Console.Clear();

                            Console.Write("Enter a String:");
                            str = Console.ReadLine();

                            if (str != null)
                                Console.WriteLine(String.Join("", str.Split(" ")));

                            else
                                Console.WriteLine("Please Enter a String.");

                            break;

                        case 13:

                            Console.Clear();

                            Console.WriteLine("Work in Progress");

                            break;

                        case 14:

                            Console.Clear();

                            FileHandling.WriteFile();

                            break;

                        case 15:

                            Console.Clear();

                            string? textToEncrypt;
                            Console.Write("Enter string to encrypt:");
                            textToEncrypt = Console.ReadLine();

                            string encryptedText, decryptedText;
                            byte[] encrypted;

                            using (Aes myAes = Aes.Create())
                            {
                                encrypted = CryptographyAes.EncryptStringToBytes(textToEncrypt, myAes.Key, myAes.IV);
                                encryptedText =  Encoding.UTF8.GetString(encrypted);
                                decryptedText = CryptographyAes.DecryptStringFromBytes(encrypted,myAes.Key, myAes.IV);

                                Console.WriteLine(encrypted);
                                Console.WriteLine("Encrypted Text:");
                                Console.WriteLine(encryptedText);
                                Console.WriteLine("Decrypted Text:");
                                Console.WriteLine(decryptedText);
                            }

                            break;

                        default:

                            Console.Clear();
                            Console.WriteLine("Invalid Input!! Please Try Again..");
                            break;
                    }
                }
                else
                    Console.WriteLine("Enter Valid Input....\nTry Again");

                // Choice to continue
                Console.Write("Do you want to Continue(yes/no):");

                continuationChoice = Console.ReadLine();

            } while (continuationChoice == "yes");
        }
    }
}
