using Microsoft.AspNetCore.Razor.TagHelpers;
using SoccerLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerLeague.TagHelpers
{
    [HtmlTargetElement("points-helper", Attributes = ValueAttribute)]
    public class PointsHelper : TagHelper
    {
        private const string ValueAttribute = "points-helper-value";
        [HtmlAttributeName(ValueAttribute)] public IEnumerable<Player> Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            uint sum = 0;
            foreach(var x in Value)
            {
                sum += x.Points;
            }
            string val = sum.ToString();
            output.Content.SetContent(val);

        }
    }
}
