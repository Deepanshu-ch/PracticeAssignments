using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.All)]
    public class ResultAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.All)]
    public class ResultTypeAttribute : Attribute { }

    [ResultAttribute]
    class Student
    {
        bool isPass;

        public Student()
        {
            Console.WriteLine("Waiting for Result:");
        }

        public Student(bool i)
        {
            isPass = i;
            Console.WriteLine(ShowIfPass());
        }

        [ResultType]
        public void SetIsPass(bool passOrFail)
        {
            isPass = passOrFail;
            Console.WriteLine(ShowIfPass());
        }
        public string ShowIfPass()
        {
            return isPass ? "Student has Pass the Exams" : "Student has Failed the Exams";
        }
    }
}
