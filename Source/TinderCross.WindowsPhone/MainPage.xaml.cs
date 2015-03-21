using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TinderCross.Portable.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace TinderCross.WindowsPhone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainViewModel mainViewModel;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            mainViewModel = new MainViewModel("Balint (Windows Phone)");
            await mainViewModel.Initialize();

            RefreshView();
        }

        private void RefreshView()
        {
            var currentGirl = mainViewModel.GetCurrentGirl();
            if (currentGirl != null)
            {
                GirlImage.Source = new BitmapImage(new Uri(currentGirl.ImageUrl));
                NameTextBlock.Text = currentGirl.Name;
                AgeTextBlock.Text = currentGirl.Age.ToString();
            }
            else
            {
                GirlImage.Source = null;
                NameTextBlock.Text = "Nincs több lány az adatbázisban";
                AgeTextBlock.Text = "";
                NopeButton.IsEnabled = false;
                LikedButton.IsEnabled = false;
            }
        }

        private async void NopeButton_Click(object sender, RoutedEventArgs e)
        {
            var currentGirl = mainViewModel.GetCurrentGirl();
            if (currentGirl != null)
            {
                await mainViewModel.AddLike(false);
                mainViewModel.MoveToNextGirl();
                RefreshView();
            }
        }

        private async void LikedButton_Click(object sender, RoutedEventArgs e)
        {
            var currentGirl = mainViewModel.GetCurrentGirl();
            if (currentGirl != null)
            {
                await mainViewModel.AddLike(true);
                mainViewModel.MoveToNextGirl();
                RefreshView();
            }
        }
    }
}
