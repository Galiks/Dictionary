namespace BusinessLogicLayer
{
    public interface ILoginLogic
    {
        string CutOffFileName(string word);
        bool IsConfirmLogin(string enteredLogin, string enteredPassword);
    }
}