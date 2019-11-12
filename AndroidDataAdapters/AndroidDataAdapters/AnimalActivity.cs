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
    [Activity(Label = "AnimalActivity")]
    public class AnimalActivity : ListActivity
    {
        List<AnimalItem> allAnimals;
        AnimalAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            allAnimals = new List<AnimalItem>();
            
            allAnimals.Add(new AnimalItem()
            {
                Name="Chicken",
                Descr="Very tasty when cooked",
                Img = Resource.Drawable.Chicken
            });


            allAnimals.Add(new AnimalItem()
            {
                Name = "Turtle",
                Descr = "One of TMNT",
                Img = Resource.Drawable.Turtle
            });

            allAnimals.Add(new AnimalItem()
            {
                Name = "Hawk",
                Descr = "The Bird",
                Img = Resource.Drawable.Hawk
            });

            allAnimals.Add(new AnimalItem()
            {
                Name = "Penguin",
                Descr = "Bad guy from Batman!",
                Img = Resource.Drawable.Chicken
            });

            allAnimals.Add(new AnimalItem()
            {
                Name = "Duck",
                Descr = "Rubber Duckyyyyyyyyy",
                Img = Resource.Drawable.Duck
            });

            adapter = new AnimalAdapter(this, allAnimals);
            this.ListAdapter = adapter;
            this.ListView.ItemLongClick += ListView_ItemLongClick;
        }

        private void ListView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Question");
            alert.SetMessage("Do you want to delete this " +adapter.GetAnimal(e.Position)+"?");
            alert.SetIcon(Resource.Drawable.Icon);
            alert.SetPositiveButton("Yes", delegate 
            {
                adapter.RemoveItem(e.Position);
            });
            alert.SetNegativeButton("No", delegate { });
            alert.Show();
        }
    }
}