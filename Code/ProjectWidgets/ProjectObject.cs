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
using System.Numerics;
using Android.Util;
using Android.Graphics;
using ProjectPlannerApp.Code.Utilities;

namespace ProjectPlannerApp
{
	class ProjectObject : View
	{
		public Vector2 Coordinates { get; set; }
		public View View { get; private set; }
		public Color Color { get; private set; }

		private ViewGroup viewGroup;
	

		public ProjectObject(Context context, Vector2 coordinates,int xmlId,
			ViewGroup viewGroup, Color color) : base(context)
		{
			Coordinates = coordinates;
			View  = Inflate(context, xmlId, null);

			if (View == null)
				throw new NullReferenceException("View is null");

			this.viewGroup = viewGroup ?? throw new NullReferenceException("ViewGroup is null");
			viewGroup.AddView(View);
			Color = color;
			
			View.SetX(Coordinates.X);
			View.SetY(Coordinates.Y);
		}

		public void DeleteObject()
		{
			viewGroup.RemoveView(View);
			View = null;
		}

	

		
	}
}