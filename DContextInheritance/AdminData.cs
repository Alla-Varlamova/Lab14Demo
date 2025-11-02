using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DContextInheritance
{
    public class AdminData
    {
        public string AdminName { get; set; } = "Администратор";  // Значение по умолчанию
        public string Role => "Админ";
    }
}
