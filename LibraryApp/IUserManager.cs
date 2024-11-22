using System.Collections.Generic;

namespace LibraryApp
{
    public interface IUserManager
    {
        bool AddUser(UserAccount user);
        bool RemoveUser(string userID);
        UserAccount GetUser(string userID);
        List<UserAccount> GetAllUsers();
    }
}