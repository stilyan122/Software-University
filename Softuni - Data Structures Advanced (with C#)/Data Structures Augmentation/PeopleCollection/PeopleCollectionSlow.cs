namespace CollectionOfPeople
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PeopleCollectionSlow : IPeopleCollection
    {
        private List<Person> people = new List<Person>();

        public bool Add(string email, string name, int age, string town)
        {
            foreach (var person in people)
            {
                if (person.Email == email)
                {
                    return false;
                }
            }

            this.people.Add(new Person(email, name, age, town));
            return true;
        }

        public int Count => this.people.Count;

        public Person Find(string email)
            => this.people.FirstOrDefault(p => p.Email == email);

        public bool Delete(string email) => this.people.Remove(this.Find(email));

        public IEnumerable<Person> FindPeople(string emailDomain)
            => this.people
                .Where(p => p.Email.EndsWith($"@{emailDomain}"))
                .OrderBy(p => p.Email);

        public IEnumerable<Person> FindPeople(string name, string town)
            => this.people
                .Where(p => p.Town == town && p.Name == name)
                .OrderBy(p => p.Email);

        public IEnumerable<Person> FindPeople(int startAge, int endAge)
            => this.people
                .Where(p => p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);

        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
            => this.people
                .Where(p => p.Age >= startAge && p.Age <= endAge && p.Town == town)
                .OrderBy(p => p.Age)
                .ThenByDescending(p => p.Town)
                .ThenBy(p => p.Email);
    }
}
