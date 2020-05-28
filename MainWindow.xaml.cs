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

namespace Dyskretna
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void NWD(object sender, RoutedEventArgs e)
        {
            wynik.Text = Convert.ToString(nwd(Convert.ToInt32(tresc1.Text), Convert.ToInt32(tresc2.Text)));
        }

        private void NWW(object sender, RoutedEventArgs e)
        {
            wynik.Text = Convert.ToString(Convert.ToInt32(tresc1.Text) * Convert.ToInt32(tresc2.Text) / (nwd(Convert.ToInt32(tresc1.Text), Convert.ToInt32(tresc2.Text))));
        }
        private void MOD(object sender, RoutedEventArgs e)
        {
            wynik.Text = Convert.ToString(Convert.ToInt32(tresc1.Text) % Convert.ToInt32(tresc2.Text));
        }
        private void Euklides(object sender, RoutedEventArgs e)
        {
            int r, a, q, b;
            int x, x1, x2;
            int y, y1, y2;
            int nwd_a, nwd_b, nwd;
            int c;

            nwd_a = Convert.ToInt32(euklides_a.Text);

            nwd_b = Convert.ToInt32(euklides_b.Text);

            c = Convert.ToInt32(euklides_c.Text);

            if (nwd_b > nwd_a)
            {
                nwd = nwd_b;
                nwd_b = nwd_a;
                nwd_a = nwd;
            }

            a = nwd_a;
            b = nwd_b;

            q = a / b;
            r = a - q * b;
            nwd = b;

            x2 = 1;
            x1 = 0;
            y2 = 0;
            y1 = 1;
            x = 1;
            y = y2 - (q - 1) * y1;

            while (r != 0)
            {
                a = b;
                b = r;

                x = x2 - q * x1;
                x2 = x1;
                x1 = x;

                y = y2 - q * y1;
                y2 = y1;
                y1 = y;

                nwd = r;
                q = a / b;
                r = a - q * b;
            }
            if (c / nwd != 1)
            {
                int mnoznik = c / nwd;
                x *= mnoznik;
                y *= mnoznik;
            }
            wynik_euklides.Text = (x + " * " + nwd_a + " + " + y + " * " + nwd_b + " = " + c);
        }

        private void Odwrotnosc(object sender, RoutedEventArgs e)
        {
            int a, b, u, w, x, z, q;

            a = Convert.ToInt32(odw_tresc.Text);
            b = Convert.ToInt32(odw_tresc_mod.Text);
            u = 1;
            w = a;
            x = 0;
            z = b;
            while (Convert.ToBoolean(w))
            {
                if (w < z)
                {
                    q = u; u = x; x = q;
                    q = w; w = z; z = q;
                }
                q = w / z;
                u -= q * x;
                w -= q * z;
            }
            if (z == 1)
            {
                if (x < 0) x += b;
                odw_wynik.Text = Convert.ToString(x);
            }
            else odw_wynik.Text = "brak";

        }

        public int nwd(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }

        private void WszystkieOdwrotnosci(object sender, RoutedEventArgs e)
        {
            wszystkie_wynik.Text = "";
            int mod = Convert.ToInt32(wszystkie_tresc.Text);
            for (int i = 1; i < mod; i++)
            {
                if (nwd(i, mod) == 1)
                {
                    wszystkie_wynik.Text += Convert.ToString(" " + i);
                }
            }
        }

        private void Dzielniki(object sender, RoutedEventArgs e)
        {
            int MAX = Convert.ToInt32(max.Text);

            int pierwsza_liczba, druga_liczba, trzecia_liczba;
            int licznik = 0;
            pierwsza_liczba = Convert.ToInt32(liczba1.Text);
            druga_liczba = Convert.ToInt32(liczba2.Text);
            trzecia_liczba = Convert.ToInt32(liczba3.Text);
            for (int i = 1; i <= MAX; i++)
            {
                if (i % pierwsza_liczba == 0)
                {
                    licznik++;
                }

                if (i % druga_liczba == 0)
                {
                    licznik++;
                }

                if (i % trzecia_liczba == 0)
                {
                    licznik++;
                }

                if (i % pierwsza_liczba == 0 && i % druga_liczba == 0)
                {
                    licznik--;
                }

                if (i % pierwsza_liczba == 0 && i % trzecia_liczba == 0)
                {
                    licznik--;
                }

                if (i % druga_liczba == 0 && i % trzecia_liczba == 0)
                {
                    licznik--;
                }

                if (i % pierwsza_liczba == 0 && i % druga_liczba == 0 && i % trzecia_liczba == 0)
                {
                    licznik++;
                }
            }
            dzielniki_wynik.Text = Convert.ToString(licznik);
        }

        private int gcd(int a, int b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }

        // A simple method to evaluate 
        // Euler Totient Function 
        private int phi(int n)
        {
            int result = 1;
            for (int i = 2; i < n; i++)
                if (gcd(i, n) == 1)
                    result++;
            return result;
        }

        private void Euler(object sender, RoutedEventArgs e)
        {
            czynniki.Text = "";
            euler_wynik.Text = Convert.ToString(phi(Convert.ToInt32(argument.Text)));

            int x, i, eu;

            x = Convert.ToInt32(argument.Text);

            //rozloz na czynniki pierwsze
            i = 2;
            eu = (int)Math.Sqrt(x);
            while (i <= eu)
            {
                while ((x % i) == 0)
                {
                    x /= i;
                    eu = (int)Math.Sqrt(x);
                    czynniki.Text += Convert.ToString(" " + i);
                }
                i++;
            }
            if (x > 1) czynniki.Text += Convert.ToString(" " + x);
        }
    }
}

