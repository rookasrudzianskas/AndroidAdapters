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

namespace AndroidDataAdapters
{
    class AnimalAdapter : BaseAdapter<AnimalItem>
    {

        Context context;
        List<AnimalItem> allAnimals;

        public AnimalAdapter(Context context, List<AnimalItem> allAnimals)
        {
            this.context = context;
            this.allAnimals = allAnimals;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public AnimalItem GetAnimal(int position)
        {
            return allAnimals[position];
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            AnimalAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as AnimalAdapterViewHolder;

            if (holder == null)
            {
                holder = new AnimalAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.itemLayout, parent, false); //same as SetContentView(Resource.Layout.itemLayout);

                holder.Name = view.FindViewById<TextView>(Resource.Id.txt1);

                holder.Descr = view.FindViewById<TextView>(Resource.Id.txt2);

                holder.Img = view.FindViewById<ImageView>(Resource.Id.img1);

                view.Tag = holder;

            }


            //fill in your items
            holder.Name.Text = allAnimals[position].Name;
            holder.Descr.Text = allAnimals[position].Descr;
            holder.Img.SetImageResource(allAnimals[position].Img);

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return allAnimals.Count;
            }
        }

        public override AnimalItem this[int position]
        {
            get
            {
                return allAnimals[position];
            }
        }

        public void RemoveItem(int position)
        {
            allAnimals.RemoveAt(position);
            NotifyDataSetChanged();
        }
    }
    //copy views from layout
    class AnimalAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView Name{ get; set; }
        public TextView Descr { get; set; }
        public ImageView Img { get; set; }
    }
}