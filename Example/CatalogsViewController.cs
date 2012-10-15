using System.Collections.Generic;
using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;


namespace Example
{
	public partial class CatalogsViewController : UIViewController 
	{


		public UITableView tableview;
		public List<TableItem> list;
		public UINavigationController nav; 
		public string _businessUnit;
	
	

		public CatalogsViewController (UINavigationController _nav, string businessUnit) : base ("CatalogsViewController", null)
		{
			this.nav = _nav;
			this._businessUnit = _businessUnit;
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
			list = new List<TableItem> ();

			for (int i = 0; i < 10; i++) {
				TableItem t = new TableItem();

				if (i == 0)
				{
					if (_businessUnit == "Electronics")
					{
						t.Heading="Electronics Circuit Protection Product Selection Guide (2.3 Mb)";
						t.SubHeading = "Littelfuse_Product_Selection_Guide.pdf";
					}
					else if (_businessUnit == "Electrical")
					{
						t.Heading="Electronics Circuit Protection Product Selection Guide (2.3 Mb)";
						t.SubHeading = "Littelfuse_Product_Selection_Guide.pdf";
					}
					else
					{
						t.Heading="Electronics Circuit Protection Product Selection Guide (2.3 Mb)";
						t.SubHeading = "Littelfuse_Product_Selection_Guide.pdf";

					}
					list.Add(t);
				}

				if (i==1)
				{
					if (_businessUnit == "Electronics")
					{
						t.Heading="Automotive OEM Product Catalog (1.8 Mb)";
						t.SubHeading="OE101.pdf";
					}else if (_businessUnit == "Electrical")
					{
						t.Heading="Automotive OEM Product Catalog (1.8 Mb)";
						t.SubHeading="OE101.pdf";
					}
					else
					{
						t.Heading="Automotive OEM Product Catalog (1.8 Mb)";
						t.SubHeading="OE101.pdf";
					}

					list.Add(t);
				}

				if(i==2)
				{
					

					t.Heading= "Electronic_Fuse_Products_Catalog (9.1 Mb)";
					t.SubHeading = "Littelfuse_Electronic_Fuse_Products_Catalog.pdf";
					list.Add(t);
				}

				
				if(i==3)
				{
	
					t.Heading= "Littelfuse_TVS_Diode_Catalog (3.5 Mb)";
					t.SubHeading = "Littelfuse_TVS_Diode_Catalog.pdf";
					list.Add(t);
				}

			}

			tableview = new UITableView()
			{
	
				Delegate = new TableViewDelegate(list,nav),
			
				DataSource = new TableViewDataSource(list),
			
				AutoresizingMask = UIViewAutoresizing.FlexibleHeight|UIViewAutoresizing.FlexibleWidth

			};

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


			
			// Perform any additional setup after loading the view, typically from a nib.
		}


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

