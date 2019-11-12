using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace AndroidDataAdapters
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView list1;
        string[] names = {"One","Two","Three","Four","Five","Six" };
        ArrayAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            list1 = FindViewById(Resource.Id.list1) as ListView;
            adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemMultipleChoice, names);
            list1.Adapter = adapter;
            list1.ItemClick += List1_ItemClick;
            list1.ItemLongClick += List1_ItemLongClick;
        }

        private void List1_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            adapter.Remove(adapter.GetItem(e.Position));
            adapter.Add("Labas");
            //list1.Adapter = adapter;
            list1.Invalidate();//refresh
            
        }

        private void List1_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, names[e.Position], ToastLength.Short).Show();
            //list1.SetItemChecked(e.Position, true);
            //list1.Invalidate();
            if (e.Position==2)
            {
                Intent intent = new Intent(this, typeof(AnimalActivity));
                StartActivity(intent);
            }
        }
    }
}