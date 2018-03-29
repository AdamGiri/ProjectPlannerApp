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
	class PeopleListAdapter : BaseAdapter
	{

		Context context;
		private readonly List<PeopleListItem> listItems;
		private IListModifier _peopleWidgetPopUp;

		public PeopleListAdapter(Context context, IListModifier peopleWidgetPopUp)
		{
			this.context = context;
			_peopleWidgetPopUp = peopleWidgetPopUp;
		}

		
		public override Java.Lang.Object GetItem(int position)
		{
			return position;
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			PeopleListItem peopleListItem = _peopleWidgetPopUp.GetPeopleListItem(position);
			var view = convertView;
			PeopleListAdapterViewHolder holder = null;

			if (view != null)
				holder = view.Tag as PeopleListAdapterViewHolder;

			if (holder == null)
			{
				holder = new PeopleListAdapterViewHolder();
				var inflater = context.GetSystemService(Context.LayoutInflaterService).
					JavaCast<LayoutInflater>();
				//replace with your item and your holder items
				//comment back in
				view = inflater.Inflate(Resource.Layout.peoplelistitem, parent, false);
				holder.Name = view.FindViewById<EditText>(Resource.Id.name);
				holder.Email = view.FindViewById<EditText>(Resource.Id.email);
				holder.Telephone = view.FindViewById<EditText>(Resource.Id.telephone);
				holder.Role = view.FindViewById<EditText>(Resource.Id.role);
				view.Tag = holder;
			}


			//fill in your items
			//holder.Title.Text = "new text here";

			if (peopleListItem != null)
			{
				holder.Name.Text = peopleListItem.Name;
				holder.Email.Text = peopleListItem.Email;
				holder.Telephone.Text = peopleListItem.Telephone;
				holder.Role.Text = peopleListItem.RoleDescription;

				if (peopleListItem.Bitmap != null)
				{
					holder.ImageView.SetImageBitmap(peopleListItem.Bitmap);
				}
		
			}
			

			return view;
		}

		//Fill in cound here, currently 0
		public override int Count
		{
			get
			{
				return 0;
			}
		}

	}

	class PeopleListAdapterViewHolder : Java.Lang.Object
	{
	   public EditText Name { get; set; }
	   public EditText Email { get; set; }
	   public EditText Telephone { get; set; }
	   public EditText Role { get; set; }
	   public ImageView ImageView { get; set; }
	}
}