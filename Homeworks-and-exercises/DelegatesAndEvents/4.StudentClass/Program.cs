namespace _4.StudentClass
{
    using System;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            Student student = new Student("Peter", 22);
            student.PropertyChanged += (sender, eventArgs) =>
            {
                Console.WriteLine("Property changed: {0} (from {1} to {2})", eventArgs.PropertyName, eventArgs.OldValue, eventArgs.NewValue);
            };

            student.Name = "Maria";
            student.Age = 19;
        }
    }
}
