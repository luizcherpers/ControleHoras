using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Interfaces;
using Application.Application.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Application.Infrastructure.Repository
{
    public class EquipeRepository : IEquipeRepository
    {
        private readonly ApplicationDbContext _context;

        public EquipeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Equipe equipe)
        {
            _context.Equipe.Add(equipe).State = EntityState.Added;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Equipe equipe)
        {
            _context.Equipe.Remove(equipe).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Equipe>> GetByAll()
        {
            return await _context.Equipe.ToListAsync();
        }

        public Task<Equipe> GetById(Guid id)
        {
            return _context.Equipe.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Update(Equipe equipe)
        {
            _context.Equipe.Update(equipe).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
