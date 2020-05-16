using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AspNetCoreDockerMysql.Model;
using AspNetCoreDockerMysql.Model.Context;

namespace AspNetCoreDockerMysql.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImpl(MySQLContext context)
        {
            _context = context;
        }

        //private volatile int count;

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            //Moki
            /*
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
            */

            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            //Moki
            /*
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Luiz",
                LastName = "Almada",
                Address = "Jardim do Ingá - Luziânia - Goiás - Brasil",
                Gender = "Male"
            };
            */

            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return person;
        }

        private bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }

        /*
        private Person MockPerson(long i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person FirstName" + i,
                LastName = "Person LastName" + i,
                Address = "Some Address" + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
        
         */
    }
}
