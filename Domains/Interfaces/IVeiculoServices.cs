using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Domains.DTO;
using minimal_api.Domains.Entities;

namespace minimal_api.Domains.Interfaces
{
    public interface IVeiculoServices
    {
        List<Veiculo> Todos(int pagina, string? nome = null, string? marca = null);
        Veiculo? BuscaPorID(int id);
        void Incluir(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        void Apagar(Veiculo veiculo);
    }
}