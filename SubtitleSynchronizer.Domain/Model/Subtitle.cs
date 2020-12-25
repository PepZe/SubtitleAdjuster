using System;

namespace SubtitleSynchronizer.Domain.Model
{
    public class Subtitle
    {
        public int Sequence { get; set; }
        public TimeSpan StartTimeCode { get; set; }
        public TimeSpan EndTimeCode { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            var startTime = StartTimeCode.ToString().Replace('.', ',');
            var endTime = EndTimeCode.ToString().Replace('.', ',');

            return $"{Sequence}\n{startTime} --> {endTime}\n{Text}\n";
        }
    }
}
