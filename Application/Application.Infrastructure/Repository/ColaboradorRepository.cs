using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Interfaces;
using Application.Application.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Application.Infrastructure.Repository
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly ApplicationDbContext _context;

        public ColaboradorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Colaborador colaborador)
        {
            _context.Colaborador.Add(colaborador).State = EntityState.Added;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Colaborador colaborador)
        {
            _context.Colaborador.Remove(colaborador).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Colaborador>> GetAll()
        {
            return await _context.Colaborador.ToListAsync();
        }

        public async Task<Colaborador> GetById(Guid id)
        {
            return await _context.Colaborador.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Update(Colaborador colaborador)
        {
            _context.Colaborador.Update(colaborador).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
