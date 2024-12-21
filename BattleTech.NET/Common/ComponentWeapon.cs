using BattleTechNET.Data;
using BattleTechNET.TotalWarfare;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public enum AerospaceWeaponRanges { SHORT,MEDIUM,LONG,EXTREME,POINTDEFENSE,NA};
    public class ComponentWeapon:Component
    {
        public ComponentWeapon()
        {
            ContributesToTargetingComputerMass = true;
        }
        public int Heat { get; set; }
        public int AeroHeat { get; set; }
        public bool HeatIsPerShot { get; set; }
        private int mDamage = 0;
        public int Damage { get
            {
                return mDamage;
            }

            set 
            {
                mDamage = value;
                ShortRangeDamage = mDamage;
                MediumRangeDamage = mDamage;
                LongRangeDamage = mDamage;
            } 
        }
        public int AeroDamage { get; set; }
        public int MinimumRange { get; set; }
        public int ShortRange { get; set; }
        public int MediumRange { get; set; }
        public int LongRange { get; set; }
        public AerospaceWeaponRanges AeroRange { get; set; }
        public double AmmoPerTon { get; set; }
        public string LauncherType { get; set; }
        public int ToHitModifier { get; set; }
        public bool ContributesToTargetingComputerMass { get; set; }
        public string AlphaStrikeAbility { get; set; }
        public bool IndirectFire { get; set; }
        public int ShortRangeDamage { get; set; }
        public int MediumRangeDamage { get; set; }
        public int LongRangeDamage { get; set; }
        //Damage done when weapon is critted.  Used for Gauss Rifles.
        //Also used to calculate defensive BV (TM302).
        public int VolatileDamage { get; set; }
        public float? SBFShortRangeDamageOverride { get; set; }
		public float? SBFMediumRangeDamageOverride { get; set; }
		public float? SBFLongRangeDamageOverride { get; set; }
		public float? SBFExtremeRangeDamageOverride { get; set; }

		public void CopyComponents(ComponentWeapon weapon)
        {
            Name = weapon.Name;
            Tonnage = weapon.Tonnage;
            BaseCost = weapon.BaseCost;
            TechnologyBase = weapon.TechnologyBase;
            Heat = weapon.Heat;
            AeroHeat = weapon.AeroHeat;
            HeatIsPerShot = weapon.HeatIsPerShot;
            Damage = weapon.Damage;
            AeroDamage = weapon.AeroDamage;
            MinimumRange = weapon.MinimumRange;
            ShortRange = weapon.ShortRange;
            MediumRange = weapon.MediumRange;
            LongRange = weapon.LongRange;
            AeroRange = weapon.AeroRange;
            AmmoPerTon = weapon.AmmoPerTon;
            CriticalSpaceMech = weapon.CriticalSpaceMech;
            CriticalSpaceProtomech = weapon.CriticalSpaceProtomech;
            CriticalSpaceCombatVehicle = weapon.CriticalSpaceCombatVehicle;
            CriticalSpaceDropShips = weapon.CriticalSpaceDropShips;
            CriticalSpaceFighters = weapon.CriticalSpaceFighters;
            CriticalSpaceSmallCraft = weapon.CriticalSpaceSmallCraft;
            CriticalSpaceSupportVehicle = weapon.CriticalSpaceSupportVehicle;
            ToHitModifier = weapon.ToHitModifier;
            TechRating = weapon.TechRating;
            LauncherType = weapon.LauncherType;
            ContributesToTargetingComputerMass = weapon.ContributesToTargetingComputerMass;
            AlphaStrikeAbility = weapon.AlphaStrikeAbility;
            ShortRangeDamage = weapon.ShortRangeDamage;
            MediumRangeDamage = weapon.MediumRangeDamage;
            LongRangeDamage = weapon.LongRangeDamage;
            IndirectFire = weapon.IndirectFire;

        }
        public override object Clone()
        {
            ComponentWeapon retval = base.Clone() as ComponentWeapon;
            retval.Heat = Heat;
            retval.AeroHeat = AeroHeat;
            retval.HeatIsPerShot = HeatIsPerShot;
            retval.Damage = Damage;
            retval.AeroDamage = AeroDamage;
            retval.MinimumRange = MinimumRange;
            retval.ShortRange = ShortRange;
            retval.MediumRange = MediumRange;
            retval.LongRange = LongRange;
            retval.AeroRange = AeroRange;
            retval.AmmoPerTon = AmmoPerTon;
            retval.ToHitModifier = ToHitModifier;
            retval.LauncherType = LauncherType;
            retval.ContributesToTargetingComputerMass = ContributesToTargetingComputerMass;
            retval.AlphaStrikeAbility = AlphaStrikeAbility;
            retval.IndirectFire = IndirectFire;
            retval.ShortRangeDamage = ShortRangeDamage;
            retval.MediumRangeDamage = MediumRangeDamage;
            retval.LongRangeDamage = LongRangeDamage;
            retval.BV = BV;
            return retval;
        }
        public ComponentWeapon SetRangeDamage(int iShort, int iMedium, int iLong)
        {
            ShortRangeDamage = iShort;
            MediumRangeDamage = iMedium;
            LongRangeDamage = iLong;
            return this;
        }
        public override Component CreateInstance()
        {
            return new ComponentWeapon();
        }

        /// <summary>
        /// Resolving weapons from the hit location table.
        /// NOTE: We'll need to figure out what to do about large weapons that span multiple hit locations, but in principle
        /// this method should have the information it needs to resolve them properly.
        /// </summary>
        /// <param name="design">The BattleMech Design</param>
        public static void ResolveComponent(Design design)
        {
            //TM212: 
            Dictionary<string, Dictionary<string, int>> dicLargeSplitWeapons = new Dictionary<string, Dictionary<string, int>>();
            foreach (HitLocation location in design.HitLocations)
            {
                BattleMechHitLocation bmhl = location as BattleMechHitLocation;
                List<CriticalSlot> slots = new List<CriticalSlot>();

                List<ComponentWeapon> canonicalWeapons = ComponentWeapon.GetCanonicalWeapons();


                foreach (CriticalSlot criticalSlot in bmhl.CriticalSlots)
                {
                    foreach (ComponentWeapon componentWeapon in canonicalWeapons)
                    {
                        if(componentWeapon.TechnologyBase == design.TechnologyBase || componentWeapon.TechnologyBase == TECHNOLOGY_BASE.BOTH)
                        if (Utilities.IsSynonymFor(componentWeapon, criticalSlot.Label.Replace("(R)","").Trim()))
                            slots.Add(criticalSlot);
                    }
                }

                
                int iComponentSlots = slots.Count;
                Dictionary<string, int> dicSlotsInSpace = new Dictionary<string, int>();
                for (int i = 0; i<slots.Count; i++)
                {
                    if (!dicSlotsInSpace.ContainsKey(slots[i].Label)) dicSlotsInSpace.Add(slots[i].Label, 0);
                    dicSlotsInSpace[slots[i].Label]++;
                }
                foreach (string s in dicSlotsInSpace.Keys)
                {

                    foreach (ComponentWeapon compWeapon in canonicalWeapons)
                    {
                        ComponentWeapon componentWeapon = compWeapon.Clone() as ComponentWeapon;
                        componentWeapon.Configure(design);
                        if(design.Tonnage > 100)
                        {
                            componentWeapon.CriticalSpaceMech = (int)Math.Ceiling(((double)componentWeapon.CriticalSpaceMech /2D));
                        }
                        bool bRear = false;
                        string sLabel = s.Trim();
                        if (sLabel.EndsWith("(R)"))
                        {
                            sLabel = sLabel.Replace("(R)", "").Trim();
                        }
                        if (Utilities.IsSynonymFor(componentWeapon, sLabel) &&
                            (componentWeapon.TechnologyBase == design.TechnologyBase || componentWeapon.TechnologyBase == TECHNOLOGY_BASE.BOTH))
                        {
                            int iSlots = dicSlotsInSpace[s];
                            if (iSlots % componentWeapon.CriticalSpaceMech == 0)
                            {
                                int iInstances = iSlots / componentWeapon.CriticalSpaceMech.Value;
                                for (int j = 0; j < iInstances; j++)
                                {
                                    iComponentSlots -= componentWeapon.CriticalSpaceMech.Value;

                                    ComponentWeapon currentWeapon = componentWeapon.Clone() as ComponentWeapon;

                                    currentWeapon.Configure(design);


                                    UnitComponent uc = new UnitComponent(currentWeapon, bmhl);
                                    uc.RearFacing = bRear;
                                    design.Components.Add(uc);
                                }
                            }
                            else
                            {
                                if (componentWeapon.CriticalSpaceMech < 8)
                                    throw new Exception("Invalid number of slots for weapon " + componentWeapon.Name + " in " + bmhl.Name);
                                else
                                {
                                    if (!dicLargeSplitWeapons.ContainsKey(componentWeapon.Name))
                                    {
                                        dicLargeSplitWeapons.Add(componentWeapon.Name, new Dictionary<string, int>());
                                        dicLargeSplitWeapons[componentWeapon.Name].Add("RT", 0);
                                        dicLargeSplitWeapons[componentWeapon.Name].Add("LT", 0);
                                        dicLargeSplitWeapons[componentWeapon.Name].Add("CT", 0);
                                    }
                                    string sLocation = null;
                                    string[] sValidLocations = new string[] { "RA", "LA", "RT", "LT", "CT" };
                                    foreach (string sCurLocation in sValidLocations)
                                        if (Utilities.IsSynonymFor(sCurLocation, bmhl.Name))
                                        {
                                            sLocation = sCurLocation;
                                        }

                                    if (sLocation == null)
                                    {
                                        throw new Exception($"Large weapon partially placed in invalid location ({bmhl.Name})");
                                    }

                                    if (sLocation == "RA") sLocation = "RT"; if (sLocation == "LA") sLocation = "LT";

                                    dicLargeSplitWeapons[componentWeapon.Name][sLocation]+=iSlots;
                                }
                            }

                        }
                    }
                


                   
                }



            }

            if(dicLargeSplitWeapons.Count > 0)
            {
                foreach(ComponentWeapon componentWeapon in ComponentLibrary.Weapons.Values)
                {
                    if(dicLargeSplitWeapons.ContainsKey(componentWeapon.Name) && componentWeapon.CriticalSpaceMech >= 8) 
                    {
                        foreach(string sLocation in dicLargeSplitWeapons[componentWeapon.Name].Keys)
                        {
                            int iSlots = dicLargeSplitWeapons[componentWeapon.Name][sLocation];
                            int iInstances = iSlots / componentWeapon.CriticalSpaceMech.Value;
                            for (int j = 0; j < iInstances; j++)
                            {
                                ComponentWeapon currentWeapon = componentWeapon.Clone() as ComponentWeapon;
                                currentWeapon.Configure(design);
                                BattleMechHitLocation bmhl = null;
                                foreach (HitLocation location in design.HitLocations)
                                {
                                    if (Utilities.IsSynonymFor(sLocation, location.Name))
                                    {
                                        bmhl = location as BattleMechHitLocation;
                                    }
                                }
                                if (bmhl == null) throw new Exception("Invalid location for large weapon");
                                UnitComponent uc = new UnitComponent(currentWeapon, bmhl);
                                design.Components.Add(uc);
                                iSlots-=componentWeapon.CriticalSpaceMech.Value;
                            }
                            if(iSlots > 0)
                            {
                                if(!dicLargeSplitWeapons[componentWeapon.Name].ContainsKey("CT")) 
                                    dicLargeSplitWeapons[componentWeapon.Name].Add("CT", 0);
                                dicLargeSplitWeapons[componentWeapon.Name]["CT"] += iSlots;
                            }
                        }
                    }
                }
            }
        }
        public void Configure(Design design)
        {
            BattleMechDesign battleMechDesign = design as BattleMechDesign;
            //Not sure if we actually need to configure weapons based on design
            //Physical weapons already have their own configure protocol
            //TODO: Need to test more on Axman, Hatchman, and other mechs with 
            //melee weapons

        }

        static public List<ComponentWeapon> GetCanonicalWeapons()
        {

            
            List<ComponentWeapon> retval = new List<ComponentWeapon>();

            retval = ComponentLibrary.Weapons.Values.ToList();

            return retval;
            
        }

        public virtual double BVHeatPoints { 
            get 
            { 
                return Heat;
            } 
        }
    }
}
