namespace _4.StudentClass
{
    using System;

    public delegate void PropertyChangedEventHandler(Student student, PropertyChangedEventArgs args);

    public class Student
    {
        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Student name should not be empty!");
                }

                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Name", this.name, value));
                }

                this.name = value;
            }
        }
        
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Student age should not be a negatuve number!");
                }

                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Age", this.age, value));
                }

                this.age = value;
            }
        }
    }
}
