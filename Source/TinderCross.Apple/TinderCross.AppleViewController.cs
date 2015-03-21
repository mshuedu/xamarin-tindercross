using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TinderCross.Portable.ViewModel;

namespace TinderCross.Apple
{
    public partial class TinderCrossAppleViewController : UIViewController
    {
        MainViewModel mainViewModel;

        public TinderCrossAppleViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            mainViewModel = new MainViewModel("Balint (iPhone)");
            await mainViewModel.Initialize();

            LikedUIButton.TouchUpInside += LikedUIButton_TouchUpInside;
            NopeUIButton.TouchUpInside += NopeUIButton_TouchUpInside;

            RefreshView();
        }

        private void RefreshView()
        {
            var currentGirl = mainViewModel.GetCurrentGirl();
            if (currentGirl != null)
            {
                GirlImageView.Image = FromUrl(currentGirl.ImageUrl);
                NameLabel.Text = currentGirl.Name;
                AgeLabel.Text = currentGirl.Age.ToString();
            }
            else
            {
                GirlImageView.Image= null;
                NameLabel.Text = "Nincs több lány az adatbázisban";
                AgeLabel.Text = "";
                NopeUIButton.Enabled = false;
                LikedUIButton.Enabled = false;
            }
        }

        private UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }

        private async void LikedUIButton_TouchUpInside(object sender, EventArgs e)
        {
            var currentGirl = mainViewModel.GetCurrentGirl();
            if (currentGirl != null)
            {
                await mainViewModel.AddLike(true);
                mainViewModel.MoveToNextGirl();
                RefreshView();
            }
        }

        private async void NopeUIButton_TouchUpInside(object sender, EventArgs e)
        {
            var currentGirl = mainViewModel.GetCurrentGirl();
            if (currentGirl != null)
            {
                await mainViewModel.AddLike(false);
                mainViewModel.MoveToNextGirl();
                RefreshView();
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}