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
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensionsAsync;

namespace XamarinProjet.Resources.Model
{
    class Student
    {
        [PrimaryKey]
        public String CIN { get; set; }
        public string Nom { get; set; }
        public String Prenom { get; set; }
        public String Email { get; set; }
        public String Tel { get; set; }

        //Relation unidirectionnelle vers Filiere
        [ForeignKey(typeof(Filiere))]
        public int FileiereId { get; set; }
        [ManyToOne]
        public Filiere Filiere { get; set; }

        // Relation bidirectionnelle vers Lesson
        [ManyToMany(typeof(Lesson))]
        public List<Lesson> Lessons { get; set; }

       // public int Nbre_Absence { get; set; }

    }
}