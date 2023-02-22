using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WindowsFormsApp9
{
    public class shell : IStrategy
    {
        public int iterationCount = 0;
        public static Form1 form1;
        public int[] Algorithm(int[] mass, bool flag = true)
        {
            if (flag)
            {
                IOFile.FillContent();
                int i, j, step;
                int tmp;

                int num;
                long freq = Stopwatch.Frequency;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                num = int.Parse("135");
                int b = 0;
                int b1 = 0;
                for (step = mass.Length / 2; step > 0; step /= 2)
                {
                    for (i = step; i < mass.Length; i++)
                    {
                        iterationCount++;
                        IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                        tmp = mass[i];
                        for (j = i; j >= step; j -= step)
                        {
                            IOFile.InputInfoAboutComparison(tmp, mass[j - step]);
                            b++;
                            if (tmp < mass[j - step])
                            {
                                IOFile.InputInfoAboutTransposition(tmp, mass[j - step]);
                                mass[j] = mass[j - step];
                                b1++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        mass[j] = tmp;

                        IOFile.FillContent();
                        form1.AddItemsListBox(mass[i], mass[j]);
                    }
                }
                stopwatch.Stop();
                double sec = (double)stopwatch.Elapsed.Ticks / freq;

                form1.label3.Text = Convert.ToString(b);
                form1.label5.Text = Convert.ToString(b1);
                form1.label6.Text = Convert.ToString(sec) + "c";
                return mass;
            }
            else
            {
                int i, j, step;
                int tmp;

                int num;
                long freq = Stopwatch.Frequency;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                num = int.Parse("135");
                int v = 0;
                int v1 = 0;
                for (step = mass.Length / 2; step > 0; step /= 2)
                {
                    for (i = step; i < mass.Length; i++)
                    {
                        iterationCount++;
                        tmp = mass[i];
                        for (j = i; j >= step; j -= step)
                        {
                            v++;
                            if (tmp < mass[j - step])
                            {
                                mass[j] = mass[j - step];
                                v1++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        mass[j] = tmp;
                    }
                }
                stopwatch.Stop();
                double sec = (double)stopwatch.Elapsed.Ticks / freq;
                form1.label3.Text = Convert.ToString(v);
                form1.label5.Text = Convert.ToString(v1);
                form1.label6.Text = Convert.ToString(sec) + "c";
                return mass;
            }
        }
    }
}
