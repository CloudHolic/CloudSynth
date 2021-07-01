namespace CloudSynth.Core.Models
{
    public record PianoCommandParameter
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
