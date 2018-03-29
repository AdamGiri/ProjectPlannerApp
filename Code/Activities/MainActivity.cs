using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace ProjectPlannerApp
{
	[Activity(Label = "ProjectPlannerApp", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
			Button button = FindViewById<Button>(Resource.Id.button1);
			button.Click += GotoPlanner;

		}

		 void GotoPlanner(object sender, EventArgs e)
		{
			Intent intent = new Intent(this, typeof(PlannerActivity));
			StartActivity(intent);
		}
	}
}

