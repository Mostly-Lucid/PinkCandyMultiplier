using System.ComponentModel;
using Exiled.API.Interfaces;

namespace PinkCandyMultiplier
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;
        [Description("The maxium possible multipler per pink candy eaten")]
        public int MaxMultiplier { get; set; } = 3;
    }
}