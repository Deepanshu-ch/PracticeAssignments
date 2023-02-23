namespace InheritStudent
{
    internal class Student
    {
        private readonly string firstName;
        private readonly string lastName;

        public Student(string fName, string lName)
        {
            firstName = fName;
            lastName = lName;
        }

        public string GetName()
        {
            return firstName + " " + lastName;
        }
    }
    internal class ShowDetails : Student
    {
        public ShowDetails(string firstName, string lastName) : base(firstName, lastName)
        {
            Console.WriteLine("Student Name:" + firstName + " " + lastName);
        }

    }
}