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

namespace DemoDataContext
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Person _person;
        public ObservableCollection<string> Items { get; set; }
        public LocalizedTexts LocalizedTexts { get; set; } = new LocalizedTexts();
        public ButtonSettings AnyButtonSettings { get; set; } = new ButtonSettings();
        public MainWindow()
        {
            InitializeComponent();
            // 1-- -
            _person = new Person { Name = "Иван Иванов", Age = 25 };
            // 2 ---
            //this.DataContext = new LocalizedTexts();
            // Устанавливаем DataContext для всего окна
            tbFName.DataContext = _person;
            tbAge.DataContext = _person;
            // 3 ---
            Items = new ObservableCollection<string>
            {
                "Элемент 1", "Элемент 2", "Элемент 3"
            };
            this.DataContext = this; // DataContext указывает на само окно
            // 4 ---
            userPanel.DataContext = new UserInfo();
            settingsPanel.DataContext = new AppSettings();
        }

        private void ShowDataButton_Click(object sender, RoutedEventArgs e)
        {
            // Данные автоматически синхронизировались через привязку
            MessageBox.Show($"Имя: {_person.Name}, Возраст: {_person.Age}");
        }

        private void ChangeDataButton_Click(object sender, RoutedEventArgs e)
        {
            // Изменяем данные - интерфейс автоматически обновится
            _person.Name = "Петр Петров";
            _person.Age = 30;
            MessageBox.Show("Данные изменены!\n" + "нажми кнопку <<Показать данные >> ", "Информация о человеке", MessageBoxButton.OK,
            MessageBoxImage.Information);
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
                    MessageBox.Show(message, "Информация о кнопке", MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    // Можем изменить настройки (интерфейс обновится автоматически)
                    settings.ButtonText = "Уже нажата!";
                    settings.IsEnabled = false;
                    settings.ToolTipText = "Кнопка уже была нажата";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данные сохранены!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
