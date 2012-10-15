using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;
using System.Drawing;

namespace Example
{
	public class MyActionSheetViewDelegate:UIActionSheetDelegate
	{

		public string fileName;
		public NSData data;
		public NSUrl _nsurl;
		public WebViewController _vw;

		public MyActionSheetViewDelegate (string fileName, NSUrl url, WebViewController vw)
		{
			this.fileName = fileName;
			this._nsurl = url;
			this._vw = vw;

		}

		
		public override void Clicked (UIActionSheet actionview, int buttonIndex) 
		{
			if (buttonIndex == 0)
			{
				Console.Write("Satya!!!!!!");

				/*UIActivityIndicatorView spinner = new UIActivityIndicatorView(new RectangleF(0,0,200,300));
				spinner.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.WhiteLarge;
				spinner.Center= new PointF(160, 140);
				spinner.HidesWhenStopped = true;
				actionview.AddSubview(spinner);
				InvokeOnMainThread(delegate() { 
					spinner.StartAnimating(); 
				}); 

				*/

				var documents = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
				
				fileName = documents + "/" + fileName;
				
				data = NSData.FromUrl(_nsurl);
				File.WriteAllBytes(fileName,data.ToArray());

				if (File.Exists(fileName))
				{
					UIAlertView alert = new UIAlertView();
					alert.Title = "Download Complete";
					alert.AddButton("Done");
					alert.Show();
				}
					//spinner.StopAnimating();


					
			}
		}
		
		public override void Canceled (UIActionSheet actionview) 
		{ 
			// Don't call base or you'll get:	
			// Unhandled Exception: //MonoTouch.Foundation.You_Should_Not_Call_base_In_This_Method 
		} 
	}
}

