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
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Interop;

namespace SQLLoginSetProfilePicture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int loggedIn { get; set; }

        public int UserID { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ImageSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();


            if (loginWindow.loginFlag == false)
            {
                System.Windows.Application.Current.Shutdown();
            }

            UserName.Content = loginWindow.userName;

            DataSet1TableAdapters.ImageTableTableAdapter imgada = new DataSet1TableAdapters.ImageTableTableAdapter();

            DataTable dataTable = imgada.GetImageData(loginWindow.userName);

            foreach(DataRow rows in dataTable.Rows)
            {
                ImageSelector.Items.Add(rows["EntryNumber"].ToString());
            }

            if (dataTable.Rows.Count > 0)
            {
                DataRow pictureRow = dataTable.Rows[0];
                if (pictureRow[2] != System.DBNull.Value)
                {
                    byte[] imageData = (byte[])pictureRow[2];
                    System.Drawing.Image imageFromBinary = ConvertBinaryToImage(imageData);
                    var bitmap = new System.Drawing.Bitmap(imageFromBinary);
                    var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    bitmap.Dispose();
                    var brush = new ImageBrush(bitmapSource);
                    ImageCircle.Fill = brush;
                    Upload.IsEnabled = false;
                }
                else
                {
                    ImageCircle.Fill = null;
                }
            }
        }

        System.Drawing.Image ConvertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        byte[] ConvertImageToBinary(System.Drawing.Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}
