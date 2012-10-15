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
	public class MyAlertViewDelegate: UIAlertViewDelegate
	{

		public string fileName;
		public NSData data;
		public NSUrl _nsurl;

		public MyAlertViewDelegate (string fileName, NSUrl url)
		{
			this.fileName = fileName;
			this._nsurl = url;
		}

		public override void Clicked (UIAlertView alertview, int buttonIndex) 
		{
			if (buttonIndex == 0)
			{
				/*Console.Write("Satya!!!!!!");

				var documents = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			
				fileName = documents + "/" + fileName;

				data = NSData.FromUrl(_nsurl);
				File.WriteAllBytes(fileName,data.ToArray());
			*/
				alertview.Show();
			}
		}

		public override void Canceled (UIAlertView alertView) 
		{ 
			// Don't call base or you'll get:	
			// Unhandled Exception: //MonoTouch.Foundation.You_Should_Not_Call_base_In_This_Method 
		} 
	}
}

