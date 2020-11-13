using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public class ComponentGyro:Component
    {
        public ComponentGyro ()
        {

        }

        public ComponentGyro(string sGyroTime,int iEngineRating)
        {
            ComponentGyro selectedGyro = null;
            foreach(ComponentGyro componentGyro in GetCanonicalGyros())
            {
                if(componentGyro.Name.Equals(sGyroTime) || Utilities.IsSynonymFor(componentGyro.Name,sGyroTime))
                {
                    selectedGyro = componentGyro;
                }
            }

            if (selectedGyro == null) throw new Exception($"Could not locate Gyro type {sGyroTime}");

            Name = selectedGyro.Name;
            WeightMultiplier = selectedGyro.WeightMultiplier;
            CriticalSpaceMech = selectedGyro.CriticalSpaceMech;
            TechnologyBase = selectedGyro.TechnologyBase;

            double adjustedEngineRating = iEngineRating / 100D;
            double adjustedTonnage = Math.Ceiling(adjustedEngineRating);
            double modifiedTonnage = Math.Ceiling(2D * adjustedTonnage * selectedGyro.WeightMultiplier) / 2D;

            Tonnage = modifiedTonnage;

        }

        public double WeightMultiplier { get; set; }

        public static List<ComponentGyro> GetCanonicalGyros()
        {
            List<ComponentGyro> retval = new List<ComponentGyro>();

            ComponentGyro standardGyro = new ComponentGyro() { Name = "Standard Gyro", TechnologyBase = TECHNOLOGY_BASE.BOTH, CriticalSpaceMech = 4, WeightMultiplier = 1 };
            ComponentGyro compactGyro = new ComponentGyro() { Name = "Compact Gyro", TechnologyBase = TECHNOLOGY_BASE.BOTH, CriticalSpaceMech = 2, WeightMultiplier = 1.5 };
            ComponentGyro heavyDutyGyro = new ComponentGyro() { Name = "Heavy-Duty Gyro", TechnologyBase = TECHNOLOGY_BASE.BOTH, CriticalSpaceMech = 4, WeightMultiplier = 2.0 };
            ComponentGyro extraLightGyro = new ComponentGyro() { Name = "Extra-Light Gyro", TechnologyBase = TECHNOLOGY_BASE.BOTH, CriticalSpaceMech = 6, WeightMultiplier = 0.5 };

            retval.Add(standardGyro);
            retval.Add(compactGyro);
            retval.Add(heavyDutyGyro);
            retval.Add(extraLightGyro);

            return retval;
        }

        public override Component CreateInstance()
        {
            return new ComponentGyro();
        }

        public override object Clone()
        {
            ComponentGyro retval = base.Clone() as ComponentGyro;
            retval.WeightMultiplier = WeightMultiplier;
            return retval;
        }
    }
}

