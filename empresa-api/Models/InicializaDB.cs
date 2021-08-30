using System;
using System.Linq;

namespace api.Models
{
    public static class InicializaDB
    {
        public static void Initialize(EmpresaContexto context)
        {
            context.Database.EnsureCreated();
            context.Empresas.RemoveRange(context.Empresas.ToList());
            context.SaveChanges();

            if (context.Empresas.Any())
            {
                return;
            }

            var empresas = new Empresa[]
            {
                new Empresa { Codigo="10", Cnpj="44.367.527/0001-24", RazaoSocial="Calebe e Pedro Henrique Gráfica Ltda", DataCadastro = DateTime.Now },
                new Empresa { Codigo="20", Cnpj="99.910.471/0001-02", RazaoSocial="Erick e Luana Assessoria Jurídica Ltda", DataCadastro = DateTime.Now},
                new Empresa { Codigo="30", Cnpj="96.240.353/0001-38", RazaoSocial="Beatriz e Rayssa Marcenaria ME", DataCadastro = DateTime.Now},
                new Empresa { Codigo="40", Cnpj="30.155.842/0001-83", RazaoSocial="Elaine e Eduardo Marketing Ltda", DataCadastro = DateTime.Now},
                new Empresa { Codigo="50", Cnpj="14.276.678/0001-06", RazaoSocial="Danilo e Henrique Publicidade e Propaganda Ltda", DataCadastro = DateTime.Now}
            };

            foreach (var item in empresas)
            {
                context.Empresas.Add(item);
            }

            context.SaveChanges();
        }
    }
}