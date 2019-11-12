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
    class AnimalItem
    {
        public string Name { get; set; }
        public string Descr { get; set; }
        public int Img { get; set; }
    }
}