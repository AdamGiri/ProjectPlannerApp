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

namespace ProjectPlannerApp.Code.Utilities
{
	class ProjectPlannerTouchListener : Java.Lang.Object, View.IOnTouchListener
	{
		public float X { get; private set; }
		public float Y { get; private set; }

		

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public bool OnTouch(View v, MotionEvent e)
		{
			Log.Info("popup", "OnTouch");
			X = e.RawX;
			Y = e.RawY-225;
			return false;
		}
	}
}