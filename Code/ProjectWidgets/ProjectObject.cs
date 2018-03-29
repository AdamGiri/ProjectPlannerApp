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
using Android.Graphics.Drawables;


namespace ProjectPlannerApp
{
	class ProjectObject : View
	{
		public Drawable _objectDrawable;

		public ProjectObject(Context context) : base(context)
		{
			
		}
	}
}