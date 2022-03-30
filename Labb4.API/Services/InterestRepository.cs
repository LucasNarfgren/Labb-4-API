using Labb4.API.Models;
using Labb4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4.API.Services
{
    public class InterestRepository : IInterestRepository
    {
        private Labb4DbContext _Context;
        public InterestRepository(Labb4DbContext Context)
        {
            _Context = Context;
        }

        public async Task<Interest> AddInterest(Interest interestToAdd)
        {
            var interest = await _Context.Interests.AddAsync(interestToAdd);
            await _Context.SaveChangesAsync();
            return interest.Entity;
        }

        public async Task<Interest> Delete(Interest interestToDelete)
        {
            var interest = await _Context.Interests.FirstOrDefaultAsync(i => i.InterestId == interestToDelete.InterestId);
            if (interest != null)
            {
                _Context.Interests.Remove(interest);
                await _Context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<Interest>> GetAllInterest()
        {
            return await _Context.Interests.ToListAsync();
        }



        public async Task<Interest> GetSingleInterest(int id)
        {
            return await _Context.Interests.FirstOrDefaultAsync(i => i.InterestId == id);
        }

        public async Task<Interest> Update(Interest interestToUpdate)
        {
            var result = await _Context.Interests.FirstOrDefaultAsync(p => p.InterestId== interestToUpdate.InterestId);
            if (result != null)
            {
                result.Title = interestToUpdate.Title;
                result.Description = interestToUpdate.Description;

                await _Context.SaveChangesAsync();
            }
            return result;
        }
    }
}
