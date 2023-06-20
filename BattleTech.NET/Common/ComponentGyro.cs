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

        public ComponentGyro(int iEngineRating, string sGyroType)
        {
            ComponentGyro selectedGyro = null;
            foreach(ComponentGyro componentGyro in GetCanonicalGyros())
            {
                if(componentGyro.Name.Equals(sGyroType) || Utilities.IsSynonymFor(componentGyro.Name,sGyroType))
                {
                    selectedGyro = componentGyro;
                }
            }

            if (selectedGyro == null) throw new Exception($"Could not locate Gyro type {sGyroType}");

            Name = selectedGyro.Name;
            WeightMultiplier = selectedGyro.WeightMultiplier;
            CriticalSpaceMech = selectedGyro.CriticalSpaceMech;
            TechnologyBase = selectedGyro.TechnologyBase;
            BattleValueModifier = selectedGyro.BattleValueModifier;

            double adjustedEngineRating = iEngineRating / 100D;
            double adjustedTonnage = Math.Ceiling(adjustedEngineRating);
            double modifiedTonnage = Math.Ceiling(2D * adjustedTonnage * selectedGyro.WeightMultiplier) / 2D;

            Tonnage = modifiedTonnage;

        }

        public double WeightMultiplier { get; set; }

        public static List<ComponentGyro> GetCanonicalGyros()
        {
            List<ComponentGyro> retval = new List<ComponentGyro>();

            ComponentGyro standardGyro = new ComponentGyro() { Name = "Standard Gyro", TechnologyBase = TECHNOLOGY_BASE.BOTH, CriticalSpaceMech = 4, WeightMultiplier = 1,BattleValueModifier = 0.5 };
            ComponentGyro compactGyro = new ComponentGyro() { Name = "Compact Gyro", TechnologyBase = TECHNOLOGY_BASE.BOTH, CriticalSpaceMech = 2, WeightMultiplier = 1.5, BattleValueModifier = 0.5 };
            ComponentGyro heavyDutyGyro = new ComponentGyro() { Name = "Heavy-Duty Gyro", TechnologyBase = TECHNOLOGY_BASE.BOTH, CriticalSpaceMech = 4, WeightMultiplier = 2.0, BattleValueModifier = 1.0 };
            ComponentGyro extraLightGyro = new ComponentGyro() { Name = "Extra-Light Gyro", TechnologyBase = TECHNOLOGY_BASE.BOTH, CriticalSpaceMech = 6, WeightMultiplier = 0.5, BattleValueModifier = 0.5 };
			ComponentGyro nullGyro = new ComponentGyro() { Name = "None", TechnologyBase = TECHNOLOGY_BASE.BOTH, CriticalSpaceMech = 0, WeightMultiplier = 0, BattleValueModifier = 0 };

			retval.Add(standardGyro);
            retval.Add(compactGyro);
            retval.Add(heavyDutyGyro);
            retval.Add(extraLightGyro);
			retval.Add(nullGyro);

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
            retval.BattleValueModifier = BattleValueModifier;
            return retval;
        }
        public double BattleValueModifier { get; set; }
    }
}

