using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Game_snake_v_3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        DispatcherTimer T;
        Rectangle[,] Re = new Rectangle[14, 14];
        Random rnd;

        int[,] Sn;
        int x, y, o;
        int X, Y;

        bool W, A, S, D, C=true, M = false;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 14; i++)
            {
                for (int k = 0; k < 14; k++)
                {
                    Re[i, k] = new Rectangle();
                    canv.Children.Add(Re[i, k]);
                    Re[i, k].Width = Re[i, k].Height = 30;
                    Re[i, k].Margin = new Thickness(31 * i, 31 * k, 0, 0);
                    Re[i, k].Fill = Brushes.Black;
                }
            }
            for (int i = 1; i < 13; i++)
            {
                for (int k = 1; k < 13; k++)
                {
                    Re[i, k].Fill = Brushes.Gray;
                }
            }
            Sn = new int[144,2];
            Sn[0, 0] = 5;
            Sn[0, 1] = 5;
            Sn[1, 0] = 6;
            Sn[1, 1] = 5;
            Sn[2, 0] = 7;
            Sn[2, 1] = 5;
        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            T = new DispatcherTimer();
            T.Interval = TimeSpan.FromMilliseconds(140);
            T.Tick += T_Tick; ;
            T.Start();

            bt.IsEnabled = false;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        { 
            if(M == false)
            {
                if (e.Key.ToString() == "A")
                {
                    A = true;
                    W = false; S = false; D = false;
                    M = true;
                }
            }
            if (M == true)
            {
                if (e.Key.ToString() == "D" & A == false)
                {
                    D = true;
                    W = false; S = false; A = false;
                }
                if (e.Key.ToString() == "A" & D == false)
                {
                    A = true;
                    W = false; S = false; D = false;
                }
                if (e.Key.ToString() == "W" & S == false)
                {
                    W = true;
                    A = false; S = false; D = false;
                }
                if (e.Key.ToString() == "S" & W == false)
                {
                    S = true;
                    W = false; A = false; D = false;
                }
            }
        }

        private void T_Tick(object sender, EventArgs e)
        {
            o = Convert.ToInt32(tbl.Text);

            if( C == true)
            {
                rnd = new Random();
                X = rnd.Next(1, 13);
                Y = rnd.Next(1, 13);

                for (int i = 0; i < 144; i++)
                {
                    for (int k = 0; k < 144; k++)
                    {
                        if (Re[X, Y] == Re[Sn[i, 0], Sn[k, 1]])
                        {
                            X = rnd.Next(1, 13);
                            Y = rnd.Next(1, 13);
                        }
                    }
                }
                C = false;
            }

            if (D == true)
            {
                for (int i = 1; i < 13; i++)
                {
                    for (int k = 1; k < 13; k++)
                    {
                        Re[i, k].Fill = Brushes.Gray;
                    }
                }
                for (int i = 2 + o; i > 0; i--)
                {
                    Sn[i, 0] = Sn[i - 1, 0];
                    Sn[i, 1] = Sn[i - 1, 1];
                }
                Sn[0, 0] = Sn[0, 0] + 1; 
                Sn[0, 1] = Sn[0, 1];
            }

            if (S == true)
            {
                for (int i = 1; i < 13; i++)
                {
                    for (int k = 1; k < 13; k++)
                    {
                        Re[i, k].Fill = Brushes.Gray;
                    }
                }
                for (int i = 2 + o; i > 0; i--)
                {
                    Sn[i, 0] = Sn[i - 1, 0];
                    Sn[i, 1] = Sn[i - 1, 1];
                }
                Sn[0, 0] = Sn[0, 0];
                Sn[0, 1] = Sn[0, 1]+1;
            }

            if (W == true)
            {
                for (int i = 1; i < 13; i++)
                {
                    for (int k = 1; k < 13; k++)
                    {
                        Re[i, k].Fill = Brushes.Gray;
                    }
                }
                for (int i = 2 + o; i > 0; i--)
                {
                    Sn[i, 0] = Sn[i - 1, 0];
                    Sn[i, 1] = Sn[i - 1, 1];
                }
                Sn[0, 0] = Sn[0, 0];
                Sn[0, 1] = Sn[0, 1]-1;
            }

            if (A == true)
            {
                for (int i = 1; i < 13; i++)
                {
                    for (int k = 1; k < 13; k++)
                    {
                        Re[i, k].Fill = Brushes.Gray;
                    } 
                }
                 for (int i = 2 + o; i > 0; i--)
            {
                Sn[i, 0] = Sn[i - 1, 0];
                Sn[i, 1] = Sn[i - 1, 1];
            }
                Sn[0, 0] = Sn[0, 0]-1;
                Sn[0, 1] = Sn[0, 1]; 
            }

            Re[X, Y].Fill = Brushes.Red;

            for (int i = 0; i < 3 + o; i++)
            {
                x = Sn[i, 0];
                y = Sn[i, 1];
                Re[x, y].Fill = Brushes.Green;
            }

            if (Re[X, Y] == Re[Sn[0, 0], Sn[0, 1]])
            {
                C = true;
                tbl.Text = Convert.ToString(Convert.ToInt32(tbl.Text) + 1);
            }

            Re[Sn[0, 0], Sn[0, 1]].Fill = Brushes.GreenYellow;
            
            for (int a = 1 ; a<144; a++)
            {
                if (Sn[0, 0] == Sn[a, 0] & Sn[0, 1] == Sn[a, 1])
                {
                    MessageBox.Show("ВЫ LOOSE");
                    T.Stop();
                }
            }
            for (int i =0; i<12; i++)
            {
                if (Re[i+1, 0] == Re[Sn[0, 0], Sn[0, 1]] || Re[i+1, 13] == Re[Sn[0, 0], Sn[0, 1]] || Re[0, i+1] == Re[Sn[0, 0], Sn[0, 1]] || Re[13, i + 1] == Re[Sn[0, 0], Sn[0, 1]])
                {
                    MessageBox.Show("ВЫ LOOSE");
                    T.Stop();
                }
            }
        }
    }
}
