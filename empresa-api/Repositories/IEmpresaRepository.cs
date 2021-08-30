using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empresa_api.Repository
{
    public interface IEmpresaRepository : IDisposable
    {
        Empresa Pesquisar(string codigo);
        List<Empresa> Listar();
        bool Inserir(Empresa empresa);
        bool Update(Empresa empresa);
        bool Delete(string codigo);

    }

}
