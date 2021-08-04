using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace BattleTechNETTest
{
    public abstract class DataTest: IDisposable
    {
        public static string sMegaMekLink = @"https://github.com/megamek/megamek/archive/master.zip";
        public DataTest()
        {

            string sTempPath = $".{Path.DirectorySeparatorChar}temp";
            string sTempEnv = Environment.GetEnvironmentVariable("TEMP") ?? "";
            if (sTempEnv != "")
                sTempPath = sTempEnv;
            else
                if (!Directory.Exists(sTempPath)) Directory.CreateDirectory(sTempPath);


            if (Utilities.DataDirectory == "")
            {
                Utilities.DataDirectory = sTempPath;
            }
            else
            {
                sTempPath = Utilities.DataDirectory;
            }

           bool bAlreadyThere = Directory.Exists($"{sTempPath}{Path.DirectorySeparatorChar}megamek-master");
            if(!bAlreadyThere)
            {
                //Download MegaMek Data
                WebClient wc = new WebClient();
                string sLocalFile = $"{sTempPath}{Path.DirectorySeparatorChar}master.zip";
                wc.DownloadFile(sMegaMekLink, sLocalFile);

                ZipFile.ExtractToDirectory(sLocalFile, sTempPath);
                
                
            }
                  
              

        }

        public void Dispose()
        {

        }
    }
}
