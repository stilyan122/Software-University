namespace CollectionOfPeople
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class PeopleCollection : IPeopleCollection
    {
        private Dictionary<string, Person> peopleByEmail;
        private Dictionary<string, SortedSet<Person>> peopleByEmailDomain;
        private Dictionary<(string name, string town), SortedSet<Person>> peopleByNameAndTown;
        private OrderedDictionary<int, SortedSet<Person>> peopleByAge;
        private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> peopleByTownAndAge;

        public PeopleCollection()
        {
            this.peopleByEmail = new Dictionary<string, Person>();
            this.peopleByEmailDomain = new Dictionary<string, SortedSet<Person>>();
            this.peopleByNameAndTown = new Dictionary<(string name, string town), SortedSet<Person>>();
            this.peopleByAge = new OrderedDictionary<int, SortedSet<Person>>();
            this.peopleByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
        }

        public bool Add(string email, string name, int age, string town)
        {
            if (peopleByEmail.ContainsKey(email))
            {
                return false;
            }

            var person = new Person(email, name, age, town);

            this.peopleByEmailDomain.AppendValueToKey(email.Split("@")[1], person);
            this.peopleByEmail.Add(email, person);
            this.peopleByNameAndTown.AppendValueToKey((name, town), person);
            this.peopleByAge.AppendValueToKey(age, person);
            this.peopleByTownAndAge.EnsureKeyExists(town);
            this.peopleByTownAndAge[town].AppendValueToKey(age, person);

            return true;
        }

        public int Count => this.peopleByEmail.Count;

        public Person Find(string email)
        {
            Person person;

            this.peopleByEmail.TryGetValue(email, out person);

            return person;
        }

        public bool Delete(string email)
        {
            var person = this.Find(email);
            if(person == null)
            {
                return false;
            }

            this.peopleByEmailDomain[email.Split("@")[1]].Remove(person);
            this.peopleByNameAndTown[(person.Name, person.Town)].Remove(person);
            this.peopleByAge[person.Age].Remove(person);
            this.peopleByTownAndAge[person.Town][person.Age].Remove(person);

            return this.peopleByEmail.Remove(email);
        }

        public IEnumerable<Person> FindPeople(string emailDomain)
        {
            return this.peopleByEmailDomain.GetValuesForKey(emailDomain);
        }

        public IEnumerable<Person> FindPeople(string name, string town)
        {
            return this.peopleByNameAndTown.GetValuesForKey((name, town));
        }

        public IEnumerable<Person> FindPeople(int startAge, int endAge)
        {
            return this.peopleByAge
                .Range(startAge, true, endAge, true)
                .SelectMany(kvp => kvp.Value.Select(p => p))
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);
        }

        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
        {
            if (!this.peopleByTownAndAge.ContainsKey(town))
            {
                return Enumerable.Empty<Person>();
            }

            return this.peopleByTownAndAge[town]
                .Range(startAge, true, endAge, true)
                .SelectMany(kvp => kvp.Value.Select(p => p));
        }
    }
}
