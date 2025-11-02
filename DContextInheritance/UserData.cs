using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DContextInheritance
{
    public class UserData
    {
        public string UserName { get; set; } = "Петр";  // Значение по умолчанию
        public string Role => "Пользователь";
    }
}
