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
	class PeopleWidget : IWidget
	{
		private ProjectWidget _projectWidget;
		private  IPopUp peopleWidgetPopUp;

		public PeopleWidget(ProjectWidget projectWidget, IPopUp peopleWidgetPopUp)
		{
			_projectWidget = projectWidget;
			this.peopleWidgetPopUp = peopleWidgetPopUp;
		}

		public void OnClickWidget()
		{
			if (peopleWidgetPopUp == null)
				throw new InvalidOperationException("Popup  is null");

			peopleWidgetPopUp.PopUp();
		}
	}
}