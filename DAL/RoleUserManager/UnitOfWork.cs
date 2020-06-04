using System.Linq;
namespace DAL.RoleUserManager
{
    public class UnitOfWork: object, IUnitOfWork
    {
        //**************************************************************
        protected Models.DatabaseContext DatabaseContext { get; set; }
        public UnitOfWork(Models.DatabaseContext databaseContext)
        {
            if (databaseContext==null)
            {
                databaseContext = new Models.DatabaseContext();
            }

            DatabaseContext = databaseContext;
        }
        //**************************************************************

        //**************************roleRepository************************************
        private IRoleRepository roleRepository;

        public IRoleRepository RoleRepository
        {
            get
            {
                if (roleRepository == null)
                {
                    roleRepository = new RoleRepository(DatabaseContext);
                }

                return (roleRepository);
            }
        }
        //************************************************************** 

        //**************************userRepository************************************
        private IUserRepository userRepository;

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(DatabaseContext);
                }

                return (userRepository);
            }
        }

        //************************************************************** 
        //**************************************************************
        //private IRepository repository;

        //public IRepository Repository
        //{
        //    get 
        //    {
        //        if (repository==null)
        //        {
        //            repository = new Repository(DatabaseContext);
        //        }

        //        return (repository);
        //    }
        //}
        //************************************************************** 
    }
}
