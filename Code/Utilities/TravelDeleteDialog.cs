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
	class TravelDeleteDialog : IDialog
	{
		private string _message = "Would you like to delete this item?";
		private Dialog dialog;

		public TravelDeleteDialog(Dialog dialog)
		{
			this.dialog = dialog;
		}



		public void ShowDialog()
		{

			AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(dialog.Context);
			dialogBuilder.SetNegativeButton("No", dialog);
			dialogBuilder.SetPositiveButton("Yes", dialog);
			dialogBuilder.SetMessage(_message);
			AlertDialog builtDialog = dialogBuilder.Create();
			builtDialog.Show();
			builtDialog.Window.SetLayout(dialog.GetWidth(), dialog.GetHeight());
		}

		public void SetProjectObject(ProjectObject projectObject)
		{
			dialog.ProjectObject = projectObject ?? throw new NullReferenceException("Project " +
				" Object is null");
		}
	}
}