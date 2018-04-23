using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProjectPlannerApp.Code.Utilities;
using ProjectPlannerApp.Code.Activities;

namespace ProjectPlannerApp
{
	public class PeopleWidgetPopUp :  IPopUp, IListModifier
	{
		private Context _context;
		private readonly List<ListItem> _peopleListItems = new List<ListItem>();
		

		public PeopleWidgetPopUp(Context context) 
		{
			_context = context;
		}



		public void PopUp()
		{
			//goto list activity for people
			System.Type peopleListActivity = typeof(
				PeopleListActivity);

			Utility.GetUtility().WidgetPopUp = this;

			var intent = new Intent(_context, peopleListActivity);
			_context.StartActivity(intent);

	

		}

		public void AddToList(ListItem peopleListItem)
		{
			if (peopleListItem == null)
				throw new InvalidOperationException("PeopleListItem is null");

			_peopleListItems.Add(peopleListItem);
		}

		public ListItem GetListItem(int i)
		{
			if (i < 0 || i > _peopleListItems.Count)
				throw new InvalidOperationException("index is out of range");

			return _peopleListItems[i];
		}

		public int GetListCount()
		{
			return _peopleListItems.Count;
		}
	}
}