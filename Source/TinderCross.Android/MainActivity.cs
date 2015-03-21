using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TinderCross.Portable.ViewModel;
using Android.Graphics;
using System.Net;

namespace TinderCross.Android
{
	[Activity (Label = "TinderCross.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private MainViewModel mainViewModel;

		ImageView girlImageView;
		TextView nameTextView;
		TextView ageTextView;
		Button likedButton;
		Button nopeButton;

		protected override async void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Initialize controls
			girlImageView = FindViewById<ImageView> (Resource.Id.girlImageView);
			nameTextView = FindViewById<TextView> (Resource.Id.nameTextView);
			ageTextView = FindViewById<TextView> (Resource.Id.ageTextView);
			likedButton = FindViewById<Button> (Resource.Id.likedButton);
			nopeButton = FindViewById<Button> (Resource.Id.nopeButton);

			// Initialize ViewModel
			mainViewModel = new MainViewModel ("Balint (Android)");
			await mainViewModel.Initialize ();

			// Load and display current girl
			RefreshView ();

			// Set up event handlers for the Nope and Liked buttons
			nopeButton.Click += async delegate {
				var currentGirl = mainViewModel.GetCurrentGirl ();
				if (currentGirl != null) {
					await mainViewModel.AddLike (false);
					mainViewModel.MoveToNextGirl ();
					RefreshView ();
				}
			};

			likedButton.Click += async delegate {
				var currentGirl = mainViewModel.GetCurrentGirl ();
				if (currentGirl != null) {
					await mainViewModel.AddLike (true);
					mainViewModel.MoveToNextGirl ();
					RefreshView ();
				}
			};
		}

		private void RefreshView ()
		{
			var currentGirl = mainViewModel.GetCurrentGirl ();
			if (currentGirl != null) {
				girlImageView.SetImageBitmap (GetImageBitmapFromUrl (currentGirl.ImageUrl));
				nameTextView.Text = currentGirl.Name;
				ageTextView.Text = currentGirl.Age.ToString ();
			} else {
				girlImageView.Visibility = ViewStates.Invisible;
				nameTextView.Text = "Nincs több lány az adatbázisban";
				ageTextView.Text = "";
				nopeButton.Enabled = false;
				likedButton.Enabled = false;
			}
		}

		private Bitmap GetImageBitmapFromUrl (string url)
		{
			Bitmap imageBitmap = null;

			using (var webClient = new WebClient ()) {
				var imageBytes = webClient.DownloadData (url);
				if (imageBytes != null && imageBytes.Length > 0) {
					imageBitmap = BitmapFactory.DecodeByteArray (imageBytes, 0, imageBytes.Length);
				}
			}

			return imageBitmap;
		}
	}
}