using System;

namespace RejestrPracownikow
{
    class Program
    {
        static void Main(string[] args)
        {
            Rejestr R = new Rejestr();

            Address a1 = new Address("Kościerzyna", "Kartuska", 5, 2);
            Address a2 = new Address("Gdańsk", "Grunwaldzka", 16, 6);
            Address a3 = new Address("Gdynia", "Kapliczna", 9, 1);
            Address a4 = new Address("Gdańsk", "Słoneczna", 10, 3);
            Address a5 = new Address("Gdynia", "Rolna", 19, 20);

            Pracownik p1 = new PracownikBiurowy(1, "Artur", "Kowalski", 25, 2, a1, 1, 80);
            Pracownik p2 = new PracownikFizyczny(2, "Konrad", "Chmieliński", 40, 8, a2, 15);
            Pracownik p3 = new Handlarz(3, "Mateusz", "Gostkowski", 30, 5, a3, Wydajnosc.ŚREDNIA, 5);
            Pracownik p4 = new PracownikFizyczny(4, "Ryszard", "Kochanowski", 40, 5, a4, 50);
            Pracownik p5 = new Handlarz(5, "Adam", "Smyczek", 40, 5, a5, Wydajnosc.NISKA, 5);

            /*            DODAWANIE POJEDYŃCZO PRACOWNIKÓW */
            R.Dodaj(p1);
            R.Dodaj(p2);
            R.Dodaj(p3);

            /*            DODAWANIE KILKU PRACOWNIKÓW */
            Pracownik[] l = new Pracownik[] { p4, p5 };
            R.Dodaj(l);

            /*            WYŚWIETLANIE POSORTOWANEJ LISTY WSZYSTKICH PRACOWNIKÓW */
            Console.WriteLine("Posortowana lista:");
            R.Wyswietl();

/*            WYŚWIETLANIE LISTY PRACOWNIKÓW PO MIEŚCIE */
            Console.WriteLine("\nWyszukiwanie po mieście:");
            R.Wyswietl("Gdańsk");

/*            WYŚWIETLANIE LISTY PRACOWNIKÓW Z WARTOŚCIAMI */
            Console.WriteLine("\nPracownicy z wartościami:");
            R.WyswietlWartosci();


        }
    }
}
