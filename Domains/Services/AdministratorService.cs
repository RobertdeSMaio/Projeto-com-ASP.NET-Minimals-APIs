using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Domains.DTO;
using minimal_api.Domains.Interfaces;
using minimal_api.Structure.DB;
using minimal_api.Domains.Entities;

namespace minimal_api.Domains.Services
{
    public class AdministratorService : IAdminServices
    {
        private readonly DbContexto _contexto;
        public AdministratorService(DbContexto contexto)
        {
            _contexto = contexto;
        }
        
        public Administrator? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Admins.Where(a => a.Email == loginDTO.Email && a.Password == loginDTO.Password).FirstOrDefault();
            return adm;
        }
    }
}