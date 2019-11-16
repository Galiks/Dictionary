using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDao : IUserDao
    {
        public string[] GetUsers()
        {
            return Directory.GetFiles(@"Users/", "*.txt");
        }
    }
}
