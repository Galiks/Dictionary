namespace DataAccessLayer
{
    public interface IUserDao
    {
        string[] GetUsers();
        bool SaveGameResult();
    }
}