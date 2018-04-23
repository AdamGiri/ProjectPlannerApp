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
	class TravelListItem : ListItem
	{
		public string Location { get; set; }
		public string Postcode { get; set; }
		public string TeleNumber { get; set; }
		public string Reason { get; set; }

		public TravelListItem()
		{
			
		}


	}
}