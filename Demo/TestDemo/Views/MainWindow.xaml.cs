using Microsoft.EntityFrameworkCore;

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TestDemo.Data;
using TestDemo.Models;

namespace TestDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<PartnersImport> Partners { get; set; }
        private readonly AppDbContext _context = new();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            this.DataContext = this;
        }
        private void LoadData()
        {
            List<PartnersImport> partnersList = new();
            var partnerProducts = _context.PartnersImports.Include(p => p.PartnerProductsImports).ToList();

            foreach (var part in partnerProducts)
            {
                partnersList.Add(new PartnersImport
                {
                    PartnerPhone = part.PartnerPhone,
                    PartnerName = part.PartnerName,
                    Director = part.Director,
                    Rating = part.Rating,
                    PartnerType = part.PartnerType,
                    Discount = CalculateDiscount(part.PartnerProductsImports.Select(p => p.QuantityOfProducts).Sum())
                });
            }
            Partners = partnersList;
        }

        private int CalculateDiscount(int sales)
        {
            int result;
            switch (sales)
            {
                case < 10000: result = 0;
                    break;
                case < 50000: result = 5;
                    break;
                case < 300_000: result = 10;
                    break;
                case > 300_000: result = 15;
                    break;
                default: result = 0;
                    break;
            }
            return result;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}