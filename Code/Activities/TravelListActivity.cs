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
	[Activity(Label = "Locations Required")]
	public class TravelListActivity : Activity
	{
		private Button _addButton;
		private ListView _list;
		private TravelListAdapter _adapter;
		private Utility utility = Utility.GetUtility();

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.listlayout);

			_list = (ListView)FindViewById<ListView>(Resource.Id.list);
			TextView title = FindViewById<TextView>(Resource.Id.listTitle);
			title.Text = "Locations Required";
			_adapter = new TravelListAdapter(this);
			_list.Adapter = _adapter;

			_addButton = (Button)FindViewById<Button>(Resource.Id.addPerson);
			_addButton.Click += PopulateList;
			Window.SetSoftInputMode(SoftInput.AdjustPan);
		}

		public void PopulateList(object o, EventArgs e)
		{

			var peopleListItem = new TravelListItem();
			utility.WidgetPopUp.AddToList(peopleListItem);
			_adapter.NotifyDataSetChanged();

		}
	}
}