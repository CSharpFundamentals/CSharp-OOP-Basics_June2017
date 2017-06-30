namespace OldestFamilyMember
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;            
        }

        public int Age
        {
            get { return this.age; }
        }

        public string Name
        {
            get { return this.name; }
        }
    }
}
