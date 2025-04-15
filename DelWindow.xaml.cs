using System;
using System.Linq;
using System.Windows;
using Pract1_Florich_I223.DBMODEL12;

namespace Pract1_Florich_I223
{
    public partial class Window1 : Window
    {
        // Ссылка на окно DataGrid
        private DataGrid _dataGridWindow;

        public Window1(DataGrid dataGridWindow)
        {
            InitializeComponent();

            // Сохраняем ссылку на окно DataGrid
            _dataGridWindow = dataGridWindow;
        }

        // Обработчик кнопки для удаления последней записи
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new ShopDBEntities())
                {
                    // Получаем последнюю запись из таблицы Products
                    var lastProduct = context.Products.OrderByDescending(p => p.ProductID).FirstOrDefault();

                    if (lastProduct != null)
                    {
                        // Удаляем последнюю запись
                        context.Products.Remove(lastProduct);
                        context.SaveChanges();

                        // Обновляем DataGrid в основном окне
                        _dataGridWindow.RefreshDataGrid();

                        MessageBox.Show("Последняя запись успешно удалена.");
                    }
                    else
                    {
                        MessageBox.Show("Нет записей для удаления.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении записи: {ex.Message}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataGrid dataGridWindow = new DataGrid();

            // Открываем окно DataGrid
            dataGridWindow.Show();

            // Закрываем текущее окно AuthWindow
            this.Close();
        }
    }
}