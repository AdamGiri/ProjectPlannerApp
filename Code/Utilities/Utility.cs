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

namespace ProjectPlannerApp.Code.Utilities
{
	class Utility
	{
		public static Utility _instance = new Utility();
		public IListModifier PeopleWidgetPopUp {  get; set; }

		private Utility()
		{
			
		}

		public static Utility GetUtility()
		{
			return _instance;
		}
	}
}