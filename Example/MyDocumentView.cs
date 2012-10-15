using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;
using System;
namespace Example
{
	public class MyDocumentView : UIViewController
	{
		UIButton myBtn;

		public MyDocumentView () : base()
		{
			View.Frame = new RectangleF(0,0,1024,768);
			
			var myRect = new RectangleF(300,300,100,50);
			
			myBtn = UIButton.FromType(UIButtonType.RoundedRect);
			myBtn.Frame = myRect;
			myBtn.TouchUpInside += delegate
			{
				var dic = UIDocumentInteractionController.FromUrl(new NSUrl("http://www.littelfuse.com/technical-resources/~/media/Files/Littelfuse/Technical%20Resources/Documents/2D%20Prints/Content/LFT30030FBCA.pdf"));
				var dicDel = new UIDocumentInteractionControllerDelegate();
				//dic.Delegate = dicDel;
				
				InvokeOnMainThread(delegate
				                   {
					var result = dic.PresentOpenInMenu(myRect, View, true);
					//If I do this -> NullReferenceException because delegate is null (something about autorelease?? Don't know)
					if(!result) dic.Delegate.DidDismissOpenInMenu(dic);
				});

			};
		}
				
			
	}
}

