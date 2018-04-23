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
using System.Numerics;
using Android.Graphics;
using ProjectPlannerApp.Code.Utilities;

namespace ProjectPlannerApp
{
	class ProjectWidget : ProjectObject
	{


		public ProjectWidget(Context context, Vector2 coordinates, int xmlId, ViewGroup viewGroup,
			Color color)
			: base(context, coordinates,xmlId, viewGroup, color)
		{
			
		}

		


	}
}