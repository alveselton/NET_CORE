using api.Models;
using empresa_api.Repositories;
using empresa_api.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace empresa_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {

        private readonly ILogger<EmpresaController> _logger;
        private readonly EmpresaContexto _context;
        private IEmpresaRepository empresaRepositorio;

        public EmpresaController(EmpresaContexto context, ILogger<EmpresaController> logger)
        {
            _context = context;
            _logger = logger;
            this.empresaRepositorio = new EmpresaRepository(_context);
        }

        [EnableCors("AllowAll")]
        [HttpGet]
        public List<Empresa> Get()
        {
            var listaEmpresas = empresaRepositorio.Listar();
            return listaEmpresas;
        }

        [HttpGet]
        [Route("{codigo}")]
        public Empresa Get(string codigo)
        {
            var empresa = empresaRepositorio.Pesquisar(codigo);
            return empresa;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Empresa))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Empresa> Post(Empresa empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empresa.DataCadastro = DateTime.Now;
                    empresaRepositorio.Inserir(empresa);
                }

                return Ok(empresa);

            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Empresa))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Empresa> Put(Empresa empresa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empresa.DataCadastro = DateTime.Now;
                    empresaRepositorio.Update(empresa);
                }

                return Ok(empresa);

            }
            catch (Exception)
            {
                _context.Database.RollbackTransaction();
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Empresa))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Empresa> Delete(string codigo)
        {
            var empresa = _context.Empresas.SingleOrDefault(x => x.Codigo.Equals(codigo));

            if (empresa != null)
            {
                empresaRepositorio.Delete(empresa.Codigo);
                return Ok(empresa);
            }
            else
            {
                return BadRequest(null);
            }

        }

    }
}
