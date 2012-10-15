using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;


namespace Example
{
	public partial class BriefCaseViewController : UIViewController
	{

		public UITableView tableview;
		public List<TableItem> list;
		public UINavigationController nav; 


		public BriefCaseViewController (UINavigationController _nav) : base ("BriefCaseViewController", null)
		{
			this.nav = _nav;

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

			list = new List<TableItem> () {  }; 
			var path = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);

			DirectoryInfo dr = new DirectoryInfo(path);
			FileInfo [] f  =  new FileInfo [10];

			f = dr.GetFiles();

			foreach (var file in f) {
				TableItem t = new TableItem();
				t.Heading = file.Name;
			//	t.SubHeading = file.FullName;
				t.ImageName = @"\Images\Icons\114_icon.png";

				list.Add(t);
			}

			tableview = new UITableView();
			tableview.Source = new TableSource(list);
			tableview.AutoresizingMask = UIViewAutoresizing.FlexibleHeight|UIViewAutoresizing.FlexibleWidth;



			// Set the table view to fit the width of the app.
			
			tableview.SizeToFit();
			// Reposition and resize the receiver
			
			tableview.Frame = new RectangleF (
				
				0, 0, this.View.Frame.Width,
				
				this.View.Frame.Height);
			
			// Add the table view as a subview
			
			this.View.AddSubview(tableview);
			
			Console.Write("If you're using the simulator, ");
			Console.WriteLine("switch to it now.");

		}
			// Perform any additional setup after loading the view, typically from a nib.
	
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
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

