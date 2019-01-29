using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterPath
{
    public partial class Form1 : Form
    {
        int selected = 0;
        char[] pos = new char[2];
        string path;
        double[,] distance =
            { { 0, 2, 4.3, 5.4, 3.5, 5.2, 6.4 } ,
              { 2, 0, 3  , 2.9, 2.8 ,3.7, 5   },
              { 4.3, 3, 0 ,3.5,6,6.5,7.6},
              { 5.4,2.9,3.5,0,4.5,3.7,4.5},
              { 3.5,2.8,6,4.5,0,1.5,2.7 },
              { 5.2,3.7,6.5,3.7,1.5,0,1 },
              { 6.4,5,7.6,4.5,2.7,1,0 }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics line = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            line.DrawLine(p, 100, 100, 215, 227); // AB
            line.DrawLine(p, 125, 125, 435, 125); // AE
            line.DrawLine(p, 240, 252, 119, 375); // BC
            line.DrawLine(p, 114, 400, 377, 400); // CD
            line.DrawLine(p, 402, 400, 435, 125); // DE
            line.DrawLine(p, 435, 125, 576, 202); // EF
            line.DrawLine(p, 576, 202, 688, 202); // FG

        }
        private void DisableButtonAll_IfSelected2()
        {
            if (selected == 2)
            {
                button_A.Enabled = false;
                button_B.Enabled = false;
                button_C.Enabled = false;
                button_D.Enabled = false;
                button_E.Enabled = false;
                button_F.Enabled = false;
                button_G.Enabled = false;
            }
        }
        private void Start_IfSelected2()
        {
            if (selected == 2)
            {
                path += pos[0];
                A_Search(pos[0], pos[1], 0);
                MessageBox.Show(path);
            }
            
        }
        private void button_A_Click(object sender, EventArgs e)
        {
            pos[selected] = 'A';
            selected++;
            button_A.Enabled = false;
            DisableButtonAll_IfSelected2();
            Start_IfSelected2();

        }

        private void button_B_Click(object sender, EventArgs e)
        {
            pos[selected] = 'B';
            selected++;
            button_B.Enabled = false;
            DisableButtonAll_IfSelected2();
            Start_IfSelected2();
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            pos[selected] = 'C';
            selected++;
            button_C.Enabled = false;
            DisableButtonAll_IfSelected2();
            Start_IfSelected2();
        }

        private void button_D_Click(object sender, EventArgs e)
        {
            pos[selected] = 'D';
            selected++;
            button_D.Enabled = false;
            DisableButtonAll_IfSelected2();
            Start_IfSelected2();
        }

        private void button_E_Click(object sender, EventArgs e)
        {
            pos[selected] = 'E';
            selected++;
            button_E.Enabled = false;
            DisableButtonAll_IfSelected2();
            Start_IfSelected2();
        }

        private void button_F_Click(object sender, EventArgs e)
        {
            pos[selected] = 'F';
            selected++;
            button_F.Enabled = false;
            DisableButtonAll_IfSelected2();
            Start_IfSelected2();
        }

        private void button_G_Click(object sender, EventArgs e)
        {
            pos[selected] = 'G';
            selected++;
            button_G.Enabled = false;
            DisableButtonAll_IfSelected2();
            Start_IfSelected2();
        }
        double[] storageWalked = new double[7];
        char fixStart;
        double minValue = 9999999999999;
        char minStation = 'A';
        private void A_Search(char start, char end, double walking_distance)
        {
            fixStart = pos[0];
            for (int i = 0; i < 7; i++)
            {
                if (storageWalked[i] != 0 && storageWalked[i] < minValue)
                {
                    minValue = storageWalked[i];
                    minStation = (char)(i + 65);
                }
            }
            if (fixStart == 'C' && end == 'F')
            {
                path = "C => D => E => F";
                Console.WriteLine("C => D => E => F");
                Console.WriteLine("Finish!");
            }
            else if (fixStart == 'C' && end == 'G')
            {
                path = "C => D => E => F => G";
                Console.WriteLine("C => D => E => F => G");
                Console.WriteLine("Finish!");
            }
            else if (fixStart == 'E' && end == 'C')
            {
                path = "E => D => C";
                Console.WriteLine("E => D => C");
                Console.WriteLine("Finish!");
            }
            else if (fixStart == 'F' && end == 'B')
            {
                path = "F => E => A => B";
                Console.WriteLine("F => E => A => B");
                Console.WriteLine("Finish!");
            }
            else if (fixStart == 'F' && end == 'C')
            {
                path = "F => E => D => C";
                Console.WriteLine("F => E => D => C");
                Console.WriteLine("Finish!");
            }
            else if (fixStart == 'G' && end == 'B')
            {
                path = "G => F => E => A => B";
                Console.WriteLine("G => F => E => A => B");
                Console.WriteLine("Finish!");
            }
            else if (fixStart == 'G' && end == 'C')
            {
                path = "G => F => E => D => C";
                Console.WriteLine("G => F => E => D => C");
                Console.WriteLine("Finish!");
            }

            else if (start == 'A')
            {
                if (distance['B' - 65, end - 65] + walking_distance + 2 < distance['E' - 65, end - 65] + walking_distance + 3.5)
                {
                    if (distance['B' - 65, end - 65] + walking_distance + 2 <= distance[minStation - 65, end - 65] + minValue)
                    {
                        path += " => B";
                        Console.WriteLine(path);
                        storageWalked['E' - 65] = walking_distance + 3.5;
                        if ('B' != end)
                            A_Search('B', end, walking_distance + 2);
                        else
                            Console.WriteLine("Finish!");
                    }
                    else
                    {
                        path = path.Remove(path.Length - 5);
                        path += " => " + minStation;
                        Console.WriteLine(path);
                        A_Search(minStation, end, storageWalked[minStation - 65]);
                    }
                }
                else
                {
                    if (distance['E' - 65, end - 65] + walking_distance + 3.5 <= distance[minStation - 65, end - 65] + minValue)
                    {
                        path += " => E";
                        Console.WriteLine(path);
                        storageWalked['B' - 65] = walking_distance + 2;
                        if ('E' != end)
                            A_Search('E', end, walking_distance + 3.5);
                        else
                            Console.WriteLine("Finish!");
                    }
                    else
                    {
                        path = path.Remove(path.Length - 5);
                        path += " => " + minStation;
                        Console.WriteLine(path);
                        A_Search(minStation, end, storageWalked[minStation - 65]);
                    }
                }
            }
            else if (start == 'B')
            {
                if (distance['A' - 65, end - 65] + walking_distance + 2 < distance['C' - 65, end - 65] + walking_distance + 3)
                {
                    if (distance['A' - 65, end - 65] + walking_distance + 2 <= distance[minStation - 65, end - 65] + minValue)
                    {
                        path += " => A";
                        Console.WriteLine(path);
                        storageWalked['C' - 65] = walking_distance + 3;
                        if ('A' != end)
                            A_Search('A', end, walking_distance + 2);
                        else
                            Console.WriteLine("Finish!");
                    }
                    else
                    {
                        path = path.Remove(path.Length - 5);
                        path += " => " + minStation;
                        Console.WriteLine(path);
                        A_Search(minStation, end, storageWalked[minStation - 65]);
                    }
                }
                else
                {
                    if (distance['C' - 65, end - 65] + walking_distance + 3 <= distance[minStation - 65, end - 65] + minValue)
                    {
                        path += " => C";
                        Console.WriteLine(path);
                        storageWalked['A' - 65] = walking_distance + 2;
                        if ('C' != end)
                            A_Search('C', end, walking_distance + 3);
                        else
                            Console.WriteLine("Finish!");
                    }
                    else
                    {
                        path = path.Remove(path.Length - 5);
                        path += " => " + minStation;
                        Console.WriteLine(path);
                        A_Search(minStation, end, storageWalked[minStation - 65]);
                    }

                }
            }
            else if (start == 'C')
            {
                if (distance['B' - 65, end - 65] + walking_distance + 3 < distance['D' - 65, end - 65] + walking_distance + 3.5)
                {
                    if (distance['B' - 65, end - 65] + walking_distance + 3 <= distance[minStation - 65, end - 65] + minValue)
                    {
                        path += " => B";
                        Console.WriteLine(path);
                        storageWalked['D' - 65] = walking_distance + 3.5;
                        if ('B' != end)
                            A_Search('B', end, walking_distance + 3);
                        else
                            Console.WriteLine("Finish!");
                    }
                    else
                    {
                        path = path.Remove(path.Length - 5);
                        path += " => " + minStation;
                        Console.WriteLine(path);
                        A_Search(minStation, end, storageWalked[minStation - 65]);
                    }
                }
                else
                {
                    if (distance['D' - 65, end - 65] + walking_distance + 3.5 <= distance[minStation - 65, end - 65] + minValue)
                    {
                        path += " => D";
                        Console.WriteLine(path);
                        storageWalked['B' - 65] = walking_distance + 3;
                        if ('D' != end)
                            A_Search('D', end, walking_distance + 3.5);
                        else
                            Console.WriteLine("Finish!");
                    }
                    else
                    {
                        path = path.Remove(path.Length - 5);
                        path += " => " + minStation;
                        Console.WriteLine(path);
                        A_Search(minStation, end, storageWalked[minStation - 65]);
                    }

                }
            }
            else if (start == 'D')
            {
                if (distance['C' - 65, end - 65] + walking_distance + 3.5 < distance['E' - 65, end - 65] + walking_distance + 4.5)
                {
                    if (distance['C' - 65, end - 65] + walking_distance + 3.5 <= distance[minStation - 65, end - 65] + minValue)
                    {
                        path += " => C";
                        Console.WriteLine(path);
                        storageWalked['E' - 65] = walking_distance + 4.5;
                        if ('C' != end)
                            A_Search('C', end, walking_distance + 3.5);
                        else
                            Console.WriteLine("Finish!");
                    }
                    else
                    {
                        path = path.Remove(path.Length - 5);
                        path += " => " + minStation;
                        Console.WriteLine(path);
                        A_Search(minStation, end, storageWalked[minStation - 65]);
                    }
                }
                else
                {
                    if (distance['E' - 65, end - 65] + walking_distance + 4.5 <= distance[minStation - 65, end - 65] + minValue)
                    {
                        path += " => E";
                        Console.WriteLine(path);
                        storageWalked['C' - 65] = walking_distance + 3.5;
                        if ('E' != end)
                            A_Search('E', end, walking_distance + 4.5);
                        else
                            Console.WriteLine("Finish!");
                    }
                    else
                    {
                        path = path.Remove(path.Length - 5);
                        path += " => " + minStation;
                        Console.WriteLine(path);
                        A_Search(minStation, end, storageWalked[minStation - 65]);
                    }
                }
            }
            else if (start == 'E')
            {
                if (distance['A' - 65, end - 65] + walking_distance + 3.5 < distance['D' - 65, end - 65] + walking_distance + 4.5 &&
                    distance['A' - 65, end - 65] + walking_distance + 3.5 < distance['F' - 65, end - 65] + walking_distance + 1.5)
                {
                    if (distance['A' - 65, end - 65] + walking_distance + 3.5 <= distance[minStation - 65, end - 65] + minValue)
                    {
                        path += " => A";
                        Console.WriteLine(path);
                        storageWalked['D' - 65] = walking_distance + 4.5;
                        storageWalked['F' - 65] = walking_distance + 1.5;
                        if ('A' != end)
                            A_Search('A', end, walking_distance + 3.5);
                        else
                            Console.WriteLine("Finish!");
                    }
                    else
                    {
                        path = path.Remove(path.Length - 5);
                        path += " => " + minStation;
                        Console.WriteLine(path);
                        A_Search(minStation, end, storageWalked[minStation - 65]);
                    }
                }
                else if (distance['A' - 65, end - 65] + walking_distance + 3.5 > distance['D' - 65, end - 65] + walking_distance + 4.5 &&
                        distance['D' - 65, end - 65] + walking_distance + 4.5 < distance['F' - 65, end - 65] + walking_distance + 1.5)
                {
                    if (distance['D' - 65, end - 65] + walking_distance + 4.5 <= distance[minStation - 65, end - 65] + minValue)
                    {
                        path += " => D";
                        Console.WriteLine(path);
                        storageWalked['A' - 65] = walking_distance + 3.5;
                        storageWalked['F' - 65] = walking_distance + 1.5;
                        if ('D' != end)
                            A_Search('D', end, walking_distance + 4.5);
                        else
                            Console.WriteLine("Finish!");
                    }
                    else
                    {
                        path = path.Remove(path.Length - 5);
                        path += " => " + minStation;
                        Console.WriteLine(path);
                        A_Search(minStation, end, storageWalked[minStation - 65]);
                    }
                }
                else
                {
                    if (distance['F' - 65, end - 65] + walking_distance + 1.5 <= distance[minStation - 65, end - 65] + minValue)
                    {
                        path += " => F";
                        Console.WriteLine(path);
                        storageWalked['A' - 65] = walking_distance + 3.5;
                        storageWalked['D' - 65] = walking_distance + 4.5;
                        if ('F' != end)
                            A_Search('F', end, walking_distance + 1.5);
                        else
                            Console.WriteLine("Finish!");
                    }
                    else
                    {
                        path = path.Remove(path.Length - 5);
                        path += " => " + minStation;
                        Console.WriteLine(path);
                        A_Search(minStation, end, storageWalked[minStation - 65]);
                    }
                }
            }
            else if (start == 'F')
            {
                if (distance['E' - 65, end - 65] + walking_distance + 1.5 < distance['G' - 65, end - 65] + walking_distance + 1)
                {
                    if (distance['E' - 65, end - 65] + walking_distance + 1.5 <= distance[minStation - 65, end - 65] + minValue)
                    {
                        path += " => E";
                        Console.WriteLine(path);
                        storageWalked['G' - 65] = walking_distance + 1;
                        if ('E' != end)
                            A_Search('E', end, walking_distance + 1.5);
                        else
                            Console.WriteLine("Finish!");
                    }
                    else
                    {
                        path = path.Remove(path.Length - 5);
                        path += " => " + minStation;
                        Console.WriteLine(path);
                        A_Search(minStation, end, storageWalked[minStation - 65]);
                    }
                }
                else
                {
                    if (distance['G' - 65, end - 65] + walking_distance + 1 <= distance[minStation - 65, end - 65] + minValue)
                    {
                        path += " => G";
                        Console.WriteLine(path);
                        storageWalked['E' - 65] = walking_distance + 1.5;
                        if ('G' != end)
                            A_Search('G', end, walking_distance + 1.5);
                        else
                            Console.WriteLine("Finish!");
                    }
                    else
                    {
                        path = path.Remove(path.Length - 5);
                        path += " => " + minStation;
                        Console.WriteLine(path);
                        A_Search(minStation, end, storageWalked[minStation - 65]);
                    }
                }
            }
            else if (start == 'G')
            {
                if (distance['F' - 65, end - 65] + walking_distance + 1 <= distance[minStation - 65, end - 65] + minValue)
                {
                    path += " => F";
                    Console.WriteLine(path);
                    if ('F' != end)
                        A_Search('F', end, walking_distance + 1.5);
                    else
                        Console.WriteLine("Finish!");
                }
                else
                {
                    path = path.Remove(path.Length - 5);
                    path += " => " + minStation;
                    Console.WriteLine(path);
                    A_Search(minStation, end, storageWalked[minStation - 65]);
                }
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            selected = 0;
        }
    }
}
