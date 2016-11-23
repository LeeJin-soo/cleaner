using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Cleaner
{
    public partial class Form1 : Form
    {
        List<Button> trashes = new List<Button>();
        PictureBox cleaner = new PictureBox();
        int[,] coordinate;
        int unit = 50;
        static IDictionary<int, Color> type = new Dictionary<int, Color>();

        public Form1()
        {
            InitializeComponent();

            type[3] = Color.PaleVioletRed;
            type[4] = Color.PaleGreen;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
        }
        
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            again:
            int x = cleaner.Left;
            int y = cleaner.Top;
            int i = 0;
            for(int index = 0; index < trashes.Count; index++)
            {
                if (x > System.Math.Abs(cleaner.Left - trashes[index].Left) || y > System.Math.Abs(cleaner.Top - trashes[index].Top))
                {
                    x = System.Math.Abs(cleaner.Left - trashes[index].Left);
                    y = System.Math.Abs(cleaner.Top - trashes[index].Top);
                    i = index;
                }
            }

            if (trashes.Count > 0)
            {
                while (cleaner.Left < trashes[i].Left)
                {
                    if (coordinate[cleaner.Top / unit, (cleaner.Left / unit) + 1] == 2)
                    {
                        path("right");
                    }
                    else
                    {
                        cleaner.Left += unit;
                        Thread.Sleep(500);
                    }
                    if (trash())
                        goto again;
                }
                while (cleaner.Left > trashes[i].Left)
                {
                    if (coordinate[cleaner.Top / unit, (cleaner.Left / unit) - 1] == 2)
                    {
                        path("left");
                    }
                    else
                    {
                        cleaner.Left -= unit;
                        Thread.Sleep(500);
                    }

                    if (trash())
                        goto again;
                }

                while (cleaner.Top < trashes[i].Top)
                {
                    if (coordinate[cleaner.Top / unit + 1, cleaner.Left / unit] == 2)
                        path("bottom");
                    else
                    {
                        cleaner.Top += unit;
                        Thread.Sleep(500);
                    }
                    if (trash())
                        goto again;
                }
                while (cleaner.Top > trashes[i].Top)
                {
                    if (coordinate[cleaner.Top / unit - 1, cleaner.Left / unit] == 2)
                    {
                        path("top");
                    }
                    else
                    {
                        cleaner.Top -= unit;
                        Thread.Sleep(500);
                        if (trash())
                            goto again;
                    }
                }
            }
            if(trashes.Count > 0)
                goto again;
        }

        private void path(string direction)
        {
            switch(direction)
            {
                case "left":
                for (int k = 1; k <= coordinate.GetLength(1); k++)
                {
                    if (coordinate[cleaner.Top / unit - k, cleaner.Left / unit - 1] != 2)
                    {
                        for (int l = 1; l <= k; l++)
                        {
                            cleaner.Top -= unit;
                            Thread.Sleep(500);
                        }
                        break;
                    }
                    if (coordinate[cleaner.Top / unit + k, cleaner.Left / unit - 1] != 2)
                    {
                        for (int l = 1; l <= k; l++)
                        {
                            cleaner.Top += unit;
                            Thread.Sleep(500);
                        }
                        break;
                    }
                }
                    break;
                case "right":
                    for (int k = 1; k <= coordinate.GetLength(1); k++)
                    {
                        if(coordinate[cleaner.Top / unit + k, cleaner.Left / unit + 1] != 2)
                        {
                            for(int l = 1; l <= k; l++)
                            {
                                cleaner.Top += unit;
                                Thread.Sleep(500);
                            }
                            break;
                        }
                        if(coordinate[cleaner.Top / unit - k, cleaner.Left / unit + 1] != 2)
                        {
                            for(int l = 1; l <= k; l++)
                            {
                                cleaner.Top -= unit;
                                Thread.Sleep(500);
                            }
                        }
                    }
                    break;
                case "top":
                    for (int k = 1; k <= coordinate.GetLength(0); k++)
                    {
                        if (coordinate[cleaner.Top / unit - 1, cleaner.Left / unit - k] != 2)
                        {
                            for (int l = 1; l <= k; l++)
                            {
                                cleaner.Left -= unit;
                                Thread.Sleep(500);
                            }
                            break;
                        }
                        if (coordinate[cleaner.Top / unit - 1, cleaner.Left / unit + k] != 2)
                        {
                            for (int l = 1; l <= k; l++)
                            {
                                cleaner.Left += unit;
                                Thread.Sleep(500);
                            }
                            break;
                        }
                    }
                    break;
                case "bottom":
                    for(int k = 1; k <= coordinate.GetLength(0); k++)
                    {
                        if(coordinate[cleaner.Top / unit + 1, cleaner.Left / unit + k] != 2)
                        {
                            for(int l = 1; l <= k; l++)
                            {
                                cleaner.Left += unit;
                                Thread.Sleep(500);
                            }
                            break;
                        }
                        if(coordinate[cleaner.Top / unit + 1, cleaner.Left / unit -k] != 2)
                        {
                            for (int l = 1; l <= k; l++)
                            {
                                cleaner.Left -= unit;
                                Thread.Sleep(500);
                            }
                            break;
                        }
                    }
                    break;
            }
        }

        progress form; 
        private bool trash()
        {
                for(int i = 0; i < trashes.Count; i++)
                    if (cleaner.Top == trashes[i].Top && cleaner.Left == trashes[i].Left)
                    {
                        Color colour = new Color();
                        colour = trashes[i].BackColor;
                        panel1.Controls.Remove(trashes[i]);
                        trashes.RemoveAt(i);
                        switch(coordinate[cleaner.Top / unit, cleaner.Left / unit])
                        {
                        case 3:
                            //this.Hide();
                            /*Thread.Sleep(5000);
                            form = new progress("dry",50);
                            form.Show();
                           
                            if (progress.complete)
                            {
                                form.Hide();
                                
                            }*/
                            //Thread.CurrentThread.
                            MessageBox.Show("Нойтон хог");
                            break;
                        case 4:
                            /*form = new progress("wet",100);
                            form.Show();
                           // Thread.Sleep(10000);
                            if (progress.complete)
                            {
                                form.Hide();

                            }*/
                            MessageBox.Show("Хуурай хог");
                            break;
                        }
                        return true;
                    }
            return false;      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.WhiteSmoke;

            cleaner.BackColor = Color.SkyBlue;
            cleaner.Width = unit;
            cleaner.Height = unit;
            panel1.Controls.Add(cleaner);

            coordinate = new int[,]{    {2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                                        {2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
                                        {2, 0, 0, 0, 0, 0, 0, 2, 0, 2 },
                                        {2, 0, 0, 0, 4, 2, 3, 2, 0, 2 },
                                        {2, 0, 0, 0, 4, 3, 0, 2, -1, 2 },
                                        {2, 0, 0, 0, 0, 0, 0, 2, 0, 2 },
                                        {2, 0, 2, 0, 0, 0, 0, 0, 0, 2 },
                                        {2, 0, 3, 0, 0, 0, 0, 0, 0, 2 },
                                        {2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
                                        {2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, };

            for (int row = 0; row < coordinate.GetLength(0); row++)
            {
                for (int column = 0; column < coordinate.GetLength(1); column++)
                {
                    if (coordinate[row, column] >= 3)
                    {
                        Button trash = new Button();
                        trash.Left = column * unit;
                        trash.Top = row * unit;
                        trash.Width = unit;
                        trash.Height = unit;
                        
                        switch(coordinate[row, column])
                        {
                            case 3:
                                trash.BackColor = type[3];
                                break;
                            case 4:
                                trash.BackColor = type[4];
                                break;
                        }
                        panel1.Controls.Add(trash);
                        trashes.Add(trash);
                    }
                    if (coordinate[row, column] == -1)
                    {
                        cleaner.Left = column * unit;
                        cleaner.Top = row * unit;
                    }
                    if (coordinate[row, column] == 2)
                    {
                        Button wall = new Button();
                        wall.BackColor = Color.Black;
                        wall.Width = unit;
                        wall.Height = unit;
                        wall.Top = row * unit;
                        wall.Left = column * unit;
                        panel1.Controls.Add(wall);
                    }
                }
            }
        }
    }
}
