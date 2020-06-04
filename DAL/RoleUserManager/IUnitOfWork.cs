using System.Linq;
namespace DAL.RoleUserManager
{
    public interface IUnitOfWork
    {
        IRoleRepository RoleRepository { get;}
        IUserRepository UserRepository { get; }
    }
}
