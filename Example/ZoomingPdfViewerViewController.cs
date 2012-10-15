using MonoTouch.UIKit;
using System.Drawing;
using System;
using MonoTouch.Foundation;

namespace ZoomingPdfViewer
{
	public partial class ZoomingPdfViewerViewController : UIViewController
	{
		public ZoomingPdfViewerViewController (string documentName) : base ()
		{
			PdfScrollView view = new PdfScrollView (View.Bounds,documentName);
			View.AddSubview (view);
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			//any additional setup after loading the view, typically from a nib.
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Release any retained subviews of the main view.
			// e.g. myOutlet = null;
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}
