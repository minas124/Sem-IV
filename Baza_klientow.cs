using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_zaliczeniowy_parydygmaty
{
    class Baza_klientow
    {
        private string sprawdzenie_peselu;
        private string sprawdzenie_nipu;
        private string sprawdzenie_iban;
        public string imie;
        public string nazwisko;
        public decimal kwota_zadluzen;
        public string IBAN
        {
            get { return sprawdzenie_iban; }
            set
            {
                if (WeryfikujIBAN(value))
                {
                    sprawdzenie_iban = value;
                }
            }
        }
        public string NIP
        {
            get { return sprawdzenie_nipu; }
            set
            {
                if (WeryfikujNip(value))
                {
                    sprawdzenie_nipu = value;
                }
            }
        }
        public string Pesel
        {
            get { return sprawdzenie_peselu; }
            set
            {
                if (WeryfikujPesel(value))
                {
                    sprawdzenie_peselu = value;
                }
            }
        }
        public bool WeryfikujPesel(string pesel)
        {

            int ile = pesel.Length;
            if (ile == 11)
            {
                foreach (char c in pesel)
                {
                    if (!char.IsDigit(c))
                        return false;
                }
                return true;
            }
            else

                return false;
        }

        public bool WeryfikujNip(string NIP)
        {
            if (NIP.Length != 10)
            {
                return false;
            }
            if (!NIP.All(d => d >= '0' && d <= '9'))
            {
                return false;
            }

            if (NIP.Length == 10)

            {
                int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7, 0 };
                int sum = NIP.Zip(weights, (d, weight) => (d - '0') * weight).Sum();

                if ((sum % 11) == (NIP[9] - '0'))
                {
                    return true;
                }
            }
            return false;
        }
        public void Zapis()
        {
            Console.WriteLine("Prosze o podanie nazwy pliku ");
            string nazwa = Console.ReadLine();
            string path = "C:\\Users\\Michał Bujalski\\Desktop\\Projekt_zaliczeniowy_parydygmaty";
            if (Directory.Exists(path))
            {

                string content = "imie: " + imie + "; nazwisko: " + nazwisko + ", IBAN: " + IBAN + ", NIP: " + NIP + ", Pesel: " + Pesel + ", kwota_zadluzen: " + kwota_zadluzen;
                string dirPaht = Directory.GetCurrentDirectory();
                string filePaht = Path.Combine(dirPaht, nazwa /*imie + " " + nazwisko + " "*/ + ".txt");



                File.WriteAllText(filePaht, content);
            }
            else
            {
                Directory.CreateDirectory(path);    
            }


        }
        public bool WeryfikujIBAN(string IBAN)
        {
            IBAN = "PL" + IBAN;
            bool info = false;


            var asciiShift = 55;
            IBAN = IBAN.ToUpper();

            if (!System.Text.RegularExpressions.Regex.IsMatch(IBAN, "^[A-Z0-9]")) info = false;

            //Rearrange iban
            IBAN = IBAN.Replace(" ", string.Empty).Replace("-", string.Empty);
            var rearrangedIban = IBAN.Substring(4, IBAN.Length - 4) + IBAN.Substring(0, 4);

            //Convert to integer checksum
            var stringBuilder = new StringBuilder();
            foreach (var ibanChar in rearrangedIban)
            {
                int convertedValue;
                if (char.IsLetter(ibanChar))
                    convertedValue = ibanChar - asciiShift;
                else
                    convertedValue = int.Parse(ibanChar.ToString());
                stringBuilder.Append(convertedValue);
            }

            //Modulo operation on IBAN checksum
            var checkSumString = stringBuilder.ToString();
            var checksum = int.Parse(checkSumString.Substring(0, 1));
            for (var i = 1; i < checkSumString.Length; i++)
            {
                checksum *= 10;
                checksum += int.Parse(checkSumString.Substring(i, 1));
                checksum %= 97;
            }
            if (checksum == 1)
                info = true;
            else
                info = false;

            return info;

        }
    }
}
    

