using DataAccessLayer.Models.UserSet;
namespace DataAccessLayer.Interface
{
    public interface IUser
    {
        UsersModel GetUserById(int id);
    }
}
