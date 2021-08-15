using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Enumerados;
using Application.Appliaction.Domain.Interfaces;
using Application.Application.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Application.Infrastructure.Repository
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly ApplicationDbContext _context;

        public PerfilRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Perfil> GetByEnum(PerfilEnum perfilEnum)
        {
            return await _context.Perfil.FirstOrDefaultAsync(x => x.PerfilEnum == perfilEnum);
        }

        public async Task<IEnumerable<Perfil>> GetPerfis()
        {
            return await _context.Perfil.ToListAsync();
        }
    }
}
