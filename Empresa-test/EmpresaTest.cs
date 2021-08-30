using api.Models;
using empresa_api.Repositories;
using empresa_api.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Empresa_test
{
    [TestClass]
    public class EmpresaTest
    {
        private IEmpresaRepository empresaRepositorio;
        private readonly EmpresaContexto _context;

        public EmpresaTest(EmpresaContexto context)
        {
            this.empresaRepositorio = new EmpresaRepository(_context);
        }


        [TestMethod]
        public void TestRetornaLista()
        {
            Assert.IsTrue(empresaRepositorio.Listar().Count > 0);
        }

        [TestMethod]
        public void TestRetornaEmpresa()
        {
            Assert.IsTrue(empresaRepositorio.Pesquisar("50") != null);
        }
    }
}
