using SubtitleSynchronizer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SubtitleSynchronizer.Business.Parser
{
    public class SubtitleParser
    {
        public List<Subtitle> Parse(string fileContent)
        {
            var subtitles = new List<Subtitle>();

            var lines = fileContent.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            while (lines.Length > i)
            {
                int sequence;
                try
                {
                    sequence = GetSequence(lines[i]);
                }
                catch (Exception)
                {
                    return subtitles;
                }

                (TimeSpan startTimeCode, TimeSpan endTimeCode) = GetTime(lines[++i]);
                string text = GetText(lines, ref i);

                subtitles.Add(new Subtitle()
                {
                    Sequence = sequence,
                    StartTimeCode = startTimeCode,
                    EndTimeCode = endTimeCode,
                    Text = text
                });
            }

            return subtitles;
        }

        private int GetSequence(string line)
        {
            try
            {
                return int.Parse(line);
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private string GetText(string[] lines, ref int i)
        {
            var text = "";
            while (Regex.IsMatch(lines[++i], "[a-z]", RegexOptions.IgnoreCase))
            {
                text += lines[i] + " ";
            }

            return text;
        }

        private (TimeSpan startTimeCode, TimeSpan endTimeCode) GetTime(string line)
        {
            var timeCode = line.Split("-->");

            var start = TimeSpan.Parse(timeCode[0]);
            var end = TimeSpan.Parse(timeCode[1]);

            return new(start, end);
        }

    }
}
