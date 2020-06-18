using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESHNETWORK.Classes
{
    /// <summary>
    /// Класс для хранения настроек пользователя
    /// </summary>
    public class Config
    {
        #region Цвета
        public string ColorBackGround { get; set; }
        public string ColorKnot { get; set; }
        public string ColorSource { get; set; }
        public string ColorTarget { get; set; }
        public string ColorSelect { get; set; }
        #endregion

        #region Авторизация
        public string Login { get; set; }
        public string Password { get; set; } 
        #endregion

        public Config() 
        {
             ColorBackGround = "#FFFFFFFF";
             ColorKnot = "#FF5491A8";
             ColorSource = "#FF62B462";
             ColorTarget = "#FFC75252";
             ColorSelect = "#FF5272C7";
             FillConfigAutorization();
        }

        public void SaveAutorization(string Login, string Password) 
        {
            File.WriteAllText(@"SaveConfig\login.txt", Login);
            File.WriteAllText(@"SaveConfig\password.txt", Password);
        }

        private void FillConfigAutorization() 
        {
            Login = File.ReadAllText(@"SaveConfig\login.txt");
            Password = File.ReadAllText(@"SaveConfig\password.txt");
        }
    }
}
