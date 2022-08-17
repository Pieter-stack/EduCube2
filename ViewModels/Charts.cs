using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.ViewModels
{
    public class Charts
    {




        public ISeries[] LineOne { get; set; }
            = new ISeries[]
            {
                new LineSeries<double>
                {
                    Name = "Staff",
                    Values = new double[] {2,1,3,5,3,4,6},
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
                    Values = new double[] {2,1,3,5,3,4,6},
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
                    Values = new double[] {2,1,3,5,3,4,6},
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
                    Values = new double[] {2,1,3,5,3,4,6},
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
        new PieSeries<double> { Values = new List<double> { 2 }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(93, 58, 243)),  Name = "Degree" },
        new PieSeries<double> { Values = new List<double> { 4 }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(234, 174, 249)),  Name = "Diploma" },
        new PieSeries<double> { Values = new List<double> { 1 }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(252, 105, 35)),  Name = "Certificate" }
   };

        public ISeries[] PieTwo { get; set; } = new ISeries[]
{
        new PieSeries<double> { Values = new List<double> { 2 }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(93, 58, 243)),  Name = "Admin" },
        new PieSeries<double> { Values = new List<double> { 4 }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(234, 174, 249)),  Name = "Teachers" }
};


        public ISeries[] PieThree { get; set; } = new ISeries[]
{
        new PieSeries<double> { Values = new List<double> { 2 }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(93, 58, 243)),  Name = "Salary" },
        new PieSeries<double> { Values = new List<double> { 4 }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(234, 174, 249)),  Name = "Income" },
        new PieSeries<double> { Values = new List<double> { 1 }, InnerRadius = 50, Fill = new SolidColorPaint(new SKColor(252, 105, 35)),  Name = "Expenses" }
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
