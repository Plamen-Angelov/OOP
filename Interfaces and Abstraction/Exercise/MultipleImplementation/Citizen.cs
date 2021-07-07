

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string Id, string birthdate)
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
            this.Id = Id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }
        public string Id { get; set; }
    }
}
