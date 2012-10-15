using System;
using MonoTouch.Dialog;
using System.Collections;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using System.IO;
using System.Drawing;

namespace Example
{
	public class TableViewDelegate:UITableViewDelegate
	{


		public List<TableItem> list;
		public UINavigationController nav;
		public string path;
		public ZoomingPdfViewer.ZoomingPdfViewerViewController z;
		public string documentName;
		public WebViewController z1;
		bool _flag = false;
		public CatalogsViewController c1;



		public TableViewDelegate(List<TableItem> list, UINavigationController _nav)
		{
			
			this.list = list;
		    nav = _nav;
		}


		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{

			
			TableItem [] rowItem = new TableItem[10];
			
			rowItem = list.ToArray();


			Console.WriteLine (
				"TableViewDelegate.RowSelected: Label={0}",
				rowItem[indexPath.Row].Heading.ToString());
		
			path = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
			DirectoryInfo dr = new DirectoryInfo (path);
			FileInfo [] f = new FileInfo [10];


			documentName = rowItem[indexPath.Row].SubHeading.ToString();

			f = dr.GetFiles ();
		
			
			
			z1 = new WebViewController (rowItem[indexPath.Row].SubHeading.ToString());
		
			
			foreach (var item in f) {

				_flag = false;
				if (item.ToString () == documentName) {
					
					nav.PushViewController (z1, true);
					break;
				}

			}

			if (!_flag) {
	
				z1 = new WebViewController (rowItem[indexPath.Row].SubHeading.ToString());
				nav.PushViewController (z1, true);
		
				_flag = false;
			
			}
		





		}
	}
}

