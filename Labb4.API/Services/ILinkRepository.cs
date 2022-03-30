using Labb4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4.API.Services
{
    public interface ILinkRepository
    {
        Task<Link> AddLink(Link linkToAdd);
        Task<IEnumerable<Link>> GetAllLinks();
    }
}
