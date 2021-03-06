﻿using System;
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
using Android.Util;

namespace ProjectPlannerApp.Code.Activities
{
	[Activity(Label = "People Required")]
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

			_list = (ListView)FindViewById<ListView>(Resource.Id.list);
			_adapter = new PeopleListAdapter(this);
			_list.Adapter = _adapter;

			_addButton = (Button)FindViewById<Button>(Resource.Id.addPerson);
			_addButton.Click += PopulateList;
			Window.SetSoftInputMode(SoftInput.AdjustPan);


		}

		public void PopulateList(object o,EventArgs e)
		{
		
			var peopleListItem = new PeopleListItem();
			utility.WidgetPopUp.AddToList(peopleListItem);
			_adapter.NotifyDataSetChanged();

		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			if (resultCode == Result.Ok)
			{
				var imageView = _adapter.ImageView;
				if (imageView == null)
					throw new InvalidOperationException("Imageview is null");
				imageView.SetImageURI(data.Data);
			}
		}
	}
}