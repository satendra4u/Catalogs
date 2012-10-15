using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace Example
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		RootElement _root;
		public UINavigationController _nav;
		DialogViewController _dvc;
		UIAlertView alert;
		public RectangleF _bounds;
		public UIImageView myAnimatedView; 
		public List<UIImage> myImages;

		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);


			myImages = new List<UIImage> ();
			
			
			myImages.Add (UIImage.FromFile ("Images/Icon-72.png"));
			myImages.Add (UIImage.FromFile ("Images/Icon.png"));
			myImages.Add (UIImage.FromFile ("Images/Icon-72.png"));
			
			myImages.Add (UIImage.FromFile ("Images/Icon-72.png"));
			
			
			_bounds = new RectangleF (140, 140, 140, 140);
			
			myAnimatedView = new UIImageView (_bounds);
			
			myAnimatedView.AnimationImages = myImages.ToArray();
			
			
			if (myImages.Count > 0) {
				
				Console.WriteLine (myImages.Count);
				
				myAnimatedView.AnimationDuration = 6.75; // Seconds
				
				myAnimatedView.AnimationRepeatCount = 0; // 0 = Loops 
				
				myAnimatedView.StartAnimating();
				
			}


			_root = new RootElement("Littelfuse")
			{
				new Section(""){},
				new Section (myAnimatedView){},
				new Section("Catalogs")
				{
					new StyledStringElement("Electronics", delegate {

						CatalogsViewController _web = new CatalogsViewController(_nav,"Electronics");
					
						_nav.PushViewController(_web,true);

						window.RootViewController = _nav;

						/*alert = new UIAlertView();

						alert.AddButton("Ok"); 
						alert.AddButton("Maybe"); 
						alert.AddButton("No"); 
						alert.Message = "This could explode the moon"; 
						alert.Delegate = new MyAlertViewDelegate(); 
						alert.Show(); 
						*/
					}),
					new StyledStringElement("Electrical",delegate {
						CatalogsViewController _web = new CatalogsViewController(_nav,"Electrical");						
						_nav.PushViewController(_web,true);						
						window.RootViewController = _nav;
					}),
					
					new StyledStringElement("AutoMotive",delegate {
						CatalogsViewController _web = new CatalogsViewController(_nav,"AutoMotive");						
						_nav.PushViewController(_web,true);						
						window.RootViewController = _nav;
					}),

					new StyledStringElement("Check Briefcase",delegate {
						BriefCaseViewController _briefcase = new BriefCaseViewController(_nav);
						_nav.PushViewController(_briefcase,true);
						window.RootViewController = _nav;
					})

					

				}
			};
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);


			// make the window visible
			_dvc = new DialogViewController(_root);
			_nav = new UINavigationController(_dvc);

			window.RootViewController = _nav;
			window.MakeKeyAndVisible ();
			
			return true;
		}

		public string ElectronicsSelected()
		{
			return "Satya !!!";		
		
		}
	}
}

