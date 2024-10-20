using System;
using Exiled.API.Features;

namespace PinkCandyMultiplier
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "PinkCandyMultiplier";
        public override string Author { get; } = "Lucid";
        public override Version Version { get; } = new Version(1, 0, 0);
        
        public static Plugin Instance { get; private set; }
        
        public override void OnEnabled()
        {
            Instance = this;
            Exiled.Events.Handlers.Scp330.EatingScp330 += EventHandler.OnEatingCandy;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Scp330.EatingScp330 -= EventHandler.OnEatingCandy;
            Instance = null;
            base.OnDisabled();
        }
    }
}