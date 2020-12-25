using Microsoft.AspNetCore.Mvc;
using SubtitleSynchronizer.Contracts;
using SubtitleSynchronizer.Domain.Operator;

namespace SubtitleSynchronizer.Controllers
{
    public class SubtitleController : Controller
    {
        private ISubtitle _subtitleHandler { get; set; }

        public SubtitleController(ISubtitle subtitleHandler)
        {
            _subtitleHandler = subtitleHandler;
        }

        [HttpPost]
        public string[] Adjuster([FromBody] SubtitleOperator obj)
        {
            var subtitlesList = _subtitleHandler.Parse(obj.FileContent);
            subtitlesList = _subtitleHandler.AddOffsetTime(subtitlesList, int.Parse(obj.Offset));

            string[] arrStr = new string[subtitlesList.Count];
            for (int i = 0; i < arrStr.Length; i++)
            {
                arrStr[i] = subtitlesList[i].ToString();
            }

            return arrStr;
        }
    }
}

