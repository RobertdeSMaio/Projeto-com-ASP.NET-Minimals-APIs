using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Domains.DTO;
using minimal_api.Domains.Entities;

namespace minimal_api.Domains.Interfaces
{
    public interface IAdminServices
    {
        Administrator? Login(LoginDTO loginDTO);
    }
}