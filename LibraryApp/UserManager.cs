using System.Collections.Generic;
using System.Linq;

namespace LibraryApp
{
    public class UserManager : IUserManager
    {
        private List<UserAccount> users = new List<UserAccount>();

        public bool AddUser(UserAccount user)
        {
            if (!users.Any(u => u.UserID == user.UserID))
            {
                users.Add(user);
                return true;
            }
            return false;
        }

        public bool RemoveUser(string userID)
        {
            var user = users.FirstOrDefault(u => u.UserID == userID);
            if (user != null)
            {
                users.Remove(user);
                return true;
            }
            return false;
        }

        public UserAccount GetUser(string userID)
        {
            return users.FirstOrDefault(u => u.UserID == userID);
        }

        public List<UserAccount> GetAllUsers()
        {
            return new List<UserAccount>(users);
        }
    }
}