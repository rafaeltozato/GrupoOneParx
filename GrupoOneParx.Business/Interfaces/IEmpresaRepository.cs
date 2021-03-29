using GrupoOneParx.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoOneParx.Business.Interfaces
{
    public interface IEmpresaRepository : IDisposable
    {
        Task<Empresa> ObterPorId(int id);
        Task<IEnumerable<Empresa>> ObterTodos();
        Task Adicionar(Empresa empresa);
        Task Atualizar(Empresa empresa);
        Task Remover(Empresa empresa);

    }
}
