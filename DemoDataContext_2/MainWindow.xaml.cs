using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoDataContext_2
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class LocalizedTexts
    {
        public string WelcomeMessage => "Добро пожаловать в приложение!";
        public string SaveButton => "Сохранить";
        public string CancelButton => "Отмена";
    }
    class UserInfo
    {
        public string Name { get; set; } = "Алексей";
        public string Email { get; set; } = "alex@example.com";
    }

    class AppSettings
    {
        public string Theme { get; set; } = "Темная";
        public string Language { get; set; } = "Русский";
    }
    public class ButtonSettings
    {
        public string ButtonText { get; set; } = "Нажми меня";
        public bool IsEnabled { get; set; } = true;
        public string ToolTipText { get; set; } = "Это кнопка";
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Person _person;
        public ObservableCollection<string> Items { get; set; }
        public LocalizedTexts Texts { get; } = new LocalizedTexts();

        public MainWindow()
        {
            InitializeComponent();
            // 1 ---
            _person = new Person { Name = "Иван Иванов", Age = 25 };
            // Устанавливаем DataContext для всего окна
            tbFName.DataContext = _person;
            tbAge.DataContext = _person;
            // 2 ---
            // this.DataContext = new LocalizedTexts();
            // 3 ---
            Items = new ObservableCollection<string>
            {
                "Элемент 1", "Элемент 2", "Элемент 3"
            };
            this.DataContext = this; // DataContext указывает на само окно
            // 4 ---
            userPanel.DataContext = new UserInfo();
            settingsPanel.DataContext = new AppSettings();
            //--5
            anyButton.DataContext = new ButtonSettings();

        }   //  MainWindow

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            Items.Add($"Элемент {Items.Count + 1}");
        }

        private void AnyButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем кнопку, которая вызвала событие
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // Получаем DataContext кнопки (наши настройки)
                ButtonSettings settings = clickedButton.DataContext as ButtonSettings;

                if (settings != null)
                {
                    // Используем данные из DataContext

                    string message = $"Кнопка была нажата!\n" +
                       $"Текст кнопки: {settings.ButtonText}\n" +
                       $"Состояние: {(settings.IsEnabled ? "Активна" : "Неактивна")}\n" +
                       $"Подсказка: {settings.ToolTipText}";

                    MessageBox.Show(message, "Информация о кнопке", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Можем изменить настройки (интерфейс обновится автоматически)
                    settings.ButtonText = "Уже нажата!";
                    settings.IsEnabled = false;
                    settings.ToolTipText = "Кнопка уже была нажата";
                }
            }
        }

        private void ChangeDataButton_Click(object sender, RoutedEventArgs e)
        {
            // Изменяем данные - интерфейс автоматически обновится
            _person.Name = "Петр Петров";
            _person.Age = 30;
            MessageBox.Show("Данные изменены!\n" + "нажми кнопку <<Показать данные>>", 
                "Информация о человеке", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowDataButton_Click(object sender, RoutedEventArgs e)
        {
            // Данные автоматически синхронизировались через привязку
            MessageBox.Show($"Имя: {_person.Name}, Возраст: {_person.Age}");
        }
    }   //  MainWindow : Window
}   //  DemoDataContext_2
