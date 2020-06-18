using System;
using Foundation;
using UIKit;
using CoreGraphics;


namespace BasicTable {
	public class CustomVegeCell: UITableViewCell  {
		
		UILabel headingLabel, subheadingLabel;
		UIImageView imageView;
		UIScrollView imageScrollView;
		public CustomVegeCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			
			ContentView.BackgroundColor = UIColor.FromRGB (218, 255, 127);
			
			imageView = new UIImageView();

			headingLabel = new UILabel () {
				Font = UIFont.FromName("Cochin-BoldItalic", 22f),
				TextColor = UIColor.FromRGB (127, 51, 0),
				BackgroundColor = UIColor.Clear
			};
			
			subheadingLabel = new UILabel () {
				Font = UIFont.FromName("AmericanTypewriter", 12f),
				TextColor = UIColor.FromRGB (38, 127, 0),
				TextAlignment = UITextAlignment.Center,
				BackgroundColor = UIColor.Clear
			};


		    imageScrollView = new UIScrollView();
			imageScrollView.ClipsToBounds = false;
			imageScrollView.ContentSize = new CGSize(50, 56);
			imageScrollView.MaximumZoomScale = 8f;
			imageScrollView.MinimumZoomScale = 1f;
			imageScrollView.Add(imageView);
			imageScrollView.ViewForZoomingInScrollView += (UIScrollView sv) =>
			{
				imageScrollView.ContentSize = new CGSize(imageView.Frame.Width, imageView.Frame.Height);
				return imageView;
			};

			imageScrollView.DidZoom += (object sender, EventArgs e) =>
			{
				//(sender as UIView).Layer.ZPosition = 2000;
			};

			imageScrollView.ZoomingEnded += (object sender, ZoomingEndedEventArgs e) =>
			{
				(sender as UIScrollView).SetZoomScale(0f, true);
				(sender as UIView).Layer.ZPosition = 0;
				this.Layer.ZPosition = 0;
			};

			ContentView.Add (headingLabel);
			ContentView.Add (subheadingLabel);
			ContentView.Add (imageScrollView);
		}

		public void UpdateCell (string caption, string subtitle, UIImage image)
		{
			imageView.Image = image;
			headingLabel.Text = caption;
			subheadingLabel.Text = subtitle;
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			imageScrollView.Frame = new CGRect(ContentView.Bounds.Width - 233, 5, 133, 133);
			headingLabel.Frame = new CGRect(5, 4, ContentView.Bounds.Width - 63, 25);
			subheadingLabel.Frame = new CGRect(100, 18, 100, 20);
			imageView.Frame = imageScrollView.Bounds;

		}
	}
}

