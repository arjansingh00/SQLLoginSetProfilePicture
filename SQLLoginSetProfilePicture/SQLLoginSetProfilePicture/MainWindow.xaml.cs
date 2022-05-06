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
using Microsoft.Win32;

namespace SQLLoginSetProfilePicture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int loggedIn { get; set; }

        public int UserID { get; set; }

        public String userName { get; set; }

        public String ImageSelectorSelectedItem { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ImageSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataSet1TableAdapters.ImageTableTableAdapter imgada = new DataSet1TableAdapters.ImageTableTableAdapter();

            DataTable dataTable;

            try
            {
                dataTable = imgada.GetSingleImage(ImageSelector.SelectedItem.ToString());
            }
            catch(NullReferenceException)
            {
                dataTable = imgada.GetSingleImage(ImageSelectorSelectedItem);
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
                }
                else
                {
                    ImageCircle.Fill = null;
                }
            }
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            userName = loginWindow.userName;

            ImageSelector.SelectedIndex = 1;

            if (loginWindow.loginFlag == false)
            {
                System.Windows.Application.Current.Shutdown();
            }

            UserName.Content = userName;

            DataSet1TableAdapters.ImageTableTableAdapter imgada = new DataSet1TableAdapters.ImageTableTableAdapter();

            DataTable dataTable = imgada.GetImageData(userName);

            foreach(DataRow rows in dataTable.Rows)
            {
                ImageSelector.Items.Add(rows["FileName"].ToString());
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

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false };

            if(ofd.ShowDialog() == true)
            {
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(ofd.FileName));
                ImageCircle.Fill = brush;

                Bitmap image = new Bitmap(ofd.FileName);

                Byte[] imgData = ConvertImageToBinary(image);

                DataSet1TableAdapters.ImageTableTableAdapter imgUpload = new DataSet1TableAdapters.ImageTableTableAdapter();

                imgUpload.AddImage(userName, imgData, ofd.FileName);
                ImageSelector.Items.Add(ofd.FileName);
                ImageSelector.SelectedIndex = ImageSelector.Items.IndexOf(ofd.FileName);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false };

            if (ofd.ShowDialog() == true)
            {
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(ofd.FileName));
                ImageCircle.Fill = brush;

                Bitmap image = new Bitmap(ofd.FileName);

                Byte[] imgData = ConvertImageToBinary(image);

                DataSet1TableAdapters.ImageTableTableAdapter imgUpload = new DataSet1TableAdapters.ImageTableTableAdapter();

                imgUpload.UpdateImage(imgData, ImageSelector.SelectedItem.ToString());
                ImageSelector.Items[ImageSelector.SelectedIndex] = ofd.FileName;
                ImageSelectorSelectedItem = ofd.FileName;
                ImageSelector.SelectedIndex = ImageSelector.Items.IndexOf(ofd.FileName);
            }
        }
    }
}
