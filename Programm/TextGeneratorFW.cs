using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace TextFW
{
    public class TextGeneratorFW
    {
        private List<(int, string)> words;
        private int maxFreq;
        private Random random;
        public TextGeneratorFW(string fileData = "../data_source/frequenc_word.txt")
        {
            random = new Random();
            words = new List<(int, string)>();
            maxFreq = 0;
            ReadDataProbability(fileData);
        }
        private void ReadDataProbability(string fileData)
        {
            int sum = 0;

            foreach (string str in File.ReadLines(fileData))
            {
                string[] parts = str.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 4)
                {
                    string word = parts[1];
                    int.TryParse(parts[4].Split('.')[0], out int frequency);
                    sum += frequency;

                    words.Add((sum, word));
                    maxFreq = sum;
                }
            }
        }
        private string GenerateWord()
        {
            int choose = random.Next(maxFreq);
            foreach (var (fric, word) in words)
                if (choose < fric)
                    return word;

            return "и";
        }

        public string GenerateText(int lengthText)
        {
            string text = string.Empty;
            for (int i = 0; i < lengthText; i++)
            {
                string newWord = GenerateWord();
                if (i % 15 == 0)
                {
                    text += "\n";
                }
                text += newWord + " ";
            }

            return text;
        }

    }
}