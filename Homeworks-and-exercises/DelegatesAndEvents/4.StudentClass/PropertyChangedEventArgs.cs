namespace _4.StudentClass
{
    using System;

    public class PropertyChangedEventArgs : EventArgs
    {
        public PropertyChangedEventArgs(string propertyName, object oldValue, object newValue)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.PropertyName = propertyName;
        }

        public object OldValue { get; set; }

        public object NewValue { get; set; }

        /*public PropertyChangedEventArgs(string oldName, string newName, int oldAge, int newAge)
        {
            this.OldName = oldName;
            this.NewName = newName;
            this.OldAge = oldAge;
            this.NewAge = newAge;
            this.studentType = typeof(Student);
        }

        public PropertyChangedEventArgs(string oldName, string newName) : 
            this(oldName, newName, 0, 0)
        {
            this.PropertyName = this.studentType.GetProperty("Name");
        }

        public PropertyChangedEventArgs(int oldAge, int newAge) : this (null, null, oldAge, newAge)
        {
            this.PropertyName = this.studentType.GetProperty("Age");
        }

        public string OldName { get; set; }

        public string NewName { get; set; }

        public int OldAge { get; set; }

        public int NewAge { get; set; }*/

        public string PropertyName { get; set; }
    }
}
