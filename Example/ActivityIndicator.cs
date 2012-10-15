using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;


namespace Example
{
	public class ActivityIndicator: UIWebViewDelegate
	{
		UIActivityIndicatorView _spinner;

		public ActivityIndicator (UIActivityIndicatorView spinner)
		{
			this._spinner = spinner;
		}

		private void loadWebViewDidStartLoad (UIWebView loadWevView)
		{
			_spinner.StartAnimating();
		}
		
		
		private void loadWebViewDidFinishLoad (UIWebView loadWevView)
		{
			_spinner.StopAnimating();
		}
	}
}

