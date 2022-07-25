using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace JsonGenerator
{
    class Program
    {
        struct ImageData
        {
            public string rarity;
            public float chance;
            public string imageName;

        }

        static public string refineName(string name)
        {
            if (name.Contains("EFFECTS"))
            {
                name = "background_effect";
                return name;
            }

            if (name.Contains("BACKGROUND"))
            {
                name = "background";
                return name;
            }
            if (name.Contains("LAYERS(0)"))
            {
                name = "layer_0";
                return name;
            }
            if (name.Contains("LAYERS(1)"))
            {
                name = "layer_1";
                return name;
            }
            if (name.Contains("LAYERS(2)"))
            {
                name = "layer_2";
                return name;
            }
            if (name.Contains("PLANTS"))
            {
                name = "plant";
                return name;
            }
            if (name.Contains("BUILDINGS"))
            {
                name = "building";
                return name;
            }
            if (name.Contains("ANIMALS"))
            {
                name = "animal";
                return name;
            }
            if (name.Contains("CHILL"))
            {
                name = "chill";
                return name;
            }
            if (name.Contains("VEHICLES"))
            {
                name = "vehicle";
                return name;
            }
            if (name.Contains("SPECIALS"))
            {
                name = "special";
                return name;
            }

            return name;
        }

        static void Main(string[] args)
        {
            string root = @"D:\freelancer\clients\RedHat\cloverseeds11\NFTs DRIVE CLOVER SEED$ 2022\0 - CLOVERPOT";
            string[] direcotryL = Directory.GetDirectories(root);

            string outfile = @"D:\freelancer\clients\RedHat\out.txt";

            foreach (string traitD in direcotryL)
            {
                string traitName = new DirectoryInfo(traitD).Name;
                traitName = traitName.Substring(traitName.IndexOf('-') + 1).Trim();
                traitName = refineName(traitName);
                if (!traitName.Contains("REWARDS"))
                {
                    string[] dirL = Directory.GetDirectories(traitD);
                    List<ImageData> imageDataL = new List<ImageData>();
                    foreach (string subD in dirL)
                    {
                        float rarity = 0;
                        if (subD.Contains("0_"))
                        {
                            string[] fileL = Directory.GetFiles(subD);
                            rarity = (float)0.1 / fileL.Length;
                            foreach (string file in fileL)
                            {
                                ImageData imageData = new ImageData();
                                imageData.rarity = "Legendary";
                                imageData.chance = rarity;
                                imageData.imageName = Path.GetFileName(file);
                                imageDataL.Add(imageData);
                            }
                        }
                        if (subD.Contains("1_"))
                        {
                            string[] fileL = Directory.GetFiles(subD);
                            rarity = (float)1.0 / fileL.Length;
                            foreach (string file in fileL)
                            {
                                ImageData imageData = new ImageData();
                                imageData.rarity = "Epic";
                                imageData.chance = rarity;
                                imageData.imageName = Path.GetFileName(file);
                                imageDataL.Add(imageData);
                            }
                        }
                        if (subD.Contains("2_"))
                        {
                            string[] fileL = Directory.GetFiles(subD);
                            rarity = (float)5.9 / fileL.Length;
                            foreach (string file in fileL)
                            {
                                ImageData imageData = new ImageData();
                                imageData.rarity = "Very Rare";
                                imageData.chance = rarity;
                                imageData.imageName = Path.GetFileName(file);
                                imageDataL.Add(imageData);
                            }
                        }
                        if (subD.Contains("3_"))
                        {
                            string[] fileL = Directory.GetFiles(subD);
                            rarity = (float)25.0 / fileL.Length;
                            foreach (string file in fileL)
                            {
                                ImageData imageData = new ImageData();
                                imageData.rarity = "Rare";
                                imageData.chance = rarity;
                                imageData.imageName = Path.GetFileName(file);
                                imageDataL.Add(imageData);
                            }
                        }
                        if (subD.Contains("4_"))
                        {
                            string[] fileL = Directory.GetFiles(subD);
                            rarity = (float)30.0 / fileL.Length;
                            foreach (string file in fileL)
                            {
                                ImageData imageData = new ImageData();
                                imageData.rarity = "Common";
                                imageData.chance = rarity;
                                imageData.imageName = Path.GetFileName(file);
                                imageDataL.Add(imageData);
                            }
                        }
                        if (subD.Contains("5_"))
                        {
                            string[] fileL = Directory.GetFiles(subD);
                            rarity = (float)38.0 / fileL.Length;
                            foreach (string file in fileL)
                            {
                                ImageData imageData = new ImageData();
                                imageData.rarity = "Banal";
                                imageData.chance = rarity;
                                imageData.imageName = Path.GetFileName(file);
                                imageDataL.Add(imageData);
                            }
                        }
                    }
                    string output = JsonConvert.SerializeObject(imageDataL, Formatting.Indented);
                    File.AppendAllText(outfile, $"{traitName}_data = {output}\n\n");
                }
            }
        }
    }
}
