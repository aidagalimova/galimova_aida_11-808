using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace КМП_алгоритм.Properties
{
    class Graph
    {
        // измерить время для строки
        static void MeasureTimeOnArray(string text, string pattern, Series series)
        {
            KMPonArray.KMPsearch(text, pattern);
            var watch = new Stopwatch();
            var repetitions = 10000;
            watch.Start();
            for (int i = 0; i < repetitions; i++)
                KMPonArray.KMPsearch(text, pattern);
            watch.Stop();
            series.Points.Add(new DataPoint(text.Length, (float)watch.ElapsedMilliseconds / repetitions));
        }
        // посчитать итерации для массива
        static void MeasureIterationsOnArray(Series series)
        {
            var strings = File.ReadAllText("Text.TXT").Split('\n');
            var patterns = File.ReadAllText("Patterns.TXT").Split('\n');
            for (int i = 0; i < strings.Length; i++)
            {
                GC.Collect();
                KMPonArray.KMPsearch(strings[i], patterns[i]);
                series.Points.Add(new DataPoint(strings[i].Length, KMPonArray.iteration));
            }
        }
        // посчитать итерации для списка
        static void MeasureIterationOnList(Series series)
        {
            var strings = File.ReadAllText("Text.TXT").Split('\n');
            var patterns = File.ReadAllText("Patterns.TXT").Split('\n');
            for (int i = 0; i < strings.Length; i++)
            {
                var list = new LinkedList<char>();
                for (int j = 0; j < strings[i].Length; j++)
                {
                    list.AddLast(strings[i][j]);
                }
                var listpattern = new LinkedList<char>();
                for (int j = 0; j < patterns[i].Length; j++)
                {
                    listpattern.AddLast(patterns[i][j]);
                }
                GC.Collect();
                KMPonLinkedLIst.KMPsearchList(list, listpattern);
                series.Points.Add(new DataPoint(list.Count, KMPonLinkedLIst.iteration));
            }
        }
        static void MeasureTimeOnLinkedList(LinkedList<char> text, LinkedList<char> pattern, Series series)
        {
            KMPonLinkedLIst.KMPsearchList(text, pattern);
            var watch = new Stopwatch();
            var repetitions = 10;
            watch.Start();
            for (int i = 0; i < repetitions; i++)
                KMPonLinkedLIst.KMPsearchList(text, pattern);
            watch.Stop();
            series.Points.Add(new DataPoint(text.Count, (float)watch.ElapsedMilliseconds / repetitions));
        }
        // измерить время для всех наборов на массиве
        static void ArrayTime(Series arrayGraph)
        {
            var strings = File.ReadAllText("Text.TXT").Split('\n');
            var patterns = File.ReadAllText("Patterns.TXT").Split('\n');
            for (int i = 0; i < strings.Length; i++)
            {
                GC.Collect();
                MeasureTimeOnArray(strings[i], patterns[i], arrayGraph);
            }
        }
        // для каждого набора создать список и добавить в него символы из строки и вызвать алгоритм
        static void ListTime(Series linearGraph)
        {
            var strings = File.ReadAllText("Text.TXT").Split('\n');
            var patterns = File.ReadAllText("Patterns.TXT").Split('\n');
            for (int i = 0; i < strings.Length; i++)
            {
                var list = new LinkedList<char>();
                for (int j = 0; j < strings[i].Length; j++)
                {
                    list.AddLast(strings[i][j]);
                }
                var listpattern = new LinkedList<char>();
                for (int j = 0; j < patterns[i].Length; j++)
                {
                    listpattern.AddLast(patterns[i][j]);
                }
                GC.Collect();
                MeasureTimeOnLinkedList(list, listpattern, linearGraph);
            }
        }

        public static void Main()
        {
            // генерировать строку и паттерн
            Generate.GenerateText();
            Generate.GeneratePattern();
            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());
           
            // график времени для массива
            var arrayGraph = new Series();
            ArrayTime(arrayGraph);
            arrayGraph.ChartType = SeriesChartType.FastLine;
            arrayGraph.Color = Color.Red;
            chart.Series.Add(arrayGraph);
            // график времени для связного списка
            var linkedListGraph = new Series();
            ListTime(linkedListGraph);
            linkedListGraph.ChartType = SeriesChartType.FastLine;
            linkedListGraph.Color = Color.Blue;
            chart.Series.Add(linkedListGraph);
            // график итераций для массива
            var iterationOnArrayGraph = new Series();
            MeasureIterationsOnArray(iterationOnArrayGraph);
            iterationOnArrayGraph.ChartType = SeriesChartType.FastLine;
            iterationOnArrayGraph.Color = Color.Red;
            chart.Series.Add(iterationOnArrayGraph);
            // график итераций для связного списка
            var iterationOnListGraph = new Series();
            MeasureIterationOnList(iterationOnListGraph);
            iterationOnListGraph.ChartType = SeriesChartType.FastLine;
            iterationOnListGraph.Color = Color.Blue;
            chart.Series.Add(iterationOnListGraph);

            chart.Dock = DockStyle.Fill;
            var form = new Form();
            form.ClientSize = new Size(1200, 600);
            form.Controls.Add(chart);
            Application.Run(form);
        }
    }
}
