﻿using BattleTechNET.Common;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace BattleTechNET.Data
{
    public class ComponentLibrary
    {
        //This stops the Ammunition list from getting loaded multiple
        //times if we're using many threaded calls (such as in the
        //testing suite.)
        static private SemaphoreSlim semaphoreAmmunitionLoad = new SemaphoreSlim(1);
        static public List<ComponentAmmunition> Ammunitions
        {
            get
            {
                semaphoreAmmunitionLoad.Wait(1);
                if (privateAmmunitionList == null)
                {

                    privateAmmunitionList = new List<ComponentAmmunition>();
                    privateAmmunitionList.Add(new ComponentAmmunition("Machine Gun Ammo", 200, "A", TECHNOLOGY_BASE.BOTH) { BV = 1 }
                        .AddAlias(new string[] { "IS Ammo MG - Full", "Clan Ammo MG - Full", "Clan Machine Gun Ammo - Full", "ISMG Ammo (200)" }) as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Machine Gun Ammo Half", 100, 0.5, "A", TECHNOLOGY_BASE.BOTH) { BV = 0.5 }
                        .AddAlias(new string[] { "IS Machine Gun Ammo - Half", "IS Machine Gun - Half", "Clan Machine Gun Ammo - Half", "Clan Light Machine Gun Ammo - Half" }) as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Light Machine Gun Ammo", 200, "A", TECHNOLOGY_BASE.BOTH) { BV = 1 }
                    .AddAlias("Clan Light Machine Gun Ammo - Full")
					.AddAlias("IS Light Machine Gun Ammo - Full")
                    .AddAlias("ISLightMG Ammo (200)") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Light Machine Gun Ammo Half", 100, 0.5, "A", TECHNOLOGY_BASE.BOTH) { BV = 0.5 }
                        .AddAlias("IS Light Machine Gun Ammo - Half") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Heavy Machine Gun Ammo", 200, "A", TECHNOLOGY_BASE.BOTH) { BV = 1 }
                        .AddAlias("Clan Heavy Machine Gun Ammo - Full") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Heavy Machine Gun Ammo Half", 100, 0.5, "A", TECHNOLOGY_BASE.BOTH) { BV = 0.5 }
                        .AddAlias("Clan Heavy Machine Gun Ammo - Half") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Autocannon/2 Ammo", 45, "C", TECHNOLOGY_BASE.INNERSPHERE) { BV = 5 }
                        .AddAlias("IS Ammo AC/2")
                        .AddAlias("ISAC2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Autocannon/5 Ammo", 20, "C", TECHNOLOGY_BASE.INNERSPHERE) { BV = 9 }
                        .AddAlias("IS Ammo AC/5")
                        .AddAlias("ISAC5 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Autocannon/10 Ammo", 10, "C", TECHNOLOGY_BASE.INNERSPHERE) { BV = 15 }
                        .AddAlias("IS Ammo AC/10")
                        .AddAlias("ISAC10 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Autocannon/20 Ammo", 5, "C", TECHNOLOGY_BASE.INNERSPHERE) { BV = 22 }
                        .AddAlias("IS Ammo AC/20")
                        .AddAlias("ISAC20 Ammo") as ComponentAmmunition);

                    privateAmmunitionList.Add(new ComponentAmmunition("LB 2-X AC Ammo", 45, "E", TECHNOLOGY_BASE.BOTH) { BV = 5 }
                        .AddAlias("IS LB 2-X AC Ammo")
                        .AddAlias("ISLBXAC2 Ammo")
                        .AddAlias("Clan LB 2-X AC Ammo")
                        .AddAlias("CLLBXAC2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 5-X AC Ammo", 20, "E", TECHNOLOGY_BASE.BOTH) { BV = 10 }
                        .AddAlias("IS LB 5-X AC Ammo")
                        .AddAlias("ISLBXAC5 Ammo")
                        .AddAlias("Clan LB 5-X AC Ammo")
                        .AddAlias("CLLBXAC5 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 10-X AC Ammo", 10, "E", TECHNOLOGY_BASE.BOTH) { BV = 19 }
                        .AddAlias("IS LB 10-X AC Ammo")
                        .AddAlias("ISLBXAC10 Ammo")
                        .AddAlias("Clan LB 10-X AC Ammo")
                        .AddAlias("CLLBXAC10 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 20-X AC Ammo", 5, "E", TECHNOLOGY_BASE.BOTH) { BV = 30 }
                        .AddAlias("IS LB 20-X AC Ammo")
                        .AddAlias("ISLBXAC20 Ammo")
                        .AddAlias("Clan LB 20-X AC Ammo")
                        .AddAlias("CLLBXAC20 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 2-X AC Cluster Ammo", 45, "E", TECHNOLOGY_BASE.BOTH) { BV = 5 }
                        .AddAlias("IS LB 2-X AC Cluster Ammo")
                        .AddAlias("IS LB 2-X Cluster Ammo")
                        .AddAlias("ISLBXAC2 CL Ammo")
                        .AddAlias("Clan LB 2-X Cluster Ammo")
                        .AddAlias("CLLBXAC2 CL Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 5-X AC Cluster Ammo", 20, "E", TECHNOLOGY_BASE.BOTH) { BV = 10 }
                        .AddAlias("IS LB 5-X AC Cluster Ammo")
                        .AddAlias("IS LB 5-X Cluster Ammo")
                        .AddAlias("ISLBXAC5 CL Ammo")
                        .AddAlias("Clan LB 5-X Cluster Ammo")
                        .AddAlias("CLLBXAC5 CL Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 10-X AC Cluster Ammo", 10, "E", TECHNOLOGY_BASE.BOTH) { BV = 19 }
                        .AddAlias("IS LB 10-X AC Cluster Ammo")
                        .AddAlias("IS LB 10-X Cluster Ammo")
                        .AddAlias("ISLBXAC10 CL Ammo")
                        .AddAlias("Clan LB 10-X Cluster Ammo")
                        .AddAlias("CLLBXAC10 CL Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LB 20-X AC Cluster Ammo", 5, "E", TECHNOLOGY_BASE.BOTH) { BV = 30 }
                        .AddAlias("IS LB 20-X AC Cluster Ammo")
                        .AddAlias("IS LB 20-X Cluster Ammo")
                        .AddAlias("ISLBXAC20 CL Ammo")
                        .AddAlias("Clan LB 20-X Cluster Ammo")
                        .AddAlias("CLLBXAC20 CL Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Light Autocannon/2 Ammo", 45, "D", TECHNOLOGY_BASE.INNERSPHERE) { BV = 4 }
                        .AddAlias("IS Ammo LAC/2")
                        .AddAlias("IS LAC2 Ammo")
                        .AddAlias("ISLAC2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Light Autocannon/5 Ammo", 20, "D", TECHNOLOGY_BASE.INNERSPHERE) { BV = 8 }
                        .AddAlias("IS Ammo LAC/5")
                        .AddAlias("IS LAC5 Ammo")
                        .AddAlias("ISLAC5 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Rotary Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 15 }
                        .AddAlias("IS Rotary AC/2 Ammo")
                        .AddAlias("ISRotaryAC2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Rotary Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 31 }
                        .AddAlias("IS Rotary AC/5 Ammo")
                        .AddAlias("ISRotaryAC5 Ammo") as ComponentAmmunition);

                    privateAmmunitionList.Add(new ComponentAmmunition("Ultra Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.BOTH) { BV = 7 }
                        .AddAlias("CLUltraAC2 Ammo")
                        .AddAlias("IS Ultra AC/2 Ammo")
                        .AddAlias("ISUltraAC2 Ammo")
                        .AddAlias("Clan Ultra AC/2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Ultra Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.BOTH) { BV = 14 }
                        .AddAlias("CLUltraAC5 Ammo")
                        .AddAlias("IS Ultra AC/5 Ammo")
                        .AddAlias("ISUltraAC5 Ammo")
                        .AddAlias("Clan Ultra AC/5 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Ultra Autocannon/10 Ammo", 10, "E", TECHNOLOGY_BASE.BOTH) { BV = 26 }
                        .AddAlias("CLUltraAC10 Ammo")
                        .AddAlias("IS Ultra AC/10 Ammo")
                        .AddAlias("ISUltraAC10 Ammo")
                        .AddAlias("Clan Ultra AC/10 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Ultra Autocannon/20 Ammo", 5, "E", TECHNOLOGY_BASE.BOTH) { BV = 35 }
                        .AddAlias("CLUltraAC20 Ammo")
                        .AddAlias("IS Ultra AC/20 Ammo")
                        .AddAlias("ISUltraAC20 Ammo")
                        .AddAlias("Clan Ultra AC/20 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 5 });
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 9 });
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Autocannon/10 Ammo", 10, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 15 });
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Autocannon/20 Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 22 });
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Light Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 4 });
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Light Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 8 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Flechette Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 5 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Flechette Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 9 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Flechette Autocannon/10 Ammo", 10, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 15 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Flechette Autocannon/20 Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 22 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Flechette Light Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 4 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Flechette Light Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 8 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Precision Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 5 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Precision Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 9 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Precision Autocannon/10 Ammo", 10, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 15 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Precision Autocannon/20 Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 22 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Precision Light Autocannon/2 Ammo", 45, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 4 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Precision Light Autocannon/5 Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 8 });
                    privateAmmunitionList.Add(new ComponentAmmunition("AP Gauss Ammo", 40, "F", TECHNOLOGY_BASE.CLAN) { Volatile = false, BV = 3 }
                        .AddAlias("CLAPGaussRifle Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Light Gauss Rifle Ammo", 16, "E", TECHNOLOGY_BASE.INNERSPHERE) { Volatile = false, BV = 20 }
                        .AddAlias("IS Light Gauss Ammo")
                        .AddAlias("ISLightGauss Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Gauss Rifle Ammo", 8, "E", TECHNOLOGY_BASE.BOTH) { Volatile = false, BV = 40 }
                        .AddAlias("Clan Gauss Ammo")
                        .AddAlias("CLGauss Ammo")
                        .AddAlias("IS Gauss Ammo")
                        .AddAlias("ISGauss Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Heavy Gauss Rifle Ammo", 4, "E", TECHNOLOGY_BASE.INNERSPHERE) { Volatile = false, BV = 43 }
                        .AddAlias("Clan Heavy Gauss Ammo")
                        .AddAlias("IS Heavy Gauss Ammo")
                        .AddAlias("ISHeavyGauss Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Hyper-Assault Gauss Rifle 20 Ammo", 6, "F", TECHNOLOGY_BASE.CLAN) { Volatile = false, BV = 33 }
                        .AddAlias("CLHAG20 Ammo")
					.AddAlias("Hyper-Assault Gauss Rifle/20 Ammo")
                        .AddAlias("HAG/20 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Hyper-Assault Gauss Rifle 30 Ammo", 4, "F", TECHNOLOGY_BASE.CLAN) { Volatile = false, BV = 50 }
					.AddAlias("CLHAG30 Ammo")
					.AddAlias("Hyper-Assault Gauss Rifle/30 Ammo")
                    .AddAlias("HAG/30 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Hyper-Assault Gauss Rifle 40 Ammo", 3, "F", TECHNOLOGY_BASE.CLAN) { Volatile = false, BV = 67 }
					.AddAlias("CLHAG40 Ammo")
					.AddAlias("Hyper-Assault Gauss Rifle/40 Ammo")
                    .AddAlias("HAG/40 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Vehicle Flamer Ammo", 20, "A", TECHNOLOGY_BASE.BOTH)); //TODO: Does this have no BV?
                    privateAmmunitionList.Add(new ComponentAmmunition("Plasma Cannon Ammo", 10, "F", TECHNOLOGY_BASE.CLAN) { BV = 21 }
                        .AddAlias("CLPlasmaCannonAmmo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Plasma Rifle Ammo", 10, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 26 }
                        .AddAlias("ISPlasmaRifle Ammo")
                        .AddAlias("ISPlasmaRifleAmmo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 3 Ammo", 20, "F", TECHNOLOGY_BASE.CLAN) { BV = 14 }
                        .AddAlias("CLATM3 Ammo")
						.AddAlias("Clan Ammo ATM-3") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 6 Ammo", 10, "F", TECHNOLOGY_BASE.CLAN) { BV = 26 }
					    .AddAlias("CLATM6 Ammo")    
					    .AddAlias("Clan Ammo ATM-6") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 9 Ammo", 7, "F", TECHNOLOGY_BASE.CLAN) { BV = 36 }
						.AddAlias("CLATM9 Ammo")
						.AddAlias("Clan Ammo ATM-9") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 12 Ammo", 5, "F", TECHNOLOGY_BASE.CLAN) { BV = 52 }
						.AddAlias("CLATM12 Ammo")
						.AddAlias("Clan Ammo ATM-12") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("ATM 3 ER Ammo", 20, "F", TECHNOLOGY_BASE.CLAN) { BV = 14 }
					    .AddAlias("CLATM3 ER Ammo")
						.AddAlias("Clan Ammo ER ATM-3") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("ATM 6 ER Ammo", 10, "F", TECHNOLOGY_BASE.CLAN) { BV = 26 }
						.AddAlias("CLATM6 ER Ammo")
						.AddAlias("Clan Ammo ER ATM-6") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("ATM 9 ER Ammo", 7, "F", TECHNOLOGY_BASE.CLAN) { BV = 36 }
					    .AddAlias("CLATM9 ER Ammo")
					    .AddAlias("Clan Ammo ER ATM-9") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("ATM 12 ER Ammo", 5, "F", TECHNOLOGY_BASE.CLAN) { BV = 52 }
						.AddAlias("CLATM12 ER Ammo")
						.AddAlias("Clan Ammo ER ATM-12") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("ATM 3 HE Ammo", 20, "F", TECHNOLOGY_BASE.CLAN) { BV = 14 }
	.AddAlias("CLATM3 HE Ammo")
	.AddAlias("Clan Ammo HE ATM-3") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("ATM 6 HE Ammo", 10, "F", TECHNOLOGY_BASE.CLAN) { BV = 26 }
						.AddAlias("CLATM6 HE Ammo")
						.AddAlias("Clan Ammo HE ATM-6") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("ATM 9 HE Ammo", 7, "F", TECHNOLOGY_BASE.CLAN) { BV = 36 }
						.AddAlias("CLATM9 HE Ammo")
						.AddAlias("Clan Ammo HE ATM-9") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("ATM 12 HE Ammo", 5, "F", TECHNOLOGY_BASE.CLAN) { BV = 52 }
						.AddAlias("CLATM12 HE Ammo")
						.AddAlias("Clan Ammo HE ATM-12") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Ammo", 24, "C", TECHNOLOGY_BASE.INNERSPHERE) { BV = 6 }
                        .AddAlias("IS Ammo LRM-5")
                        .AddAlias("ISLRM5 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Ammo", 24, "C", TECHNOLOGY_BASE.CLAN) { BV = 7 }
                        .AddAlias("Clan Ammo LRM-5")
                        .AddAlias("CLLRM5 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Ammo", 12, "C", TECHNOLOGY_BASE.INNERSPHERE) { BV = 11 }
                        .AddAlias("IS Ammo LRM-10")
                        .AddAlias("ISLRM10 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Ammo", 12, "C", TECHNOLOGY_BASE.CLAN) { BV = 14 }
                        .AddAlias("Clan Ammo LRM-10")
                        .AddAlias("CLLRM10 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Ammo", 8, "C", TECHNOLOGY_BASE.INNERSPHERE) { BV = 17 }
                        .AddAlias("IS Ammo LRM-15")
                        .AddAlias("ISLRM15 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Ammo", 8, "C", TECHNOLOGY_BASE.CLAN) { BV = 21 }
                        .AddAlias("Clan Ammo LRM-15")
                        .AddAlias("CLLRM15 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Ammo", 6, "C", TECHNOLOGY_BASE.INNERSPHERE) { BV = 23 }
                        .AddAlias("IS Ammo LRM-20")
                        .AddAlias("ISLRM20 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Ammo", 6, "C", TECHNOLOGY_BASE.CLAN) { BV = 27 }
                        .AddAlias("Clan Ammo LRM-20")
                        .AddAlias("CLLRM20 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 LRM Ammo", 40, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 4 }
                        .AddAlias("ISMML3 LRM Ammo")
                        .AddAlias("IS Ammo MML-3 LRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 SRM Ammo", 33, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 4 }
                        .AddAlias("ISMML3 SRM Ammo")
                        .AddAlias("IS Ammo MML-3 SRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 6 }
                        .AddAlias("ISMML5 LRM Ammo")
                        .AddAlias("IS Ammo MML-5 LRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Ammo", 20, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 6 }
                        .AddAlias("ISMML5 SRM Ammo")
                        .AddAlias("IS Ammo MML-5 SRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 LRM Ammo", 17, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 8 }
                        .AddAlias("ISMML7 LRM Ammo")
                        .AddAlias("IS Ammo MML-7 LRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 SRM Ammo", 14, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 8 }
                        .AddAlias("ISMML7 SRM Ammo")
                        .AddAlias("IS Ammo MML-7 SRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Ammo", 13, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 11 }
                        .AddAlias("ISMML9 LRM Ammo")
                        .AddAlias("IS Ammo MML-9 LRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Ammo", 11, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 11 }
                        .AddAlias("ISMML9 SRM Ammo")
                        .AddAlias("IS Ammo MML-9 SRM") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MRM 10 Ammo", 24, "C", TECHNOLOGY_BASE.INNERSPHERE) { BV = 7 }
                        .AddAlias("IS MRM 10 Ammo")
                        .AddAlias("ISMRM10 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MRM 20 Ammo", 12, "C", TECHNOLOGY_BASE.INNERSPHERE) { BV = 14 }
                        .AddAlias("IS MRM 20 Ammo")
                        .AddAlias("ISMRM20 Ammo") as ComponentAmmunition); ;
                    privateAmmunitionList.Add(new ComponentAmmunition("MRM 30 Ammo", 8, "C", TECHNOLOGY_BASE.INNERSPHERE) { BV = 21 }
                        .AddAlias("IS MRM 30 Ammo")
                        .AddAlias("ISMRM30 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MRM 40 Ammo", 6, "C", TECHNOLOGY_BASE.INNERSPHERE) { BV = 28 }
                        .AddAlias("IS MRM 40 Ammo")
                        .AddAlias("ISMRM40 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Ammo", 50, "C", TECHNOLOGY_BASE.BOTH) { BV = 3 }
                        .AddAlias("Clan Ammo SRM-2")
                        .AddAlias("IS Ammo SRM-2")
                        .AddAlias("ISSRM2 Ammo")
                        .AddAlias("CLSRM2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Ammo", 25, "C", TECHNOLOGY_BASE.BOTH) { BV = 5 }
                        .AddAlias("Clan Ammo SRM-4")
                        .AddAlias("IS Ammo SRM-4")
                        .AddAlias("ISSRM4 Ammo")
                        .AddAlias("CLSRM4 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Ammo", 15, "C", TECHNOLOGY_BASE.BOTH) { BV = 7 }
                        .AddAlias("Clan Ammo SRM-6")
                        .AddAlias("IS Ammo SRM-6")
                        .AddAlias("ISSRM6 Ammo")
                        .AddAlias("CLSRM6 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Streak SRM 2 Ammo", 50, "E", TECHNOLOGY_BASE.BOTH) { BV = 4 }
                        .AddAlias("Clan Ammo Streak SRM-2")
                        .AddAlias("Clan Ammo Streak SRM 2")
                        .AddAlias("IS Ammo Streak SRM-2")
                        .AddAlias("ISStreakSRM2 Ammo")
                        .AddAlias("IS Streak SRM 2 Ammo")
                        .AddAlias("Clan Streak SRM 2 Ammo")
                        .AddAlias("CLStreakSRM2 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Streak SRM 4 Ammo", 25, "E", TECHNOLOGY_BASE.BOTH) { BV = 7 }
                        .AddAlias("Clan Ammo Streak SRM-4")
                        .AddAlias("Clan Ammo Streak SRM 4")
                        .AddAlias("IS Ammo Streak SRM-4")
                        .AddAlias("IS Streak SRM 4 Ammo")
                        .AddAlias("ISStreakSRM4 Ammo")
                        .AddAlias("Clan Streak SRM 4 Ammo")
                        .AddAlias("CLStreakSRM4 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Streak SRM 6 Ammo", 15, "E", TECHNOLOGY_BASE.BOTH) { BV = 11 }
                        .AddAlias("Clan Ammo Streak SRM-6")
                        .AddAlias("Clan Ammo Streak SRM 6")
                        .AddAlias("IS Ammo Streak SRM-6")
                        .AddAlias("IS Streak SRM 6 Ammo")
                        .AddAlias("ISStreakSRM6 Ammo")
                        .AddAlias("Clan Streak SRM 6 Ammo")
                        .AddAlias("CLStreakSRM6 Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 3 ER Ammo", 20, "F", TECHNOLOGY_BASE.CLAN) { BV = 14 }
                        .AddAlias("Clan Ammo ATM-3 ER") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 6 ER Ammo", 10, "F", TECHNOLOGY_BASE.CLAN) { BV = 26 }
                        .AddAlias("Clan Ammo ATM-6 ER") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 9 ER Ammo", 7, "F", TECHNOLOGY_BASE.CLAN) { BV = 36 }
                        .AddAlias("Clan Ammo ATM-9 ER") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 12 ER Ammo", 5, "F", TECHNOLOGY_BASE.CLAN) { BV = 52 }
                        .AddAlias("Clan Ammo ATM-12 ER") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 3 HE Ammo", 20, "F", TECHNOLOGY_BASE.CLAN) { BV = 14 }
                        .AddAlias("Clan Ammo ATM-3 HE") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 6 HE Ammo", 10, "F", TECHNOLOGY_BASE.CLAN) { BV = 26 }
                        .AddAlias("Clan Ammo ATM-6 HE") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 9 HE Ammo", 7, "F", TECHNOLOGY_BASE.CLAN) { BV = 36 }
                        .AddAlias("Clan Ammo ATM-9 HE") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("ATM 12 HE Ammo", 5, "F", TECHNOLOGY_BASE.CLAN) { BV = 52 }
                        .AddAlias("Clan Ammo ATM-12 HE") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Ammo Artemis-capable", 24, "F", TECHNOLOGY_BASE.BOTH) { BV = 7 }
                        .AddAlias("IS Ammo LRM-5 Artemis-capable")
                        .AddAlias("Clan Ammo LRM-5 (Clan) Artemis-capable")
                        .AddAlias("ISLRM5 Ammo Artemis-capable")
                        .AddAlias("CLLRM5 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Ammo Artemis-capable", 12, "F", TECHNOLOGY_BASE.BOTH) { BV = 14 }
                        .AddAlias("IS Ammo LRM-10 Artemis-capable")
                        .AddAlias("Clan Ammo LRM-10 (Clan) Artemis-capable")
                        .AddAlias("ISLRM10 Ammo Artemis-capable")
                        .AddAlias("CLLRM10 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Ammo Artemis-capable", 8, "F", TECHNOLOGY_BASE.BOTH) { BV = 21 }
                        .AddAlias("IS Ammo LRM-15 Artemis-capable")
                        .AddAlias("Clan Ammo LRM-15 (Clan) Artemis-capable")
                        .AddAlias("ISLRM15 Ammo Artemis-capable")
                        .AddAlias("CLLRM15 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Ammo Artemis-capable", 6, "F", TECHNOLOGY_BASE.BOTH) { BV = 27 }
                        .AddAlias("IS Ammo LRM-20 Artemis-capable")
                        .AddAlias("Clan Ammo LRM-20 (Clan) Artemis-capable")
                        .AddAlias("ISLRM20 Ammo Artemis-capable")
                        .AddAlias("CLLRM20 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Ammo Artemis-capable", 50, "F", TECHNOLOGY_BASE.BOTH) { BV = 3 }
                        .AddAlias("IS Ammo SRM-2 Artemis-capable")
                        .AddAlias("Clan Ammo SRM-2 (Clan) Artemis-capable")
                        .AddAlias("ISSRM2 Ammo Artemis-capable")
                        .AddAlias("CLSRM2 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Ammo Artemis-capable", 25, "F", TECHNOLOGY_BASE.BOTH) { BV = 5 }
                        .AddAlias("IS Ammo SRM-4 Artemis-capable")
                        .AddAlias("Clan Ammo SRM-4 (Clan) Artemis-capable")
                        .AddAlias("ISSRM4 Ammo Artemis-capable")
                        .AddAlias("CLSRM4 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Ammo Artemis-capable", 15, "F", TECHNOLOGY_BASE.BOTH) { BV = 7 }
                        .AddAlias("IS Ammo SRM-6 Artemis-capable")
                        .AddAlias("Clan Ammo SRM-6 (Clan) Artemis-capable")
                        .AddAlias("ISSRM6 Ammo Artemis-capable")
                        .AddAlias("CLSRM6 Ammo (Clan) Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 LRM Ammo Artemis-capable", 40, "F", TECHNOLOGY_BASE.INNERSPHERE) { BV = 4 }
                        .AddAlias("ISMML3 LRM Ammo Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 SRM Ammo Artemis-capable", 33, "F", TECHNOLOGY_BASE.INNERSPHERE) { BV = 4 }
                        .AddAlias("ISMML3 SRM Ammo Artemis-capable") as ComponentAmmunition);


                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Ammo Artemis-capable", 24, "F", TECHNOLOGY_BASE.INNERSPHERE) { BV = 6 }
                        .AddAlias("ISMML5 LRM Ammo Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Ammo Artemis-capable", 20, "F", TECHNOLOGY_BASE.INNERSPHERE) { BV = 6 }
                        .AddAlias("ISMML5 SRM Ammo Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 LRM Ammo Artemis-capable", 17, "F", TECHNOLOGY_BASE.INNERSPHERE) { BV = 8 }
                        .AddAlias("ISMML7 LRM Ammo Artemis-capable") as ComponentAmmunition);

                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 SRM Ammo Artemis-capable", 14, "F", TECHNOLOGY_BASE.INNERSPHERE) { BV = 8 }
                        .AddAlias("ISMML7 SRM Ammo Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Ammo Artemis-capable", 13, "F", TECHNOLOGY_BASE.INNERSPHERE) { BV = 11 }
                        .AddAlias("ISMML9 LRM Ammo Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Ammo Artemis-capable", 11, "F", TECHNOLOGY_BASE.INNERSPHERE) { BV = 11 }
                        .AddAlias("ISMML9 SRM Ammo Artemis-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Flare Ammo", 24, "C", TECHNOLOGY_BASE.BOTH) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Flare Ammo", 12, "C", TECHNOLOGY_BASE.BOTH) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Flare Ammo", 8, "C", TECHNOLOGY_BASE.BOTH) { BV = 17 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Flare Ammo", 6, "C", TECHNOLOGY_BASE.BOTH) { BV = 21 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Fragmentation Ammo", 24, "D", TECHNOLOGY_BASE.BOTH) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Fragmentation Ammo", 12, "D", TECHNOLOGY_BASE.BOTH) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Fragmentation Ammo", 8, "D", TECHNOLOGY_BASE.BOTH) { BV = 17 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Fragmentation Ammo", 6, "D", TECHNOLOGY_BASE.BOTH) { BV = 23 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Fragmentation Ammo", 50, "D", TECHNOLOGY_BASE.BOTH) { BV = 3 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Fragmentation Ammo", 25, "D", TECHNOLOGY_BASE.BOTH) { BV = 5 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Fragmentation Ammo", 15, "D", TECHNOLOGY_BASE.BOTH) { BV = 7 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 LRM Fragmentation Ammo", 40, "D", TECHNOLOGY_BASE.BOTH) { BV = 4 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 SRM Fragmentation Ammo", 33, "D", TECHNOLOGY_BASE.BOTH) { BV = 4 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Fragmentation Ammo", 24, "D", TECHNOLOGY_BASE.BOTH) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Fragmentation Ammo", 20, "D", TECHNOLOGY_BASE.BOTH) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 LRM Fragmentation Ammo", 17, "D", TECHNOLOGY_BASE.BOTH) { BV = 8 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 SRM Fragmentation Ammo", 14, "D", TECHNOLOGY_BASE.BOTH) { BV = 8 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Fragmentation Ammo", 13, "D", TECHNOLOGY_BASE.BOTH) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Fragmentation Ammo", 11, "D", TECHNOLOGY_BASE.BOTH) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Harpoon Ammo", 50, "D", TECHNOLOGY_BASE.BOTH) { BV = 3 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Harpoon Ammo", 25, "D", TECHNOLOGY_BASE.BOTH) { BV = 5 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Harpoon Ammo", 15, "D", TECHNOLOGY_BASE.BOTH) { BV = 7 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Incendiary Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Incendiary Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Incendiary Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 17 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Incendiary Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 21 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Inferno Ammo", 50, "B", TECHNOLOGY_BASE.BOTH) { BV = 3 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Inferno Ammo", 25, "B", TECHNOLOGY_BASE.BOTH) { BV = 5 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Inferno Ammo", 15, "B", TECHNOLOGY_BASE.BOTH) { BV = 7 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Semi-Guided Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Semi-Guided Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Semi-Guided Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 17 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Semi-Guided Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 21 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Swarm Ammo", 24, "E", TECHNOLOGY_BASE.BOTH) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Swarm Ammo", 12, "E", TECHNOLOGY_BASE.BOTH) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Swarm Ammo", 8, "E", TECHNOLOGY_BASE.BOTH) { BV = 17 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Swarm Ammo", 6, "E", TECHNOLOGY_BASE.BOTH) { BV = 21 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Swarm-I Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Swarm-I Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Swarm-I Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 17 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Swarm-I Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 21 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Tear Gas Ammo", 50, "B", TECHNOLOGY_BASE.BOTH) { BV = 3 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Tear Gas Ammo", 25, "B", TECHNOLOGY_BASE.BOTH) { BV = 5 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Tear Gas Ammo", 15, "B", TECHNOLOGY_BASE.BOTH) { BV = 7 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Thunder Ammo", 24, "E", TECHNOLOGY_BASE.BOTH) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Thunder Ammo", 12, "E", TECHNOLOGY_BASE.BOTH) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Thunder Ammo", 8, "E", TECHNOLOGY_BASE.BOTH) { BV = 17 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Thunder Ammo", 6, "E", TECHNOLOGY_BASE.BOTH) { BV = 21 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Thunder-Augmented Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Thunder-Augmented Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Thunder-Augmented Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 17 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Thunder-Augmented Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 21 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Thunder-Inferno Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Thunder-Inferno Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Thunder-Inferno Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 17 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Thunder-Inferno Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 21 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Thunder-Vibrobomb Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Thunder-Vibrobomb Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Thunder-Vibrobomb Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 17 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Thunder-Vibrobomb Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 21 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Thunder-Active Ammo", 24, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Thunder-Active Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Thunder-Active Ammo", 8, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 17 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Thunder-Active Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 21 });

                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Narc-Capable Ammo", 24, "E", TECHNOLOGY_BASE.BOTH) { BV = 6 }
                        .AddAlias("IS Ammo LRM-5 Narc-capable")
                        .AddAlias("ISLRM5 Ammo Narc-capable")
                        .AddAlias("Clan Ammo LRM-5 (Clan) Narc-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Narc-Capable Ammo", 12, "E", TECHNOLOGY_BASE.BOTH) { BV = 11 }
                        .AddAlias("IS Ammo LRM-10 Narc-capable")
                        .AddAlias("ISLRM10 Ammo Narc-capable")
                        .AddAlias("Clan Ammo LRM-10 (Clan) Narc-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Narc-Capable Ammo", 8, "E", TECHNOLOGY_BASE.BOTH) { BV = 17 }
                        .AddAlias("IS Ammo LRM-15 Narc-capable")
                        .AddAlias("ISLRM15 Ammo Narc-capable")
                        .AddAlias("Clan Ammo LRM-15 (Clan) Narc-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Narc-Capable Ammo", 6, "E", TECHNOLOGY_BASE.BOTH) { BV = 21 }
                        .AddAlias("IS Ammo LRM-20 Narc-capable")
                        .AddAlias("ISLRM20 Ammo Narc-capable")
                        .AddAlias("Clan Ammo LRM-20 (Clan) Narc-capable") as ComponentAmmunition);

                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Narc-Capable Ammo", 50, "E", TECHNOLOGY_BASE.BOTH) { BV = 3 }
                        .AddAlias("IS Ammo SRM-2 Narc-capable")
                        .AddAlias("ISSRM2 Ammo Narc-capable")
                        .AddAlias("Clan Ammo SRM-2 (Clan) Narc-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Narc-Capable Ammo", 25, "E", TECHNOLOGY_BASE.BOTH) { BV = 5 }
                        .AddAlias("IS Ammo SRM-4 Narc-capable")
                        .AddAlias("ISSRM4 Ammo Narc-capable")
                        .AddAlias("Clan Ammo SRM-4 (Clan) Narc-capable") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Narc-Capable Ammo", 15, "E", TECHNOLOGY_BASE.BOTH) { BV = 7 }
                        .AddAlias("IS Ammo SRM-6 Narc-capable")
                        .AddAlias("ISSRM6 Ammo Narc-capable")
                        .AddAlias("Clan Ammo SRM-6 (Clan) Narc-capable") as ComponentAmmunition);

                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 LRM Narc-Capable Ammo", 40, "E", TECHNOLOGY_BASE.BOTH) { BV = 4 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 3 SRM Narc-Capable Ammo", 33, "E", TECHNOLOGY_BASE.BOTH) { BV = 4 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Narc-Capable Ammo", 24, "E", TECHNOLOGY_BASE.BOTH) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 5 LRM Narc-Capable Ammo", 20, "E", TECHNOLOGY_BASE.BOTH) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 LRM Narc-Capable Ammo", 17, "E", TECHNOLOGY_BASE.BOTH) { BV = 8 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 7 SRM Narc-Capable Ammo", 14, "E", TECHNOLOGY_BASE.BOTH) { BV = 8 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Narc-Capable Ammo", 13, "E", TECHNOLOGY_BASE.BOTH) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("MML 9 LRM Narc-Capable Ammo", 11, "E", TECHNOLOGY_BASE.BOTH) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Torpedo Ammo", 24, "C", TECHNOLOGY_BASE.BOTH) { BV = 6 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Torpedo Ammo", 12, "C", TECHNOLOGY_BASE.BOTH) { BV = 11 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Torpedo Ammo", 8, "C", TECHNOLOGY_BASE.BOTH) { BV = 17 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Torpedo Ammo", 6, "C", TECHNOLOGY_BASE.BOTH) { BV = 21 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Torpedo Ammo", 50, "C", TECHNOLOGY_BASE.BOTH) { BV = 3 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Torpedo Ammo", 25, "C", TECHNOLOGY_BASE.BOTH) { BV = 5 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Torpedo Ammo", 15, "C", TECHNOLOGY_BASE.BOTH) { BV = 7 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 5 Multi-Purpose Ammo", 24, "F", TECHNOLOGY_BASE.CLAN) { BV = 7 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 10 Multi-Purpose Ammo", 12, "F", TECHNOLOGY_BASE.CLAN) { BV = 14 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 15 Multi-Purpose Ammo", 8, "F", TECHNOLOGY_BASE.CLAN) { BV = 21 });
                    privateAmmunitionList.Add(new ComponentAmmunition("LRM 20 Multi-Purpose Ammo", 6, "F", TECHNOLOGY_BASE.CLAN) { BV = 27 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 2 Multi-Purpose Ammo", 50, "F", TECHNOLOGY_BASE.CLAN) { BV = 3 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 4 Multi-Purpose Ammo", 25, "F", TECHNOLOGY_BASE.CLAN) { BV = 5 });
                    privateAmmunitionList.Add(new ComponentAmmunition("SRM 6 Multi-Purpose Ammo", 15, "F", TECHNOLOGY_BASE.CLAN) { BV = 7 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Anti-Missile System Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 11 }
                        .AddAlias("IS AMS Ammo")
                        .AddAlias("ISAMS Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Anti-Missile System Ammo", 24, "F", TECHNOLOGY_BASE.CLAN) { BV = 22 }
                        .AddAlias("CL AMS Ammo")
                        .AddAlias("CLAMS Ammo") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Narc Missile Beacon Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 0 }
                        .AddAlias("ISNarc Pods") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Narc Missile Beacon Ammo", 6, "E", TECHNOLOGY_BASE.CLAN) { BV = 0 }
                        .AddAlias("CLNarc Pods") as ComponentAmmunition);  //TODO: NO REFERENCE FOUND FOR THIS, EXISTENCE IMPLICIT
                    privateAmmunitionList.Add(new ComponentAmmunition("Narc Missile Beacon Explosive Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 0 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Improved Narc Launcher Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 0 }
                        .AddAlias("IS Ammo iNarc")
                        .AddAlias("ISiNarc Pods") as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Improved Narc Launcher ECM Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 0 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Improved Narc Launcher Explosive Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 0 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Improved Narc Launcher Haywire Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 0 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Improved Narc Launcher Nemesis Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 0 });
                    privateAmmunitionList.Add(new ComponentAmmunition("Arrow IV Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 30 }
                        .AddAlias("ISArrowIVAmmo")
                        .AddAlias("ISArrowIV Ammo") as ComponentAmmunition
                        );
                    privateAmmunitionList.Add(new ComponentAmmunition("Arrow IV Ammo", 5, "E", TECHNOLOGY_BASE.CLAN) { BV = 30 }
                    .AddAlias("CLArrowIVAmmo")
					.AddAlias("CLArrowIV Ammo") as ComponentAmmunition
                        );
                    privateAmmunitionList.Add(new ComponentAmmunition("Arrow IV Homing Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 30 }
                        .AddAlias("ISArrowIV Homing Ammo") as ComponentAmmunition
                        );
                    privateAmmunitionList.Add(new ComponentAmmunition("Arrow IV Homing Ammo", 5, "E", TECHNOLOGY_BASE.CLAN) { BV = 30 }
                        .AddAlias("CLArrowIV Homing Ammo") as ComponentAmmunition
                        );
                    privateAmmunitionList.Add(new ComponentAmmunition("Taser Ammo", 5, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 5 }
                        as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Thunderbolt 5 Ammo", 12, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 8 }
                        as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Thunderbolt 10 Ammo", 6, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 16 }
                        as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Thunderbolt 15 Ammo", 4, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 29 }
                        as ComponentAmmunition);
                    privateAmmunitionList.Add(new ComponentAmmunition("Thunderbolt 20 Ammo", 3, "E", TECHNOLOGY_BASE.INNERSPHERE) { BV = 38 }
                        as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("Mortar Airburst", 1, "C", TECHNOLOGY_BASE.BOTH) { BV = 0 }
					    .AddAlias("IS Ammo AB Mortar-8")
					    .AddAlias("CL Ammo AB Mortar-8") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("Mortar Anti-Personnel", 1, "C", TECHNOLOGY_BASE.BOTH) { BV = 0 }
					    .AddAlias("IS Ammo AP Mortar-8")
					    .AddAlias("CL Ammo AP Mortar-8") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("Mortar Flare", 1, "C", TECHNOLOGY_BASE.BOTH) { BV = 0 }
					    .AddAlias("IS Ammo F Mortar-8")
					    .AddAlias("CL Ammo F Mortar-8") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("Mortar Semi-Guide", 1, "C", TECHNOLOGY_BASE.INNERSPHERE) { BV = 0 }
					    .AddAlias("IS Ammo SG Mortar-8") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("Mortar Smoke", 1, "C", TECHNOLOGY_BASE.BOTH) { BV = 0 }
					    .AddAlias("IS Ammo S Mortar-8")
					    .AddAlias("CL Ammo S Mortar-8") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("Mortar Shaped Charge", 1, "C", TECHNOLOGY_BASE.BOTH) { BV = 0 }
					    .AddAlias("IS Ammo SC Mortar-8")
                        .AddAlias("Clan Ammo SC Mortar-8")
						.AddAlias("CL Ammo SC Mortar-8") as ComponentAmmunition);

                    privateAmmunitionList.Add(new ComponentAmmunition("ProtoMech AC/2 Ammo", 40, "F", TECHNOLOGY_BASE.CLAN) { BV = 4 }
                        .AddAlias("Clan ProtoMech AC/2 Ammo") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("ProtoMech AC/4 Ammo", 20, "F", TECHNOLOGY_BASE.CLAN) { BV = 6 }
						.AddAlias("Clan ProtoMech AC/4 Ammo") as ComponentAmmunition);
					privateAmmunitionList.Add(new ComponentAmmunition("ProtoMech AC/8 Ammo", 10, "F", TECHNOLOGY_BASE.CLAN) { BV = 8 }
						.AddAlias("Clan ProtoMech AC/8 Ammo") as ComponentAmmunition);
						
                }
                semaphoreAmmunitionLoad.Release();
                return privateAmmunitionList;
            }
        }

        static private List<ComponentAmmunition> privateAmmunitionList = null;

        //TODO: Base Costs are wrong
        static public Dictionary<string, ComponentWeapon> Weapons = new System.Collections.Generic.Dictionary<string, ComponentWeapon>()
        {
            {"LRM 5",new ComponentWeaponClustered() //TM341
            {
                Name = "LRM 5",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                SalvoSize=5,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                AlphaStrikeAbility = "LRM",
                ContributesToTargetingComputerMass=false,
                BV=45

            }
            .AddAlias("LRM 5")
            .AddAlias("LRM/5")
            .AddAlias("LRM5")
            .AddAlias("ISLRM5") as ComponentWeapon
            },
            {"LRM 10",new ComponentWeaponClustered() //TM341
            {
                Name = "LRM 10",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 6,
                SalvoSize=10,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=90
            }.AddAlias("LRM 10")
            .AddAlias("LRM/10")
            .AddAlias("LRM10")
            .AddAlias("ISLRM10") as ComponentWeapon
            },
            {"LRM 15",new ComponentWeaponClustered() //TM341
            {
                Name = "LRM 15",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 9,
                IndirectFire=true,
                SalvoSize=15,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=136
            }.AddAlias("LRM 15")
            .AddAlias("LRM/15")
            .AddAlias("LRM15")
            .AddAlias("ISLRM15") as ComponentWeapon
            },
            {"LRM 20",new ComponentWeaponClustered() //TM341
            {
                Name = "LRM 20",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                SalvoSize=20,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=181
            }.AddAlias("LRM 20")
            .AddAlias("LRM/20")
            .AddAlias("LRM20")
            .AddAlias("ISLRM20") as ComponentWeapon
            },
             {"Primitive LRM 5",new ComponentWeaponClustered() //IO216
            {
                Name = "Primitive LRM 5",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                SalvoSize=5,
                IndirectFire=true,
                AeroDamage = 3,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 18,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                AlphaStrikeAbility = "LRM",
                ContributesToTargetingComputerMass=false,
                BV=45

            }
            .AddAlias("Primitive LRM 5")
            .AddAlias("Primitive LRM/5")
            .AddAlias("Primitive LRM5")
            .AddAlias("Primitive ISLRM5") as ComponentWeapon
            },
            {"Primitive LRM 10",new ComponentWeaponClustered() //IO216
            {
                Name = "Primitive LRM 10",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 6,
                SalvoSize=10,
                IndirectFire=true,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 9,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=90
            }.AddAlias("Primitive LRM 10")
            .AddAlias("Primitive LRM/10")
            .AddAlias("Primitive LRM10")
            .AddAlias("Primitive ISLRM10") as ComponentWeapon
            },
            {"Primitive LRM 15",new ComponentWeaponClustered() //IO216
            {
                Name = "Primitive LRM 15",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 9,
                IndirectFire=true,
                SalvoSize=15,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 6,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=136
            }.AddAlias("Primitive LRM 15")
            .AddAlias("Primitive LRM/15")
            .AddAlias("Primitive LRM15")
            .AddAlias("Primitive ISLRM15") as ComponentWeapon
            },
            {"Primitive LRM 20",new ComponentWeaponClustered() //IO216
            {
                Name = "Primitive LRM 20",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                SalvoSize=20,
                IndirectFire=true,
                AeroDamage = 12,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 4,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=181
            }.AddAlias("Primitive LRM 20")
            .AddAlias("Primitive LRM/20")
            .AddAlias("Primitive LRM20")
            .AddAlias("Primitive ISLRM20") as ComponentWeapon
            },
                         {"Improved LRM 5",new ComponentWeaponClustered() //IO216
            {
                Name = "Improved LRM 5",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                SalvoSize=5,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                AlphaStrikeAbility = "LRM",
                ContributesToTargetingComputerMass=false,
                BV=45

            }
            .AddAlias("Improved LRM 5")
            .AddAlias("Improved LRM/5")
            .AddAlias("Improved LRM5")
            .AddAlias("Improved ISLRM5") as ComponentWeapon
            },
            {"Improved LRM 10",new ComponentWeaponClustered() //IO216
            {
                Name = "Improved LRM 10",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 6,
                SalvoSize=10,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=90
            }.AddAlias("Improved LRM 10")
            .AddAlias("Improved LRM/10")
            .AddAlias("Improved LRM10")
            .AddAlias("Improved ISLRM10") as ComponentWeapon
            },
            {"Improved LRM 15",new ComponentWeaponClustered() //IO216
            {
                Name = "Improved LRM 15",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 9,
                IndirectFire=true,
                SalvoSize=15,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=136
            }.AddAlias("Improved LRM 15")
            .AddAlias("Improved LRM/15")
            .AddAlias("Improved LRM15")
            .AddAlias("Improved ISLRM15") as ComponentWeapon
            },
            {"Improved LRM 20",new ComponentWeaponClustered() //IO217
            {
                Name = "Improved LRM 20",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                SalvoSize=20,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=181
            }.AddAlias("Improved LRM 20")
            .AddAlias("Improved LRM/20")
            .AddAlias("Improved LRM20")
            .AddAlias("Improved ISLRM20") as ComponentWeapon
            },
            {"Streak LRM 5",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak LRM 5",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                SalvoSize=5,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                AlphaStrikeAbility = "LRM",
                ContributesToTargetingComputerMass=false,
                BV=45

            }

            .AddAlias("ISSLRM5") as ComponentWeapon
            },
            {"Streak LRM 10",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak LRM 10",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 6,
                SalvoSize=10,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=90
            }
            .AddAlias("ISSLRM10") as ComponentWeapon
            },
            {"Streak LRM 15",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak LRM 15",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 9,
                IndirectFire=true,
                SalvoSize=15,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=136
            }
            .AddAlias("ISSLRM15") as ComponentWeapon
            },
            {"Streak LRM 20",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak LRM 20",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                SalvoSize=20,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=181
            }
            .AddAlias("ISSLRM20") as ComponentWeapon
            },
            {"LRT 5",new ComponentWeaponClustered() //TM341
            {
                Name = "LRT 5",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                SalvoSize=5,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                AlphaStrikeAbility = "LRM",
                ContributesToTargetingComputerMass=false,
                BV=45

            }
            .AddAlias("LRT 5")
            .AddAlias("LRT/5")
            .AddAlias("LRT5")
            .AddAlias("ISLRT5") as ComponentWeapon
            },
            {"LRT 10",new ComponentWeaponClustered() //TM341
            {
                Name = "LRT 10",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 6,
                SalvoSize=10,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRT",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=90
            }.AddAlias("LRT 10")
            .AddAlias("LRT/10")
            .AddAlias("LRT10")
            .AddAlias("ISLRT10") as ComponentWeapon
            },
            {"LRT 15",new ComponentWeaponClustered() //TM341
            {
                Name = "LRT 15",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 9,
                IndirectFire=true,
                SalvoSize=15,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRT",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=136
            }.AddAlias("LRT 15")
            .AddAlias("LRT/15")
            .AddAlias("LRT15")
            .AddAlias("ISLRT15") as ComponentWeapon
            },
            {"LRT 20",new ComponentWeaponClustered() //TM341
            {
                Name = "LRT 20",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                SalvoSize=20,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRT",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=181
            }.AddAlias("LRT 20")
            .AddAlias("LRT/20")
            .AddAlias("LRT20")
            .AddAlias("ISLRT20") as ComponentWeapon
            },
            {"Enhanced LRM 5",new ComponentWeaponClustered() //TM341
            {
                Name = "Enhanced LRM 5",
                BaseCost = 37500,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                SalvoSize=5,
                IndirectFire=true,
                AeroDamage = 3,
                MinimumRange = 3,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                AlphaStrikeAbility = "LRM",
                ContributesToTargetingComputerMass=false,
                BV=52

            }

            .AddAlias("ISEnhancedLRM5") as ComponentWeapon
            },
            {"Enhanced LRM 10",new ComponentWeaponClustered() //TM341
            {
                Name = "Enhanced LRM 10",
                BaseCost = 125000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 6,
                SalvoSize=10,
                IndirectFire=true,
                MinimumRange = 3,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 12,
                Tonnage = 6,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=104
            }
            .AddAlias("ISEnhancedLRM10") as ComponentWeapon
            },
            {"Enhanced LRM 15",new ComponentWeaponClustered() //TM341
            {
                Name = "Enhanced LRM 15",
                BaseCost = 218750,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 9,
                IndirectFire=true,
                SalvoSize=15,
                MinimumRange = 3,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 8,
                Tonnage = 9,
                CriticalSpaceMech = 6,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 6,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=157
            }
            .AddAlias("ISEnhancedLRM15") as ComponentWeapon
            },
            {"Enchanced LRM 20",new ComponentWeaponClustered() //TM341
            {
                Name = "Enhanced LRM 20",
                BaseCost = 312500,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                SalvoSize=20,
                IndirectFire=true,
                AeroDamage = 12,
                MinimumRange = 3,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 6,
                Tonnage = 12,
                CriticalSpaceMech = 9,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 9,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=181
            }
            .AddAlias("ISEnhancedLRM20") as ComponentWeapon
            },
            {"Extended LRM 5",new ComponentWeaponClustered() //TM341
            {
                Name = "Extended LRM 5",
                BaseCost = 37500,
                Heat = 3,
                AeroHeat = 3,
                Damage = 1,
                SalvoSize=5,
                IndirectFire=true,
                AeroDamage = 3,
                MinimumRange = 10,
                ShortRange = 12,
                MediumRange = 22,
                LongRange = 38,
                AmmoPerTon = 18,
                Tonnage = 6,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.EXTREME,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                AlphaStrikeAbility = "LRM",
                ContributesToTargetingComputerMass=false,
                BV=67,
                SBFShortRangeDamageOverride = 1,
				SBFMediumRangeDamageOverride = 3,
                SBFLongRangeDamageOverride = 3,
                SBFExtremeRangeDamageOverride = 3
			}

            .AddAlias("ISExtendedLRM5") as ComponentWeapon
            },
            {"Extended LRM 10",new ComponentWeaponClustered() //TM341
            {
                Name = "Extended LRM 10",
                BaseCost = 125000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                AeroDamage = 6,
                SalvoSize=10,
                IndirectFire=true,
                MinimumRange = 10,
                ShortRange = 12,
                MediumRange = 22,
                LongRange = 38,
                AmmoPerTon = 9,
                Tonnage = 8,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.EXTREME,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=104,
				SBFShortRangeDamageOverride = 1.5F,
				SBFMediumRangeDamageOverride = 6,
				SBFLongRangeDamageOverride = 6,
				SBFExtremeRangeDamageOverride = 6
			}
            .AddAlias("ISExtendedLRM10") as ComponentWeapon
            },
            {"Extended LRM 15",new ComponentWeaponClustered() //TM341
            {
                Name = "Extended LRM 15",
                BaseCost = 218750,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 9,
                IndirectFire=true,
                SalvoSize=15,
                MinimumRange = 10,
                ShortRange = 12,
                MediumRange = 22,
                LongRange = 38,
                AmmoPerTon = 6,
                Tonnage = 12,
                CriticalSpaceMech = 6,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 6,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.EXTREME,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=200,
				SBFShortRangeDamageOverride = 2.5F,
				SBFMediumRangeDamageOverride = 9,
				SBFLongRangeDamageOverride = 9,
				SBFExtremeRangeDamageOverride = 9
			}
            .AddAlias("ISExtendededLRM15") as ComponentWeapon
            },
            {"Extended LRM 20",new ComponentWeaponClustered() //TM341
            {
                Name = "Extended LRM 20",
                BaseCost = 312500,
                Heat = 12,
                AeroHeat = 12,
                Damage = 1,
                SalvoSize=20,
                IndirectFire=true,
                AeroDamage = 12,
                MinimumRange = 10,
                ShortRange = 12,
                MediumRange = 22,
                LongRange = 38,
                AmmoPerTon = 4,
                Tonnage = 18,
                CriticalSpaceMech = 8,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 8,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=268,
				SBFShortRangeDamageOverride = 3,
				SBFMediumRangeDamageOverride = 12,
				SBFLongRangeDamageOverride = 12,
				SBFExtremeRangeDamageOverride = 12
			}
            .AddAlias("ISExtendedLRM20") as ComponentWeapon
            },
            {"Clan LRM 5",new ComponentWeaponClustered() //TM343
            {
                Name = "LRM 5",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                SalvoSize=5,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=55
            }.AddAlias("LRM 5")
            .AddAlias("LRM/5")
            .AddAlias("LRM5")
            .AddAlias("CLLRM5") as ComponentWeapon
            },
            {"Clan LRM 10",new ComponentWeaponClustered() //TM343
            {
                Name = "LRM 10",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                SalvoSize=10,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=109
            }.AddAlias("LRM 10")
            .AddAlias("LRM/10")
            .AddAlias("LRM10")
            .AddAlias("CLLRM10") as ComponentWeapon
            },
            {"Clan LRM 15",new ComponentWeaponClustered() //TM343
            {
                Name = "LRM 15",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                SalvoSize=15,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=164
            }.AddAlias("LRM 15")
            .AddAlias("LRM/15")
            .AddAlias("LRM15")
            .AddAlias("CLLRM15") as ComponentWeapon
            },
            {"Clan LRM 20",new ComponentWeaponClustered() //TM341
            {
                Name = "LRM 20",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                SalvoSize=20,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRM",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=220
            }
            .AddAlias("LRM 20")
            .AddAlias("LRM/20")
            .AddAlias("LRM20")
            .AddAlias("CLLRM20") as ComponentWeapon
            },
            {"Clan LRT 5",new ComponentWeaponClustered() //TM343
            {
                Name = "LRT 5",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                SalvoSize=5,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRT",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=55
            }.AddAlias("LRT 5")
            .AddAlias("LRT/5")
            .AddAlias("LRT5")
            .AddAlias("CLLRT5") as ComponentWeapon
            },
            {"Clan LRT 10",new ComponentWeaponClustered() //TM343
            {
                Name = "LRT 10",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                SalvoSize=10,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRT",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=109
            }.AddAlias("LRT 10")
            .AddAlias("LRT/10")
            .AddAlias("LRT10")
            .AddAlias("CLLRT10") as ComponentWeapon
            },
            {"Clan LRT 15",new ComponentWeaponClustered() //TM343
            {
                Name = "LRT 15",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                SalvoSize=15,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRT",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=164
            }.AddAlias("LRT 15")
            .AddAlias("LRT/15")
            .AddAlias("LRT15")
            .AddAlias("CLLRT15") as ComponentWeapon
            },
            {"Clan LRT 20",new ComponentWeaponClustered() //TM341
            {
                Name = "LRT 20",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                SalvoSize=20,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "LRT",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=220
            }
            .AddAlias("LRT 20")
            .AddAlias("LRT/20")
            .AddAlias("LRT20")
            .AddAlias("CLLRT20") as ComponentWeapon
            },
            { "Retractable Blade",
                new ComponentRetractableBlade() as ComponentWeapon

            },
              {"Improved SRM 2 One-Shot",new ComponentWeaponClustered() //TM341
            {
                Name = "Improved SRM 2 One-Shot",
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
                Tonnage = 0.5,
                LauncherType="OS",
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=21
            }
            .AddAlias("Improved SRM 2 OS")
                .AddAlias("SRM 2 (I-OS)") as ComponentWeapon
            },
            {"Improved SRM 4 One-Shot",new ComponentWeaponClustered() //TM341
            {
                Name = "Improved SRM 4  One-Shot",
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
                Tonnage = 1.5,
                LauncherType="OS",
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=39
            }
                        .AddAlias("Improved SRM 4 OS")
                .AddAlias("SRM 4 (I-OS)") as ComponentWeapon
            },
            {"Improved SRM 6 One-Shot",new ComponentWeaponClustered() //TM341
            {
                Name = "Improved SRM 6 One-Shot",
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
                Tonnage = 2.5,
                LauncherType="OS",
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=59
            }            .AddAlias("Improved SRM 6 OS")
                .AddAlias("SRM 6 (I-OS)") as ComponentWeapon
            },
            {"Nail/Rivet Gun",new ComponentWeapon() //TM341
            {
                Name = "Nail/Rivet Gun",
                BaseCost = 7000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 1,
                LongRange = 1,
                AmmoPerTon = 300,
                Tonnage = 0.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = int.MaxValue,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                //AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=37
            }
            .AddAlias("Nail Gun")
            .AddAlias("Rivet Gun")
            .AddAlias("Nail Rivet Gun")
            .AddAlias("ISNailGun") as ComponentWeapon
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=37
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=70
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=123
            }
               .AddAlias("AC10")
               .AddAlias("AC/10")
               .AddAlias("Autocannon/10")
               .AddAlias("ISAC10") as ComponentWeapon
            },
               {"Hyper-Velocity Autocannon 2",new ComponentWeapon() //TM341
            {
                Name = "Hyper-Velocity Autocannon 2",
                BaseCost = 100000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 4,
                ShortRange = 8,
                MediumRange = 16,
                LongRange = 24,
                AmmoPerTon = 45,
                Tonnage = 8,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=37
            }
            .AddAlias("HVAC2")
            .AddAlias("HVAC/2")
            .AddAlias("Hyper-Velocity Autocannon/2")
                .AddAlias("Hyper Velocity Auto Cannon/2")
            .AddAlias("ISHVAC2") as ComponentWeapon
            },
            {"Hyper-Velocity Autocannon 5",new ComponentWeapon() //TM341
            {
                Name = "Hyper-Velocity Autocannon 5",
                BaseCost = 160000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 5,
                AeroDamage = 5,
                MinimumRange = 3,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 20,
                Tonnage = 12,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=70
            }
            .AddAlias("HVAC5")
            .AddAlias("HVAC/5")
                .AddAlias("Hyper Velocity Auto Cannon/5")
            .AddAlias("Hyper-Velocity Autocannon/5")
            .AddAlias("ISHVAC5") as ComponentWeapon
            },
              {"Hyper-Velocity Autocannon 10",new ComponentWeapon() //TM341
            {
                Name = "Hyper-Velocity Autocannon 10",
                BaseCost = 230000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 10,
                AeroDamage = 10,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 10,
                Tonnage = 14,
                CriticalSpaceMech = 6,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 6,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=123
            }
               .AddAlias("HVAC10")
               .AddAlias("HVAC/10")
               .AddAlias("Hyper-Velocity Autocannon/10")
                .AddAlias("Hyper Velocity Auto Cannon/10")
               .AddAlias("ISHVAC10") as ComponentWeapon
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=178


            }
            .AddAlias("AC20")
            .AddAlias("AC/20")
            .AddAlias("Autocannon/20")
            .AddAlias("ISAC20") as ComponentWeapon
            },
            {"Primitive Autocannon 2",new ComponentWeapon() //IO216
            {
                Name = "Primitive Autocannon 2",
                BaseCost = 75000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 4,
                ShortRange = 8,
                MediumRange = 16,
                LongRange = 24,
                AmmoPerTon = 34,
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=37
            }
            .AddAlias("Primitive AC2")
            .AddAlias("Primitive AC/2")
            .AddAlias("Primitive Autocannon/2")
            .AddAlias("ISPrimitiveAC2") as ComponentWeapon
            },
            {"Primitive Autocannon 5",new ComponentWeapon() //IO216
            {
                Name = "Primitive Autocannon 5",
                BaseCost = 125000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 5,
                AeroDamage = 5,
                MinimumRange = 3,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 15,
                Tonnage = 8,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=70
            }
            .AddAlias("Primitive AC5")
            .AddAlias("Primitive AC/5")
            .AddAlias("Primitive Autocannon/5")
            .AddAlias("PrimitiveISAC5") as ComponentWeapon
            },
              {"Primitive Autocannon 10",new ComponentWeapon() //IO216
            {
                Name = "Primitive Autocannon 10",
                BaseCost = 200000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 10,
                AeroDamage = 10,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 8,
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=123
            }
               .AddAlias("Primitive AC10")
               .AddAlias("Primitive AC/10")
               .AddAlias("Primitive Autocannon/10")
               .AddAlias("PrimitiveISAC10") as ComponentWeapon
            },
            {"Primitive Autocannon 20",new ComponentWeapon() //IO216
            {
                Name = "Primitive Autocannon 20",
                BaseCost = 300000,
                Heat = 7,
                AeroHeat = 7,
                Damage = 20,
                AeroDamage = 20,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 4,
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=178


            }
            .AddAlias("Primitive AC20")
            .AddAlias("Primitive AC/20")
            .AddAlias("Primitive Autocannon/20")
            .AddAlias("Primitive ISAC20") as ComponentWeapon
            },
            {"Improved Autocannon 2",new ComponentWeapon() //IO216
            {
                Name = "Improved Autocannon 2",
                BaseCost = 75000,
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=37
            }
            .AddAlias("Improved AC2")
            .AddAlias("Improved AC/2")
            .AddAlias("Improved Autocannon/2")
            .AddAlias("ISImprovedAC2") as ComponentWeapon
            },
            {"Improved Autocannon 5",new ComponentWeapon() //IO216
            {
                Name = "Improved Autocannon 5",
                BaseCost = 125000,
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
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=70
            }
            .AddAlias("Improved AC5")
            .AddAlias("Improved AC/5")
            .AddAlias("Improved Autocannon/5")
            .AddAlias("ImprovedISAC5") as ComponentWeapon
            },
              {"Improved Autocannon 10",new ComponentWeapon() //IO216
            {
                Name = "Improved Autocannon 10",
                BaseCost = 200000,
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=123
            }
               .AddAlias("Improved AC10")
               .AddAlias("Improved AC/10")
               .AddAlias("Improved Autocannon/10")
               .AddAlias("ImprovedISAC10") as ComponentWeapon
            },
            {"Improved Autocannon 20",new ComponentWeapon() //IO216
            {
                Name = "Improved Autocannon 20",
                BaseCost = 300000,
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=178


            }
            .AddAlias("Improved AC20")
            .AddAlias("Improved AC/20")
            .AddAlias("Improved Autocannon/20")
            .AddAlias("Improved ISAC20") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=9
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=46
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=123
            }
                         .AddAlias("LLaser")
            .AddAlias("ISLargeLaser") as ComponentWeapon
            },
               {"Binary Laser Cannon",new ComponentWeapon() //TO406
            {
                Name = "Bnary Laser Cannon",
                BaseCost = 200000,
                Heat = 16,
                AeroHeat = 16,
                Damage = 12,
                AeroDamage = 12,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 0,
                Tonnage = 9,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="D",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=222
            }
                         .AddAlias("Blazer")
                .AddAlias("ISBlazer")
                .AddAlias("Binary Laser (Blazer) Cannon")
            .AddAlias("Blazer Cannon") as ComponentWeapon
            },
              {"Primitive Small Laser",new ComponentWeapon() //TM341
            {
                Name = "Primitive Small Laser",
                BaseCost = 11250,
                Heat = 2,
                AeroHeat = 2,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=9
            }
            .AddAlias("Primitive SLaser")
            .AddAlias("ISPrimitive SmallLaser") as ComponentWeapon
            },
            {"Primitive Medium Laser",new ComponentWeapon() //TM341
            {
                Name = "Primitive Medium Laser",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=46
            }
                        .AddAlias("Primitive MLaser")
            .AddAlias("Primitive ISMediumLaser") as ComponentWeapon
            },
             {"Primitive Large Laser",new ComponentWeapon() //TM341
            {
                Name = "Primitive Large Laser",
                BaseCost = 20000,
                Heat = 12,
                AeroHeat = 12,
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
                CriticalSpaceSupportVehicle = 2, //TODO: Seems like this should be 2.
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=123
            }
                         .AddAlias("Primitive LLaser")
            .AddAlias("Primitive ISLargeLaser") as ComponentWeapon
            },

             {"Improved Large Laser",new ComponentWeapon() //TM341
            {
                Name = "Improved Large Laser",
                BaseCost = 20000,
                Heat = 12,
                AeroHeat = 12,
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
                CriticalSpaceSupportVehicle = 2, //TODO: Seems like this should be 2.
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=123
            }
                         .AddAlias("Improved LLaser")
            .AddAlias("Improved ISLargeLaser") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=15
            }
             .AddAlias("CLHeavySmallLaser") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=76
            }
            .AddAlias("CLHeavyMediumLaser") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
				BV=244
            }
             .AddAlias("CLHeavyLargeLaser") as ComponentWeapon
            },
             {"Improved Heavy Small Laser",new ComponentWeapon() //TO406
            {
                Name = "Improved Heavy Small Laser",
                BaseCost = 30000,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=19
            }
             .AddAlias("CLImprovedHeavySmallLaser") as ComponentWeapon
            },
            {"Improved Heavy Medium Laser",new ComponentWeapon() //TM406
            {
                Name = "Improved Heavy Medium Laser",
                BaseCost = 150000,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=93
            }
            .AddAlias("CLHeavyMediumLaser") as ComponentWeapon
            },
             {"Improved Heavy Large Laser",new ComponentWeapon() //TM406
            {
                Name = "Improved Heavy Large Laser",
                BaseCost = 350000,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=296
            }
             .AddAlias("CLHeavyLargeLaser") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=176
            }
              .AddAlias("Particle Cannon")
                .AddAlias("ISPPC") as ComponentWeapon
            },
                {"Improved PPC",new ComponentWeapon() //TM341
            {
                Name = "Improved PPC",
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=176
            }
              .AddAlias("Improved Particle Cannon")
                .AddAlias("ISImprovedPPC") as ComponentWeapon
            },
                   {"Enhanced PPC",new ComponentWeapon() //TM341
            {
                Name = "Enhanced PPC",
                BaseCost = 300000,
                Heat = 15,
                AeroHeat = 15,
                Damage = 12,
                AeroDamage = 12,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=176
            }
              .AddAlias("Enhanced Particle Cannon")

                .AddAlias("CLEnhancedPPC") as ComponentWeapon
            },
              {"Primitive PPC",new ComponentWeapon() //IO216
            {
                Name = "Primitive PPC",
                BaseCost = 20000,
                Heat = 15,
                AeroHeat = 15,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=176
            }
              .AddAlias("Primitive Particle Cannon")
                .AddAlias("Primitive ISPPC") as ComponentWeapon
            },
				{"Primitive Prototype PPC",new ComponentWeapon() //IO216
            {
				Name = "Primitive Prototype PPC",
				BaseCost = 200000,
				Heat = 15,
				AeroHeat = 15,
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
				HeatIsPerShot= false,
				TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
				BV=176
			}
			  .AddAlias("Primitive Prototype Particle Cannon")
				.AddAlias("Primitive Prototype ISPPC") as ComponentWeapon
			},
				 {"Bombast Laser",new ComponentWeapon() //TM341
            {
                     // The Bombast Laser is a ridiculous corner case weapon
                     // that is almost never used.  We aren't going to implement
                     // it unless someone asks for it.
                Name = "Bombast Laser",
                BaseCost = 200000,
                Heat = 0,
                AeroHeat = 12,
                Damage = 12,
                AeroDamage = 12,
                MinimumRange = 5,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
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
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=137,
                SBFShortRangeDamageOverride= 10.2F,
                SBFMediumRangeDamageOverride=10.2F
            }
              .AddAlias("ISBombastLaser") as ComponentWeapon
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=21
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=39
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=59
            }.AddAlias("SRM/6")
                .AddAlias("SRM6")
                .AddAlias("ISSRM6") as ComponentWeapon
            },
            {"Primitive SRM 2",new ComponentWeaponClustered() //IO216
            {
                Name = "Primitive SRM 2",
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
                AmmoPerTon = 37,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=21
            }
            .AddAlias("Primitive SRM/2")
                .AddAlias("Primitive SRM2")
                .AddAlias("Primitive ISSRM2") as ComponentWeapon
            },
            {"Primitive SRM 4",new ComponentWeaponClustered() //IO216
            {
                Name = "Primitive SRM 4",
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
                AmmoPerTon = 18,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=39
            }
            .AddAlias("Primitive SRM/4")
                .AddAlias("Primitive SRM4")
                .AddAlias("Primitive ISSRM4") as ComponentWeapon
            },
            {"Primitive SRM 6",new ComponentWeaponClustered() //IO216
            {
                Name = "Primitive SRM 6",
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
                AmmoPerTon = 11,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRM",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=59
            }.AddAlias("Primitive SRM/6")
                .AddAlias("Primitive SRM6")
                .AddAlias("Primitive ISSRM6") as ComponentWeapon
            },
            {"Improved SRM 2",new ComponentWeaponClustered() //IO217
            {
                Name = "Improved SRM 2",
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRM",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=21
            }
            .AddAlias("Improved SRM/2")
                .AddAlias("Improved SRM2")
                .AddAlias("Improved ISSRM2") as ComponentWeapon
            },
            {"Improved SRM 4",new ComponentWeaponClustered() //IO217
            {
                Name = "Improved SRM 4",
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRM",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=39
            }
            .AddAlias("Improved SRM/4")
                .AddAlias("Improved SRM4")
                .AddAlias("Improved ISSRM4") as ComponentWeapon
            },
            {"Improved SRM 6",new ComponentWeaponClustered() //IO217
            {
                Name = "Improved SRM 6",
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRM",
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=59
            }.AddAlias("Improved SRM/6")
                .AddAlias("Improved SRM6")
                .AddAlias("Improved ISSRM6") as ComponentWeapon
            },
            {"SRT 2",new ComponentWeaponClustered() //TM341
            {
                Name = "SRT 2",
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRT",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=21
            }
            .AddAlias("SRT/2")
                .AddAlias("SRT2")
                .AddAlias("ISSRT2") as ComponentWeapon
            },
            {"SRT 4",new ComponentWeaponClustered() //TM341
            {
                Name = "SRT 4",
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRT",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=39
            }
            .AddAlias("SRT/4")
                .AddAlias("SRT4")
                .AddAlias("ISSRT4") as ComponentWeapon
            },
            {"SRT 6",new ComponentWeaponClustered() //TM341
            {
                Name = "SRT 6",
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                AlphaStrikeAbility = "SRT",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=59
            }.AddAlias("SRT/6")
                .AddAlias("SRT6")
                .AddAlias("ISSRT6") as ComponentWeapon
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=4
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=8
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=12
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "SRM",
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=21
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "SRM",
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=39
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "SRM",
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=59
            }.AddAlias("SRM/6")
                .AddAlias("SRM6")
                .AddAlias("CLSRM6") as ComponentWeapon
            },
            {"Clan SRT 2",new ComponentWeaponClustered() //TM341
            {
                Name = "SRT 2",
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "SRT",
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=21
            }
             .AddAlias("SRT/2")
                .AddAlias("SRT2")
                .AddAlias("CLSRT2") as ComponentWeapon
            },
            {"Clan SRT 4",new ComponentWeaponClustered() //TM341
            {
                Name = "SRT 4",
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "SRT",
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=39
            }
            .AddAlias("SRT/4")
                .AddAlias("SRT4")
                .AddAlias("CLSRT4") as ComponentWeapon
            },
            {"Clan SRT 6",new ComponentWeaponClustered() //TM341
            {
                Name = "SRT 6",
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "SRT",
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=59
            }.AddAlias("SRT/6")
                .AddAlias("SRT6")
                .AddAlias("CLSRT6") as ComponentWeapon
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=5
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=5

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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=5

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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=5

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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=6

            }
             },

                      {"ProtoMech AC/2",new ComponentWeapon() //TM341
            {
                Name = "ProtoMech AC/2",
                BaseCost = 95000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 0,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 40,
                Tonnage = 3.5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = 1,
                CriticalSpaceCombatVehicle = 2,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=34

            }
                    .AddAlias("ProtoMech Autocannon/2") as ComponentWeapon
             },
                          {"ProtoMech AC/4",new ComponentWeapon() //TM341
            {
                Name = "ProtoMech AC/4",
                BaseCost = 133000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 4,
                AeroDamage = 4,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 20,
                Tonnage = 4.5,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = 1,
                CriticalSpaceCombatVehicle = 3,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=49

            }
                    .AddAlias("ProtoMech Autocannon/4") as ComponentWeapon
             },
                                     {"ProtoMech AC/8",new ComponentWeapon() //TM341
            {
                Name = "ProtoMech AC/8",
                BaseCost = 175000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 8,
                AeroDamage = 8,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 7,
                LongRange = 10,
                AmmoPerTon = 10,
                Tonnage = 5.5,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = 1,
                CriticalSpaceCombatVehicle = 4,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=66

            }
                    .AddAlias("ProtoMech Autocannon/8") as ComponentWeapon
             },

               {"IS Heavy Machine Gun",new ComponentWeapon() //TM341
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=6

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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=6
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=6
            }
             .AddAlias("CLFlamer") as ComponentWeapon
            },
              {"Vehicle Flamer",new ComponentWeapon() //TM341
            {
                Name = "Vehicle Flamer",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 20,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=6
            }
              .AddAlias("Flamer (Vehicle)")
            .AddAlias("ISVehicleFlamer") as ComponentWeapon
            },
                {"Clan Vehicle Flamer",new ComponentWeapon() //TM341
            {
                Name = "Clan Vehicle Flamer",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 2,
                AeroDamage = 2,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 20,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=6
            }
              .AddAlias("Flamer (Vehicle)")
            .AddAlias("CLVehicleFlamer") as ComponentWeapon
            },
                {"LB 2-X AC",new ComponentWeaponClustered() //TM341
            {
                Name = "LB 2-X AC",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 1,
                AeroDamage = 2,
                SalvoSize =2,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=42
            }.AddAlias("ISLBXAC2") as ComponentWeapon
            },
                    {"Light Rifle",new ComponentWeapon() //TO411
            {
                Name = "Light Rifle",
                BaseCost = 37750,
                Heat = 1,
                AeroHeat = 1,
                
                Damage = 3,
                AeroDamage = 3,
                MinimumRange = 0,
                ShortRange = 4,
                MediumRange = 8,
                LongRange = 12,
                AmmoPerTon = 18,
                Tonnage = 3,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=83
            }
                .AddAlias("LightRifle") as ComponentWeapon
            },
                     {"Medium Rifle",new ComponentWeapon() //TO411
            {
                Name = "Medium Rifle",
                BaseCost = 75500,
                Heat = 2,
                AeroHeat = 2,

                Damage = 6,
                AeroDamage = 6,
                MinimumRange = 1,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 9,
                Tonnage = 5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=83
            }
                .AddAlias("MediumRifle") as ComponentWeapon
            },
                           {"Heavy Rifle",new ComponentWeapon() //TO411
            {
                Name = "Heavy Rifle",
                BaseCost = 90000,
                Heat = 4,
                AeroHeat = 4,

                Damage = 9,
                AeroDamage = 9,
                MinimumRange = 2,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 18,
                AmmoPerTon = 6,
                Tonnage = 8,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=83
            }
                .AddAlias("HeavyRifle") as ComponentWeapon
            },
                {"LB 5-X AC",new ComponentWeaponClustered() //TM341
            {
                Name = "LB 5-X AC",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                SalvoSize =5,
                Damage = 1,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=83
            }
                .AddAlias("ISLBXAC5") as ComponentWeapon
            },
                {"LB 10-X AC",new ComponentWeaponClustered() //TM341
            {
                Name = "LB 10-X AC",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                SalvoSize =10,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=148
            }
                .AddAlias("ISLBXAC10") as ComponentWeapon
            },
                {"LB 20-X AC",new ComponentWeaponClustered() //TM341
            {
                Name = "LB 20-X AC",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                SalvoSize =20,
                Damage = 1,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=237
            }
                .AddAlias("ISLBXAC20") as ComponentWeapon
            },
            {"Clan LB 2-X AC",new ComponentWeaponClustered() //TM343
            {
                Name = "LB 2-X AC",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 1,
                AeroDamage = 2,
                MinimumRange = 4,
                SalvoSize =2,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=47
            }
            .AddAlias("CLLBXAC2") as ComponentWeapon
            },
            {"Clan LB 5-X AC",new ComponentWeaponClustered() //TM343
            {
                Name = "LB 5-X AC",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 1,
                AeroDamage = 3,
                MinimumRange = 3,
                SalvoSize =5,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=93
            }
            .AddAlias("CLLBXAC5") as ComponentWeapon
            },
            {"Clan LB 10-X AC",new ComponentWeaponClustered() //TM343
            {
                Name = "LB 10-X AC",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                AeroDamage = 6,
                MinimumRange = 0,
                SalvoSize =10,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=148
            }
            .AddAlias("CLLBXAC10") as ComponentWeapon
            },
            {"Clan LB 20-X AC",new ComponentWeaponClustered() //TM343
            {
                Name = "LB 20-X AC",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                AeroDamage = 12,
                SalvoSize =10,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=237
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=17
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=62
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=163
            }
             .AddAlias("ISERLargeLaser") as ComponentWeapon
            },
             {"Prototype ER Small Laser",new ComponentWeapon() //TM341
            {
                Name = "Prototype ER Small Laser",
                BaseCost = 11250,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=17
            }
            .AddAlias("ISPrototypeERSmallLaser") as ComponentWeapon
            },
            {"Prototype ER Medium Laser",new ComponentWeapon() //TM341
            {
                Name = "Prototype ER Medium Laser",
                BaseCost = 80000,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=62
            }
            .AddAlias("ISPrototypeERMediumLaser") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=228
            }
              .AddAlias("ISERPPC")
              .AddAlias("ER Particle Cannon") as ComponentWeapon
            },
              {"Enhanced ER PPC",new ComponentWeapon() //TM341
            {
                Name = "Enhanced ER PPC",
                BaseCost = 20000,
                Heat = 15,
                AeroHeat = 15,
                Damage = 12,
                AeroDamage = 12,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=228
            }
              .AddAlias("ISEHERPPC")
              .AddAlias("Enhanced ER Particle Cannon") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                ToHitModifier=-2,
                BV=12
            }.AddAlias("CLMicroPulseLaser") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=7
            }
            },
            {"Ultra Autocannon 2",new ComponentWeaponUltraAutocannon() //TM341
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
                HeatIsPerShot= true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=56
            }
            .AddAlias("UAC2")
                .AddAlias("Ultra AC/2")
                .AddAlias("Ultra Autocannon/2")
                .AddAlias("ISUltraAC2") as ComponentWeapon
            },
            {"Ultra Autocannon 5",new ComponentWeaponUltraAutocannon() //TM341
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
                HeatIsPerShot= true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=112
            }
            .AddAlias("UAC5")
                .AddAlias("Ultra AC/5")
                .AddAlias("Ultra Autocannon/5")
                .AddAlias("ISUltraAC5") as ComponentWeapon
            },
              {"Ultra Autocannon 10",new ComponentWeaponUltraAutocannon() //TM341
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
                HeatIsPerShot= true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=210
            }
              .AddAlias("UAC10")
                .AddAlias("Ultra AC/10")
                .AddAlias("Ultra Autocannon/10")
                .AddAlias("ISUltraAC10") as ComponentWeapon
            },
            {"Ultra Autocannon 20",new ComponentWeaponUltraAutocannon() //TM341
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
                HeatIsPerShot= true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV=281
            }
            .AddAlias("UAC20")
                .AddAlias("Ultra AC/20")
                .AddAlias("Ultra Autocannon/20")
                .AddAlias("ISUltraAC20") as ComponentWeapon
            },
            {"Clan Ultra Autocannon 2",new ComponentWeaponUltraAutocannon() //TM341
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
                HeatIsPerShot= true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=62
            }
            .AddAlias("UAC2")
                .AddAlias("Ultra AC/2")
                .AddAlias("Ultra Autocannon/2")
                .AddAlias("CLUltraAC2") as ComponentWeapon
            },
            {"Clan Ultra Autocannon 5",new ComponentWeaponUltraAutocannon() //TM341
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
                HeatIsPerShot= true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=122
            }
            .AddAlias("UAC5")
                .AddAlias("Ultra AC/5")
                .AddAlias("Ultra Autocannon/5")
                .AddAlias("CLUltraAC5") as ComponentWeapon
            },
              {"Clan Ultra Autocannon 10",new ComponentWeaponUltraAutocannon() //TM341
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
                HeatIsPerShot= true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=210
            }
              .AddAlias("UAC10")
                .AddAlias("Ultra AC/10")
                .AddAlias("Ultra Autocannon/10")
                .AddAlias("CLUltraAC10") as ComponentWeapon
            },
            {"Clan Ultra Autocannon 20",new ComponentWeaponUltraAutocannon() //TM341
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
                HeatIsPerShot= true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV=335
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
                HeatIsPerShot= false,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }
            },
             {"Mace",new ComponentMace() //TM341
            {
                Name = "Mace",

                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE
            }.AddAlias("Mace") as ComponentWeapon
            },
              {"Spike",new ComponentSpike() //TM341
            {

            }.AddAlias("Spike") as ComponentWeapon
            },
             {"LRM 5 + Artemis IV",new ComponentWeaponClustered() //TM341
            {
                Name = "LRM 5 + Artemis IV",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 1,
                AeroDamage = 4,
                SalvoSize=5,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 54



            }
             .AddAlias("LRM/5 + Artemis IV")
                .AddAlias("LRM5 + Artemis IV") as ComponentWeapon
            },
            {"LRM 10 + Artemis IV",new ComponentWeaponClustered() //TM341
            {
                Name = "LRM 10 + Artemis IV",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 8,
                SalvoSize=10,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 108
            }.AddAlias("LRM/10 + Artemis IV")
                .AddAlias("LRM10 + Artemis IV") as ComponentWeapon
            },
            {"LRM 15 + Artemis IV",new ComponentWeaponClustered() //TM341
            {
                Name = "LRM 15 + Artemis IV",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 12,
                SalvoSize=15,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 163
            }.AddAlias("LRM/15 + Artemis IV")
                .AddAlias("LRM15 + Artemis IV") as ComponentWeapon
            },
            {"LRM 20 + Artemis IV",new ComponentWeaponClustered() //TM341
            {
                Name = "LRM 20 + Artemis IV",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 1,
                AeroDamage = 16,
                SalvoSize=20,
                IndirectFire=true,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 217
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-2,
                BV = 12
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-2,
                BV = 48
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-2,
                BV = 119
            }
             .AddAlias("ISLargePulseLaser") as ComponentWeapon
            },
             {"Prototype Small Pulse Laser",new ComponentWeapon() //TM341
            {
                Name = "Prototype Small Pulse Laser",
                BaseCost = 20000,
                Heat = 5,//TODO: Generates 10+1D3 Heat
                AeroHeat = 5,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-1,
                BV = 12
            }
               .AddAlias("ISPrototypeSmallPulseLaser") as ComponentWeapon
            },
            {"Prototype Medium Pulse Laser",new ComponentWeapon() //TM341
            {
                Name = "Prototype Medium Pulse Laser",
                BaseCost = 20000,
                Heat = 10, //TODO: Generates 4+1D6 Heat
                AeroHeat = 10,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-1,
                BV = 48
            }
            .AddAlias("ISPrototypeMediumPulseLaser") as ComponentWeapon
            },
             {"Prototype Large Pulse Laser",new ComponentWeapon() //TM341
            {
                Name = "Prototype Large Pulse Laser",
                BaseCost = 20000,
                Heat = 16, //TODO: Generates 10+1D6 Heat
                AeroHeat = 16,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-1,
                BV = 119
            }
             .AddAlias("ISLargePulseLaser") as ComponentWeapon
            },
               {"ER Small Pulse Laser",new ComponentWeapon() //TO406
            {
                Name = "ER Small Pulse Laser",
                BaseCost = 30000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 5,
                AeroDamage = 5,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                ToHitModifier=-2,
                BV = 36
            }
               .AddAlias("ERSmallPulseLaser") as ComponentWeapon
            },
            {"ER Medium Pulse Laser",new ComponentWeapon() //TO406
            {
                Name = "ER Medium Pulse Laser",
                BaseCost = 150000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 7,
                AeroDamage = 7,
                MinimumRange = 0,
                ShortRange = 2,
                MediumRange = 4,
                LongRange = 6,
                AmmoPerTon = 0,
                Tonnage = 2,
                CriticalSpaceMech =2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle =2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                ToHitModifier=-2,
                BV = 117
            }
            .AddAlias("ERMediumPulseLaser") as ComponentWeapon
            },
             {"ER Large Pulse Laser",new ComponentWeapon() //TO406
            {
                Name = "ER Large Pulse Laser",
                BaseCost = 400000,
                Heat = 13,
                AeroHeat = 13,
                Damage = 10,
                AeroDamage = 10,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 0,
                Tonnage = 6,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                ToHitModifier=-2,
                BV = 272
            }
             .AddAlias("ERLargePulseLaser") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                ToHitModifier=-2,
                BV = 24
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                ToHitModifier=-2,
                BV = 111
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                ToHitModifier=-2,
                BV = 265
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
                HeatIsPerShot= false,
                AlphaStrikeAbility = "AC",
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 30
            }
            .AddAlias("LAC2")
                .AddAlias("LAC/2")
                .AddAlias("Light Autocannon/2")
                .AddAlias("Light AC/2")
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
                MinimumRange = 0,
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
                AlphaStrikeAbility = "AC",
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 62
            }
            .AddAlias("LAC5")
                .AddAlias("LAC/5")
                .AddAlias("Light Autocannon/5")
                .AddAlias("Light AC/5")
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 317
            }
            .AddAlias("ISHPPC")
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 31
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 108
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 248
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 412
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 88
            }
              .AddAlias("ISLPPC")
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
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 0
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
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 0
            }
                   .AddAlias("TAG (Clan)")
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
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 0
            }
            .AddAlias("Light TAG [Clan]")
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 21
            }
                .AddAlias("ISSmallXPulseLaser") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 71
            }
            .AddAlias("ISMediumXPulseLaser") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 178
            }
             .AddAlias("ISLargeXPulseLaser") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                VolatileDamage = 20,
                BV = 320
            }
             .AddAlias("ISGaussRifle") as ComponentWeapon
            },
               {"Improved Gauss Rifle",new ComponentWeapon() //TM341
            {
                Name = "Improved Gauss Rifle",
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
                Tonnage = 13,
                CriticalSpaceMech = 6,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 6,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                VolatileDamage = 15,
                BV = 320
            }
             .AddAlias("ISGaussRifle") as ComponentWeapon
            },
              {"Prototype Gauss Rifle",new ComponentWeapon() //IO216
            {
                Name = "Prototype Gauss Rifle",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 15,
                AeroDamage = 15,
                MinimumRange = 2,
                ShortRange = 7,
                MediumRange = 15,
                LongRange = 22,
                AmmoPerTon = 8, //Pretty sure there's a typo in IO, but it isn't in the errata
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                VolatileDamage = 20,
                BV = 320
            }
              .AddAlias("ISGaussRiflePrototype")
             .AddAlias("ISPrototypeGaussRifle") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                VolatileDamage = 3,
                BV = 21
            }
             .AddAlias("CLAPGaussRifle") as ComponentWeapon
            },
              {"Silver Bullet Gauss Rifle",new ComponentWeapon() //TM341
            {
                Name = "Silver Bullet Gauss Rifle",
                BaseCost = 350000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 1,
                AeroDamage = 1,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                VolatileDamage = 20,
                ContributesToTargetingComputerMass = false,
                ToHitModifier=-1,
                BV = 320
            }
              .AddAlias("ISSBGR")
             .AddAlias("ISSBGaussRifle") as ComponentWeapon
            },
            {"Hyper-Assault Gauss 20",new ComponentWeaponClustered () //TM341
            {
                Name = "Hyper-Assault Gauss 20",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                SalvoSize=20,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                VolatileDamage = 10,
                BV = 267
            }
            .AddAlias("CLHAG20")
            .AddAlias("HAG/20") as ComponentWeapon
            },
            {"Hyper-Assault Gauss 30",new ComponentWeaponClustered() //TM341
            {
                Name = "Hyper-Assault Gauss 30",
                BaseCost = 20000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 30,
                AeroDamage = 24, //TODO: Range-based damage
                SalvoSize=30,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                VolatileDamage = 15,
                BV = 401
            }
            .AddAlias("CLHAG30")
            .AddAlias("HAG/30") as ComponentWeapon
            },
            {"Hyper-Assault Gauss 40",new ComponentWeaponClustered() //TM341
            {
                Name = "Hyper-Assault Gauss 40",
                BaseCost = 20000,
                Heat = 8,
                AeroHeat = 8,
                Damage = 40,
                AeroDamage = 32, //TODO: Range-based damage
                SalvoSize=40,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                VolatileDamage = 20,
                BV = 535
            }
            .AddAlias("CLHAG40")
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                VolatileDamage = 15,
                BV = 320
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                VolatileDamage = 16,
                BV = 159
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                VolatileDamage = 16,
                BV = 346
            }
             .SetRangeDamage(25,20,10)
             .AddAlias("ISHeavyGaussRifle") as ComponentWeapon
            },
             {"Improved Heavy Gauss Rifle",new ComponentWeapon() //TM341
            {
                Name = "Improved Heavy Gauss Rifle",
                BaseCost = 700000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 22,
                AeroDamage = 22,
                MinimumRange = 3,
                ShortRange = 6,
                MediumRange = 12,
                LongRange = 19,
                AmmoPerTon = 4,
                Tonnage = 20,
                CriticalSpaceMech = 11,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 11,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                VolatileDamage = 22,
                BV = 385
            }
             .AddAlias("ISImprovedHeavyGaussRifle") as ComponentWeapon
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                VolatileDamage = 25,
                BV = 32,
                DefensiveBV=true
            }
              .AddAlias("AMS")
              .AddAlias("ISAntiMissileSystem")
              .AddAlias("ISAMS") as ComponentWeapon
            },
                  {"Clan Anti-Missile System",new ComponentWeapon() //TM343
            {
                Name = "Anti-Missile System",
                BaseCost = 225000,
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
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.POINTDEFENSE,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 32,
                DefensiveBV = true
            }
                  .AddAlias("AMS")
                  .AddAlias("CLAntiMissileSystem")
                  .AddAlias("CLAMS") as ComponentWeapon
            },
                   {"Laser Anti-Missile System",new ComponentWeapon() //TM343
            {
                Name = "Laser Anti-Missile System",
                BaseCost = 225000,
                Heat = 7,
                AeroHeat = 7,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 0,
                MediumRange = 0,
                LongRange = 0,
                AmmoPerTon = 0,
                Tonnage = 1.5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.POINTDEFENSE,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 45,
                DefensiveBV=true
            }
                  .AddAlias("Laser AMS")
                .AddAlias("CLLaserAntiMissileSystem")
                  .AddAlias("LAMS") as ComponentWeapon
            },
                    {"Clan Laser Anti-Missile System",new ComponentWeapon() //TM343
            {
                Name = "Laser Anti-Missile System",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                VolatileDamage = 25,
                BV = 45,
                DefensiveBV=true
            }
                  .AddAlias("Laser AMS")
                .AddAlias("ISLaserAntiMissileSystem")
                  .AddAlias("LAMS") as ComponentWeapon
            },

                     {"IS 'Mech Mortar 1",new ComponentWeapon() //TO408
            {
                Name = "'Mech Mortar 1",
                BaseCost = 7000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 0,
                AeroDamage = 0,
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
                CriticalSpaceFighters = int.MaxValue,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 10,
                ToHitModifier=3
            }
                     .AddAlias("Mortar 1")
                  .AddAlias("ISMechMortar1") as ComponentWeapon
            },
                      {"Clan 'Mech Mortar 1",new ComponentWeapon() //TO408
            {
                Name = "'Mech Mortar 1",
                BaseCost = 7000,
                Heat = 1,
                AeroHeat = 1,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 24,
                Tonnage = 1,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = int.MaxValue,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 10,
                ToHitModifier=3
            }
                      .AddAlias("Mortar 1")
                  .AddAlias("CLMechMortar1") as ComponentWeapon
            },

                     {"IS 'Mech Mortar 2",new ComponentWeapon() //TO408
            {
                Name = "'Mech Mortar 2",
                BaseCost = 15000,
                Heat = 2,
                AeroHeat = 0,
                Damage = 0,
                AeroDamage = 0,
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
                CriticalSpaceFighters = int.MaxValue,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 14,
                ToHitModifier=3
            }
                     .AddAlias("Mortar 2")
                  .AddAlias("ISMechMortar2") as ComponentWeapon
            },
                      {"Clan 'Mech Mortar 2",new ComponentWeapon() //TO408
            {
                Name = "'Mech Mortar 2",
                BaseCost = 15000,
                Heat = 2,
                AeroHeat = 0,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 12,
                Tonnage = 2.5,
                CriticalSpaceMech = 1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = int.MaxValue,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 10,
                ToHitModifier=3
            }
                      .AddAlias("Mortar 2")
                  .AddAlias("CLMechMortar2") as ComponentWeapon
            },
                               {"IS 'Mech Mortar 4",new ComponentWeapon() //TO408
            {
                Name = "'Mech Mortar 4",
                BaseCost = 32000,
                Heat = 5,
                AeroHeat = 0,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 6,
                Tonnage = 7,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = int.MaxValue,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 26,
                ToHitModifier=3
            }
                               .AddAlias("Mortar 4")
                  .AddAlias("ISMechMortar4") as ComponentWeapon
            },
                      {"Clan 'Mech Mortar 4",new ComponentWeapon() //TO408
            {
                Name = "'Mech Mortar 4",
                BaseCost = 32000,
                Heat = 5,
                AeroHeat = 0,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 6,
                Tonnage = 3.5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = int.MaxValue,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 26,
                ToHitModifier=3
            }
                      .AddAlias("Mortar 4")
                  .AddAlias("CLMechMortar4") as ComponentWeapon
            },
                                         {"IS 'Mech Mortar 8",new ComponentWeapon() //TO408
            {
                Name = "'Mech Mortar 8",
                BaseCost = 70000,
                Heat = 10,
                AeroHeat = 0,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 4,
                Tonnage = 10,
                CriticalSpaceMech = 5,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5,
                CriticalSpaceFighters = int.MaxValue,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 50,
                ToHitModifier=3
            }
                .AddAlias("Mortar 8")
                  .AddAlias("ISMechMortar4") as ComponentWeapon
            },
                      {"Clan 'Mech Mortar 8",new ComponentWeapon() //TO408
            {
               Name = "'Mech Mortar 8",
                BaseCost = 70000,
                Heat = 10,
                AeroHeat = 0,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 6,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 4,
                Tonnage = 5,
                CriticalSpaceMech = 3,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 3,
                CriticalSpaceFighters = int.MaxValue,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 50,
                ToHitModifier=3
            }
                      .AddAlias("Mortar 8")
                  .AddAlias("CLMechMortar8") as ComponentWeapon
            },
            {"Streak SRM 2",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak SRM 2",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 2,
                AeroDamage = 4,
                Streak = true,
                SalvoSize=2,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 30
            }
            .AddAlias("ISStreakSRM2") as ComponentWeapon
            },
            {"Streak SRM 4",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak SRM 4",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 2,
                AeroDamage = 8,
                Streak = true,
                SalvoSize=4,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 59
            }
            .AddAlias("ISStreakSRM4") as ComponentWeapon
            },
            {"Streak SRM 6",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak SRM 6",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 2,
                AeroDamage = 12,
                Streak = true,
                SalvoSize=6,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 89
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
                Streak= true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 40
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
                Streak=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 79
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
                Streak=true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 118
            }
            .AddAlias("CLStreakSRM6") as ComponentWeapon
            },
            {"Streak SRM 2 (OS)",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak SRM 2 (OS)",
                BaseCost = 20000,
                Heat = 2,
                AeroHeat = 2,
                Damage = 2,
                AeroDamage = 4,
                Streak = true,
                SalvoSize=2,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 6
            }
            },
            {"Streak SRM 4 (OS)",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak SRM 4 (OS)",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 2,
                AeroDamage = 8,
                Streak = true,
                SalvoSize=4,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 12
            }
            },
            {"Streak SRM 6 (OS)",new ComponentWeaponClustered() //TM341
            {
                Name = "Streak SRM 6 (OS)",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 2,
                AeroDamage = 12,
                Streak = true,
                SalvoSize=6,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 18
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
                Streak = true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 8
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
                Streak = true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 16
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
                Streak = true,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 24
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 165
            }
            .SetRangeDamage(10,8,5)
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 53
            }
            .AddAlias("CLATM3") as ComponentWeapon
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 105
            }.AddAlias("CLATM6") as ComponentWeapon
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 147
            }
            .AddAlias("CLATM9") as ComponentWeapon
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 212
            }
            .AddAlias("CLATM12") as ComponentWeapon
            },
            {"Rocket Launcher 10",new ComponentWeaponClustered() //TM342
            {
                Name = "Rocket Launcher 10",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 1,
                AeroDamage = 6,
                SalvoSize=10,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                BV = 18
            }
            .AddAlias("Rocket Launcher 10")
            .AddAlias("ISRocketLauncher10") as ComponentWeapon
            },
             {"Rocket Launcher 15",new ComponentWeaponClustered() //TM342
            {
                Name = "Rocket Launcher 15",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 9,
                SalvoSize=15,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                BV = 23
            }
             .AddAlias("ISRocketLauncher15") as ComponentWeapon
            },
            {"Rocket Launcher 20",new ComponentWeaponClustered() //TM342
            {
                Name = "Rocket Launcher 20",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 12,
                SalvoSize=20,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                BV = 24
            }
            .AddAlias("ISRocketLauncher20") as ComponentWeapon
            },
            {"Prototype Rocket Launcher 10",new ComponentWeaponClustered() //TM342
            {
                Name = "Prototype Rocket Launcher 10",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 1,
                AeroDamage = 6,
                SalvoSize=10,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                BV = 18
            }
            .AddAlias("CLRocketLauncher10Prototype")
            .AddAlias("Rocket Launcher 10 (PP)") as ComponentWeapon
            },
             {"Prototype Rocket Launcher 15",new ComponentWeaponClustered() //TM342
            {
                Name = "Prototype Rocket Launcher 15",
                BaseCost = 20000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 1,
                AeroDamage = 9,
                SalvoSize=15,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                BV = 23
            }
             .AddAlias("CLRocketLauncher15Prototype")
             .AddAlias("Prototype Rocket Launcher 15 (PP)") as ComponentWeapon
            },
            {"Prototype Rocket Launcher 20",new ComponentWeaponClustered() //TM342
            {
                Name = "Prototype Rocket Launcher 20",
                BaseCost = 20000,
                Heat = 5,
                AeroHeat = 5,
                Damage = 1,
                AeroDamage = 12,
                SalvoSize=20,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                BV = 24
            }
            .AddAlias("CLRocketLauncher20Prototype")
            .AddAlias("Rocket Launcher 20 (PP)") as ComponentWeapon
            },
            {"Prototype Arrow IV",new ComponentArtillery() //TM342
            {
                Name = "Prototype Arrow IV",
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
                AmmoPerTon = 3,
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 240
            }
            .AddAlias("Prototype Arrow IV")
            .AddAlias("ISPrototypeArrowIVSystem") as ComponentWeapon
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 240
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 168
            }
            .AddAlias("Arrow IV")
            .AddAlias("CLArrowIVSystem") as ComponentWeapon
            },
            {"Sniper",new ComponentArtillery() //TM342
            {
                Name = "Sniper",
                BaseCost = 300000,
                Heat = 10,
                AeroHeat = 10,
                Damage = 20,
                AeroDamage = 0,
                ArtilleryRange = 18,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 7,
                LongRange = 12,
                AmmoPerTon = 10,
                Tonnage = 20,
                CriticalSpaceMech =20,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 20,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                BV = 240
            }
            .AddAlias("Sniper Cannon")
            .AddAlias("ISSniperArtCannon")
            .AddAlias("ISSniper")
            .AddAlias("CLSniper") as ComponentWeapon
            },
            {"Thumper",new ComponentArtillery() //TM342
            {
                Name = "Thumper",
                BaseCost = 187500,
                Heat = 6,
                AeroHeat = 6,
                Damage = 15,
                AeroDamage = 0,
                ArtilleryRange = 21,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 7,
                LongRange = 12,
                AmmoPerTon = 20,
                Tonnage = 12,
                CriticalSpaceMech =12,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 12,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                BV = 240
            }
            .AddAlias("Thumper Cannon")
                .AddAlias("ISThumperArtCannon")
            .AddAlias("ISThumper")
            .AddAlias("CLThumper") as ComponentWeapon
            },
            {"Long Tom",new ComponentArtillery() //TM342
            {
                Name = "Long Tom",
                BaseCost = 450000,
                Heat = 20,
                AeroHeat = 20,
                Damage = 25,
                AeroDamage = 0,
                ArtilleryRange = 30,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 7,
                LongRange = 12,
                AmmoPerTon = 5,
                Tonnage = 20,
                CriticalSpaceMech =20,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 20,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="B",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                BV = 240
            }
            .AddAlias("Long Tom Cannon")
            .AddAlias("ISLongTom")
                .AddAlias("ISLongTomArtCannon")
            .AddAlias("CLLongTom") as ComponentWeapon
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
                CriticalSpaceProtomech = 1,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 0
            }
            .AddAlias("ISMGA")
                .AddAlias("ISLMGA")
                .AddAlias("Light Machine Gun Array")
                .AddAlias("Heavy Machine Gun Array") as ComponentWeapon
            },
             {"Heavy Flamer",new ComponentWeapon() //TO400
            {
                Name = "Heavy Flamer",
                BaseCost = 11250,
                Heat = 5,
                AeroHeat = 5,
                Damage = 4,
                AeroDamage = 4,

                MinimumRange = 0,
                ShortRange = 2,
                MediumRange = 3,
                LongRange = 4,
                AmmoPerTon = 10,
                Tonnage = 1.5,
                CriticalSpaceMech =1,
                CriticalSpaceProtomech = 1,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = int.MaxValue,
                CriticalSpaceDropShips = int.MaxValue,
                TechRating="D",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                BV = 15 
            }
             .AddAlias("ISHeavyFlamer")
                .AddAlias("CLHeavyFlamer") as ComponentWeapon
                
            },
              {"ER Flamer",new ComponentWeapon() //TO400
            {
                Name = "ER Flamer",
                BaseCost = 15000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 2,
                AeroDamage = 2,

                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 5,
                LongRange = 7,
                AmmoPerTon = 0,
                Tonnage = 1,
                CriticalSpaceMech =1,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 1,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                BV = 16 
            }
              .AddAlias("CLERFlamer")
                .AddAlias("ISERFlamer")
                .AddAlias("ERFlamer") as ComponentWeapon
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 0 //Double-check we're calculating this right
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 29
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 45
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 67
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 86
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 210



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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 170
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                ToHitModifier=1,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 56
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                ToHitModifier=1,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 112
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                ToHitModifier=1,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 168
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                ToHitModifier=1,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 224
            }
              .AddAlias("ISMRM40") as ComponentWeapon
            },
            {"Rotary AC/2",new ComponentWeaponRotaryAutocannon() //TM342
            {
                Name = "Rotary AC/2",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 6,
                Damage = 2,
                AeroDamage = 8,
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
                HeatIsPerShot= true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 118
            }
            .AddAlias("ISRotaryAC2") as ComponentWeapon
            },
            {"Rotary AC/5",new ComponentWeaponRotaryAutocannon() //TM342
            {
                Name = "Rotary AC/5",
                BaseCost = 20000,
                Heat = 1,
                AeroHeat = 6,
                Damage = 5,
                AeroDamage = 20,
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
                HeatIsPerShot= true,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 247
            }
            .AddAlias("ISRotaryAC5") as ComponentWeapon
            },
            {"Clan Rotary AC/2",new ComponentWeaponRotaryAutocannon() //TM342
            {
                Name = "Rotary AC/2",
                BaseCost = 175000,
                Heat = 1,
                AeroHeat = 6,
                Damage = 2,
                AeroDamage = 8,
                MinimumRange = 0,
                ShortRange = 8,
                MediumRange = 17,
                LongRange = 25,
                AmmoPerTon = 45,
                Tonnage = 8,
                CriticalSpaceMech =4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.EXTREME,
                HeatIsPerShot= true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 161
            }
            .AddAlias("CLRotaryAC2") as ComponentWeapon
            },
            {"Clan Rotary AC/5",new ComponentWeaponRotaryAutocannon() //TM342
            {
                Name = "Rotary AC/5",
                BaseCost = 275000,
                Heat = 1,
                AeroHeat = 6,
                Damage = 5,
                AeroDamage = 20,
                MinimumRange = 0,
                ShortRange = 7,
                MediumRange = 14,
                LongRange = 21,
                AmmoPerTon = 20,
                Tonnage = 10,
                CriticalSpaceMech =8,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 8,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="F",
                AeroRange = AerospaceWeaponRanges.LONG,
                HeatIsPerShot= true,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 345
            }
            .AddAlias("CLRotaryAC5") as ComponentWeapon
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
                HeatIsPerShot= true,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 30

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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 30
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
                HeatIsPerShot= false,
                ContributesToTargetingComputerMass=false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 75
            }
            .AddAlias("iNarc")
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 1,
                DefensiveBV=true
            }
            .AddAlias("ISAntiPersonnelPod")
            .AddAlias("CLAntiPersonnelPod") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.CLAN,
                BV = 2,
                DefensiveBV=true
            }
            .AddAlias("B-Pod")
            .AddAlias("CLBPod")
            .AddAlias("Anti-BattleArmor Pods (B-Pods)") as ComponentWeapon
            },
            {"IS A-Pods",new ComponentAntiPersonnelPod() //TM341
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 1,
                DefensiveBV=true
            }
            .AddAlias("ISAntiPersonnelPod")
            .AddAlias("CLAntiPersonnelPod") as ComponentWeapon
            },
            {"IS B-Pod",new ComponentAntiPersonnelPod() //TM341
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 2,
                DefensiveBV=true
            }
            .AddAlias("B-Pod")
            .AddAlias("ISBPod")
            .AddAlias("Anti-BattleArmor Pods (B-Pods)") as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=1,
                VolatileDamage = 1, //So we treat it as a Gauss for BV (TO383)
                BV = 40


            }
              .AddAlias("ISTaser")
                .AddAlias("ISMekTaser")
                .AddAlias("BattleMech Taser")
              .AddAlias("Mech Taser") as ComponentWeapon
            },
              {"Dual Saw",new ComponentWeapon() //TO410
            {
                Name = "Dual Saw",
                BaseCost = 20000,
                Heat = 0,
                AeroHeat = 0,
                Damage = 7,
                AeroDamage = 7,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 1,
                LongRange = 1,
                AmmoPerTon = 0,
                Tonnage = 7,
                CriticalSpaceMech = 7,
                CriticalSpaceProtomech = null,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 7,
                CriticalSpaceFighters = null,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="C",
                AeroRange = AerospaceWeaponRanges.NA,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=1,
                BV = 9

            }
              .AddAlias("ISDualSaw")
               as ComponentWeapon
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 64
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 127
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 229
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 305
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 5
            }
               .AddAlias("ISMPod")
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                BV = 15
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.BOTH,
                BV = 6
            }
              .AddAlias("ISFluid Gun")
                .AddAlias("ISFluidGun")
                .AddAlias("CLFluidGun")
              .AddAlias("CLFluid Gun") as ComponentWeapon
            },
             {"Small Variable-Speed Pulse Laser",new ComponentWeapon() //TM341
            {
                Name = "Small Variable-Speed Pulse Laser",
                BaseCost = 20000,
                Heat = 3,
                AeroHeat = 3,
                Damage = 5, //TODO: Range-dependent damage
                AeroDamage = 5,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-2, //TODO: VSP To-Hit Modifier
                BV=22
            }
             .SetRangeDamage(5,4,3)
                .AddAlias("Small VSP")
                .AddAlias("Small VSP Laser")
               .AddAlias("ISSmallVSPLaser") as ComponentWeapon
            },
            {"Medium Variable-Speed Pulse Laser",new ComponentWeapon() //TM341
            {
                Name = "Medium Variable-Speed Pulse Laser",
                BaseCost = 20000,
                Heat = 7,
                AeroHeat = 7,
                Damage = 9,
                AeroDamage = 9,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 0,
                Tonnage = 4,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-2,
                BV = 56
            }
            .SetRangeDamage(9,7,5)
                .AddAlias("Medium VSP")
                .AddAlias("Medium VSP Laser")
            .AddAlias("ISMediumVSPLaser") as ComponentWeapon
            },
             {"Large Variable-Speed Pulse Laser",new ComponentWeapon() //TM341
            {
                Name = "Large Variable-Speed Pulse Laser",
                BaseCost = 20000,
                Heat = 10,
                AeroHeat = 10,
                Damage = 11,
                AeroDamage = 11,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 0,
                Tonnage = 9,
                CriticalSpaceMech = 4,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 4,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-2,
                BV = 123
            }
             .SetRangeDamage(11,9,7)
                .AddAlias("Large VSP")
                .AddAlias("Large VSP Laser")
             .AddAlias("ISLargeVSPLaser") as ComponentWeapon
            },
             {"Small Re-Engineered Laser",new ComponentWeapon() //TM341
            {
                Name = "Small Re-Engineered Laser",
                BaseCost = 25000,
                Heat = 4,
                AeroHeat = 4,
                Damage = 4,
                AeroDamage = 4,
                MinimumRange = 0,
                ShortRange = 1,
                MediumRange = 2,
                LongRange = 3,
                AmmoPerTon = 0,
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
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-1,
                BV = 123
            }

             .AddAlias("SmallReengineeredLaser") as ComponentWeapon
            },
              {"Medium Re-Engineered Laser",new ComponentWeapon() //TM341
            {
                Name = "Medium Re-Engineered Laser",
                BaseCost = 100000,
                Heat = 6,
                AeroHeat = 6,
                Damage = 6,
                AeroDamage = 6,
                MinimumRange = 0,
                ShortRange = 3,
                MediumRange = 6,
                LongRange = 9,
                AmmoPerTon = 0,
                Tonnage = 2.5,
                CriticalSpaceMech = 2,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 2,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.SHORT,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-1,
                BV = 123
            }

             .AddAlias("MediumReengineeredLaser") as ComponentWeapon
            },
                 {"Large Re-Engineered Laser",new ComponentWeapon() //TM341
            {
                Name = "Large Re-Engineered Laser",
                BaseCost = 250000,
                Heat = 9,
                AeroHeat = 9,
                Damage = 9,
                AeroDamage = 9,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 0,
                Tonnage = 8,
                CriticalSpaceMech = 5,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                ToHitModifier=-1,
                BV = 123
            }

             .AddAlias("LargeReengineeredLaser") as ComponentWeapon
            },
                     {"TSEMP Cannon",new ComponentWeapon() //TM341
            {
                Name = "TSEMP Cannon",
                BaseCost = 800000,
                Heat = 10,
                AeroHeat = 10,
                Damage = 0,
                AeroDamage = 0,
                MinimumRange = 0,
                ShortRange = 5,
                MediumRange = 10,
                LongRange = 15,
                AmmoPerTon = 0,
                Tonnage = 6,
                CriticalSpaceMech = 5,
                CriticalSpaceProtomech = int.MaxValue,
                CriticalSpaceCombatVehicle = 1,
                CriticalSpaceSupportVehicle = 5,
                CriticalSpaceFighters = 1,
                CriticalSpaceSmallCraft = 1,
                CriticalSpaceDropShips = 1,
                TechRating="E",
                AeroRange = AerospaceWeaponRanges.MEDIUM,
                HeatIsPerShot= false,
                TechnologyBase = TECHNOLOGY_BASE.INNERSPHERE,
                
                BV = 123
            }

             .AddAlias("TSEMP") as ComponentWeapon
            },

            {
                "Remote Sensor Launcher", new ComponentWeapon()
                {
                    Name="Remote Sensor Launcher",
                    Damage=0,
                    AeroDamage=0,
                    Heat=0,
                    HeatIsPerShot = false,
                    MinimumRange=0,
                    ShortRange=3,
                    MediumRange=6,
                    LongRange=9,
                    ContributesToTargetingComputerMass=false,
                    Tonnage = 4,
                    CriticalSpaceMech=3,
                    CriticalSpaceSupportVehicle=3,
                    CriticalSpaceCombatVehicle=1,
                    CriticalSpaceFighters=1,
                    CriticalSpaceSmallCraft=1,
                    AmmoPerTon=4,
                    TechnologyBase= TECHNOLOGY_BASE.INNERSPHERE,
                    TechRating="E",
                    AeroRange=AerospaceWeaponRanges.SHORT,
                    AeroHeat=0,
                    BaseCost=400000,
                    BV=30
                    

                }
                .AddAlias("ISRemoteSensorDispenser") as ComponentWeapon
            }
        };
    }
}
