using Application.Appliaction.Domain.Entities;
using Application.Appliaction.Domain.Interfaces;
using Application.Application.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Application.Application.Infrastructure.Repository
{
    public class HorasTrabalhadasRepository : IHorasTrabalhadasRepository
    {
        private readonly ApplicationDbContext _context;

        public HorasTrabalhadasRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(ProjetoHoras horas)
        {
            _context.ProjetoHoras.Add(horas).State = EntityState.Added;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(ProjetoHoras horas)
        {
            _context.ProjetoHoras.Remove(horas).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public async Task<ProjetoHoras> GetById(Guid id)
        {
            return  await _context.ProjetoHoras.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Update(ProjetoHoras horas)
        {
            _context.ProjetoHoras.Update(horas).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
