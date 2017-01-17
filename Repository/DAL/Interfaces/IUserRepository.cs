using Microsoft.Owin.Security;
using Repository.POCO;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        bool UserIsInRole(string userName, string roleName);
        OperationResult CreateUser(string userName, string password, IAuthenticationManager authManager);
        OperationResult LoginUser(string userName, string password, IAuthenticationManager authManager);
    }
}