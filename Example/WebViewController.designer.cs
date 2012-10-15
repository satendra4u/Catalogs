// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Example
{
	[Register ("WebViewController")]
	partial class WebViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITabBar Cache { get; set; }


		[Outlet]
		MonoTouch.UIKit.UIWebView loadWebView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Cache != null) {
				Cache.Dispose ();
				Cache = null;
			}

			if (Cache != null) {
				Cache.Dispose ();
				Cache = null;
			}

			if (loadWebView != null) {
				loadWebView.Dispose ();
				loadWebView = null;
			}
		}
	}
}
