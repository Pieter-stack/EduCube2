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

namespace EduCube.ViewModels
{
    public partial class Charts : ObservableObject
    {

        [ObservableProperty]
        int _totalFundsText = Preferences.Get("MonthlyFunds", 0);
        [ObservableProperty]
        int _totalStaffText = Preferences.Get("TotalLecturer", 0) + Preferences.Get("TotalAdmin", 0);
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

                  //  Preferences.Set("ProfileImage", successAuth.StaffImage);

        //get prefrenced data
        private static int TotalFunds = Preferences.Get("MonthlyFunds", 0);
        private static int TotalIncome = Preferences.Get("FundsTuition", 0);
        private static double TotalSalary = Preferences.Get("FundsSalary", 0);

                        

        private static int TotalLecturers = Preferences.Get("TotalLecturer", TotalLecturers);
        private static int TotalAdmin = Preferences.Get("TotalAdmin", TotalAdmin);

        private static int TotalStaff = Preferences.Get("TotalLecturer", TotalLecturers) + Preferences.Get("TotalAdmin", TotalAdmin);

        private static int DegreeStudents = Preferences.Get("TotalDegree", 0);
        private static int DiplomaStudents = Preferences.Get("TotalDiploma", 0);

        private static int TotalStudents = Preferences.Get("TotalDegree", 0) + Preferences.Get("TotalDiploma", 0);




        public ISeries[] LineOne { get; set; }
            = new ISeries[]
            {
                new LineSeries<double>
                {
                    Name = "Staff",
                    Values = new double[] {0,TotalStaff},
                    Stroke = new SolidColorPaint(new SKColor(252, 105, 35)) { StrokeThickness = 3 },
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null

                }


            };



        public ISeries[] LineTwo { get; set; }
            = new ISeries[]
            {
                new LineSeries<double>
                {
                    Name = "Students",
                    Values = new double[] {0,TotalStudents},
                    Stroke = new SolidColorPaint(new SKColor(93, 58, 243)) { StrokeThickness = 3 },
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null

                }


            };



        public ISeries[] LineThree { get; set; }
    = new ISeries[]
    {
                new LineSeries<double>
                {
                    Name = "Teachers",
                    Values = new double[] {0,TotalLecturers},
                    Stroke = new SolidColorPaint(new SKColor(234, 174, 249)) { StrokeThickness = 3 },
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null

                }


    };


        public ISeries[] LineFour { get; set; }
= new ISeries[]
{
                new LineSeries<double>
                {
                    Name = "Admin",
                    Values = new double[] {0,TotalAdmin},
                    Stroke = new SolidColorPaint(new SKColor(255, 188, 36)) { StrokeThickness = 3 },
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null

                }


};

        public ISeries[] BarOne { get; set; }
= new ISeries[]
{
                new ColumnSeries<double>
                {
                    Name = "Salary",
                    Values = new double[] { 2, 5, 4, -2, 4, -3, 5 },
                    Fill = new SolidColorPaint(new SKColor(93, 58, 243)),
                    Rx = 10,
                    Ry = 10
                },
                new ColumnSeries<double>
                {
                    Name = "Tuition",
                    Values = new double[] { 2, 5, 4, -2, 4, -3, 5 },
                    Fill = new SolidColorPaint(new SKColor(234, 174, 249)),
                    Rx = 10,
                    Ry = 10
                },
                new ColumnSeries<double>
                {
                    Name = "Expenses",
                    Values = new double[] { 2, 5, 4, -2, 4, -3, 5 },
                    Fill = new SolidColorPaint(new SKColor(252, 105, 35)),
                    Rx = 10,
                    Ry = 10
                },

};




        public ISeries[] PieOne { get; set; } = new ISeries[]
   {
        new PieSeries<double> { Values = new List<double> { DegreeStudents }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(93, 58, 243)),  Name = "Degree" },
        new PieSeries<double> { Values = new List<double> { DiplomaStudents }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(234, 174, 249)),  Name = "Diploma" },
   };

        public ISeries[] PieTwo { get; set; } = new ISeries[]
{
        new PieSeries<double> { Values = new List<double> { TotalAdmin }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(93, 58, 243)),  Name = "Admin" },
        new PieSeries<double> { Values = new List<double> { TotalLecturers }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(234, 174, 249)),  Name = "Teachers" }
};


        public ISeries[] PieThree { get; set; } = new ISeries[]
{
        new PieSeries<double> { Values = new List<double> { TotalSalary }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(93, 58, 243)),  Name = "Salary" },
        new PieSeries<double> { Values = new List<double> { TotalIncome }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(234, 174, 249)),  Name = "Income" },
        new PieSeries<double> { Values = new List<double> { TotalFunds }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(252, 105, 35)),  Name = "TotalFunds" }
};



        public Axis[] XAxes { get; set; }
           = new Axis[]
           {
                new Axis
                {
                    NamePaint = null,

                    LabelsPaint = null,
                    TextSize = 0,

                    SeparatorsPaint = null
                }
           };

        public Axis[] YAxes { get; set; }
            = new Axis[]
            {
                new Axis
                {
                    NamePaint = null,

                    LabelsPaint = null,

                    TextSize = 0,
                     SeparatorsPaint = null

                }
            };

        public Axis[] XAxesBar { get; set; }
           = new Axis[]
           {
                new Axis
                {
                    Labels = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul" }
                }
           };


    }
}
