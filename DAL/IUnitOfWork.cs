using System.Linq;
namespace DAL
{
    public interface IUnitOfWork
    {
        RoleUserManager.IUnitOfWork RoleUserManagerUnitOfWork { get; }
    }
}
