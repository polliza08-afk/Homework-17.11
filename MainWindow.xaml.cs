using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using Bogus; //Підключаємо Bogus для генерації фейкових даних
using WpfMVVM.Models;

namespace WpfMVVM
{
    public partial class MainWindow : Window
    {
        //Колекція для автоматичного оновлення інтерфейсу
        private ObservableCollection<UserVM> users = new();

        public MainWindow()
        {
            InitializeComponent();
            dgvUsers.ItemsSource = users; //Прив'язка даних до таблиці

            GenerateInitialUsers(5); //Генерація 5 стартових користувачів
        }

        //Генерація випадкових користувачів через Bogus
        private void GenerateInitialUsers(int count)
        {
            var faker = new Faker<UserVM>("uk")
                .RuleFor(u => u.Id, f => f.IndexFaker + 1)
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber("+38 (0##) ###-##-##"))
                .RuleFor(u => u.Image, f => $"https://i.pravatar.cc/300?img={f.Random.Number(1, 70)}");

            foreach (var user in faker.Generate(count))
            {
                users.Add(user);
            }
        }

        //Додавання нового випадкового користувача по кліку
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            var faker = new Faker<UserVM>("uk")
                .RuleFor(u => u.Id, f => users.Count + 1)
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber("+38 (0##) ###-##-##"))
                .RuleFor(u => u.Image, f => $"https://i.pravatar.cc/300?img={f.Random.Number(1, 70)}");

            users.Add(faker.Generate());
        }
    }
}