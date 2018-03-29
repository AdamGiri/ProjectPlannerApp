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


namespace ProjectPlannerApp
{
	[Activity(Label = "PlannerActivity")]
	public class PlannerActivity : Activity
	{
		private RelativeLayout _backgroundLayout;
		private ProjectPlannerApp.Code.Utilities.ProjectPlannerTouchListener touchListener;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.ProjectPlanner);

			_backgroundLayout = 	FindViewById<RelativeLayout>(Resource.Id.backgroundLayout);
			touchListener = new ProjectPlannerApp.Code.Utilities.ProjectPlannerTouchListener();
			_backgroundLayout.SetOnTouchListener(touchListener);
			_backgroundLayout.LongClick += ShowPopUpMenu;
		}

		public void ShowPopUpMenu(object o, EventArgs e)
		{
			var widgetMenu = new ProjectPlannerApp.Code.Utilities.WidgetMenu(touchListener, 
				this)
			{
				BackgroundLayout = _backgroundLayout
			};
			widgetMenu.PopUp();
		}


	}

	}
	