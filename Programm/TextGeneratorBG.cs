using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace TextBG
{
    public class TextGeneratorBG
    {
        private Dictionary<char, List<(int, char)>> data;
        private Dictionary<char, int> maxSum;
        private Random random;
        public TextGeneratorBG(string fileData = "../data_source/bgramm_data.txt")
        {
            random = new Random();
            data = new Dictionary<char, List<(int, char)>>();
            maxSum = new Dictionary<char, int>();
            ReadDataProbability(fileData);
        }
        private void ReadDataProbability(string fileData)
        {
            int sum = 0;

            foreach (string str in File.ReadLines(fileData))
            {

                string[] parts = str.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 2)
                {
                    string chars = parts[1];
                    int.TryParse(parts[2], out int frequency);
                    sum += frequency;

                    if (!data.ContainsKey(chars[0]))
                    {
                        sum = 0;
                        data[chars[0]] = new List<(int, char)>();
                    }
                    sum += frequency;
                    data[chars[0]].Add((sum, chars[1]));
                    maxSum[chars[0]] = sum;
                }
            }
        }
        private char GenerateChar(char lastChar)
        {
            if (lastChar == '-')
            {
                return (char)random.Next(1072, 1103);
            }

            int allFric = maxSum[lastChar];
            int choose = random.Next(allFric);
            foreach (var (fric, el) in data[lastChar])
                if (choose < fric)
                    return el;

            return '-';
        }

        public string GenerateText(int lengthText)
        {
            string text = string.Empty;
            text += GenerateChar('-');
            for (int i = 0; i < lengthText - 1; i++)
            {
                char newCh = GenerateChar(text[i]);
                text += newCh;
            }

            return lengthText == 0 ? "" : text;
        }
    }
}