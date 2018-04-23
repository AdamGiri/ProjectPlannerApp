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
using Android.Util;
using ProjectPlannerApp.Code.Utilities;


namespace ProjectPlannerApp
{
	[Activity(Label = "Planner")]
	public class PlannerActivity : Activity
	{
		private RelativeLayout _backgroundLayout;
		private ProjectPlannerTouchListener touchListener;
		private WidgetMenu widgetMenu;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.ProjectPlanner);

			_backgroundLayout = 	FindViewById<RelativeLayout>(Resource.Id.backgroundLayout);
			touchListener = new ProjectPlannerTouchListener();
			_backgroundLayout.SetOnTouchListener(touchListener);
			_backgroundLayout.LongClick += ShowPopUpMenu;
		}

		public void ShowPopUpMenu(object o, EventArgs e)
		{
			widgetMenu = new WidgetMenu(touchListener, 
				this)
			{
				BackgroundLayout = _backgroundLayout
			};
			widgetMenu.PopUp();
		}


	}

	}
	