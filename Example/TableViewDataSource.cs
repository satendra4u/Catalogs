using System;
using MonoTouch.Dialog;
using System.Collections;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using MonoTouch.Foundation;


namespace Example
{
	public class TableViewDataSource:UITableViewDataSource
	{
		static NSString kCellIdentifier = new NSString ("MyIdentifier");

			private List<TableItem> list;

			
			
				public TableViewDataSource (List<TableItem> list)
				{

					this.list = list;

				}

				public override int RowsInSection (UITableView tableview, int section)
				{
					return list.Count;

				}


		public  void CommitEditingStyle (UITableView tableView, NSIndexPath indexPath, UITableViewCellEditingStyle editingStyle)
		{
			switch (editingStyle) {
			case UITableViewCellEditingStyle.Delete:
				// remove the item from the underlying data source
				list.RemoveAt(indexPath.Row);
				// delete the row from the table
				tableView.DeleteRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
				break;
			case UITableViewCellEditingStyle.None:
				Console.WriteLine ("CommitEditingStyle:None called");
				break;
			}
			
		}
		
		
		public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
		{
			return true; // return false if you wish to disable editing for a specific indexPath or for all rows
			
		}


		public  string TitleForDeleteConfirmation (UITableView tableView, NSIndexPath indexPath)
		{   // Optional – default text is 'Delete'
			
			return "Trash (" + list[indexPath.Row].ToString() + ")";
		}
			
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{

					UITableViewCell cell = tableView.DequeueReusableCell (kCellIdentifier);
					if (cell == null)
					{
							cell = new UITableViewCell (UITableViewCellStyle.Default,kCellIdentifier);
				
					}

			TableItem [] rowItem = new TableItem[10];

			rowItem = list.ToArray();

			cell.TextLabel.Text = rowItem[indexPath.Row].Heading.ToString();
					return cell;

		}

	}
}

