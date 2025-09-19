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

            

            var slices = new List<PieSlice>();


            int i = 0;
            while (slices.Count < stats_numbers.Length)
            {
                Color randomColor = new Color(rand.Next(256), rand.Next(256), rand.Next(256));

              
                if (usedColors.Contains(randomColor))
                    continue; 

                slices.Add(new PieSlice() { Value = stats_numbers[i], FillColor = randomColor });
                usedColors.Add(randomColor);
                i++;
            }
            var pie = myPlot.Add.Pie(slices);
            pie.ExplodeFraction = 0;
            pie.SliceLabelDistance = 1.4;

            myPlot.ShowLegend();

            myPlot.Axes.Frameless();
            myPlot.HideGrid();

            usedColors.Clear();

            myPlot.SavePng("wwwroot/images/demo.png", 600, 400);

        }
    }
}
