using System;
using System.Linq;
using System.Windows;
using Pract1_Florich_I223.DBMODEL12;

namespace Pract1_Florich_I223
{
    public partial class DataGrid : Window
    {
        // Контекст базы данных
        private ShopDBEntities _dbContext;

        public DataGrid()
        {
            InitializeComponent();

            // Инициализация контекста базы данных
            _dbContext = new ShopDBEntities();

            // Загрузка данных из таблицы Products
            LoadProducts();
        }

        // Метод для загрузки данных из таблицы Products
        private void LoadProducts()
        {
            try
            {
                // Получаем данные из таблицы Products
                var products = _dbContext.Products.ToList();

                // Привязываем данные к DataGrid
                ProductsDataGrid.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        // Метод для обновления данных в DataGrid
        public void RefreshDataGrid()
        {
            LoadProducts();
        }

        // Обработчик кнопки ADD
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр MainWindow
            MainWindow mainWindow = new MainWindow();

            // Открываем MainWindow
            mainWindow.Show();

            // Закрываем текущее окно DataGrid
            this.Close();
        }

        // Обработчик кнопки для перехода к окну DelWindow
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 delwindow = new Window1(this); // Передаем текущее окно DataGrid в DelWindow
            delwindow.Show();
            this.Close();
        }
    }
}