using System;
using LiveCharts;
using LiveCharts.Defaults;

namespace CloudSynth.Graph.Models
{
    internal static class GraphSeries
    {
        internal static ChartValues<ObservablePoint> SineWaves;

        internal static ChartValues<ObservablePoint> SawWaves;

        internal static ChartValues<ObservablePoint> ReverseSawWaves;

        internal static ChartValues<ObservablePoint> TriangleWaves;

        internal static ChartValues<ObservablePoint> SquareWaves;

        internal const double AxisGap = 0.01;

        internal const double Tolerance = 0.005;

        static GraphSeries()
        {
            SineWaves = new ChartValues<ObservablePoint>();
            SawWaves = new ChartValues<ObservablePoint>();
            ReverseSawWaves = new ChartValues<ObservablePoint>();
            TriangleWaves = new ChartValues<ObservablePoint>();
            SquareWaves = new ChartValues<ObservablePoint>();

            for (double i = -1; i < 1 + AxisGap; i += AxisGap)
            {
                SineWaves.Add(new ObservablePoint(i, Math.Sin(i * Math.PI)));

                SawWaves.Add(new ObservablePoint(i, i));

                ReverseSawWaves.Add(new ObservablePoint(i, -i));

                TriangleWaves.Add(new ObservablePoint(i, 2 * Math.Abs(2 * (i / 2 - Math.Floor((i + 1.5) / 2) + 0.25)) - 1));

                if (Math.Abs(i + 1) < Tolerance || i == 0 || Math.Abs(i - 1) < Tolerance)
                    SquareWaves.Add(new ObservablePoint(i, 0));
                else
                    SquareWaves.Add(new ObservablePoint(i, 2 * (2 * Math.Floor(0.5 * i) - Math.Floor(i)) + 1));
            }
        }
    }
}
