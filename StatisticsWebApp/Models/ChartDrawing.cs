using ScottPlot;

namespace StatisticsWebApp.Models

{
    public class ChartDrawing
    {
        public static Random rand = new Random();
        public static HashSet<Color> usedColors = new HashSet<Color>();
        public static void saveChart(int[] stats_numbers)
        {
            ScottPlot.Plot myPlot = new();


            int sum_of_elements = stats_numbers.Sum();
            var slices = new List<PieSlice>();


            int i = 0;
            while (slices.Count < stats_numbers.Length)
            {
                Color randomColor = new Color(rand.Next(256), rand.Next(256), rand.Next(256));

              
                if (usedColors.Contains(randomColor))
                    continue;

                int percentage_rate = (int)Math.Round((double)stats_numbers[i] / sum_of_elements * 100, 0);
                slices.Add(new PieSlice() { Value = stats_numbers[i], FillColor = randomColor, Label=$"{percentage_rate}%", LegendText=$"Firma nr{i+1}" });
                usedColors.Add(randomColor);
                i++;
            }
            var pie = myPlot.Add.Pie(slices);
            pie.ExplodeFraction = 0;
            pie.SliceLabelDistance = 1.2;

            myPlot.ShowLegend();

            myPlot.Axes.Frameless();
            myPlot.HideGrid();

            usedColors.Clear();

            myPlot.SavePng("wwwroot/images/demo.png", 700, 500);

        }
    }
}
