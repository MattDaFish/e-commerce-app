using Infrastructure.Data;
using JustSports.Core.Entities;
using JustSports.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustSports.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly JustSportsDBContext _context;

        public BaseRepository(JustSportsDBContext context)
        {
            _context = context;
        }
    }
}