using System.Windows.Controls;
using CloudSynth.Graph.Models;

namespace CloudSynth.Graph.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class GraphView : UserControl
    {
        public GraphView()
        {
            InitializeComponent();

            SineWave.Values = GraphSeries.SineWaves;
            SawWave.Values = GraphSeries.SawWaves;
            ReverseSawWave.Values = GraphSeries.ReverseSawWaves;
            SquareWave.Values = GraphSeries.SquareWaves;
            TriangleWave.Values = GraphSeries.TriangleWaves;
        }
    }
}
