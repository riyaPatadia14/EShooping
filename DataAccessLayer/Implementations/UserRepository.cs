using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using DataAccessLayer.Models.UserSet;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Implementations
{
    public class UserRepository : IUser
    {
        private readonly EShoppingDbContext _eShoppingDbContext;
        public UserRepository(EShoppingDbContext eShoppingDbContext)
        {
            _eShoppingDbContext= eShoppingDbContext;
        }

        public UsersModel GetUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
