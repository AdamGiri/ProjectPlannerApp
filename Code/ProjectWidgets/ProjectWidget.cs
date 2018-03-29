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
	class ProjectWidget : ProjectObject, IProjectWidget
	{
		private readonly List<IWidget> _widgets = new List<IWidget>();

		public ProjectWidget(Context context) : base(context)
		{
		}

		public void AddWidget(IWidget widget)
		{
			_widgets.Add(widget);
		}

		public List<IWidget> GetWidgets()
		{
				return _widgets;
		}

		public void RemoveWidget(int i)
		{
			if (_widgets.Count > 0)
				_widgets.RemoveAt(i);
		}
	}
}