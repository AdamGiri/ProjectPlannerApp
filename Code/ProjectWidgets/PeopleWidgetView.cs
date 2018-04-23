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

namespace ProjectPlannerApp.Code.ProjectWidgets
{
	class PeopleWidgetView : IWidgetView
	{
		private readonly Context context;

		public PeopleWidgetView(Context context)
		{
			this.context = context;
		}

		public void InflateWidget()
		{
			
		}
	}
}