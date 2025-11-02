using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataContext
{
    public class Person : INotifyPropertyChanged
    {
        private string _name;
        private int _age;
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public int Age { get => _age; set { _age = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
