using Labb4.API.Models;
using Labb4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4.API.Services
{
    public class LinkRepository : ILinkRepository
    {
        private Labb4DbContext _Context;
        public LinkRepository(Labb4DbContext Context)
        {
            _Context = Context;
        }

        public async Task<Link> AddLink(Link linkToAdd)
        {
            var link = await _Context.Links.AddAsync(linkToAdd);
            await _Context.SaveChangesAsync();
            return link.Entity;
        }

        public async Task<IEnumerable<Link>> GetAllLinks()
        {
            return await _Context.Links.ToListAsync();
        }
    }
}
