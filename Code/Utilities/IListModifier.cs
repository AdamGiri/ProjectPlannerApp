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
	interface IListModifier
	{
		void AddToList(ListItem peopleListItem);
		ListItem GetListItem(int i);
		int GetListCount();
	}
}