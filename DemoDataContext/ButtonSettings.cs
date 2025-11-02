using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataContext
{
    public class ButtonSettings
    {
        public string ButtonText { get; set; } = "Нажми меня";
        public bool IsEnabled { get; set; } = true;
        public string ToolTipText { get; set; } = "Это кнопка";

    }
}
