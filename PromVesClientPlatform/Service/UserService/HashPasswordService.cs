using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromVesClientPlatform.Service.UserService
{
    public class HashPasswordService
    {
        //получаем хеш пароля
        public string getHashPasswordUser(string passwordUser)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(passwordUser);
            return hash;
        }
        //проверка пароля на соотвествие хэша
        public bool passwordСheck(string password, string hashPassword)
        {
            bool ok = BCrypt.Net.BCrypt.Verify(
            password,
            hashPassword);
            return ok;
        }
    }
}
