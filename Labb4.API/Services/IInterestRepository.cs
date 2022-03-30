using Labb4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4.API.Services
{
    public interface IInterestRepository
    {
        Task<IEnumerable<Interest>> GetAllInterest();
        Task<Interest> AddInterest(Interest interestToAdd);
        Task<Interest> GetSingleInterest(int id);
        Task<Interest> Update(Interest interestToUpdate);
        Task<Interest> Delete(Interest interestToDelete);
        
    }
}
