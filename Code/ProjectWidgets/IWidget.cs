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

namespace ProjectPlannerApp
{
	public interface IWidget
	{
		void OnClickWidget(object o, EventArgs e);
		void OnLongClickWidget(object o, EventArgs e);
	}
}