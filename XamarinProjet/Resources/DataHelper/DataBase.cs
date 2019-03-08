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


using Android.Util;
using SQLite;

namespace XamarinProjet.Resources.DataHelper
{
    class DataBase
    {
        String DbName = "School1.db";
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            public bool createDataBase()
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, DbName)))
                    {
                        connection.CreateTable<Model.User>();
                        connection.CreateTable<Model.Filiere>();
                        connection.CreateTable<Model.Lesson>();
                        connection.CreateTable<Model.Student>();
                        connection.CreateTable<Model.StudentLesson>();

                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

            public bool insertIntoTableUser(Model.User user)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, DbName)))
                    {
                        connection.Insert(user);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }
        public bool insertIntoTableStudent(Model.Student student)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, DbName)))
                    {
                    student.FileiereId = student.Filiere.id_filiere;
                        connection.Insert(student);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

            public bool insertIntoTableFiliere(Model.Filiere filiere)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, DbName)))
                    {
                        connection.Insert(filiere);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

            public bool insertIntoTableLesson(Model.Lesson lesson)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, DbName)))
                    {
                        connection.Insert(lesson);
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

           public bool insertIntoTableStudent_lesson(Model.Lesson lesson, Model.Student student)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, DbName)))
                    {
                        
                            Model.StudentLesson Student_Lesson = new Model.StudentLesson();

                    Student_Lesson.LessonId = lesson.id_lesson;
                    Student_Lesson.StudentCIN = student.CIN;
                            connection.Insert(Student_Lesson);
                        
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

            public bool auth(Model.User user)
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, DbName)))
                    {
                        List<Model.User> res = connection.Query<Model.User>("SELECT * FROM User Where login=? AND mdp = ?", user.login, user.mdp);
                        if (res.Count > 0) return true;
                        else return false;
                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return false;
                }
            }

            public List<Model.Filiere> getAllFilieres()
            {
                try
                {
                    using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, DbName)))
                    {
                        return connection.Table<Model.Filiere>().ToList();

                    }
                }
                catch (SQLiteException ex)
                {
                    Log.Info("SQLiteEx", ex.Message);
                    return null;
                }
            }
        }
    }
