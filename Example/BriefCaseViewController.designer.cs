// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Example
{
	[Register ("BriefCaseViewController")]
	partial class BriefCaseViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITableView briefcase { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (briefcase != null) {
				briefcase.Dispose ();
				briefcase = null;
			}
		}
	}
}
