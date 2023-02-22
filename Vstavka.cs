using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WindowsFormsApp9
{
    public class Vstavka : IStrategy
    {
        public int iterationCount = 0;
        public static Form1 form1;
        public int[] Algorithm(int[] mas, bool flag = true)
        {
            if (flag)
            {
                IOFile.FillContent();
                int num;
                long freq = Stopwatch.Frequency;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                num = int.Parse("135");
                int j2 = 0;
                for (int i = 0; i < mas.Length; i++)
                {
                    for (int j = i + 1; j < mas.Length; j++)
                    {
                        this.iterationCount++;
                        IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                        IOFile.InputInfoAboutComparison(mas[i], mas[j]);
                        int newElement, location;    
                        if (mas[i] > mas[j])
                        {
                            newElement = mas[i];
                            location = i - 1;
                            while (location >= 0 && (mas[location] > newElement))
                            {
                                mas[location + 1] = mas[location];
                                location = location - 1;
                                j2++;
                            }
                            mas[location + 1] = newElement;
                            IOFile.InputInfoAboutTransposition(mas[i], mas[j]); 
                            IOFile.FillContent();
                            form1.AddItemsListBox(mas[i], mas[j]);
                        }
                    }
                }
                stopwatch.Stop();
                double sec = (double)stopwatch.Elapsed.Ticks / freq;
                form1.label3.Text = Convert.ToString(mas.Length * (mas.Length - 1) / 2);
                form1.label5.Text = Convert.ToString(j2);
                form1.label6.Text = Convert.ToString(sec) + "c";
                return mas;
            }
            else
            {
                int num;
                long freq = Stopwatch.Frequency;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                num = int.Parse("135");
                int newElement, location;
                int j1 = 0;
                for (int i = 0; i < mas.Length; i++)
                {
                    newElement = mas[i];
                    location = i - 1;
                    while (location >= 0 && (mas[location] > newElement))
                    {
                        mas[location + 1] = mas[location];
                        location = location - 1;
                        j1++;
                    }
                    mas[location + 1] = newElement;
                }
                stopwatch.Stop();
                double sec = (double)stopwatch.Elapsed.Ticks / freq;
                form1.label3.Text = Convert.ToString(mas.Length * (mas.Length - 1) / 2);
                form1.label5.Text = Convert.ToString(j1);
                form1.label6.Text = Convert.ToString(sec) + "c";
                return mas;
            }
        }
    }
}
