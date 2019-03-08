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
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int id_user { get; set; }
        public string login { get; set; }
        public string mdp { get; set; }
      
        public String Role  { get; set; }// s'il s'agit d'un prof ou d'un simple utilisateur
    }
}