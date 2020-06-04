using System;
using System.Linq;
namespace DAL.RoleUserManager
{
    public class RoleRepository : Repository<Models.Role>, IRoleRepository
    {

       
        public RoleRepository(Models.DatabaseContext databaseContext) : base(databaseContext)
        {
            
        }

        
    }
}
