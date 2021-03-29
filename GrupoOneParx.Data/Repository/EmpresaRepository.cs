using GrupoOneParx.Business.Interfaces;
using GrupoOneParx.Business.Models;
using GrupoOneParx.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoOneParx.Data.Repository
{
    public class EmpresaRepository : IDisposable, IEmpresaRepository
    {
        protected readonly GrupoOneParxContext Db;
        protected readonly DbSet<Empresa> DbSet;

        public EmpresaRepository(GrupoOneParxContext db)
        {
            Db = db;
            DbSet = db.Set<Empresa>();
        }

        public virtual async Task<Empresa> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<Empresa>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(Empresa empresa)
        {
            DbSet.Add(empresa);
            await SaveChanges();
        }

        public virtual async Task Atualizar(Empresa empresa)
        {
            DbSet.Update(empresa);
            await SaveChanges();
        }

        public virtual async Task Remover(Empresa empresa)
        {
            DbSet.Remove(empresa);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
