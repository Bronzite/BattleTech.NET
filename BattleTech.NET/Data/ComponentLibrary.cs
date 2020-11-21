using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BattleTechNET.Data
{
    public class ComponentLibrary
    {
        static public List<ComponentAmmunition> Ammunitions
        {
            get
            {
                if (privateAmmunitionList == null)
                {
                    privateAmmunitionList = new List<ComponentAmmunition>();
                    privateAmmunitionList.Add(new ComponentAmmunition("Machine Gun Ammo", 200, "A", TECHNOLOGY_BASE.BOTH)
                        .AddAlias(new string[] {"IS Ammo MG - Full", "Clan Ammo MG - Full", "Clan Machine Gun Ammo - Full","ISMG Ammo (200)" }) as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Machine Gun Ammo Half", 100, 0.5, "A", TECHNOLOGY_BASE.BOTH)
                        .AddAlias(new string[] { "IS Machine Gun Ammo - Half", "IS Machine Gun - Half", "Clan Machine Gun Ammo - Half", "Clan Light Machine Gun Ammo - Half" }) as ComponentAmmunition); 
                    privateAmmunitionList.Add(new ComponentAmmunition("Light Machine Gun Ammo", 200, "A", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("ISLightMG Ammo (200)") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Light Machine Gun Ammo Half", 100, 0.5, "A", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("Heavy Machine Gun Ammo", 200, "A", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("Clan Heavy Machine Gun Ammo - Full") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Heavy Machine Gun Ammo Half", 100, 0.5, "A", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("Clan Heavy Machine Gun Ammo - Half") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Autocannon/2 Ammo", 45, "C", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS Ammo AC/2")
                        .AddAlias("ISAC2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Autocannon/5 Ammo", 20, "C", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS Ammo AC/5")
                        .AddAlias("ISAC5 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Autocannon/10 Ammo", 10, "C", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS Ammo AC/10")
                        .AddAlias("ISAC10 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Autocannon/20 Ammo", 5, "C", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS Ammo AC/20")
                        .AddAlias("ISAC20 Ammo") as ComponentAmmunition);

                    privateAmmunitionList.Add(new ComponentAmmunition("LB 2-X AC Ammo", 45, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS LB 2-X AC Ammo")
                        .AddAlias("ISLBXAC2 Ammo")
                        .AddAlias("Clan LB 2-X AC Ammo")
                        .AddAlias("CLLBXAC2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 5-X AC Ammo", 20, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS LB 5-X AC Ammo")
                        .AddAlias("ISLBXAC5 Ammo")
                        .AddAlias("Clan LB 5-X AC Ammo")
                        .AddAlias("CLLBXAC5 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 10-X AC Ammo", 10, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS LB 10-X AC Ammo")
                        .AddAlias("ISLBXAC10 Ammo")
                        .AddAlias("Clan LB 10-X AC Ammo")
                        .AddAlias("CLLBXAC10 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 20-X AC Ammo", 5, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS LB 20-X AC Ammo")
                        .AddAlias("ISLBXAC20 Ammo")
                        .AddAlias("Clan LB 20-X AC Ammo")
                        .AddAlias("CLLBXAC20 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 2-X AC Cluster Ammo", 45, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS LB 2-X AC Cluster Ammo")
                        .AddAlias("IS LB 2-X Cluster Ammo")
                        .AddAlias("ISLBXAC2 CL Ammo")
                        .AddAlias("Clan LB 2-X Cluster Ammo")
                        .AddAlias("CLLBXAC2 CL Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 5-X AC Cluster Ammo", 20, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS LB 5-X AC Cluster Ammo")
                        .AddAlias("IS LB 5-X Cluster Ammo")
                        .AddAlias("ISLBXAC5 CL Ammo")
                        .AddAlias("Clan LB 5-X Cluster Ammo")
                        .AddAlias("CLLBXAC5 CL Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 10-X AC Cluster Ammo", 10, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS LB 10-X AC Cluster Ammo")
                        .AddAlias("IS LB 10-X Cluster Ammo")
                        .AddAlias("ISLBXAC10 CL Ammo")
                        .AddAlias("Clan LB 10-X Cluster Ammo")
                        .AddAlias("CLLBXAC10 CL Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 20-X AC Cluster Ammo", 5, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS LB 20-X AC Cluster Ammo")
                        .AddAlias("IS LB 20-X Cluster Ammo")
                        .AddAlias("ISLBXAC20 CL Ammo")
                        .AddAlias("Clan LB 20-X Cluster Ammo")
                        .AddAlias("CLLBXAC20 CL Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Light Autocannon/2 Ammo", 45, "D", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS Ammo LAC/2")
                        .AddAlias("IS LAC2 Ammo")
                        .AddAlias("ISLAC2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Light Autocannon/5 Ammo", 20, "D", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS Ammo LAC/5")
                        .AddAlias("IS LAC5 Ammo")
                        .AddAlias("ISLAC5 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Rotary Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS Rotary AC/2 Ammo")
                        .AddAlias("ISRotaryAC2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Rotary Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS Rotary AC/5 Ammo")
                        .AddAlias("ISRotaryAC5 Ammo") as ComponentAmmunition);
                        
                    privateAmmunitionList.Add(new ComponentAmmunition("Ultra Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("CLUltraAC2 Ammo")
                        .AddAlias("IS Ultra AC/2 Ammo")
                        .AddAlias("ISUltraAC2 Ammo")
                        .AddAlias("Clan Ultra AC/2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Ultra Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("CLUltraAC5 Ammo")
                        .AddAlias("IS Ultra AC/5 Ammo")
                        .AddAlias("ISUltraAC5 Ammo")
                        .AddAlias("Clan Ultra AC/5 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Ultra Autocannon/10 Ammo", 10, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("CLUltraAC10 Ammo")
                        .AddAlias("IS Ultra AC/10 Ammo")
                        .AddAlias("ISUltraAC10 Ammo")
                        .AddAlias("Clan Ultra AC/10 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Ultra Autocannon/20 Ammo", 5, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("CLUltraAC20 Ammo")
                        .AddAlias("IS Ultra AC/20 Ammo")
                        .AddAlias("ISUltraAC20 Ammo")
                        .AddAlias("Clan Ultra AC/20 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Autocannon/10 Ammo", 10, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Autocannon/20 Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Light Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Light Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Flechette Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Flechette Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Flechette Autocannon/10 Ammo", 10, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Flechette Autocannon/20 Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Flechette Light Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Flechette Light Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Precision Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Precision Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Precision Autocannon/10 Ammo", 10, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Precision Autocannon/20 Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Precision Light Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Precision Light Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Gauss Ammo", 40, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("CLAPGaussRifle Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Light Gauss Rifle Ammo", 16, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS Light Gauss Ammo")
                        .AddAlias("ISLightGauss Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Gauss Rifle Ammo", 8, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("Clan Gauss Ammo")
                        .AddAlias("IS Gauss Ammo")
                        .AddAlias("ISGauss Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Heavy Gauss Rifle Ammo", 4, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("Clan Heavy Gauss Ammo")
                        .AddAlias("IS Heavy Gauss Ammo")
                        .AddAlias("ISHeavyGauss Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Hyper-Assault Gauss Rifle 20 Ammo", 6, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("HAG/20 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Hyper-Assault Gauss Rifle 30 Ammo", 4, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("HAG/30 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Hyper-Assault Gauss Rifle 40 Ammo", 3, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("HAG/40 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Vehicle Flamer Ammo", 20, "A", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("Plasma Cannon Ammo", 10, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("CLPlasmaCannonAmmo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Plasma Rifle Ammo", 10, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISPlasmaRifle Ammo")
                        .AddAlias("ISPlasmaRifleAmmo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 3 Ammo", 20, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("Clan Ammo ATM-3") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 6 Ammo", 10, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("Clan Ammo ATM-6") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 9 Ammo", 7, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("Clan Ammo ATM-9") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 12 Ammo", 5, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("Clan Ammo ATM-12") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Ammo", 24, "C", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo LRM-5")
                        .AddAlias("ISLRM5 Ammo")
                        .AddAlias("Clan Ammo LRM-5")
                        .AddAlias("CLLRM5 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Ammo", 12, "C", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo LRM-10")
                        .AddAlias("ISLRM10 Ammo")
                        .AddAlias("Clan Ammo LRM-10")
                        .AddAlias("CLLRM10 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Ammo", 8, "C", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo LRM-15")
                        .AddAlias("ISLRM15 Ammo")
                        .AddAlias("Clan Ammo LRM-15")
                        .AddAlias("CLLRM15 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Ammo", 6, "C", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo LRM-20")
                        .AddAlias("Clan Ammo LRM-20")
                        .AddAlias("ISLRM20 Ammo")
                        .AddAlias("CLLRM20 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 LRM Ammo", 40, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML3 LRM Ammo")
                        .AddAlias("IS Ammo MML-3 LRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 SRM Ammo", 33, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML3 SRM Ammo")
                        .AddAlias("IS Ammo MML-3 SRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML5 LRM Ammo")
                        .AddAlias("IS Ammo MML-5 LRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML5 SRM Ammo")
                        .AddAlias("IS Ammo MML-5 SRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 LRM Ammo", 17, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML7 LRM Ammo")
                        .AddAlias("IS Ammo MML-7 LRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 SRM Ammo", 14, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML7 SRM Ammo")
                        .AddAlias("IS Ammo MML-7 SRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Ammo", 13, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML9 LRM Ammo")
                        .AddAlias("IS Ammo MML-9 LRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Ammo", 11, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML9 SRM Ammo")
                        .AddAlias("IS Ammo MML-9 SRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MRM 10 Ammo", 24, "C", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS MRM 10 Ammo")
                        .AddAlias("ISMRM10 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MRM 20 Ammo", 12, "C", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS MRM 20 Ammo")
                        .AddAlias("ISMRM20 Ammo") as ComponentAmmunition); ;
                    privateAmmunitionList.Add(new ComponentAmmunition("MRM 30 Ammo", 8, "C", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS MRM 30 Ammo")
                        .AddAlias("ISMRM30 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MRM 40 Ammo", 6, "C", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS MRM 40 Ammo")
                        .AddAlias("ISMRM40 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Ammo", 50, "C", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("Clan Ammo SRM-2")
                        .AddAlias("IS Ammo SRM-2")
                        .AddAlias("ISSRM2 Ammo")
                        .AddAlias("CLSRM2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Ammo", 25, "C", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("Clan Ammo SRM-4")
                        .AddAlias("IS Ammo SRM-4")
                        .AddAlias("ISSRM4 Ammo")
                        .AddAlias("CLSRM4 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Ammo", 15, "C", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("Clan Ammo SRM-6")
                        .AddAlias("IS Ammo SRM-6")
                        .AddAlias("ISSRM6 Ammo")
                        .AddAlias("CLSRM6 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Streak SRM 2 Ammo", 50, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("Clan Ammo Streak SRM-2")
                        .AddAlias("Clan Ammo Streak SRM 2")
                        .AddAlias("IS Ammo Streak SRM-2")
                        .AddAlias("ISStreakSRM2 Ammo")
                        .AddAlias("IS Streak SRM 2 Ammo")
                        .AddAlias("Clan Streak SRM 2 Ammo")
                        .AddAlias("CLStreakSRM2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Streak SRM 4 Ammo", 25, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("Clan Ammo Streak SRM-4")
                        .AddAlias("Clan Ammo Streak SRM 4")
                        .AddAlias("IS Ammo Streak SRM-4")
                        .AddAlias("IS Streak SRM 4 Ammo")
                        .AddAlias("ISStreakSRM4 Ammo")
                        .AddAlias("Clan Streak SRM 4 Ammo")
                        .AddAlias("CLStreakSRM4 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Streak SRM 6 Ammo", 15, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("Clan Ammo Streak SRM-6")
                        .AddAlias("Clan Ammo Streak SRM 6")
                        .AddAlias("IS Ammo Streak SRM-6")
                        .AddAlias("IS Streak SRM 6 Ammo")
                        .AddAlias("ISStreakSRM6 Ammo")
                        .AddAlias("Clan Streak SRM 6 Ammo")
                        .AddAlias("CLStreakSRM6 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 3 ER Ammo", 20, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("Clan Ammo ATM-3 ER") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 6 ER Ammo", 10, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("Clan Ammo ATM-6 ER") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 9 ER Ammo", 7, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("Clan Ammo ATM-9 ER") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 12 ER Ammo", 5, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("Clan Ammo ATM-12 ER") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 3 HE Ammo", 20, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("Clan Ammo ATM-3 HE") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 6 HE Ammo", 10, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("Clan Ammo ATM-6 HE") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 9 HE Ammo", 7, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("Clan Ammo ATM-9 HE") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 12 HE Ammo", 5, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("Clan Ammo ATM-12 HE") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Ammo Artemis-capable", 24, "F", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo LRM-5 Artemis-capable")
                        .AddAlias("Clan Ammo LRM-5 (Clan) Artemis-capable")
                        .AddAlias("ISLRM5 Ammo Artemis-capable")
                        .AddAlias("CLLRM5 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Ammo Artemis-capable", 12, "F", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo LRM-10 Artemis-capable")
                        .AddAlias("Clan Ammo LRM-10 (Clan) Artemis-capable")
                        .AddAlias("ISLRM10 Ammo Artemis-capable")
                        .AddAlias("CLLRM10 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Ammo Artemis-capable", 8, "F", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo LRM-15 Artemis-capable")
                        .AddAlias("Clan Ammo LRM-15 (Clan) Artemis-capable")
                        .AddAlias("ISLRM15 Ammo Artemis-capable")
                        .AddAlias("CLLRM15 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Ammo Artemis-capable", 6, "F", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo LRM-20 Artemis-capable")
                        .AddAlias("Clan Ammo LRM-20 (Clan) Artemis-capable")
                        .AddAlias("ISLRM20 Ammo Artemis-capable")
                        .AddAlias("CLLRM20 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Ammo Artemis-capable", 50, "F", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo SRM-2 Artemis-capable")
                        .AddAlias("Clan Ammo SRM-2 (Clan) Artemis-capable")
                        .AddAlias("ISSRM2 Ammo Artemis-capable")
                        .AddAlias("CLSRM2 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Ammo Artemis-capable", 25, "F", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo SRM-4 Artemis-capable")
                        .AddAlias("Clan Ammo SRM-4 (Clan) Artemis-capable")
                        .AddAlias("ISSRM4 Ammo Artemis-capable")
                        .AddAlias("CLSRM4 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Ammo Artemis-capable", 15, "F", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo SRM-6 Artemis-capable")
                        .AddAlias("Clan Ammo SRM-6 (Clan) Artemis-capable")
                        .AddAlias("ISSRM6 Ammo Artemis-capable")
                        .AddAlias("CLSRM6 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 LRM Ammo Artemis-capable", 40, "F", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML3 LRM Ammo Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 SRM Ammo Artemis-capable", 33, "F", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML3 SRM Ammo Artemis-capable") as ComponentAmmunition);


                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Ammo Artemis-capable", 24, "F", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML5 LRM Ammo Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Ammo Artemis-capable", 20, "F", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML5 SRM Ammo Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 LRM Ammo Artemis-capable", 17, "F", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML7 LRM Ammo Artemis-capable") as ComponentAmmunition);

                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 SRM Ammo Artemis-capable", 14, "F", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML7 SRM Ammo Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Ammo Artemis-capable", 13, "F", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML9 LRM Ammo Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Ammo Artemis-capable", 11, "F", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISMML9 SRM Ammo Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Flare Ammo", 24, "C", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Flare Ammo", 12, "C", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Flare Ammo", 8, "C", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Flare Ammo", 6, "C", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Fragmentation Ammo", 24, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Fragmentation Ammo", 12, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Fragmentation Ammo", 8, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Fragmentation Ammo", 6, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Fragmentation Ammo", 50, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Fragmentation Ammo", 25, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Fragmentation Ammo", 15, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 LRM Fragmentation Ammo", 40, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 SRM Fragmentation Ammo", 33, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Fragmentation Ammo", 24, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Fragmentation Ammo", 20, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 LRM Fragmentation Ammo", 17, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 SRM Fragmentation Ammo", 14, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Fragmentation Ammo", 13, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Fragmentation Ammo", 11, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Harpoon Ammo", 50, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Harpoon Ammo", 25, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Harpoon Ammo", 15, "D", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Incendiary Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Incendiary Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Incendiary Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Incendiary Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Inferno Ammo", 50, "B", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Inferno Ammo", 25, "B", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Inferno Ammo", 15, "B", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Semi-Guided Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Semi-Guided Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Semi-Guided Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Semi-Guided Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Swarm Ammo", 24, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Swarm Ammo", 12, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Swarm Ammo", 8, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Swarm Ammo", 6, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Swarm-I Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Swarm-I Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Swarm-I Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Swarm-I Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Tear Gas Ammo", 50, "B", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Tear Gas Ammo", 25, "B", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Tear Gas Ammo", 15, "B", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Thunder Ammo", 24, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Thunder Ammo", 12, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Thunder Ammo", 8, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Thunder Ammo", 6, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Thunder-Augmented Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Thunder-Augmented Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Thunder-Augmented Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Thunder-Augmented Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Thunder-Inferno Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Thunder-Inferno Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Thunder-Inferno Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Thunder-Inferno Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Thunder-Vibrobomb Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Thunder-Vibrobomb Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Thunder-Vibrobomb Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Thunder-Vibrobomb Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Thunder-Active Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Thunder-Active Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Thunder-Active Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Thunder-Active Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Narc-Capable Ammo", 24, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo LRM-5 Narc-capable")
                        .AddAlias("ISLRM5 Ammo Narc-capable")
                        .AddAlias("Clan Ammo LRM-5 (Clan) Narc-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Narc-Capable Ammo", 12, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo LRM-10 Narc-capable")
                        .AddAlias("ISLRM10 Ammo Narc-capable")
                        .AddAlias("Clan Ammo LRM-10 (Clan) Narc-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Narc-Capable Ammo", 8, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo LRM-15 Narc-capable")
                        .AddAlias("ISLRM15 Ammo Narc-capable")
                        .AddAlias("Clan Ammo LRM-15 (Clan) Narc-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Narc-Capable Ammo", 6, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo LRM-20 Narc-capable")
                        .AddAlias("ISLRM20 Ammo Narc-capable")
                        .AddAlias("Clan Ammo LRM-20 (Clan) Narc-capable") as ComponentAmmunition);

                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Narc-Capable Ammo", 50, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo SRM-2 Narc-capable")
                        .AddAlias("ISSRM2 Ammo Narc-capable")
                        .AddAlias("Clan Ammo SRM-2 (Clan) Narc-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Narc-Capable Ammo", 25, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo SRM-4 Narc-capable")
                        .AddAlias("ISSRM4 Ammo Narc-capable")
                        .AddAlias("Clan Ammo SRM-4 (Clan) Narc-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Narc-Capable Ammo", 15, "E", TECHNOLOGY_BASE.BOTH)
                        .AddAlias("IS Ammo SRM-6 Narc-capable")
                        .AddAlias("ISSRM6 Ammo Narc-capable")
                        .AddAlias("Clan Ammo SRM-6 (Clan) Narc-capable") as ComponentAmmunition);

                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 LRM Narc-Capable Ammo", 40, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 SRM Narc-Capable Ammo", 33, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Narc-Capable Ammo", 24, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Narc-Capable Ammo", 20, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 LRM Narc-Capable Ammo", 17, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 SRM Narc-Capable Ammo", 14, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Narc-Capable Ammo", 13, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Narc-Capable Ammo", 11, "E", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Torpedo Ammo", 24, "C", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Torpedo Ammo", 12, "C", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Torpedo Ammo", 8, "C", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Torpedo Ammo", 6, "C", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Torpedo Ammo", 50, "C", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Torpedo Ammo", 25, "C", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Torpedo Ammo", 15, "C", TECHNOLOGY_BASE.BOTH));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Multi-Purpose Ammo", 24, "F", TECHNOLOGY_BASE.CLAN));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Multi-Purpose Ammo", 12, "F", TECHNOLOGY_BASE.CLAN));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Multi-Purpose Ammo", 8, "F", TECHNOLOGY_BASE.CLAN));
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Multi-Purpose Ammo", 6, "F", TECHNOLOGY_BASE.CLAN));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Multi-Purpose Ammo", 50, "F", TECHNOLOGY_BASE.CLAN));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Multi-Purpose Ammo", 25, "F", TECHNOLOGY_BASE.CLAN));
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Multi-Purpose Ammo", 15, "F", TECHNOLOGY_BASE.CLAN));
                    privateAmmunitionList.Add(new ComponentAmmunition("Anti-Missile System Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISAMS Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Anti-Missile System Ammo", 24, "F", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("CLAMS Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Narc Missile Beacon Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISNarc Pods") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Narc Missile Beacon Ammo", 6, "E", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("CLNarc Pods") as ComponentAmmunition);  //TODO: NO REFERENCE FOUND FOR THIS, EXISTENCE IMPLICIT
                    privateAmmunitionList.Add(new ComponentAmmunition("Narc Missile Beacon Explosive Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Improved Narc Launcher Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("IS Ammo iNarc")
                        .AddAlias("ISiNarc Pods") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Improved Narc Launcher ECM Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Improved Narc Launcher Explosive Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Improved Narc Launcher Haywire Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Improved Narc Launcher Nemesis Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE));
                    privateAmmunitionList.Add(new ComponentAmmunition("Arrow IV Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISArrowIV Ammo") as ComponentAmmunition
                        );
                    privateAmmunitionList.Add(new ComponentAmmunition("Arrow IV Ammo", 5, "E", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("CLArrowIV Ammo") as ComponentAmmunition
                        );
                    privateAmmunitionList.Add(new ComponentAmmunition("Arrow IV Homing Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        .AddAlias("ISArrowIV Homing Ammo") as ComponentAmmunition
                        );
                    privateAmmunitionList.Add(new ComponentAmmunition("Arrow IV Homing Ammo", 5, "E", TECHNOLOGY_BASE.CLAN)
                        .AddAlias("CLArrowIV Homing Ammo") as ComponentAmmunition
                        );
                    privateAmmunitionList.Add(new ComponentAmmunition("Taser Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Thunderbolt 5 Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Thunderbolt 10 Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Thunderbolt 15 Ammo", 4, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Thunderbolt 20 Ammo", 3, "E", TECHNOLOGY_BASE.INNERSPHERE)
                        as ComponentAmmunition);
                }
                return privateAmmunitionList;
            }
        }

        static private List<ComponentAmmunition> privateAmmunitionList = null;

        //TODO: Base Costs are wrong
        static public Dictionary<string, ComponentWeapon> Weapons = new System.Collections.Generic.Dictionary<string, ComponentWeapon>()
        {
            {"LRM 5",new ComponentWeapon() //TM341
            {
                Name = "LRM 5",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                AeroDamage = 3,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 24,
                Tonnage = 2,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ContributesToTargetingComputerMass=false,


            }
            .AddAlias("LRM 5")
            .AddAlias("LRM/5")
            .AddAlias("LRM5")
            .AddAlias("ISLRM5") as ComponentWeapon
            },
            {"LRM 10",new ComponentWeapon() //TM341
            {
                Name = "LRM 10",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 6,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 12,
                Tonnage = 5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }.AddAlias("LRM 10")
            .AddAlias("LRM/10")
            .AddAlias("LRM10")
            .AddAlias("ISLRM10") as ComponentWeapon
            },
            {"LRM 15",new ComponentWeapon() //TM341
            {
                Name = "LRM 15",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 9,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 8,
                Tonnage = 7,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }.AddAlias("LRM 15")
            .AddAlias("LRM/15")
            .AddAlias("LRM15")
            .AddAlias("ISLRM15") as ComponentWeapon
            },
            {"LRM 20",new ComponentWeapon() //TM341
            {
                Name = "LRM 20",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                AeroDamage = 12,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 6,
                Tonnage = 10,
                CriticalSpaceMech = 5,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }.AddAlias("LRM 20")
            .AddAlias("LRM/20")
            .AddAlias("LRM20")
            .AddAlias("ISLRM20") as ComponentWeapon
            },
            {"Clan LRM 5",new ComponentWeapon() //TM343
            {
                Name = "LRM 5",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                AeroDamage = 3,
                MinimumRange = 0,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 24,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }.AddAlias("LRM 5")
            .AddAlias("LRM/5")
            .AddAlias("LRM5")
            .AddAlias("CLLRM5") as ComponentWeapon
            },
            {"Clan LRM 10",new ComponentWeapon() //TM343
            {
                Name = "LRM 10",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 6,
                MinimumRange = 0,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 12,
                Tonnage = 2.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }.AddAlias("LRM 10")
            .AddAlias("LRM/10")
            .AddAlias("LRM10")
            .AddAlias("ISLRM10") as ComponentWeapon
            },
            {"Clan LRM 15",new ComponentWeapon() //TM343
            {
                Name = "LRM 15",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 9,
                MinimumRange = 0,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 8,
                Tonnage = 3.5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }.AddAlias("LRM 15")
            .AddAlias("LRM/15")
            .AddAlias("LRM15")
            .AddAlias("CLLRM15") as ComponentWeapon
            },
            {"Clan LRM 20",new ComponentWeapon() //TM341
            {
                Name = "LRM 20",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                AeroDamage = 12,
                MinimumRange = 0,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 6,
                Tonnage = 5,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("LRM 20")
            .AddAlias("LRM/20")
            .AddAlias("LRM20")
            .AddAlias("CLLRM20") as ComponentWeapon
            },
            {"Autocannon 2",new ComponentWeapon() //TM341
            {
                Name = "Autocannon 2",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 4,
                ShortRange = 8,
                MediumRange = 16,
                LongRange = 24,
                AmmoPerTon = 45,
                Tonnage = 6,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("AC2")
            .AddAlias("AC/2")
            .AddAlias("Autocannon/2")
            .AddAlias("ISAC2") as ComponentWeapon
            },
            {"Autocannon 5",new ComponentWeapon() //TM341
            {
                Name = "Autocannon 5",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 5,
                AeroDamage = 5,
                MinimumRange = 3,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 20,
                Tonnage = 8,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1, //TODO: This seems like it should be 4
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("AC5")
            .AddAlias("AC/5")
            .AddAlias("Autocannon/5")
            .AddAlias("ISAC5") as ComponentWeapon
            },
              {"Autocannon 10",new ComponentWeapon() //TM341
            {
                Name = "Autocannon 10",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 10,
                AeroDamage = 10,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 10,
                Tonnage = 12,
                CriticalSpaceMech = 7,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 7,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
               .AddAlias("AC10")
               .AddAlias("AC/10")
               .AddAlias("Autocannon/10")
               .AddAlias("ISAC10") as ComponentWeapon
            },
            {"Autocannon 20",new ComponentWeapon() //TM341
            {
                Name = "Autocannon 20",
                BaseCost = 20000,
                Heat = 7,
                AeroHeat = 7,
                Damage = 20,
                AeroDamage = 20,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 5,
                Tonnage = 14,
                CriticalSpaceMech = 10,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 10,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("AC20")
            .AddAlias("AC/20")
            .AddAlias("Autocannon/20")
            .AddAlias("ISAC20") as ComponentWeapon
            },
            {"Small Laser",new ComponentWeapon() //TM341
            {
                Name = "Small Laser",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 3,
                AeroDamage = 3,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 0,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("SLaser")
            .AddAlias("ISSmallLaser") as ComponentWeapon
            },
            {"Medium Laser",new ComponentWeapon() //TM341
            {
                Name = "Medium Laser",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 5,
                AeroDamage = 5,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 0,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
                        .AddAlias("MLaser")
            .AddAlias("ISMediumLaser") as ComponentWeapon
            },
             {"Large Laser",new ComponentWeapon() //TM341
            {
                Name = "Large Laser",
                BaseCost = 20000,
                Heat = 8,
                AeroHeat = 8,
                Damage = 8,
                AeroDamage = 8,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 0,
                Tonnage = 5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5, //TODO: Seems like this should be 2.
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
                         .AddAlias("LLaser")
            .AddAlias("ISLargeLaser") as ComponentWeapon
            },
             {"Heavy Small Laser",new ComponentWeapon() //TM341
            {
                Name = "Heavy Small Laser",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 6,
                AeroDamage = 6,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 0,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            },
            {"Heavy Medium Laser",new ComponentWeapon() //TM341
            {
                Name = "Heavy Medium Laser",
                BaseCost = 20000,
                Heat = 7,
                AeroHeat = 7,
                Damage = 10,
                AeroDamage = 10,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 0,
                Tonnage = 1,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            },
             {"Heavy Large Laser",new ComponentWeapon() //TM341
            {
                Name = "Heavy Large Laser",
                BaseCost = 20000,
                Heat = 18,
                AeroHeat = 18,
                Damage = 16,
                AeroDamage = 16,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 0,
                Tonnage = 4,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            },
              {"PPC",new ComponentWeapon() //TM341
            {
                Name = "PPC",
                BaseCost = 20000,
                Heat = 10,
                AeroHeat = 10,
                Damage = 10,
                AeroDamage = 10,
                MinimumRange = 3,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 0,
                Tonnage = 7,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="D",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
              .AddAlias("Particle Cannon")
                .AddAlias("ISPPC") as ComponentWeapon
            },
            {"SRM 2",new ComponentWeaponClustered() //TM341
            {
                Name = "SRM 2",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 2,
                DamagePerMissile=2,
                SalvoSize=2,
                AeroDamage = 2,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 50,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("SRM/2")
                .AddAlias("SRM2")
                .AddAlias("ISSRM2") as ComponentWeapon
            },
            {"SRM 4",new ComponentWeaponClustered() //TM341
            {
                Name = "SRM 4",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 2,
                AeroDamage = 2,
                DamagePerMissile=2,
                SalvoSize=4,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 25,
                Tonnage = 2,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("SRM/4")
                .AddAlias("SRM4")
                .AddAlias("ISSRM4") as ComponentWeapon
            },
            {"SRM 6",new ComponentWeaponClustered() //TM341
            {
                Name = "SRM 6",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 2,
                AeroDamage = 8,
                DamagePerMissile=2,
                SalvoSize=6,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 15,
                Tonnage = 3,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }.AddAlias("SRM/6")
                .AddAlias("SRM6")
                .AddAlias("ISSRM6") as ComponentWeapon
            },
             {"SRM 2 (OS)",new ComponentWeaponClustered() //TM341
            {
                Name = "SRM 2 (OS)",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 0,
                DamagePerMissile=2,
                SalvoSize=2,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 0,
                Tonnage = 1.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
             .AddAlias("ISSRM2 (OS)") as ComponentWeapon
            },
            {"SRM 4 (OS)",new ComponentWeaponClustered() //TM341
            {
                Name = "SRM 4 (OS)",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 2,
                AeroDamage = 2,
                DamagePerMissile=2,
                SalvoSize=4,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 0,
                Tonnage = 2.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
    .AddAlias("ISSRM4 (OS)") as ComponentWeapon
            },
            {"SRM 6 (OS)",new ComponentWeaponClustered() //TM341
            {
                Name = "SRM 6 (OS)",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 2,
                AeroDamage = 8,
                DamagePerMissile=2,
                SalvoSize=6,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 0,
                Tonnage = 3.5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISSRM6 (OS)") as ComponentWeapon
            },
             {"Clan SRM 2",new ComponentWeaponClustered() //TM341
            {
                Name = "SRM 2",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 0,
                DamagePerMissile=2,
                SalvoSize=2,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 50,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
             .AddAlias("SRM/2")
                .AddAlias("SRM2")
                .AddAlias("CLSRM2") as ComponentWeapon
            },
            {"Clan SRM 4",new ComponentWeaponClustered() //TM341
            {
                Name = "SRM 4",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 2,
                AeroDamage = 2,
                DamagePerMissile=2,
                SalvoSize=4,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 25,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("SRM/4")
                .AddAlias("SRM4")
                .AddAlias("CLSRM4") as ComponentWeapon
            },
            {"Clan SRM 6",new ComponentWeaponClustered() //TM341
            {
                Name = "SRM 6",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 2,
                DamagePerMissile=2,
                SalvoSize=6,
                AeroDamage = 8,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 15,
                Tonnage = 1.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }.AddAlias("SRM/6")
                .AddAlias("SRM6")
                .AddAlias("CLSRM6") as ComponentWeapon
            },
             {"Machine Gun",new ComponentWeapon() //TM341
            {
                Name = "Machine Gun",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 200,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
             .AddAlias("MGun")
                .AddAlias("MG")
                .AddAlias("ISMachine Gun")
                .AddAlias("ISMG") as ComponentWeapon
             },
               {"Clan Machine Gun",new ComponentWeapon() //TM341
            {
                Name = "Machine Gun",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 200,
                Tonnage = 0.25,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN

            }
               .AddAlias("MGun")
                .AddAlias("MG")
                .AddAlias("CLMachine Gun")
                .AddAlias("CLMG") as ComponentWeapon
             },
               {"Clan Light Machine Gun",new ComponentWeapon() //TM341
            {
                Name = "Light Machine Gun",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 1,
                AeroDamage = 1,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 200,
                Tonnage = 0.25,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN

            }
             },
                    {"Light Machine Gun",new ComponentWeapon() //TM341
            {
                Name = "Light Machine Gun",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 1,
                AeroDamage = 1,
                MinimumRange = 0,
                ShortRange = 2,
                MediumRange = 4,
                LongRange = 6,
                AmmoPerTon = 200,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE

            }
                    .AddAlias("ISLightMG") as ComponentWeapon
             },
               {"Clan Heavy Machine Gun",new ComponentWeapon() //TM341
            {
                Name = "Heavy Machine Gun",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 3,
                AeroDamage = 3,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 2,
                AmmoPerTon = 100,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN

            }
             },
            {"Flamer",new ComponentWeapon() //TM341
            {
                Name = "Flamer",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 0,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISFlamer") as ComponentWeapon
            },
             {"Clan Flamer",new ComponentWeapon() //TM341
            {
                Name = "Flamer",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 0,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
             .AddAlias("CLFlamer") as ComponentWeapon
            },
                {"LB 2-X AC",new ComponentWeapon() //TM341
            {
                Name = "LB 2-X AC",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 4,
                ShortRange = 9,
                MediumRange = 18,
                LongRange = 27,
                AmmoPerTon = 45,
                Tonnage = 6,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.EXTREME,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }.AddAlias("ISLBXAC2") as ComponentWeapon
            },
                {"LB 5-X AC",new ComponentWeapon() //TM341
            {
                Name = "LB 5-X AC",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 5,
                AeroDamage = 3,
                MinimumRange = 3,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 20,
                Tonnage = 8,
                CriticalSpaceMech = 5,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
                .AddAlias("ISLBXAC5") as ComponentWeapon
            },
                {"LB 10-X AC",new ComponentWeapon() //TM341
            {
                Name = "LB 10-X AC",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 10,
                AeroDamage = 6,
                MinimumRange = 0,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 10,
                Tonnage = 11,
                CriticalSpaceMech = 6,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 6,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
                .AddAlias("ISLBXAC10") as ComponentWeapon
            },
                {"LB 20-X AC",new ComponentWeapon() //TM341
            {
                Name = "LB 20-X AC",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 20,
                AeroDamage = 12,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 8,
                LongRange = 12,
                AmmoPerTon = 5,
                Tonnage = 14,
                CriticalSpaceMech = 11,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 11,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
                .AddAlias("ISLBXAC20") as ComponentWeapon
            },
            {"Clan LB 2-X AC",new ComponentWeapon() //TM343
            {
                Name = "LB 2-X AC",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 4,
                ShortRange = 10,
                MediumRange = 20,
                LongRange = 30,
                AmmoPerTon = 45,
                Tonnage = 5,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.EXTREME,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("CLLBXAC2") as ComponentWeapon
            },
            {"Clan LB 5-X AC",new ComponentWeapon() //TM343
            {
                Name = "LB 5-X AC",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 5,
                AeroDamage = 3,
                MinimumRange = 3,
                ShortRange = 8,
                MediumRange = 15,
                LongRange = 24,
                AmmoPerTon = 20,
                Tonnage = 7,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("CLLBXAC5") as ComponentWeapon
            },
            {"Clan LB 10-X AC",new ComponentWeapon() //TM343
            {
                Name = "LB 10-X AC",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 10,
                AeroDamage = 6,
                MinimumRange = 0,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 10,
                Tonnage = 10,
                CriticalSpaceMech = 5,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("CLLBXAC10") as ComponentWeapon
            },
            {"Clan LB 20-X AC",new ComponentWeapon() //TM343
            {
                Name = "LB 20-X AC",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 20,
                AeroDamage = 12,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 8,
                LongRange = 12,
                AmmoPerTon = 5,
                Tonnage = 12,
                CriticalSpaceMech = 9,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 9,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("CLLBXAC20") as ComponentWeapon
            },
            {"ER Small Laser",new ComponentWeapon() //TM341
            {
                Name = "ER Small Laser",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 3,
                AeroDamage = 3,
                MinimumRange = 0,
                ShortRange = 2,
                MediumRange = 4,
                LongRange = 5,
                AmmoPerTon = 0,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISERSmallLaser") as ComponentWeapon
            },
            {"ER Medium Laser",new ComponentWeapon() //TM341
            {
                Name = "ER Medium Laser",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 5,
                AeroDamage = 5,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 8,
                LongRange = 12,
                AmmoPerTon = 0,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISERMediumLaser") as ComponentWeapon
            },
             {"ER Large Laser",new ComponentWeapon() //TM341
            {
                Name = "ER Large Laser",
                BaseCost = 20000,
                Heat = 12,
                AeroHeat = 12,
                Damage = 8,
                AeroDamage = 8,
                MinimumRange = 0,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 19,
                AmmoPerTon = 0,
                Tonnage = 5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
             .AddAlias("ISERLargeLaser") as ComponentWeapon
            },
              {"ER PPC",new ComponentWeapon() //TM341
            {
                Name = "ER PPC",
                BaseCost = 20000,
                Heat = 15,
                AeroHeat = 15,
                Damage = 10,
                AeroDamage = 10,
                MinimumRange = 0,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 23,
                AmmoPerTon = 0,
                Tonnage = 7,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
              .AddAlias("ISERPPC")
              .AddAlias("ER Particle Cannon") as ComponentWeapon
            },
                            {"Clan Micro Pulse Laser",new ComponentWeapon() //TM341
            {
                Name = "Micro Pulse Laser",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 3,
                AeroDamage = 3,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 0,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                ToHitModifier=-2
            }
            },
              {"Clan ER Micro Laser",new ComponentWeapon() //TM341
            {
                Name = "ER Micro Laser",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 4,
                AmmoPerTon = 0,
                Tonnage = 0.25,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            },
            {"Ultra Autocannon 2",new ComponentWeapon() //TM341
            {
                Name = "Ultra Autocannon 2",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 2,
                Damage = 2,
                AeroDamage = 3,
                MinimumRange = 3,
                ShortRange = 8,
                MediumRange = 17,
                LongRange = 25,
                AmmoPerTon = 45,
                Tonnage = 7,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.EXTREME,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("UAC2")
                .AddAlias("Ultra AC/2")
                .AddAlias("Ultra Autocannon/2")
                .AddAlias("ISUltraAC2") as ComponentWeapon
            },
            {"Ultra Autocannon 5",new ComponentWeapon() //TM341
            {
                Name = "Ultra Autocannon 5",
                BaseCost = 20000,
                Heat = 1, //TODO: Seems like this is wrong
                AeroHeat = 2,
                Damage = 5,
                AeroDamage = 7,
                MinimumRange = 2,
                ShortRange = 6,
                MediumRange = 13,
                LongRange = 20,
                AmmoPerTon = 20,
                Tonnage = 9,
                CriticalSpaceMech = 5,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("UAC5")
                .AddAlias("Ultra AC/5")
                .AddAlias("Ultra Autocannon/5")
                .AddAlias("ISUltraAC5") as ComponentWeapon
            },
              {"Ultra Autocannon 10",new ComponentWeapon() //TM341
            {
                Name = "Ultra Autocannon 10",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 8,
                Damage = 10,
                AeroDamage = 15,
                MinimumRange = 0,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 10,
                Tonnage = 13,
                CriticalSpaceMech = 7,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 7,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
              .AddAlias("UAC10")
                .AddAlias("Ultra AC/10")
                .AddAlias("Ultra Autocannon/10")
                .AddAlias("ISUltraAC10") as ComponentWeapon
            },
            {"Ultra Autocannon 20",new ComponentWeapon() //TM341
            {
                Name = "Ultra Autocannon 20",
                BaseCost = 20000,
                Heat = 8,
                AeroHeat = 16,
                Damage = 20,
                AeroDamage = 30,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 7,
                LongRange = 10,
                AmmoPerTon = 5,
                Tonnage = 15,
                CriticalSpaceMech = 10,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 10,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("UAC20")
                .AddAlias("Ultra AC/20")
                .AddAlias("Ultra Autocannon/20")
                .AddAlias("ISUltraAC20") as ComponentWeapon
            },
            {"Clan Ultra Autocannon 2",new ComponentWeapon() //TM341
            {
                Name = "Ultra Autocannon 2",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 2,
                Damage = 2,
                AeroDamage = 3,
                MinimumRange = 2,
                ShortRange = 9,
                MediumRange = 18,
                LongRange = 27,
                AmmoPerTon = 45,
                Tonnage = 5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.EXTREME,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("UAC2")
                .AddAlias("Ultra AC/2")
                .AddAlias("Ultra Autocannon/2")
                .AddAlias("CLUltraAC2") as ComponentWeapon
            },
            {"Clan Ultra Autocannon 5",new ComponentWeapon() //TM341
            {
                Name = "Ultra Autocannon 5",
                BaseCost = 20000,
                Heat = 1, //TODO: Seems like this is wrong
                AeroHeat = 2,
                Damage = 5,
                AeroDamage = 7,
                MinimumRange = 0,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 20,
                Tonnage = 7, //TechManual Errata 4.0 p.35
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("UAC5")
                .AddAlias("Ultra AC/5")
                .AddAlias("Ultra Autocannon/5")
                .AddAlias("CLUltraAC5") as ComponentWeapon
            },
              {"Clan Ultra Autocannon 10",new ComponentWeapon() //TM341
            {
                Name = "Ultra Autocannon 10",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 6,
                Damage = 10,
                AeroDamage = 15,
                MinimumRange = 0,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 10,
                Tonnage = 10,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
              .AddAlias("UAC10")
                .AddAlias("Ultra AC/10")
                .AddAlias("Ultra Autocannon/10")
                .AddAlias("CLUltraAC10") as ComponentWeapon
            },
            {"Clan Ultra Autocannon 20",new ComponentWeapon() //TM341
            {
                Name = "Ultra Autocannon 20",
                BaseCost = 20000,
                Heat = 7,
                AeroHeat = 14,
                Damage = 20,
                AeroDamage = 30,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 8,
                LongRange = 12,
                AmmoPerTon = 5,
                Tonnage = 12,
                CriticalSpaceMech = 8,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 8,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("UAC20")
                .AddAlias("Ultra AC/20")
                .AddAlias("Ultra Autocannon/20")
                .AddAlias("CLUltraAC20") as ComponentWeapon
            },
             {"Hatchet",new ComponentHatchet() //TM341
            {
                Name = "Hatchet",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 20,
                AeroDamage = 30,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 1,
                LongRange = 1,
                AmmoPerTon = 0,
                Tonnage = 7,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = int.MaxValue,
                CriticalSpaceSupportVehicle = int.MaxValue,
                CriticalSpaceFighters = int.MaxValue,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.EXTREME, //TODO: Need an NA AerospaceWeaponRange
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            },
             {"Sword",new ComponentSword() //TM341
            {
                Name = "Sword",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 20,
                AeroDamage = 30,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 1,
                LongRange = 1,
                AmmoPerTon = 0,
                Tonnage = 7,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = int.MaxValue,
                CriticalSpaceSupportVehicle = int.MaxValue,
                CriticalSpaceFighters = int.MaxValue,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.EXTREME, //TODO: Need an NA AerospaceWeaponRange
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            },
             {"LRM 5 + Artemis IV",new ComponentWeapon() //TM341
            {
                Name = "LRM 5 + Artemis IV",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                AeroDamage = 4,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 24,
                Tonnage = 3,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE



            }
             .AddAlias("LRM/5 + Artemis IV")
                .AddAlias("LRM5 + Artemis IV") as ComponentWeapon
            },
            {"LRM 10 + Artemis IV",new ComponentWeapon() //TM341
            {
                Name = "LRM 10 + Artemis IV",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 8,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 12,
                Tonnage = 6,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }.AddAlias("LRM/10 + Artemis IV")
                .AddAlias("LRM10 + Artemis IV") as ComponentWeapon
            },
            {"LRM 15 + Artemis IV",new ComponentWeapon() //TM341
            {
                Name = "LRM 15 + Artemis IV",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 12,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 8,
                Tonnage = 8,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }.AddAlias("LRM/15 + Artemis IV")
                .AddAlias("LRM15 + Artemis IV") as ComponentWeapon
            },
            {"LRM 20 + Artemis IV",new ComponentWeapon() //TM341
            {
                Name = "LRM 20 + Artemis IV",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                AeroDamage = 16,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 6,
                Tonnage = 11,
                CriticalSpaceMech = 6,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 6,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }.AddAlias("LRM/20 + Artemis IV")
                .AddAlias("LRM20 + Artemis IV") as ComponentWeapon
            },
               {"Small Pulse Laser",new ComponentWeapon() //TM341
            {
                Name = "Small Pulse Laser",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 3,
                AeroDamage = 3,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 0,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-2
            }
               .AddAlias("ISSmallPulseLaser") as ComponentWeapon
            },
            {"Medium Pulse Laser",new ComponentWeapon() //TM341
            {
                Name = "Medium Pulse Laser",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 6,
                AeroDamage = 6,
                MinimumRange = 0,
                ShortRange = 2,
                MediumRange = 4,
                LongRange = 6,
                AmmoPerTon = 0,
                Tonnage = 2,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-2
            }
            .AddAlias("ISMediumPulseLaser") as ComponentWeapon
            },
             {"Large Pulse Laser",new ComponentWeapon() //TM341
            {
                Name = "Large Pulse Laser",
                BaseCost = 20000,
                Heat = 10,
                AeroHeat = 10,
                Damage = 9,
                AeroDamage = 9,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 0,
                Tonnage = 7,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5, //TODO: Seems like this should be 2.
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-2
            }
             .AddAlias("ISLargePulseLaser") as ComponentWeapon
            },
             {"Clan Small Pulse Laser",new ComponentWeapon() //TM341
            {
                Name = "Small Pulse Laser",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 3,
                AeroDamage = 3,
                MinimumRange = 0,
                ShortRange = 2,
                MediumRange = 4,
                LongRange = 6,
                AmmoPerTon = 0,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                ToHitModifier=-2
            }
             .AddAlias("CLSmallPulseLaser") as ComponentWeapon
            },
            {"Clan Medium Pulse Laser",new ComponentWeapon() //TM341
            {
                Name = "Medium Pulse Laser",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 7,
                AeroDamage = 7,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 8,
                LongRange = 12,
                AmmoPerTon = 0,
                Tonnage = 2,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                ToHitModifier=-2
            }
            .AddAlias("CLMediumPulseLaser") as ComponentWeapon
            },
             {"Clan Large Pulse Laser",new ComponentWeapon() //TM341
            {
                Name = "Large Pulse Laser",
                BaseCost = 20000,
                Heat = 10,
                AeroHeat = 10,
                Damage = 10,
                AeroDamage = 10,
                MinimumRange = 0,
                ShortRange = 6,
                MediumRange = 14,
                LongRange = 20,
                AmmoPerTon = 0,
                Tonnage = 6,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2, //TODO: Seems like this should be 2.
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                ToHitModifier=-2
            }
             .AddAlias("CLLargePulseLaser") as ComponentWeapon
            },
            {"Light Autocannon 2",new ComponentWeapon() //TM341
            {
                Name = "Light Autocannon 2",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 0,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 45,
                Tonnage = 4,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="D",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("LAC2")
                .AddAlias("LAC/2")
                .AddAlias("Light Autocannon/2")
                .AddAlias("ISLAC2")
                .AddAlias("Light Auto Cannon/2") as ComponentWeapon
            },
            {"Light Autocannon 5",new ComponentWeapon() //TM341
            {
                Name = "Light Autocannon 5",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 5,
                AeroDamage = 5,
                MinimumRange = 3,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 20,
                Tonnage = 5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="D",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("LAC5")
                .AddAlias("LAC/5")
                .AddAlias("Light Autocannon/5")
                .AddAlias("ISLAC5")
                .AddAlias("Light Auto Cannon/5") as ComponentWeapon
            },
            {"Heavy PPC",new ComponentWeapon() //TM341
            {
                Name = "Heavy PPC",
                BaseCost = 20000,
                Heat = 15,
                AeroHeat = 15,
                Damage = 15,
                AeroDamage = 15,
                MinimumRange = 3,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 0,
                Tonnage = 10,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISHeavyPPC") as ComponentWeapon
            },
            {"Clan ER Small Laser",new ComponentWeapon() //TM341
            {
                Name = "ER Small Laser",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 5,
                AeroDamage = 5,
                MinimumRange = 0,
                ShortRange = 2,
                MediumRange = 4,
                LongRange = 5,
                AmmoPerTon = 0,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("CLERSmallLaser") as ComponentWeapon
            },
            {"Clan ER Medium Laser",new ComponentWeapon() //TM341
            {
                Name = "ER Medium Laser",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 7,
                AeroDamage = 7,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 0,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("CLERMediumLaser") as ComponentWeapon
            },
             {"Clan ER Large Laser",new ComponentWeapon() //TM341
            {
                Name = "ER Large Laser",
                BaseCost = 20000,
                Heat = 12,
                AeroHeat = 12,
                Damage = 10,
                AeroDamage = 10,
                MinimumRange = 0,
                ShortRange = 8,
                MediumRange = 15,
                LongRange = 25,
                AmmoPerTon = 0,
                Tonnage = 4,
                CriticalSpaceMech = 4, //TODO: Seems like this should be 2 (TM343)
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1, //TODO: Seems like this should be 2 (TM343)
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.EXTREME,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
             .AddAlias("CLERLargeLaser") as ComponentWeapon
            },
              {"Clan ER PPC",new ComponentWeapon() //TM341
            {
                Name = "ER PPC",
                BaseCost = 20000,
                Heat = 15,
                AeroHeat = 15,
                Damage = 15,
                AeroDamage = 15,
                MinimumRange = 0,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 23,
                AmmoPerTon = 0,
                Tonnage = 6,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
              .AddAlias("ER Particle Cannon")
              .AddAlias("CLERPPC") as ComponentWeapon
            },
              {"Light PPC",new ComponentWeapon() //TM341
            {
                Name = "Light PPC",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 5,
                AeroDamage = 5,
                MinimumRange = 3,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 0,
                Tonnage = 3,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
              .AddAlias("ISLightPPC") as ComponentWeapon
            },
                {"TAG",new ComponentWeapon() //TM341
            {
                Name = "TAG",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat =0,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 9,
                LongRange = 15,
                AmmoPerTon = 0,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM, //TODO: Need NA Aerospace Range
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
                .AddAlias("ISTAG") as ComponentWeapon
            },
                   {"Clan TAG",new ComponentWeapon() //TM341
            {
                Name = "TAG",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat =0,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 9,
                LongRange = 15,
                AmmoPerTon = 0,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM, //TODO: Need NA Aerospace Range
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
                   .AddAlias("Clan TAG") as ComponentWeapon
            },
                                      {"Clan Light TAG",new ComponentWeapon() //TM341
            {
                Name = "Clan Light TAG",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat =0,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 0,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.NA, //TODO: Need NA Aerospace Range
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("Light TAG") as ComponentWeapon
            },
                {"Small X-Pulse Laser",new ComponentWeapon() //TO408
            {
                Name = "Small X-Pulse Laser",
                BaseCost = 31000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 3,
                AeroDamage = 3,
                MinimumRange = 0,
                ShortRange = 2,
                MediumRange = 4,
                LongRange = 5,
                AmmoPerTon = 0,
                Tonnage = 1,
                ToHitModifier =-2,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            },
            {"Medium X-Pulse Laser",new ComponentWeapon() //TO408
            {
                Name = "Medium X-Pulse Laser",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 6,
                AeroDamage = 6,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 0,
                ToHitModifier = -2,
                Tonnage = 2,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            },
             {"Large X-Pulse Laser",new ComponentWeapon() //TO408
            {
                Name = "Large X-Pulse Laser",
                BaseCost = 20000,
                Heat = 14,
                AeroHeat = 14,
                Damage = 9,
                AeroDamage = 9,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 0,
                ToHitModifier=-2,
                Tonnage = 7,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            },
             {"Gauss Rifle",new ComponentWeapon() //TM341
            {
                Name = "Gauss Rifle",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 15,
                AeroDamage = 15,
                MinimumRange = 2,
                ShortRange = 7,
                MediumRange = 15,
                LongRange = 22,
                AmmoPerTon = 8,
                Tonnage = 15,
                CriticalSpaceMech = 7,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 7,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
             .AddAlias("ISGaussRifle") as ComponentWeapon
            },
             {"AP Gauss Rifle",new ComponentWeapon() //TM341
            {
                Name = "AP Gauss Rifle",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 3,
                AeroDamage = 3,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 40,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.POINTDEFENSE,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            },
            {"Hyper-Assault Gauss 20",new ComponentWeapon() //TM341
            {
                Name = "Hyper-Assault Gauss 20",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 20,
                AeroDamage = 16, //TODO: Range-based damage
                MinimumRange = 2,
                ShortRange = 8,
                MediumRange = 16,
                LongRange = 24,
                AmmoPerTon = 6,
                Tonnage = 10,
                CriticalSpaceMech = 6,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 6,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.BOTH
            }
            .AddAlias("HAG/20") as ComponentWeapon
            },
            {"Hyper-Assault Gauss 30",new ComponentWeapon() //TM341
            {
                Name = "Hyper-Assault Gauss 30",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 30,
                AeroDamage = 24, //TODO: Range-based damage
                MinimumRange = 2,
                ShortRange = 8,
                MediumRange = 16,
                LongRange = 24,
                AmmoPerTon = 4,
                Tonnage = 13,
                CriticalSpaceMech = 8,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 8,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.BOTH
            }
            .AddAlias("HAG/30") as ComponentWeapon
            },
            {"Hyper-Assault Gauss 40",new ComponentWeapon() //TM341
            {
                Name = "Hyper-Assault Gauss 40",
                BaseCost = 20000,
                Heat = 8,
                AeroHeat = 8,
                Damage = 40,
                AeroDamage = 32, //TODO: Range-based damage
                MinimumRange = 2,
                ShortRange = 8,
                MediumRange = 16,
                LongRange = 24,
                AmmoPerTon = 3,
                Tonnage = 16,
                CriticalSpaceMech = 10,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 10,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.BOTH
            }
            .AddAlias("HAG/40") as ComponentWeapon
            },
             {"Clan Gauss Rifle",new ComponentWeapon() //TM341
            {
                Name = "Gauss Rifle",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 15,
                AeroDamage = 15,
                MinimumRange = 2,
                ShortRange = 7,
                MediumRange = 15,
                LongRange = 22,
                AmmoPerTon = 8,
                Tonnage = 12,
                CriticalSpaceMech = 6,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 6,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
             .AddAlias("CLGaussRifle") as ComponentWeapon
            },
             {"Light Gauss Rifle",new ComponentWeapon() //TM341
            {
                Name = "Light Gauss Rifle",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 8,
                AeroDamage = 8,
                MinimumRange = 3,
                ShortRange = 8,
                MediumRange = 17,
                LongRange = 25,
                AmmoPerTon = 16,
                Tonnage = 12,
                CriticalSpaceMech = 5,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.EXTREME,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
             .AddAlias("ISLightGaussRifle") as ComponentWeapon
            },
             {"Heavy Gauss Rifle",new ComponentWeapon() //TM341
            {
                Name = "Heavy Gauss Rifle",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 25,
                AeroDamage = 25, //TODO: Damage fall-off weapon
                MinimumRange = 4,
                ShortRange = 6,
                MediumRange = 13,
                LongRange = 20,
                AmmoPerTon = 4,
                Tonnage = 18,
                CriticalSpaceMech = 11,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 11,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
             .AddAlias("ISHeavyGaussRifle") as ComponentWeapon
            },
              {"Anti-Missile System",new ComponentWeapon() //TM341
            {
                Name = "Anti-Missile System",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 0,
                MediumRange = 0,
                LongRange = 0,
                AmmoPerTon = 12,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.POINTDEFENSE,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
              .AddAlias("AMS")
              .AddAlias("ISAntiMissileSystem")
              .AddAlias("ISAMS") as ComponentWeapon
            },
                  {"Clan Anti-Missile System",new ComponentWeapon() //TM343
            {
                Name = "Anti-Missile System",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 0,
                MediumRange = 0,
                LongRange = 0,
                AmmoPerTon = 24,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.POINTDEFENSE,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
                  .AddAlias("AMS")
                  .AddAlias("CLAntiMissileSystem")
                  .AddAlias("CLAMS") as ComponentWeapon
            },
            {"Streak SRM 2",new ComponentWeapon() //TM341
            {
                Name = "Streak SRM 2",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 2,
                AeroDamage = 4,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 50,
                Tonnage = 1.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISStreakSRM2") as ComponentWeapon
            },
            {"Streak SRM 4",new ComponentWeapon() //TM341
            {
                Name = "Streak SRM 4",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 2,
                AeroDamage = 8,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 25,
                Tonnage = 3,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISStreakSRM4") as ComponentWeapon
            },
            {"Streak SRM 6",new ComponentWeapon() //TM341
            {
                Name = "Streak SRM 6",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 2,
                AeroDamage = 12,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 15,
                Tonnage = 4.5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISStreakSRM6") as ComponentWeapon
            },
             {"Clan Streak SRM 2",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak SRM 2",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 2,
                SalvoSize = 2,
                AeroDamage = 4,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 8,
                LongRange = 12,
                AmmoPerTon = 50,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
             .AddAlias("CLStreakSRM2") as ComponentWeapon
            },
            {"Clan Streak SRM 4",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak SRM 4",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 2,
                AeroDamage = 8,
                SalvoSize = 4,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 8,
                LongRange = 12,
                AmmoPerTon = 25,
                Tonnage = 2,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("CLStreakSRM4") as ComponentWeapon
            },
            {"Clan Streak SRM 6",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak SRM 6",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 2,
                AeroDamage = 12,
                SalvoSize = 6,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 8,
                LongRange = 12,
                AmmoPerTon = 15,
                Tonnage = 3,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("CLStreakSRM6") as ComponentWeapon
            },
            {"Streak SRM 2 (OS)",new ComponentWeapon() //TM341
            {
                Name = "Streak SRM 2 (OS)",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 2,
                AeroDamage = 4,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 0,
                Tonnage = 2,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            },
            {"Streak SRM 4 (OS)",new ComponentWeapon() //TM341
            {
                Name = "Streak SRM 4 (OS)",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 2,
                AeroDamage = 8,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 0,
                Tonnage = 3.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            },
            {"Streak SRM 6 (OS)",new ComponentWeapon() //TM341
            {
                Name = "Streak SRM 6 (OS)",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 2,
                AeroDamage = 12,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 0,
                Tonnage = 5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            },
             {"Clan Streak SRM 2 (OS)",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak SRM 2 (OS)",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 2,
                SalvoSize = 2,
                AeroDamage = 4,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 8,
                LongRange = 12,
                AmmoPerTon = 0,
                Tonnage = 1.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            },
            {"Clan Streak SRM 4 (OS)",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak SRM 4 (OS)",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 2,
                AeroDamage = 8,
                SalvoSize = 4,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 8,
                LongRange = 12,
                AmmoPerTon = 25,
                Tonnage = 2.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            },
            {"Clan Streak SRM 6 (OS)",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak SRM 6 (OS)",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 2,
                AeroDamage = 12,
                SalvoSize = 6,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 8,
                LongRange = 12,
                AmmoPerTon = 0,
                Tonnage = 3.5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            },
            {"Snub-Nose PPC",new ComponentWeapon() //TM341
            {
                Name = "Snub-Nose PPC",
                BaseCost = 20000,
                Heat = 10,
                AeroHeat = 10,
                Damage = 10, //TODO:Range-based Damage
                AeroDamage = 10,
                MinimumRange = 0,
                ShortRange = 9,
                MediumRange = 13,
                LongRange = 15,
                AmmoPerTon = 0,
                Tonnage = 6,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISSNPPC") as ComponentWeapon
            },
            {"ATM 3",new ComponentWeapon() //TM343
            {
                Name = "ATM 3",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 2,
                AeroDamage = 4,
                MinimumRange = 4,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 20,
                Tonnage = 1.5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            },
            {"ATM 6",new ComponentWeapon() //TM343
            {
                Name = "ATM 6",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 2,
                AeroDamage = 8,
                MinimumRange = 4,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 10,
                Tonnage = 3.5,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            },
            {"ATM 9",new ComponentWeapon() //TM343
            {
                Name = "ATM 9",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 2,
                AeroDamage = 10,
                MinimumRange = 4,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 7,
                Tonnage = 5,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            },
            {"ATM 12",new ComponentWeapon() //TM343
            {
                Name = "ATM 12",
                BaseCost = 20000,
                Heat = 8,
                AeroHeat = 8,
                Damage = 2,
                AeroDamage = 16,
                MinimumRange = 4,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 5,
                Tonnage = 7,
                CriticalSpaceMech = 5,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            },
            {"Rocket Launcher 10",new ComponentWeapon() //TM342
            {
                Name = "Rocket Launcher 10",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 1,
                AeroDamage = 6,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 11,
                LongRange = 18,
                LauncherType="OS",
                Tonnage = 0.5,
                CriticalSpaceMech =1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH
            }
            .AddAlias("ISRocketLauncher10") as ComponentWeapon
            },
             {"Rocket Launcher 15",new ComponentWeapon() //TM342
            {
                Name = "Rocket Launcher 15",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 9,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 9,
                LongRange = 15,
                LauncherType="OS",
                Tonnage = 1,
                CriticalSpaceMech =2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH
            }
             .AddAlias("ISRocketLauncher15") as ComponentWeapon
            },
            {"Rocket Launcher 20",new ComponentWeapon() //TM342
            {
                Name = "Rocket Launcher 20",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 12,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 7,
                LongRange = 12,
                LauncherType="OS",
                Tonnage = 1.5,
                CriticalSpaceMech =3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH
            }
            .AddAlias("ISRocketLauncher20") as ComponentWeapon
            },
            {"Arrow IV Missile",new ComponentArtillery() //TM342
            {
                Name = "Arrow IV Missile",
                BaseCost = 20000,
                Heat = 10,
                AeroHeat = 10,
                Damage = 20,
                AeroDamage = 0,
                ArtilleryRange = 8,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 7,
                LongRange = 12,
                AmmoPerTon = 5,
                Tonnage = 15,
                CriticalSpaceMech =15,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 15,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("Arrow IV")
            .AddAlias("ISArrowIVSystem") as ComponentWeapon
            },
            {"Clan Arrow IV Missile",new ComponentArtillery() //TM342
            {
                Name = "Arrow IV Missile",
                BaseCost = 20000,
                Heat = 10,
                AeroHeat = 10,
                Damage = 20,
                AeroDamage = 0,
                ArtilleryRange = 9,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 7,
                LongRange = 12,
                AmmoPerTon = 5,
                Tonnage = 12,
                CriticalSpaceMech =12,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 12,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("Arrow IV")
            .AddAlias("CLArrowIVSystem") as ComponentWeapon
            },
            {"Machine Gun Array",new ComponentMachineGunArray() //TM342
            {
                Name = "Machine Gun Array",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 0,
                AeroDamage = 0,

                MinimumRange = 0,
                ShortRange = 0,
                MediumRange = 0,
                LongRange = 0,
                AmmoPerTon = 0,
                Tonnage = 0.5,
                CriticalSpaceMech =1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISMGA")
                .AddAlias("ISLMGA")
                .AddAlias("Light Machine Gun Array")
                .AddAlias("Heavy Machine Gun Array") as ComponentWeapon
            },
            {"Clan Machine Gun Array",new ComponentMachineGunArray() //TM342
            {
                Name = "Machine Gun Array",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 0,
                AeroDamage = 0,

                MinimumRange = 0,
                ShortRange = 0,
                MediumRange = 0,
                LongRange = 0,
                AmmoPerTon = 0,
                Tonnage = 0.25,
                CriticalSpaceMech =1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("CLMGA")
                .AddAlias("Light Machine Gun Array")
                .AddAlias("Heavy Machine Gun Array") as ComponentWeapon
            },
            {"MML 3",new ComponentWeaponClustered() //TM342
            {//TODO: We need to build a multi-mode weapon class
                Name = "MML 3",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 0,
                AeroDamage = 0,
                SalvoSize=3,
                MinimumRange = 0,
                ShortRange = 0,
                MediumRange = 0,
                LongRange = 0,
                AmmoPerTon = 0,
                Tonnage = 1.5,
                CriticalSpaceMech =2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISMML3") as ComponentWeapon
            },
            {"MML 5",new ComponentWeaponClustered() //TM342
            {//TODO: We need to build a multi-mode weapon class
                Name = "MML 5",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 0,
                AeroDamage = 0,
                SalvoSize=5,
                MinimumRange = 0,
                ShortRange = 0,
                MediumRange = 0,
                LongRange = 0,
                AmmoPerTon = 0,
                Tonnage = 3,
                CriticalSpaceMech =3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISMML5") as ComponentWeapon
            },
            {"MML 7",new ComponentWeaponClustered() //TM342
            {//TODO: We need to build a multi-mode weapon class
                Name = "MML 7",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 0,
                AeroDamage = 0,
                SalvoSize=7,
                MinimumRange = 0,
                ShortRange = 0,
                MediumRange = 0,
                LongRange = 0,
                AmmoPerTon = 0,
                Tonnage = 4.5,
                CriticalSpaceMech =4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISMML7") as ComponentWeapon
            },
            {"MML 9",new ComponentWeaponClustered() //TM342
            {//TODO: We need to build a multi-mode weapon class
                Name = "MML 9",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 0,
                AeroDamage = 0,
                SalvoSize=9,
                MinimumRange = 0,
                ShortRange = 0,
                MediumRange = 0,
                LongRange = 0,
                AmmoPerTon = 0,
                Tonnage = 6,
                CriticalSpaceMech =5,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISMML9") as ComponentWeapon
            },
            {"Plasma Rifle",new ComponentWeapon() //TM341
            {
                Name = "Plasma Rifle",
                BaseCost = 20000,
                Heat = 10,
                AeroHeat = 10,
                Damage = 10,
                AeroDamage = 10,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 10,
                Tonnage = 6,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE



            }
            .AddAlias("ISPlasmaRifle") as ComponentWeapon
            },
            {"Plasma Cannon",new ComponentWeapon() //TM341
            {
                Name = "Plasma Cannon",
                BaseCost = 20000,
                Heat = 7,
                AeroHeat = 7,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 10,
                Tonnage = 3,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            .AddAlias("CLPlasmaCannon") as ComponentWeapon
            },
            {"MRM 10",new ComponentWeaponClustered() //TM342
            {
                Name = "MRM 10",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 6,
                SalvoSize=10,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 8,
                LongRange = 15,
                AmmoPerTon = 24,
                Tonnage = 3,
                CriticalSpaceMech =2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISMRM10") as ComponentWeapon
            },
            {"MRM 20",new ComponentWeaponClustered() //TM342
            {
                Name = "MRM 20",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                AeroDamage = 12,
                SalvoSize=20,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 8,
                LongRange = 15,
                AmmoPerTon = 12,
                Tonnage = 7,
                CriticalSpaceMech =3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISMRM20") as ComponentWeapon
            },
             {"MRM 30",new ComponentWeaponClustered() //TM342
            {
                Name = "MRM 30",
                BaseCost = 20000,
                Heat = 10,
                AeroHeat = 10,
                Damage = 1,
                AeroDamage = 18,
                SalvoSize=30,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 8,
                LongRange = 15,
                AmmoPerTon = 8,
                Tonnage = 10,
                CriticalSpaceMech =5,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
             .AddAlias("ISMRM30") as ComponentWeapon
            },
              {"MRM 40",new ComponentWeaponClustered() //TM342
            {
                Name = "MRM 40",
                BaseCost = 20000,
                Heat = 12,
                AeroHeat = 12,
                Damage = 1,
                AeroDamage = 24,
                SalvoSize=40,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 8,
                LongRange = 15,
                AmmoPerTon = 6,
                Tonnage = 12,
                CriticalSpaceMech =7,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 7,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
              .AddAlias("ISMRM40") as ComponentWeapon
            },
            {"Rotary AC/2",new ComponentWeaponClustered() //TM342
            {
                Name = "Rotary AC/2",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 6,
                Damage = 2,
                AeroDamage = 8,
                SalvoSize=6, //TODO: Selectable Salvo Size
                MinimumRange = 0,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 45,
                Tonnage = 8,
                CriticalSpaceMech =3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISRotaryAC2") as ComponentWeapon
            },
            {"Rotary AC/5",new ComponentWeaponClustered() //TM342
            {
                Name = "Rotary AC/5",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 6,
                Damage = 5,
                AeroDamage = 20,
                SalvoSize=6, //TODO: Selectable Salvo Size
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 20,
                Tonnage = 10,
                CriticalSpaceMech =6,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 6,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            .AddAlias("ISRotaryAC5") as ComponentWeapon
            },
            {"Narc Missile Beacon",new ComponentWeapon() //TM341
            {
                Name = "Narc Missile Beacon",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0, //TODO: Narc Aerospace Rules
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 6,
                Tonnage = 3,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
            }
            .AddAlias("Narc")
            .AddAlias("ISNarcBeacon") as ComponentWeapon
            },
                        {"Clan Narc Missile Beacon",new ComponentWeapon() //TM341
            {
                Name = "Narc Missile Beacon",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0, //TODO: Narc Aerospace Rules
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 6,
                Tonnage = 2,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
            }
                        .AddAlias("Narc") as ComponentWeapon
            },
            {"Improved Narc Launcher",new ComponentWeapon() //TM341
            {
                Name = "Improved Narc Launcher",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0, //TODO: Narc Aerospace Rules
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 9,
                LongRange = 15,
                AmmoPerTon = 4,
                Tonnage = 5,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
            }
            .AddAlias("ISImprovedNarc") as ComponentWeapon
            },
            {"Clan A-Pods",new ComponentAntiPersonnelPod() //TM341
            {
                Name = "A-Pod",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 0,
                MediumRange = 0,
                LongRange = 0,
                AmmoPerTon = 0,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = int.MaxValue,
                CriticalSpaceSupportVehicle = int.MaxValue,
                CriticalSpaceFighters = int.MaxValue,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }.AddAlias("CLAntiPersonnelPod") as ComponentWeapon
            },
            {"Clan B-Pod",new ComponentAntiPersonnelPod() //TM341
            {
                Name = "B-Pod",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 0,
                MediumRange = 0,
                LongRange = 0,
                AmmoPerTon = 0,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = int.MaxValue,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN
            }
            },
             {"Taser",new ComponentWeapon() //TO410
            {
                Name = "Taser",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                AeroDamage = 1,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 5,
                Tonnage = 4,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=1

            }
              .AddAlias("ISTaser")
              .AddAlias("Mech Taser") as ComponentWeapon
            },
              {"Thunderbolt 5",new ComponentWeapon() //TO410
            {
                Name = "Thunderbolt 5",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 5,
                AeroDamage = 5,
                MinimumRange = 5,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 12,
                Tonnage = 3,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
            }
              .AddAlias("ISThunderbolt5")
              .AddAlias("Thunderbolt5") as ComponentWeapon
            },
                {"Thunderbolt 10",new ComponentWeapon() //TO410
            {
                Name = "Thunderbolt 10",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 10,
                AeroDamage = 10,
                MinimumRange = 5,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 6,
                Tonnage = 7,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
            }
              .AddAlias("ISThunderbolt10")
              .AddAlias("Thunderbolt10") as ComponentWeapon
            },
                  {"Thunderbolt 15",new ComponentWeapon() //TO410
            {
                Name = "Thunderbolt 15",
                BaseCost = 20000,
                Heat = 7,
                AeroHeat = 7,
                Damage = 15,
                AeroDamage = 15,
                MinimumRange = 5,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 4,
                Tonnage = 11,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
            }
              .AddAlias("ISThunderbolt15")
              .AddAlias("Thunderbolt15") as ComponentWeapon
            },
                    {"Thunderbolt 20",new ComponentWeapon() //TO410
            {
                Name = "Thunderbolt 20",
                BaseCost = 20000,
                Heat = 8,
                AeroHeat = 8,
                Damage = 20,
                AeroDamage = 20,
                MinimumRange = 5,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 3,
                Tonnage = 15,
                CriticalSpaceMech = 5,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
            }
              .AddAlias("ISThunderbolt20")
              .AddAlias("Thunderbolt20") as ComponentWeapon
            },
                        {"M-Pod",new ComponentWeapon() //TO408
            {
                Name = "M-Pod",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 15, //TODO: Need Range damage
                AeroDamage = 15,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 0,
                Tonnage = 1,
                ToHitModifier = -1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
            }
              .AddAlias("MPod") as ComponentWeapon
            },
            {"Magshot",new ComponentWeapon() //TO407
            {
                Name = "Magshot",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 50,
                Tonnage = 0.5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
            }
              .AddAlias("ISMagshot")
              .AddAlias("ISGaussMagshot") as ComponentWeapon
            },
             {"Fluid Gun",new ComponentWeapon() //TO407
            {
                Name = "Fluid Gun",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 20,
                Tonnage = 2,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1, //TODO: Seems like this should be 2.
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot = true,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
            }
              .AddAlias("ISFluid Gun")
              .AddAlias("CLFluid Gun") as ComponentWeapon
            }
        };
    }
}
