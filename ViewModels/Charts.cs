using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using EduCube.Services;
using Microsoft.Toolkit.Mvvm.Input;
using System.Diagnostics;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using System.Collections.ObjectModel;

namespace EduCube.ViewModels
{
    public partial class Charts : ObservableObject
    {

        //set prefrences as observable properties to use on Dashboard page
        [ObservableProperty]
        int _totalFundsText = Preferences.Get("MonthlyFunds", 0);

        [ObservableProperty]
        int _totalUsersText = Preferences.Get("TotalLecturer", TotalLecturers) + 
            Preferences.Get("TotalAdmin", TotalAdmin) + Preferences.Get("TotalDegree", 0)
            + Preferences.Get("TotalDiploma", 0);
        
        [ObservableProperty]
        int _totalStudentText = Preferences.Get("TotalDegree", 0) + Preferences.Get("TotalDiploma", 0);
        
        [ObservableProperty]
        int _totalLecturerText = Preferences.Get("TotalLecturer", 0);
        
        [ObservableProperty]
        int _totalAdminText = Preferences.Get("TotalAdmin", 0);
        
        [ObservableProperty]
        string _firstNameText = Preferences.Get("FirstName", "");
        
        [ObservableProperty]
        string _lastNameText = Preferences.Get("LastName", "");
       
        [ObservableProperty]
        string _profilePic = Preferences.Get("ProfileImage", "profilepic.png" );

        [ObservableProperty]
        int _SubjectsText = Preferences.Get("Subjects", 0);

       
        //Get prefrenced data
        private static int TotalFunds = Preferences.Get("MonthlyFunds", 0);
        private static int TotalIncome = Preferences.Get("FundsTuition", 0);
        private static double TotalSalary = Preferences.Get("FundsSalary", 0);

        private static int TotalLecturers = Preferences.Get("TotalLecturer", TotalLecturers);
        private static int TotalAdmin = Preferences.Get("TotalAdmin", TotalAdmin);

        private static int DegreeStudents = Preferences.Get("TotalDegree", 0);
        private static int DiplomaStudents = Preferences.Get("TotalDiploma", 0);
        private static int TotalStudents = Preferences.Get("TotalDegree", 0) + Preferences.Get("TotalDiploma", 0);

        private static int TotalSubjects = Preferences.Get("Subjects", 0);


        //Line chart for Total admin users
        public ISeries[] LineOne { get; set; }
            = new ISeries[]
            {
                new LineSeries<double>
                {
                    Name = "Admin",
                    Values = new double[] {0,TotalAdmin/2, TotalAdmin / 2.2, TotalAdmin / 1.2, TotalAdmin},
                    Stroke = new SolidColorPaint(new SKColor(252, 105, 35)) { StrokeThickness = 3 },
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null
                }
            };

