using Labb4.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4.API.Services
{
    public interface IPersonRepository
    {
        Task<Person> AddPerson(Person personToAdd);
        Task<IEnumerable<Person>> GetAllPersons();
        Task<Person> GetSinglePerson(int id);
        Task<Person> UpdatePerson(Person personToUpdate);
        Task<Person> DeletePerson(Person personToDelete);
        Task<ICollection> GetinterestwithPerson(int id);

    }
}
