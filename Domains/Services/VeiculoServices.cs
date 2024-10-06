using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using minimal_api.Domains.Entities;
using minimal_api.Domains.Interfaces;
using minimal_api.Structure.DB;

namespace minimal_api.Domains.Services
{
    public class VeiculoServices : IVeiculoServices
    {
        private readonly DbContexto _contexto;
        public VeiculoServices(DbContexto contexto)
        {
            _contexto = contexto;
        }
        public void Apagar(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
        }

        public void Atualizar(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public Veiculo? BuscaPorID(int id)
        {
            return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
        }

        public void Incluir(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public List<Veiculo> Todos(int pagina, string nome = null, string marca = null)
        {
            var query = _contexto.Veiculos.AsQueryable();
            if(!string.IsNullOrEmpty(nome))
            {
                query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome.ToLower()}%"));
            }

            int itensPorPagina = 10;

            query = query.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina);

            return query.ToList();
        }
    }
}