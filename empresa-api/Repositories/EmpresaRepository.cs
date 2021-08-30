using api.Models;
using empresa_api.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace empresa_api.Repositories
{
    public class EmpresaRepository : IEmpresaRepository, IDisposable
    {
        private readonly EmpresaContexto _context;

        public EmpresaRepository(EmpresaContexto context)
        {
            this._context = context;
        }

        public void Salvar(Empresa empresa)
        {

        }

        public List<Empresa> Listar()
        {
            return _context.Empresas.AsNoTracking().ToList();
        }

        public Empresa Pesquisar(string codigo)
        {
            return _context.Empresas.AsNoTracking().SingleOrDefault(x => x.Codigo.Equals(codigo));
        }

        public bool Inserir(Empresa empresa)
        {
            try
            {
                _context.Database.BeginTransaction();
                _context.Empresas.Add(empresa);
                _context.Database.CommitTransaction();
                _context.SaveChanges();
            }
            catch (Exception)
            {
                _context.Database.RollbackTransaction();
                return false;
            }

            return true;
        }

        public bool Update(Empresa empresa)
        {
            try
            {
                _context.Database.BeginTransaction();
                _context.Empresas.Update(empresa);
                _context.Database.CommitTransaction();
                _context.SaveChanges();
            }
            catch (Exception)
            {
                _context.Database.RollbackTransaction();
                return false;
            }

            return true;
        }

        public bool Delete(string codigo)
        {
            var empresa = _context.Empresas.SingleOrDefault(x => x.Codigo.Equals(codigo));

            if (empresa != null)
            {
                try
                {
                    _context.Database.BeginTransaction();
                    _context.Empresas.Remove(empresa);
                    _context.Database.CommitTransaction();
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
