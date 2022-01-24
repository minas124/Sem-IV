using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_zaliczeniowy_parydygmaty
{
    class Pracownik
    {
        private string kod_dostepu_logowania="1297"; 
        public string Imie= "Anna";
        public string Nazwisko = "Polos";
        public string kod_dostepu
        {
            get { return this.kod_dostepu_logowania; }

            set {
            if(kod_dostepu == kod_dostepu_logowania)
                {
                    kod_dostepu_logowania = value;
                }
            
            }
        }
       
    }
}
