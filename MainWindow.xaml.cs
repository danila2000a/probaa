﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Pract1_Florich_I223.DBMODEL12;

namespace Pract1_Florich_I223
{
    public partial class MainWindow : Window
    {
        private ShopDBEntities dbContext;

        public MainWindow()
        {
            InitializeComponent();
            dbContext = new ShopDBEntities();
            LoadProducts();
        }

        private void LoadProducts()
        {
            
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string productName = NameTextBox.Text;
                if (string.IsNullOrEmpty(productName))
                {
                    MessageBox.Show("Введите название товара.");
                    return;
                }

                if (!decimal.TryParse(PriceTextBox.Text, out decimal productPrice))
                {
                    MessageBox.Show("Введите корректную цену товара.");
                    return;
                }

                string productDescription = DescriptionTextBox.Text;

                var newProduct = new Products
                {
                    ProductName = productName,
                    Price = productPrice,
                    Description = productDescription
                };

                dbContext.Products.Add(newProduct);
                dbContext.SaveChanges();

                LoadProducts(); // Обновляем ListBox
                NameTextBox.Clear();
                PriceTextBox.Clear();
                DescriptionTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр окна DataGrid
            DataGrid dataGridWindow = new DataGrid();

            // Открываем окно DataGrid
            dataGridWindow.Show();

            // Закрываем текущее окно AuthWindow
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Логика для кнопки "Авторизация"
            MessageBox.Show("Авторизация");
        }
    }
}