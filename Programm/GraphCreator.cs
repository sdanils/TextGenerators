using System;
using System.Collections.Generic;
using ScottPlot;
using System.Drawing;

namespace GraphicCreator
{
    public class GraphCreator
    {
        static public List<string> GetFrequentChars(int numChars, Dictionary<string, double> freqDict)
        {
            var frequent = new List<string>();
            var maxHeap = new PriorityQueue<string, double>(Comparer<double>.Create((a, b) => b.CompareTo(a)));

            foreach (var kvp in freqDict)
                maxHeap.Enqueue(kvp.Key, kvp.Value);

            for (int i = 0; i < numChars && maxHeap.Count > 0; i++)
                frequent.Add(maxHeap.Dequeue());

            return frequent;
        }
        static public void CreateGraph(Dictionary<string, double> wordFrequance, Dictionary<string, double> wordFrequanceText, string title, string fileName)
        {
            var plt = new ScottPlot.Plot(800, 600);

            List<string> chars = GetFrequentChars(10, wordFrequanceText);
            List<double> values1 = new List<double>();
            List<double> values2 = new List<double>();
            foreach (var str in chars)
            {
                values1.Add(wordFrequance[str]);
                values2.Add(wordFrequanceText[str]);
            }
            double[] positions = Enumerable.Range(0, chars.Count).Select(x => (double)x).ToArray();
            double barWidth = 0.35;

            var bars1 = plt.AddBar(values1.ToArray(), positions);
            bars1.FillColor = Color.Yellow;
            bars1.BarWidth = barWidth;
            bars1.Label = "Ожидаемая частота";

            var bars2 = plt.AddBar(values2.ToArray(), positions.Select(x => x + barWidth).ToArray());
            bars2.FillColor = Color.Orange;
            bars2.BarWidth = barWidth;
            bars2.Label = "Фактическая частота";

            plt.XTicks(positions.Select(x => x + barWidth / 2).ToArray(), chars.ToArray());
            plt.YLabel("Частота появления");
            plt.Title(title);
            plt.Legend();

            plt.AxisAuto(0, 0.1);
            plt.SetAxisLimits(yMin: 0);

            plt.SaveFig($"../Results/{fileName}");
        }
    }

    public class GraphCreatorBD
    {
        public Dictionary<string, double> charsFrequenc;
        public Dictionary<string, double> charsFrequencText;

        public GraphCreatorBD(string fileStats = "../data_source/bgramm_data.txt", string fileText = "../Results/gen-1.txt")
        {
            charsFrequenc = new Dictionary<string, double>();
            charsFrequencText = new Dictionary<string, double>();
            GenerateFrequency(fileStats);
            GenerateFrequencyText(fileText);
        }

        private void GenerateFrequency(string fileText = "../data_source/bgramm_data.txt")
        {
            int sum = 0;
            List<(string, int)> data = new List<(string, int)>();

            foreach (string str in File.ReadLines(fileText))
            {
                string[] parts = str.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 2)
                {
                    string chars = parts[1];
                    int.TryParse(parts[2], out int frequency);
                    sum += frequency;
                    data.Add((chars, frequency));
                }
            }

            foreach (var (chars, freq) in data)
                charsFrequenc[chars] = (double)freq / sum;

        }

        private void GenerateFrequencyText(string fileText = "../Results/gen-1.txt")
        {
            string text = File.ReadAllText(fileText);
            int lengthText = text.Length;
            Dictionary<string, int> curFreqText = new Dictionary<string, int>();

            for (int i = 0; i < lengthText - 1; i++)
            {
                string chars = text.Substring(i, 2);
                if (curFreqText.ContainsKey(chars))
                {
                    curFreqText[chars] += 1;
                }
                else
                {
                    curFreqText[chars] = 1;
                }
            }

            foreach (var (chars, frec) in curFreqText)
                charsFrequencText[chars] = (double)frec / lengthText;

        }
    }

    public class GraphCreatorFW
    {
        public Dictionary<string, double> wordFrequenc;
        public Dictionary<string, double> wordFrequencText;

        public GraphCreatorFW(string fileStats = "../data_source/frequenc_word.txt", string fileText = "../Results/gen-2.txt")
        {
            wordFrequenc = new Dictionary<string, double>();
            wordFrequencText = new Dictionary<string, double>();
            GenerateFrequency(fileStats);
            GenerateFrequencyText(fileText);
        }

        public void GenerateFrequency(string fileText)
        {
            int sum = 0;
            List<(string, int)> data = new List<(string, int)>();

            foreach (string str in File.ReadLines(fileText))
            {
                string[] parts = str.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 4)
                {
                    string word = parts[1];
                    int.TryParse(parts[4].Split('.')[0], out int frequency);
                    sum += frequency;

                    data.Add((word, frequency));
                }
            }

            foreach (var (chars, freq) in data)
                wordFrequenc[chars] = (double)freq / sum;

        }
        private void GenerateFrequencyText(string fileText)
        {
            string text = File.ReadAllText(fileText);
            string[] words = text.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int lengthText = words.Length;
            Dictionary<string, int> curFreqText = new Dictionary<string, int>();

            for (int i = 0; i < lengthText - 1; i++)
            {
                string word = words[i];
                if (curFreqText.ContainsKey(word))
                {
                    curFreqText[word] += 1;
                }
                else
                {
                    curFreqText[word] = 1;
                }
            }

            foreach (var (word, frec) in curFreqText)
                wordFrequencText[word] = (double)frec / lengthText;
        }
    }
}