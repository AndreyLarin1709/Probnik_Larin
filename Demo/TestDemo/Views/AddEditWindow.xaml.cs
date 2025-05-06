using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

using TestDemo.Data;
using TestDemo.Models;

namespace TestDemo.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private readonly AppDbContext _context = new();
        private PartnersImport _partnerDTO;

        public AddEditWindow()
        {
            InitializeComponent();
            LoadTypes();
            Title = "Добавление партнера";
        }

        public AddEditWindow(PartnersImport partnerDTO)
        {
            InitializeComponent();
            LoadTypes();
            FillFields(partnerDTO);
            add.Content = "Изменить";
            this.Title = "Изменение партнера";
            _partnerDTO = partnerDTO;
        }

        private void FillFields(PartnersImport partnerDTO)
        {
            name.Text = partnerDTO.Name;
            rating.Text = partnerDTO.Rating.ToString();
            adress.Text = partnerDTO.Address;
            directorName.Text = partnerDTO.Position;
            phoneNumber.Text = partnerDTO.Phone;
            email.Text = partnerDTO.Email;
            var allTypes = type.ItemsSource as List<PartnerTypeImport>;
            type.SelectedItem = allTypes.Where(t => t.Title == partnerDTO.Type).FirstOrDefault();

        }

        private void LoadTypes()
        {
            // Загружаем список типов партнёров
            type.ItemsSource = _context.PartnerTypeImports.ToList();
            type.SelectedIndex = 0;
        }

        private void AddOrEditPartner(object sender, RoutedEventArgs e)
        {
            // Простейшая валидация: убедимся, что выбрали тип и ввели обязательные поля
            if (type.SelectedItem is not PartnerTypeImport selectedType)
            {
                MessageBox.Show("Пожалуйста, выберите тип партнёра.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ValidateString("Наименование организации", name.Text) ||
                !ValidateRating(rating.Text) ||
                !ValidateString("Адрес", adress.Text) ||
                !ValidateName(directorName.Text) ||
                !ValidatePhone(phoneNumber.Text) ||
                !ValidateEmail(email.Text))
            {

                return;
            }

            try
            {
                // Создаём новую сущность партнёра
                var newPartner = new PartnersImport
                {

                    Title = name.Text.Trim(),
                    PartnerTypeId = selectedType.PartnerTypeId,
                    Rating = int.Parse(rating.Text),
                    AddressPartner = adress.Text.Trim(),
                    Director = directorName.Text.Trim(),
                    PhonePartner = phoneNumber.Text.Trim(),
                    EmailPartner = string.IsNullOrWhiteSpace(email.Text) ? null : email.Text.Trim()
                };
                if (_partnerDTO != null)
                {


                    var partner = _context.PartnersImports.Where(p => p.PartnerId == _partnerDTO.Id).FirstOrDefault();
                    if (partner != null)
                    {
                        partner.PartnerId = _partnerDTO.Id;
                        partner.AddressPartner = adress.Text.Trim();
                        partner.Director = directorName.Text;
                        partner.PhonePartner = phoneNumber.Text;
                        partner.Title = name.Text.Trim();
                        partner.PartnerTypeId = selectedType.PartnerTypeId;
                        partner.EmailPartner = email.Text.Trim();
                        _context.PartnersImports.Update(partner);
                        _context.SaveChanges();

                        MessageBox.Show("Партнёр успешно обновлен.", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    newPartner.PartnerId = _context.PartnersImports.Count() + 2;
                    _context.PartnersImports.Add(newPartner);
                    _context.SaveChanges();
                    MessageBox.Show("Партнёр успешно обновлен.", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                // Закрываем окно
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
