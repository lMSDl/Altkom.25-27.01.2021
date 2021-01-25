using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services.InMemoryService
{
    public class PeopleService : IService<Person>
    {
        private int _idCounter = 0;
        private readonly IList<Person> _people; //= new List<Person>();
        //private ICollection<Person> People { get; };// = new List<Person>();

        public PeopleService()
        {
            //People = new List<Person>();
            _people = new List<Person>()
            {
                new Person(){ Id = 1, FirstName = "Marek", LastName = "Markowski", BirthDate = new DateTime(1977, 7, 12), Gender = Gender.Male},
                new Person(){ Id = 5, FirstName = "Ewa", LastName = "Ewowska", BirthDate = new DateTime(1990, 1, 1), Gender = Gender.Female},
            };

            /*for (int i = 0; i < _people.Count; i++)
            {
                var person = _people[i];

                {
                    if (person.Id > _idCounter)
                        _idCounter = person.Id;
                }
            }*/

            foreach (Person person in _people)
            {
                if (person.Id > _idCounter)
                {
                    _idCounter = person.Id;
                }
            }
        }


        public int Create(Person entity)
        {
            entity = (Person)entity.Clone();
            entity.Id = ++_idCounter;
            _people.Add(entity);
            return entity.Id;
        }

        public bool Delete(int id)
        {
            Person entity = InternalRead(id);
            if (entity != null)
            {
                return _people.Remove(entity);
            }

            return false;
        }

        private Person InternalRead(int id)
        {
            Person entity = null;
            int i = 0;
            while (i < _people.Count && entity == null)
            {
                Person person = _people[i++];
                if (person.Id == id)
                {
                    entity = person;
                }
            }
            return entity;
        }

        public Person Read(int id)
        {
            var entity = InternalRead(id);
            return (Person)entity.Clone();
            //return entity.Clone() as Person;
        }

        public bool Update(int id, Person entity)
        {
            if (!Delete(id))
            {
                return false;
            }

            entity = (Person)entity.Clone();
            entity.Id = id;
            _people.Add(entity);
            return true;
        }

        public IEnumerable<Person> Read()
        {
            List<Person> people = new List<Person>();
            foreach (Person person in _people)
            {
                people.Add((Person)person.Clone());
            }
            return people;
        }
    }
}
