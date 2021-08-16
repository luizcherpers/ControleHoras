using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Interfaces;
using Application.Application.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Application.Infrastructure.Repository
{
    public class ColaboradorEquipeRepository : IColaboradorEquipeRepository
    {
        private readonly ApplicationDbContext _context;

        public ColaboradorEquipeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ColaboradorEquipe> GteByIdColaboradorEquipe(Guid colaboradorId, Guid EquipeId)
        {
            return await _context.ColaboradorEquipe.FirstOrDefaultAsync(x => x.ColaboradorId == colaboradorId && x.EquipeId == EquipeId);
        }

        public async Task<int> Create(ColaboradorEquipe colaboradorEquipe)
        {
            _context.ColaboradorEquipe.Add(colaboradorEquipe).State = EntityState.Added;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(ColaboradorEquipe colaboradorEquipe)
        {
            _context.ColaboradorEquipe.Update(colaboradorEquipe).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
