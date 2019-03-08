using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using XamarinProjet.Resources.DataHelper;
using XamarinProjet.Resources.Model;



namespace XamarinProjet
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        DataBase db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            db = new DataBase();
            db.createDataBase();
            Resources.Model.User user = new Resources.Model.User();
            user.login = "mery";
            user.mdp = "123";
            db.insertIntoTableUser(user);

            Filiere fil = new Filiere();
            fil.nom_filiere="Genie informatique";
            db.insertIntoTableFiliere(fil);

            Student student = new Student();
            student.CIN = "HH456789";
            student.Nom = "ZOUAQ";
            student.Prenom = "Laila";
            student.Tel = "09876";
            student.Filiere = fil;
            db.insertIntoTableStudent(student);


            Lesson lesson = new Lesson();
            lesson.nom_lesson = "Genie logiciel";

            db.insertIntoTableLesson(lesson);


            db.insertIntoTableStudent_lesson(lesson, student);




           


        }
    
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

