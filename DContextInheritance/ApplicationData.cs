using DContextInheritance.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DContextInheritance
{
    public class ApplicationData
    {
        public User CurrentUser { get; } = new User { Name = "Мария" };
        public Settings AppSettings { get; } = new Settings { Theme = "Темная" };

    }
}
