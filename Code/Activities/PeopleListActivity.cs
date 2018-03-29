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

namespace ProjectPlannerApp.Code.Activities
{
	[Activity(Label = "PeopleListActivity")]
	public class PeopleListActivity : Activity
	{

	
		private Button _addButton;
		private ListView _list;
		private PeopleListAdapter _adapter;
		private Utility utility = Utility.GetUtility();
		

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.listlayout);

			
			_addButton = (Button)FindViewById<Button>(Resource.Id.addPerson);
			_addButton.Click += PopulateList;

			_list = (ListView)FindViewById<ListView>(Resource.Id.list);
			_adapter = new PeopleListAdapter(this, utility.PeopleWidgetPopUp);
			_list.Adapter = _adapter;

		}

		public void PopulateList(object o,EventArgs e)
		{
			var peopleListItem = new PeopleListItem();
			utility.PeopleWidgetPopUp.AddToList(peopleListItem);
			_adapter.NotifyDataSetChanged();

		}
	}
}