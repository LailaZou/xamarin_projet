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
using SQLiteNetExtensions.Attributes;

namespace XamarinProjet.Resources.Model
{
    class StudentLesson
    {
        //Relation intermediaire entre les classes Lesson et student
        [ForeignKey(typeof(Student))]
        public String StudentCIN { get; set; }

        [ForeignKey(typeof(Lesson))]
        public int LessonId { get; set; }

        // le nombre d'absence d'un etudiant dans un cours particulier
        public int Nbre_Absence;
    }
}