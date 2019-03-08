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
using SQLiteNetExtensions.Attributes;

namespace XamarinProjet.Resources.Model
{
    class Lesson
    {
        [PrimaryKey, AutoIncrement]
        public int id_lesson { get; set; }
        public string nom_lesson { get; set; }

        // Relation bidirectionelle vers Student
        [ManyToMany(typeof(Student))]
        public List<Student> Students { get; set; }
    }
}