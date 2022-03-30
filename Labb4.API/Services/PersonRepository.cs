using Labb4.API.Models;
using Labb4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4.API.Services
{
    public class PersonRepository : IPersonRepository
    {
        private Labb4DbContext _Context;

        public PersonRepository(Labb4DbContext Context)
        {
            _Context = Context; 
        }

        public async Task<Person> DeletePerson(Person personToDelete)
        {
            var person = _Context.Persons.FirstOrDefault(p => p.PersonId == personToDelete.PersonId);
            if (person != null)
            {
                _Context.Persons.Remove(person);
                await _Context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await _Context.Persons.ToListAsync();
        }

        public async Task<Person> GetSinglePerson(int id)
        {
            return await _Context.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
        }

        public async Task<Person> UpdatePerson(Person personToUpdate)
        {
            var result = await _Context.Persons.FirstOrDefaultAsync(p => p.PersonId == personToUpdate.PersonId);
            if (result != null)
            {
                result.FirstName = personToUpdate.FirstName;
                result.LastName = personToUpdate.LastName;
                result.Adress = personToUpdate.Adress;
                result.Phone = personToUpdate.Phone;

                await _Context.SaveChangesAsync();
            }
            return result;
        }
        
        public async Task<ICollection> GetinterestwithPerson(int id)
        {
            var test3 = (from per in _Context.Persons
                         where per.PersonId == id
                         join inter in _Context.Interests
                         on per.PersonId equals inter.PersonId
                         join link in _Context.Links
                         on inter.InterestId equals link.InterestId
                         
                         select new
                         {
                             Fullname = per.FirstName + " " + per.LastName,
                             interest = inter.Title,
                             description = inter.Description,
                             Link = link.URL

                         }).ToListAsync();

            return await test3;
        }

        public async Task<Person> AddPerson(Person personToAdd)
        {
            var person = await _Context.Persons.AddAsync(personToAdd);
            await _Context.SaveChangesAsync();
            return person.Entity;
        }
    }
}
