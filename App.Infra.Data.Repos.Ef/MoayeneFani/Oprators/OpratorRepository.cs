using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.MoayeneFani.Operators.Data.Repositories;
using App.Domain.Core.MoayeneFani.Operators.DTOs;
using App.Domain.Core.MoayeneFani.Users.DTOs;
using Connection;

namespace App.Infra.Data.Repos.Ef.MoayeneFani.Oprators
{
    public class OpratorRepository : IOpratorRepository
    {
        private readonly AppDbContext _dbContext;
        public OpratorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Login(string username, string password)
        {
            var Oprator=_dbContext.Oprators.FirstOrDefault(x=>x.UserName == username && x.Password == password);
            if (Oprator is not null)
            {
                if(OpratorDTO.CurrentOperator is null)
                {
                    if(UserDTO.CurrentUser is null)
                    {
                        OpratorDTO.CurrentOperator = Oprator;
                        return true;//این برنامه روی یک سیستم پیاده میشود پس در هر لحطه فقط یک کاربر یا اوپراتور لاکین است
                    }
                }
            }
            return false;
        }

        public bool Logout()
        {
            if(OpratorDTO.CurrentOperator == null)
            { 
                return false; 
            }
            else
            {
                OpratorDTO.CurrentOperator=null;
                return true;
            }
        }
    }
}
