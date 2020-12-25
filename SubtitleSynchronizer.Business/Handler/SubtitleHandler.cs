using SubtitleSynchronizer.Business.Parser;
using SubtitleSynchronizer.Contracts;
using SubtitleSynchronizer.Domain.Model;
using System;
using System.Collections.Generic;

namespace SubtitleSynchronizer.Business.Handler
{
    public class SubtitleHandler : ISubtitle
    {
        private SubtitleParser _subtitleParser;

        public SubtitleHandler()
        {
            _subtitleParser = new SubtitleParser();
        }

        public List<Subtitle> AddOffsetTime(List<Subtitle> subtitles, int time)
        {
            var timeToSum = new TimeSpan(0, 0, 0, 0, time);
            foreach (var subtitle in subtitles)
            {
                subtitle.StartTimeCode += timeToSum;
                subtitle.EndTimeCode += timeToSum;
            }

            return subtitles;
        }

        public List<Subtitle> Parse(string fileContent)
        {
            return _subtitleParser.Parse(fileContent);
        }
    }
}
