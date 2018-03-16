using System;
using System.Windows.Forms;

namespace ArrangeWF
{
    public partial class Form1 : Form
    {
        private class Benchmark
        {

            private static DateTime _startDate = DateTime.MinValue;
            private static DateTime _endDate = DateTime.MinValue;

            private static TimeSpan Span { get { return _endDate.Subtract(_startDate); } }

            public static void Start()
            {
                _startDate = DateTime.Now;
                _endDate = DateTime.MinValue;

                //var myStopwatch = new System.Diagnostics.Stopwatch(); //Можно через Stopwatch
            }

            public static void End()
            {
                _endDate = DateTime.Now;
            }

            //public static bool IsRun()
            //{
            //    return _startDate > DateTime.MinValue && (_startDate < _endDate  || _endDate == DateTime.MinValue);
            //}

            public static double GetSeconds()
            {
                return _endDate == DateTime.MinValue ? 0.0 : Span.TotalSeconds;
            }
        }
    }
}
