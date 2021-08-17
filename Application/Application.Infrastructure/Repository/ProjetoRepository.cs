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
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjetoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Projeto projeto)
        {
            _context.Projeto.Add(projeto).State = EntityState.Added;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Projeto projeto)
        {
            _context.Projeto.Remove(projeto).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Projeto>> GetAll()
        {
            return await _context.Projeto.ToListAsync();
        }

        public async Task<Projeto> GetById(Guid id)
        {
            return await _context.Projeto.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Update(Projeto projeto)
        {
            _context.Projeto.Add(projeto).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
