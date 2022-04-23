﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students { get; set; } = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();


            using (ApplicationContext db = new ApplicationContext())
            {
                // Read
                var studentsDB = db.Students.ToList();

                foreach(var student in studentsDB)
                {
                    this.students.Add(student);
                }
                ReloadList();
                
            }


            /*string? line;
            StreamReader file;
            try
            {
                file = new System.IO.
                StreamReader("students.txt");
                while ((line = file.ReadLine()) != null)
                {
                    string[] arr = line.Split();

                    Student student = new Student();

                    student.FirstName = arr[1];
                    student.LastName = arr[0];
                    student.MiddleName = arr[2];                    
                    student.Sex = arr[3];                    

                    students.Add(student);
                }

                ReloadList();
            }
            catch (Exception e)
            {
                File.Create("students.txt");
            }*/
        }
        private void ReloadList()
        {
            /*students.Sort((x, y) => {
                return x.FirstName == y.FirstName ?
                x.LastName == y.LastName ?
                x.MiddleName.CompareTo(y.MiddleName) :
                x.LastName.CompareTo(y.LastName) :
                x.FirstName.CompareTo(y.FirstName);
            });*/

            this.StudentsList.Items.Clear();

            foreach (Student s in students)
            {
                this.StudentsList.Items.Add(s);
            }
        }
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Create
            Student student = new Student();
            student.FirstName = this.FirstName.Text;
            student.LastName = this.LastName.Text;
            student.MiddleName = this.MiddleName.Text;            
            student.Sex = this.Sex.Text;

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Students.Add(student);
                db.SaveChanges();                
            }

            this.students.Add(student);
            
            ReloadList();
        }

        private void SaveList()
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter("students.txt"))
            {
                foreach (Student student in students)
                {
                    file.WriteLine(student.LastName + " " + student.FirstName+ " " + student.MiddleName +
                        " " + student.Sex);
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveList();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.students.Clear();
            ReloadList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.StudentsList.SelectedIndex == -1) return;


            Student student = (Student)this.StudentsList.SelectedItem;
            student.FirstName = this.FirstName.Text;
            student.LastName = this.LastName.Text;
            student.MiddleName = this.MiddleName.Text;
            student.Sex = this.Sex.Text;

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Students.Update(student);
                db.SaveChanges();
                
            }

            //this.students.Add(student);

            ReloadList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.StudentsList.SelectedIndex == -1) return;

            Student student = (Student)this.StudentsList.SelectedItem;

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }

            this.students.Remove(student);

            ReloadList();
        }
    }
}
