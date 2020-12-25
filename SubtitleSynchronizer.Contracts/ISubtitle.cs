using SubtitleSynchronizer.Domain.Model;
using System.Collections.Generic;

namespace SubtitleSynchronizer.Contracts
{
    public interface ISubtitle
    {
        List<Subtitle> Parse(string fileContent);
        List<Subtitle> AddOffsetTime(List<Subtitle> subtitles, int time);
    }
}
