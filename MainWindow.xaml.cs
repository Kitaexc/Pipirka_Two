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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pipirka_Two
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private UNLV_STOREEntities context = new UNLV_STOREEntities();
        public MainWindow()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            var orderDetails = from o in context.Orders
                               join c in context.Clients on o.ID_Client equals c.ID_Client
                               join ct in context.ClientTags on c.ID_Tag equals ct.ID_Tag
                               join p in context.Products on o.ID_Product equals p.ID_Product
                               join pt in context.ProductTypes on p.ID_ProductType equals pt.ID_ProductType
                               select new OrderDetail 
                               {
                                   OrderId = o.ID_Order,
                                   ClientName = c.ClientName,
                                   ClientSurName = c.ClientSurName,
                                   TagName = ct.TagName,
                                   ClientNumberPhone = c.ClientNumberPhone,
                                   ProductType = pt.PrType,
                                   ProductName = p.ProductName,
                                   ProductPrice = p.ProductPrice,
                                   OrderDate = o.OrderDate,
                                   Quantity = o.Quantity,
                                   TotalPrice = o.TotalPrice
                               };

            FullTable.ItemsSource = orderDetails.ToList();
        }
    }
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public string ClientName { get; set; }
        public string ClientSurName { get; set; }
        public string TagName { get; set; }
        public string ClientNumberPhone { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
