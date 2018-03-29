﻿using System;
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
	interface IProjectWidget
	{
		void AddWidget(IWidget widget);
		void RemoveWidget(int i);
		List<IWidget> GetWidgets();
	}
}