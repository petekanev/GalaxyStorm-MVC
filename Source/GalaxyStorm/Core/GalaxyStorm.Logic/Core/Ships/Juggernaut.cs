﻿namespace GalaxyStorm.Logic.Core.Ships
{
    using System;

    public class Juggernaut : IShip
    {
        public string Name
        {
            get { return "Juggernaut"; }
        }

        public string Description { get; private set; }

        public int Attack { get; private set; }

        public int Armor { get; private set; }
        
        public int CargoCapacity { get; private set; }
        
        public int Prerequisite { get; private set; }

        public TimeSpan BuildTime { get; private set; }
        
        public int[] RequiredResourcesToBuild { get; private set; }
    }
}
