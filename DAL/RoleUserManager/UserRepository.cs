using System;
using System.Data.Entity;
using System.Linq;
namespace DAL.RoleUserManager
{
    public class UserRepository :Repository<Models.User>, IUserRepository
    {
        
        public UserRepository(Models.DatabaseContext databaseContext) : base(databaseContext)
        {
            
        }
       
    }
}