        //Line chart for Total students
        public ISeries[] LineTwo { get; set; } = new ISeries[]
        {
            new LineSeries<double>
            {
                Name = "Students",
                Values = new double[] {0,TotalStudents/3, TotalStudents / 2.2, TotalStudents / 2, TotalStudents},
                Stroke = new SolidColorPaint(new SKColor(93, 58, 243)) { StrokeThickness = 5 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
            }
        };

        //Line chart for Total lecturers
        public ISeries[] LineThree { get; set; } = new ISeries[]
        {
            new LineSeries<double>
            {
                Name = "Teachers",
                Values = new double[] {0,TotalLecturers/3.5, TotalLecturers/3, TotalLecturers/2.5, TotalLecturers/2, TotalLecturers},
                Stroke = new SolidColorPaint(new SKColor(234, 174, 249)) { StrokeThickness = 5 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
            }
        };

        //Line chart for Total subjects
        public ISeries[] LineFour { get; set; } = new ISeries[]
        {
            new LineSeries<double>
            {
                Name = "Subjects",
                Values = new double[] {0,TotalSubjects},
                Stroke = new SolidColorPaint(new SKColor(255, 188, 36)) { StrokeThickness = 5 },
                Fill = null,
                GeometryFill = null,
                GeometryStroke = null
            }
        };

        //Bubbles and weighted charts for displaying Lecturers, Admin and students
        public Charts()
        {
            var r = new Random();
            var values1 = new ObservableCollection<WeightedPoint>();
            var values2 = new ObservableCollection<WeightedPoint>();
            var values3 = new ObservableCollection<WeightedPoint>();

            //populate with lecturers
            for (var i = 0; i < TotalLecturers; i++)
            {
                values1.Add(new WeightedPoint(r.Next(0, 20), r.Next(0, 20), r.Next(0, 100)));
            }
            //populate with admin
            for (var i = 0; i < TotalAdmin; i++)
            {
                values2.Add(new WeightedPoint(r.Next(0, 20), r.Next(0, 20), r.Next(0, 100)));
            }
            //populate with students
            for (var i = 0; i < TotalStudents; i++)
            {
                values3.Add(new WeightedPoint(r.Next(0, 20), r.Next(0, 20), r.Next(0, 100)));
            }


            //Load scatter chart
            Series = new ISeries[]
            {
            new ScatterSeries<WeightedPoint>
            {   
                Name = "Lecturers",
                Values = values1,
                GeometrySize = 50,
                MinGeometrySize = 5,
                Fill = new SolidColorPaint(new SKColor(252,105,35,80)),
                Stroke = new SolidColorPaint(new SKColor(252, 105, 35)) { StrokeThickness = 3 },
            },
            new ScatterSeries<WeightedPoint, RoundedRectangleGeometry>
            {   
                Name = "Admin",
                Values = values2,
                GeometrySize = 50,
                MinGeometrySize = 5,
                Fill = new SolidColorPaint(new SKColor(234, 174, 249,80)),
                Stroke = new SolidColorPaint(new SKColor(234, 174, 249)) { StrokeThickness = 3 },
            },
            new ScatterSeries<WeightedPoint>
            {   
                Name = "Students",
                Values = values3,
                GeometrySize = 50,
                MinGeometrySize = 5,
                Fill = new SolidColorPaint(new SKColor(255, 188, 36,80)),
                Stroke = new SolidColorPaint(new SKColor(255, 188, 36)) { StrokeThickness = 3 },
            }
            };
        }
        
        public ISeries[] Series { get; set; }

        //Pie chart for Degree and Diploma Students
        public ISeries[] PieOne { get; set; } = new ISeries[]
        {
        new PieSeries<double> { Values = new List<double> { DegreeStudents }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(93, 58, 243)),  Name = "Degree" },
        new PieSeries<double> { Values = new List<double> { DiplomaStudents }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(234, 174, 249)),  Name = "Diploma" },
        };
        //Pie chart for Admin and Lecturers
        public ISeries[] PieTwo { get; set; } = new ISeries[]
        {
        new PieSeries<double> { Values = new List<double> { TotalAdmin }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(93, 58, 243)),  Name = "Admin" },
        new PieSeries<double> { Values = new List<double> { TotalLecturers }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(234, 174, 249)),  Name = "Teachers" }
        };
        //Pie chart for Salary, Tuition and Total Funds
        public ISeries[] PieThree { get; set; } = new ISeries[]
        {
        new PieSeries<double> { Values = new List<double> { TotalSalary }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(93, 58, 243)),  Name = "Salary" },
        new PieSeries<double> { Values = new List<double> { TotalIncome }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(234, 174, 249)),  Name = "Income" },
        new PieSeries<double> { Values = new List<double> { TotalFunds }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(252, 105, 35)),  Name = "TotalFunds" }
        };

        //Making x axis invisible
        public Axis[] XAxes { get; set; } = new Axis[]
        {
            new Axis
            {
                NamePaint = null,
                LabelsPaint = null,
                TextSize = 0,
                SeparatorsPaint = null
            }
        };
        //Making y axis invisible
        public Axis[] YAxes { get; set; } = new Axis[]
        {
            new Axis
            {
                NamePaint = null,
                LabelsPaint = null,
                TextSize = 0,
                SeparatorsPaint = null
            }
        };
    }
}
