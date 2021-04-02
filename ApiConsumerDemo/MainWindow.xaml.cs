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
using DemoLibrary;

namespace ApiConsumerDemo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int MaxNumber { get; set; } = 0;
        public int CurrentNumber { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            nextImageButton.IsEnabled = false;
        }

        private async Task LoadImage(int imageNumber = 0)
        {
            var comic = await ComicProcessor.LoadComic(imageNumber);

            if (imageNumber == 0)
                MaxNumber = comic.Num;

            CurrentNumber = comic.Num;

            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            comicImage.Source = new BitmapImage(uriSource);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImage();
        }

        private async void previousImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentNumber > 1)
            {
                CurrentNumber -= 1;
                nextImageButton.IsEnabled = true;
                await LoadImage(CurrentNumber);

                if (CurrentNumber == 1)
                    previousImageButton.IsEnabled = false;
            }
        }

        private async void nextImageButton_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentNumber < MaxNumber)
            {
                CurrentNumber += 1;
                previousImageButton.IsEnabled = true;
                await LoadImage(CurrentNumber);

                if (CurrentNumber == MaxNumber)
                    nextImageButton.IsEnabled = false;
            }
        }

        private void sunInformationButton_Click(object sender, RoutedEventArgs e)
        {
            SunInfo sunInfo = new SunInfo();
            sunInfo.Show();
        }
    }
}
