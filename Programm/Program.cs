using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using TextBG;
using TextFW;
using GraphicCreator;

namespace Program
{
    public class SaverFile
    {
        static public void SaveText(string text, string fileName)
        {
            File.WriteAllText(fileName, text);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TextGeneratorBG genBG = new TextGeneratorBG();
            string textBG = genBG.GenerateText(100000);
            SaverFile.SaveText(textBG, "../Results/gen-1.txt");

            GraphCreatorBD gbd = new GraphCreatorBD();
            GraphCreator.CreateGraph(gbd.charsFrequenc, gbd.charsFrequencText, "Частота пар", "gen-1.png");

            TextGeneratorFW genFW = new TextGeneratorFW();
            string textFW = genFW.GenerateText(10000);
            SaverFile.SaveText(textFW, "../Results/gen-2.txt");

            GraphCreatorFW gfw = new GraphCreatorFW();
            GraphCreator.CreateGraph(gfw.wordFrequenc, gfw.wordFrequencText, "Частота слов", "gen-2.png");
        }
    }
}