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
using Android.Graphics;


namespace ProjectPlannerApp.Code.Utilities
{
	public class PeopleListItem
	{
		public Bitmap Bitmap { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Telephone { get; set; }
		public string RoleDescription { get; set; }

		public PeopleListItem( )
		{
			
		}

		
	}
}