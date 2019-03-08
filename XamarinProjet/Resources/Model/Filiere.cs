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
using SQLite;


namespace XamarinProjet.Resources.Model
{
    class Filiere
    {
        [PrimaryKey, AutoIncrement]
        public int id_filiere { get; set; }
        [Unique]
        public string nom_filiere { get; set; }
    }
}
