using CloudSynth.Core.Models;

namespace CloudSynth.Piano.Controls
{
    internal record PianoCommandParameter
    {
        public Tonic Key { get; init; }

        public int Octave { get; init; }

        public PianoCommandParameter(Tonic key, int octave)
        {
            Key = key;
            Octave = octave;
        }
    }
}
