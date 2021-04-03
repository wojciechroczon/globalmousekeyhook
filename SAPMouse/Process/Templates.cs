using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SAPMouse.Process
{
    public class Templates
    {
        public Dictionary<string, string> fileLocations;
        public Templates()
        {
            this.fileLocations = new Dictionary<string, string>();
            CreateDictionary();
        }

        public void CreateDictionary()
        {
            //Okno główne początek
            fileLocations.Add("cancel", @"\OdbiorcaZmiana_EkranPoczatkowy\btnCancel.png");
            fileLocations.Add("ograniczenieZakresu", @"\OdbiorcaZmiana_EkranPoczatkowy\windowOgraniczenieZakresu.png");
            fileLocations.Add("wyborKlienta", @"\OdbiorcaZmiana_EkranPoczatkowy\wyborKlientaWindow.png");
            fileLocations.Add("windowAcceptGotowe", @"\OdbiorcaZmiana_EkranPoczatkowy\windowAcceptGotowe.png");
            fileLocations.Add("accept", @"\OdbiorcaZmiana_EkranPoczatkowy\btnAccept.png");

            //Sprawdzenie okna
            fileLocations.Add("oknoEkranPoczatkowy", @"\KontrolaOkien\windowEkranPoczatkowy.png");
            fileLocations.Add("windowInformacja", @"\KontrolaOkien\windowInformacja.png");
            fileLocations.Add("oknoDaneOgolne", @"\KontrolaOkien\DaneOgolne.png");
            fileLocations.Add("oknoDaneObszaruZbytu", @"\KontrolaOkien\DaneObszaruZbytu.png");
            fileLocations.Add("windowSprzedaz", @"\KontrolaOkien\windowSprzedaz.png");
            fileLocations.Add("RolePartneraActive", @"\KontrolaOkien\RolePartneraActive.png");
            fileLocations.Add("windowError", @"\KontrolaOkien\windowError.png");
            fileLocations.Add("errorOstrzezenie", @"\KontrolaOkien\errorOstrzezenie.png");
            fileLocations.Add("DaneSterowaniaNIP", @"\KontrolaOkien\DaneSterowaniaNIP.png");
            fileLocations.Add("errorOdbiorcaDoUsuniecia", @"\KontrolaOkien\errorOdbiorcaDoUsuniecia.png");
            fileLocations.Add("btnacceptOstrzerenie", @"\KontrolaOkien\btnacceptOstrzerenie.png");
            fileLocations.Add("errorKodPodatku", @"\NIP\errorKodPodatku.png");


            fileLocations.Add("btnDaneObszaruZbytu", @"\KontrolaOkien\BtnDaneObszaruZbytu.png");


            fileLocations.Add("pracownikDzialuSprzedazy", @"\DaneObszaruZbytu\PracownikDzialuSprzedazyExists.png");
            fileLocations.Add("windowBiuroMiasto", @"\DaneObszaruZbytu\windowBiuroMiasto.png");
            fileLocations.Add("windowWyborBiuraSprzedazy", @"\DaneObszaruZbytu\windowWyborBiuraSprzedazy.png");

            //Okno osoba kontaktowa
            fileLocations.Add("fieldOsobaKontaktowa", @"\OsobaKontaktowa\fieldOsobaKontaktowa.png");
            fileLocations.Add("fieldDodanieOsobyKontaktowej", @"\OsobaKontaktowa\fieldDodanieOsobyKontaktowej.png");
            fileLocations.Add("btnWyborOsobyKontaktowej", @"\OsobaKontaktowa\btnWyborOsobyKontaktowej.png");



        }

        public string GetTemplate(string key)
        {
            string template;

           

            if (fileLocations.TryGetValue(key, out template ))
            {
                return template;
            }
            else
            {
                Console.WriteLine("Brak wartosci");
                return "no value";
            }

        }
    }
}
