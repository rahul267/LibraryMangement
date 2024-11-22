namespace LibraryApp
{
    public class UserAccount
    {
        public string UserID { get; set; }
        public string Name { get; set; }

        public UserAccount(string userID, string name)
        {
            UserID = userID;
            Name = name;
        }
    }
}