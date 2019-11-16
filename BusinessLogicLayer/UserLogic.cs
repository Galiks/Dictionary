using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UserLogic : IUserLogic
    {
        private const string patternForLogin = @"Users\/(.+?)\.";
        private readonly IUserDao userDao;

        public UserLogic(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public string CutOffFileName(string word)//этот метод обрезает найденный файл в каталоге так, чтобы осталось только название
        {
            try
            {
                return Regex.Match(word, patternForLogin).Groups[1].ToString();
            }
            catch (Exception)
            {
                throw new Exception("Login не найден");
            }
        }

        public bool IsConfirmLogin(string enteredLogin, string enteredPassword)
        {
            string[] dirs = userDao.GetUsers();
            foreach (string dir in dirs)
            {
                bool isLogin = (enteredLogin == CutOffFileName(dir).Trim());
                if (isLogin)
                {
                    using (StreamReader reader = new StreamReader(dir))
                    {
                        string userPassword = reader.ReadToEnd();
                        if (enteredPassword == userPassword)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
