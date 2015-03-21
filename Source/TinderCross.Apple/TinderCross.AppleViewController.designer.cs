// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace TinderCross.Apple
{
	[Register ("TinderCrossAppleViewController")]
	partial class TinderCrossAppleViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel AgeLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView GirlImageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton LikedUIButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel NameLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton NopeUIButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AgeLabel != null) {
				AgeLabel.Dispose ();
				AgeLabel = null;
			}
			if (GirlImageView != null) {
				GirlImageView.Dispose ();
				GirlImageView = null;
			}
			if (LikedUIButton != null) {
				LikedUIButton.Dispose ();
				LikedUIButton = null;
			}
			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}
			if (NopeUIButton != null) {
				NopeUIButton.Dispose ();
				NopeUIButton = null;
			}
		}
	}
}
