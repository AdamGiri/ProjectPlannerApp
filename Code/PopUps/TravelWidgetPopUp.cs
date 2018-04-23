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

namespace ProjectPlannerApp.Code.PopUps
{
	class TravelWidgetPopUp : IPopUp, IListModifier
	{

		private Context _context;
		private readonly List<ListItem> _travelListItems = new List<ListItem>();

		public TravelWidgetPopUp(Context context)
		{
			_context = context;
		}

		public void AddToList(ListItem travelListItem)
		{
			if (travelListItem == null)
				throw new InvalidOperationException("TravelListItem is null");

			_travelListItems.Add(travelListItem);
		}

		public int GetListCount()
		{
			return _travelListItems.Count;
		}

		public ListItem GetListItem(int i)
		{
			if (i < 0 || i > _travelListItems.Count)
				throw new InvalidOperationException("index is out of range");

			return _travelListItems[i];
		}

		public void PopUp()
		{
			System.Type travelListActivity = typeof(
				TravelListActivity);

			Utility.GetUtility().WidgetPopUp = this;

			var intent = new Intent(_context, travelListActivity);
			_context.StartActivity(intent);
		}
	}
	

}