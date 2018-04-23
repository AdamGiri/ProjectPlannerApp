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
using Android.Graphics;
using ProjectPlannerApp.Code.Utilities;
using ProjectPlannerApp.Code.ProjectWidgets;

namespace ProjectPlannerApp.Code.ProjectWidgets
{
	class TravelWidget : Widget, IWidget
	{
		private static string title = "Travel";
		private static Color color = Color.Blue;
		private readonly ProjectObject _projectWidget;

		public TravelWidget(ProjectObject projectWidget, IPopUp widgetPopUp, IDialog dialog)
			: base(projectWidget, widgetPopUp, dialog)
		{
			_projectWidget = projectWidget;
		}

		public override void DesignWidget()
		{
			TextView tv = (TextView)_projectWidget.View.
				FindViewById<TextView>(Resource.Id.widget);


			if (tv == null)
				throw new NullReferenceException("textview is null");

			tv.SetBackgroundColor(color);
			tv.Text = title;
			tv.Click += OnClickWidget;
			tv.LongClick += OnLongClickWidget;


		}
	}
}