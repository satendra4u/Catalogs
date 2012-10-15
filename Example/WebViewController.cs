using System.IO;
using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Example
{
	public partial class WebViewController : UIViewController
	{
		public string docName;
		public UIActionSheet action;
		public List<string> list;
		public NSUrlRequest nsurlRequest;
		public NSUrl docUrl;
		public bool _flag = false;
		public string path;
		public string a, b;
		public UIActivityIndicatorView spinner; 

		public WebViewController (string documentName) : base ("WebViewController", null)
		{
			this.docName = documentName;
		

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

			spinner = new UIActivityIndicatorView(new RectangleF(0,0,200,300));
			spinner.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Gray;
			spinner.Center= new PointF(160, 120);
			spinner.HidesWhenStopped = true;
			this.View.AddSubview(spinner);
			InvokeOnMainThread(delegate() { 
				spinner.StartAnimating(); 
			}); 

			string path = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			string fileName; 
			DirectoryInfo dr = new DirectoryInfo (path);
			FileInfo [] f = new FileInfo [10];
			f = dr.GetFiles ();
			
			foreach (var item in f) {
				fileName = Path.Combine (path, item.ToString ());
				
				if (File.Exists (fileName) && (docName == item.ToString())) {
					docUrl = NSUrl.FromFilename (fileName);
					nsurlRequest = new NSUrlRequest (docUrl);
					_flag = true;
					break;
				}
				
			}

			if (!_flag) {
				
				docUrl = new NSUrl ("http://www.littelfuse.com/about-us/~/media/Files/Littelfuse/Technical%20Resources/Documents/Product%20Catalogs/Content/" + docName.ToString ());
				nsurlRequest = new NSUrlRequest (docUrl);
				UIBarButtonItem uiBar = new UIBarButtonItem(UIBarButtonSystemItem.Bookmarks,Activate_UIActionSheet);
				
				this.NavigationItem.RightBarButtonItem = uiBar;

				loadWebView.LoadRequest (nsurlRequest);

			} else {
				loadWebView.LoadRequest(nsurlRequest);
			}

			loadWebView.LoadFinished += delegate(object sender, EventArgs e) {
				spinner.StopAnimating();

			};
			// Perform any additional setup after loading the view, typically from a nib.
		}


		
		private void Activate_UIActionSheet (object sender, EventArgs e)
		{
			
			action = new UIActionSheet("Download File") { "Download", "Cancel" };
			action.Frame = new RectangleF(0,0,400,700);
			action.CancelButtonIndex = 1;
			action.AutoresizingMask =  UIViewAutoresizing.FlexibleWidth|UIViewAutoresizing.FlexibleHeight|UIViewAutoresizing.FlexibleTopMargin|UIViewAutoresizing.FlexibleRightMargin|UIViewAutoresizing.FlexibleLeftMargin|UIViewAutoresizing.FlexibleBottomMargin;
			action.ShowInView(this.View);

			action.Delegate = new MyActionSheetViewDelegate(docName.ToString(),docUrl,this); 

		}

		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			spinner = null;
			action= null;
			nsurlRequest = null;
			loadWebView = null;
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

