using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14Demo
{
    internal class Person : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;

        // Создаем свойства полей
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(FullName));
            }
        }

        // Вычисляемое свойство (только для чтения)
        public string FullName => $"{_firstName} {_lastName}".Trim();

        // Метод (здесь событие) реализации интерфейса (ОБЯЗАТЕЛЬНО)
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// метод OnPropertyChanged(string propertyName) реализует принцип инкапсуляции
        /// </summary>
        /// <param name="propertyName"></param>

        public void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString() { return FullName; }
    }
}
