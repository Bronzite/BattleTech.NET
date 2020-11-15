using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleTechNET.Common
{
    public class ComponentAmmunition:Component
    {
        public ComponentAmmunition() : base() { Tonnage = 1; }
        public ComponentAmmunition(string sName):this() { Name = sName; }
        public ComponentAmmunition(string sName, int iRounds): this(sName) { Rounds = iRounds; }
        public ComponentAmmunition(string sName, int iRounds, string sTechRating) : this(sName, iRounds) { TechRating = sTechRating; }
        public ComponentAmmunition(string sName, int iRounds, string sTechRating,TECHNOLOGY_BASE techBase) : this(sName, iRounds,sTechRating) { TechnologyBase = techBase; }
        public ComponentAmmunition(string sName, int iRounds, double dTonnage):this(sName,iRounds) { Tonnage = dTonnage; }
        public ComponentAmmunition(string sName, int iRounds, double dTonnage, string sTechRating) : this(sName, iRounds, dTonnage) { TechRating = sTechRating; }
        public ComponentAmmunition(string sName, int iRounds, double dTonnage, string sTechRating, TECHNOLOGY_BASE techBase) : this(sName, iRounds, dTonnage,sTechRating) { TechnologyBase = techBase; }




        public int Rounds { get; set; }

        public override Component CreateInstance()
        {
            return new ComponentAmmunition();
        }

        public override object Clone()
        {
            ComponentAmmunition retval = base.Clone() as ComponentAmmunition;
            retval.Rounds = Rounds;
            return retval;
        }

        public static List<ComponentAmmunition> GetCanonicalAmmunitions()
        {
            List<ComponentAmmunition> retval = new List<ComponentAmmunition>();
            retval.Add(new ComponentAmmunition("Machine Gun Ammo", 200,"A",TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Machine Gun Ammo Half", 100, 0.5, "A", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Light Machine Gun Ammo", 200, "A", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Light Machine Gun Ammo Half", 100, 0.5, "A", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Heavy Machine Gun Ammo", 200, "A", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Heavy Machine Gun Ammo Half", 100, 0.5, "A", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Autocannon/2 Ammo", 45, "C",TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Autocannon/5 Ammo", 20, "C", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Autocannon/10 Ammo", 10, "C", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Autocannon/20 Ammo", 5, "C", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LB 2-X AC Ammo", 45, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LB 5-X AC Ammo", 20, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LB 10-X AC Ammo", 10, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LB 20-X AC Ammo", 5, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Light Autocannon/2 Ammo", 45, "D", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Light Autocannon/5 Ammo", 20, "D", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Rotary Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Rotary Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Ultra Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Ultra Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Ultra Autocannon/10 Ammo", 10, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Ultra Autocannon/20 Ammo", 5, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("AP Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("AP Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("AP Autocannon/10 Ammo", 10, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("AP Autocannon/20 Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("AP Light Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("AP Light Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Flechette Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Flechette Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Flechette Autocannon/10 Ammo", 10, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Flechette Autocannon/20 Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Flechette Light Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Flechette Light Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Precision Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Precision Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Precision Autocannon/10 Ammo", 10, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Precision Autocannon/20 Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Precision Light Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Precision Light Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("AP Gauss Ammo", 40, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("Light Gauss Rifle Ammo", 16, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Gauss Rifle Ammo", 8, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Heavy Gauss Rifle Ammo", 4, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Vehicle Flamer Ammo", 20, "A", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Plasma Cannon Ammo", 10, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("Plasma Rifle Ammo", 10, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("ATM 3 Ammo", 20, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("ATM 6 Ammo", 10, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("ATM 9 Ammo", 7, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("ATM 12 Ammo", 5, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("LRM 5 Ammo", 24, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 10 Ammo", 12, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 15 Ammo", 8, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 20 Ammo", 6, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 3 LRM Ammo", 40, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 3 SRM Ammo", 33, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 5 LRM Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 5 LRM Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 7 LRM Ammo", 17, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 7 SRM Ammo", 14, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 9 LRM Ammo", 13, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 9 LRM Ammo", 11, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MRM 10 LRM Ammo", 24, "C", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MRM 20 LRM Ammo", 12, "C", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MRM 30 LRM Ammo", 8, "C", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MRM 40 LRM Ammo", 6, "C", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("SRM 2 Ammo", 50, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 4 Ammo", 25, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 6 Ammo", 15, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Streak SRM 2 Ammo", 50, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Streak SRM 4 Ammo", 25, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("Streak SRM 6 Ammo", 15, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("ATM 3 ER Ammo", 20, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("ATM 6 ER Ammo", 10, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("ATM 9 ER Ammo", 7, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("ATM 12 ER Ammo", 5, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("ATM 3 HE Ammo", 20, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("ATM 6 HE Ammo", 10, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("ATM 9 HE Ammo", 7, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("ATM 12 HE Ammo", 5, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("LRM 5 Ammo Artemis-capable", 24, "F", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 10 Ammo Artemis-capable", 12, "F", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 15 Ammo Artemis-capable", 8, "F", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 20 Ammo Artemis-capable", 6, "F", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 2 Ammo Artemis-capable", 50, "F", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 4 Ammo Artemis-capable", 25, "F", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 6 Ammo Artemis-capable", 15, "F", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 3 LRM Ammo Artemis-capable", 40, "F", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 3 SRM Ammo Artemis-capable", 33, "F", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 5 LRM Ammo Artemis-capable", 24, "F", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 5 LRM Ammo Artemis-capable", 20, "F", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 7 LRM Ammo Artemis-capable", 17, "F", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 7 SRM Ammo Artemis-capable", 14, "F", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 9 LRM Ammo Artemis-capable", 13, "F", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("MML 9 LRM Ammo Artemis-capable", 11, "F", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 5 Flare Ammo", 24, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 10 Flare Ammo", 12, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 15 Flare Ammo", 8, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 20 Flare Ammo", 6, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 5 Fragmentation Ammo", 24, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 10 Fragmentation Ammo", 12, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 15 Fragmentation Ammo", 8, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 20 Fragmentation Ammo", 6, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 2 Fragmentation Ammo", 50, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 4 Fragmentation Ammo", 25, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 6 Fragmentation Ammo", 15, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 3 LRM Fragmentation Ammo", 40, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 3 SRM Fragmentation Ammo", 33, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 5 LRM Fragmentation Ammo", 24, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 5 LRM Fragmentation Ammo", 20, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 7 LRM Fragmentation Ammo", 17, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 7 SRM Fragmentation Ammo", 14, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 9 LRM Fragmentation Ammo", 13, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 9 LRM Fragmentation Ammo", 11, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 2 Harpoon Ammo", 50, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 4 Harpoon Ammo", 25, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 6 Harpoon Ammo", 15, "D", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 5 Incendiary Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 10 Incendiary Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 15 Incendiary Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 20 Incendiary Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("SRM 2 Inferno Ammo", 50, "B", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 4 Inferno Ammo", 25, "B", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 6 Inferno Ammo", 15, "B", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 5 Semi-Guided Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 10 Semi-Guided Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 15 Semi-Guided Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 20 Semi-Guided Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 5 Swarm Ammo", 24, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 10 Swarm Ammo", 12, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 15 Swarm Ammo", 8, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 20 Swarm Ammo", 6, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 5 Swarm-I Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 10 Swarm-I Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 15 Swarm-I Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 20 Swarm-I Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("SRM 2 Tear Gas Ammo", 50, "B", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 4 Tear Gas Ammo", 25, "B", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 6 Tear Gas Ammo", 15, "B", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 5 Thunder Ammo", 24, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 10 Thunder Ammo", 12, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 15 Thunder Ammo", 8, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 20 Thunder Ammo", 6, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 5 Thunder-Augmented Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 10 Thunder-Augmented Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 15 Thunder-Augmented Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 20 Thunder-Augmented Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 5 Thunder-Inferno Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 10 Thunder-Inferno Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 15 Thunder-Inferno Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 20 Thunder-Inferno Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 5 Thunder-Vibrobomb Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 10 Thunder-Vibrobomb Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 15 Thunder-Vibrobomb Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 20 Thunder-Vibrobomb Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 5 Thunder-Active Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 10 Thunder-Active Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 15 Thunder-Active Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 20 Thunder-Active Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("LRM 5 Narc-Capable Ammo", 24, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 10 Narc-Capable Ammo", 12, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 15 Narc-Capable Ammo", 8, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 20 Narc-Capable Ammo", 6, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 2 Narc-Capable Ammo", 50, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 4 Narc-Capable Ammo", 25, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 6 Narc-Capable Ammo", 15, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 3 LRM Narc-Capable Ammo", 40, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 3 SRM Narc-Capable Ammo", 33, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 5 LRM Narc-Capable Ammo", 24, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 5 LRM Narc-Capable Ammo", 20, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 7 LRM Narc-Capable Ammo", 17, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 7 SRM Narc-Capable Ammo", 14, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 9 LRM Narc-Capable Ammo", 13, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("MML 9 LRM Narc-Capable Ammo", 11, "E", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 5 Torpedo Ammo", 24, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 10 Torpedo Ammo", 12, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 15 Torpedo Ammo", 8, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 20 Torpedo Ammo", 6, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 2 Torpedo Ammo", 50, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 4 Torpedo Ammo", 25, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("SRM 6 Torpedo Ammo", 15, "C", TECHNOLOGY_BASE.BOTH));
            retval.Add(new ComponentAmmunition("LRM 5 Multi-Purpose Ammo", 24, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("LRM 10 Multi-Purpose Ammo", 12, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("LRM 15 Multi-Purpose Ammo", 8, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("LRM 20 Multi-Purpose Ammo", 6, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("SRM 2 Multi-Purpose Ammo", 50, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("SRM 4 Multi-Purpose Ammo", 25, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("SRM 6 Multi-Purpose Ammo", 15, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("Anti-Missile System Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Anti-Missile System Ammo", 24, "F", TECHNOLOGY_BASE.CLAN));
            retval.Add(new ComponentAmmunition("Narc Missile Beacon Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Narc Missile Beacon Explosive Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Improved Narc Launcher Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Improved Narc Launcher ECM Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Improved Narc Launcher Explosive Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Improved Narc Launcher Haywire Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            retval.Add(new ComponentAmmunition("Improved Narc Launcher Nemesis Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
            return retval;
        }
    }

    
}
