using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;


namespace ProjectPlannerApp.Code.Utilities
{
	class PeopleListAdapter : BaseAdapter, View.IOnKeyListener
	{

		public ImageView ImageView { get; private set; }

		private Context context;
		private int _keyCounter = 0;
		private InputMethodManager imm;


		private IListModifier _peopleWidgetPopUp = Utility.GetUtility().WidgetPopUp;

		public PeopleListAdapter(Context context)
		{
			this.context = context;
		    imm = (InputMethodManager)context.GetSystemService(Context.InputMethodService);

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
			Log.Info("getview", "GetView called");
			PeopleListItem peopleListItem = (PeopleListItem) _peopleWidgetPopUp.
				GetListItem(position);
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
				holder.ImageView = view.FindViewById<ImageView>(Resource.Id.imageView);
				view.Tag = holder;
				SetViewFunctionality(holder,position);
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

		private void SetViewFunctionality(PeopleListAdapterViewHolder holder,int position)
		{
			holder.Name.SetOnKeyListener(this);
			holder.Email.SetOnKeyListener(this);
			holder.Telephone.SetOnKeyListener(this);
			holder.Role.SetOnKeyListener(this);

			holder.ImageView.Click += OnImageViewClick;

			holder.Name.SetTag(Resource.Id.addPerson, (Java.Lang.Object) "name");
			holder.Email.SetTag(Resource.Id.addPerson, (Java.Lang.Object)"email");
			holder.Telephone.SetTag(Resource.Id.addPerson, (Java.Lang.Object) "telephone");
			holder.Role.SetTag(Resource.Id.addPerson, (Java.Lang.Object) "role");
		

			holder.Name.SetTag(Resource.Id.backgroundLayout, position);
			holder.Email.SetTag(Resource.Id.backgroundLayout, position);
			holder.Telephone.SetTag(Resource.Id.backgroundLayout, position);
			holder.Role.SetTag(Resource.Id.backgroundLayout, position);
		}


		public bool OnKey(View v, [GeneratedEnum] Keycode keyCode, KeyEvent e)
		{
			_keyCounter++;
			

			if (keyCode == Keycode.Enter && _keyCounter%2!=0)
			{
				EditText et = (EditText)v;
				CheckTag(et);
				imm.HideSoftInputFromWindow(v.WindowToken, 0);
			}

			return false;
		
		}

		private void CheckTag(EditText et)
		{
			PeopleListItem peopleListItem = (PeopleListItem)_peopleWidgetPopUp.
						GetListItem((int)et.GetTag(Resource.Id.backgroundLayout));
			string textInput = et.Text.ToString();

			switch ((string)et.GetTag(Resource.Id.addPerson))
			{
				case "name":
					peopleListItem.Name = textInput;
					break;
				case "email":
					peopleListItem.Email = textInput;
					break;
				case "telephone":
					peopleListItem.Telephone = textInput;
					break;
				case "role":
					peopleListItem.RoleDescription = textInput;
					break;


			}
		}


		//Fill in cound here, currently 0
		public override int Count
		{
			get
			{
				return _peopleWidgetPopUp.GetListCount();
			}
		}

		public void OnImageViewClick(object o, EventArgs e)
		{
			//set image from gallery 
			ImageView imageView = (ImageView)o;
			ImageView = imageView;
			var imageIntent = new Intent();
			imageIntent.SetType("image/*");
			imageIntent.SetAction(Intent.ActionGetContent);
			((Activity)context).StartActivityForResult(
				Intent.CreateChooser(imageIntent, "Select photo"), 0);
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