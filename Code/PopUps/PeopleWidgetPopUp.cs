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
	public class PeopleWidgetPopUp : View, IPopUp, IListModifier
	{
		private Context _context;
		private readonly List<PeopleListItem> _peopleListItems = new List<PeopleListItem>();
		

		public PeopleWidgetPopUp(Context context) : base(context)
		{
			_context = context;
			CreatePopUp();
		}

		public void CreatePopUp()
		{

			var inflater = LayoutInflater.From(_context);
			//create xml layout and then inflate.

		}

		public void PopUp()
		{
			//goto list activity for people
			System.Type peopleListActivity = typeof(
				PeopleListActivity);

			Utility.GetUtility().PeopleWidgetPopUp = this;

			var intent = new Intent(_context, peopleListActivity);
			Context.StartActivity(intent);

	

		}

		public void AddToList(PeopleListItem peopleListItem)
		{
			if (peopleListItem == null)
				throw new InvalidOperationException("PeopleListItem is null");

			_peopleListItems.Add(peopleListItem);
		}

		public PeopleListItem GetPeopleListItem(int i)
		{
			if (i < 0 || i > _peopleListItems.Count)
				throw new InvalidOperationException("index is out of range");

			return _peopleListItems[i];
		}
	}
}