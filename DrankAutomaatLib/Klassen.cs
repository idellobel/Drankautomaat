using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrankAutomaatLib
{
    public enum Status { Kies, Betaal, Koop, Neem }

    public class Drankje
    {
        private decimal drankprijs;
        public decimal Drankprijs { get; set; }

        private string dranknaam;
        public string Dranknaam { get; set; }

        public Drankje() { }

        public Drankje(string dranknaam, decimal drankprijs)
        {
            Dranknaam = dranknaam;
            Drankprijs = drankprijs;
        }

        public override string ToString()
        {
            return String.Format(" {0} "
               , Dranknaam);
        }

    }

    public class Wisselgeld
    {
        private decimal geldwaarde;
        public decimal Geldwaarde { get; set; }

        int[] aantalstukken = new int[6];
        public int[] Aantalstukken
        {
            get { return aantalstukken; }
            set { aantalstukken = value; }
        }

        public Wisselgeld() { }

        public Wisselgeld(decimal geldwaarde)
        {
            Geldwaarde = geldwaarde;
        }

        public decimal OmzettingCent(Wisselgeld geld)
        {
            Geldwaarde = Math.Round(Geldwaarde * 100);
            return Geldwaarde;
        }

        public override string ToString()
        {
            return String.Format(" {0} "
               , Geldwaarde);
        }

    }

    public class Drankenautomaat
    {
        public static Status Status { get; set; }
        public Wisselgeld geld;
        public Drankje keuze;

        public decimal automaatInworp;
        public decimal totaleInworp;

        public string automaatKeuze;
        public decimal automaatDrankprijs;
        public string automaatDranknaam;
        public List<Drankje> dranken;

        public List<Wisselgeld> euro;
        public List<Wisselgeld> cent;

        public string berekenWisselgeld;
        public decimal terug;
        //private decimal resterendBedrag;

        public Drankenautomaat()
        {
            keuze = new Drankje();

            dranken = new List<Drankje>();
            dranken.Add(new Drankje("Cola", 1.50M));
            dranken.Add(new Drankje("Water", 1.20M));
            dranken.Add(new Drankje("Koffie", 2.00M));
            dranken.Add(new Drankje("Soep", 1.75M));

            geld = new Wisselgeld();

            euro = new List<Wisselgeld>();
            euro.Add(new Wisselgeld(2M));
            euro.Add(new Wisselgeld(1M));

            cent = new List<Wisselgeld>();
            cent.Add(new Wisselgeld(50M));
            cent.Add(new Wisselgeld(20M));
            cent.Add(new Wisselgeld(10M));
            cent.Add(new Wisselgeld(5M));

        }

        public decimal TotaleInworp(Wisselgeld geld)
        {
            automaatInworp = geld.Geldwaarde * 1.00M;
            if (automaatInworp > 2.00M)
            {
                automaatInworp = automaatInworp / 100;
            }
            totaleInworp += automaatInworp;
            return totaleInworp;

        }
        public decimal AnnulerenInworp()
        {
            totaleInworp = 0;
            return totaleInworp;
        }

        public string HuidigeKeuze(Drankje keuze)
        {
            automaatKeuze = keuze.Dranknaam + "( €" + keuze.Drankprijs + ")";
            automaatDranknaam = keuze.Dranknaam;
            return automaatKeuze;
        }
        /// <summary>
        /// Melding: berekenen wisselgeld
        /// </summary>
        /// <returns>terug.ToString()</returns>
        public string BerekenTerug()
        {
            terug = totaleInworp - automaatDrankprijs;
            return terug.ToString();
        }

        /// <summary>
        /// Melding: berekenen van de munten van het wisselgeld
        /// </summary>
        /// <param name="terug"></param>
        /// <returns>berekenWisselgeld </returns>
        public string BerekenWisselGeld(decimal terug)
        {
            decimal resterendBedrag = terug;
            var muntstukken = new[]
            {
                new { geldstuk = " x € 2,00 ", waarde   = 2.00M },
                new { geldstuk = " x € 1,00 ", waarde   = 1.00M },
                new { geldstuk = " x € 0,50 ", waarde   = 0.50M},
                new { geldstuk = " x € 0,20 ", waarde   = 0.20M},
                new { geldstuk = " x € 0,10 ", waarde   = 0.10M},
                new { geldstuk = " x € 0,05 " , waarde   = 0.05M }
             };
            /*
            //Voorlopig niet geslaagde uitvoering
            int[] aantalstukken = new int[6];
           
            for (int i = 0; i < muntstukken.Length; i++)
             {
               
                decimal hulp = resterendBedrag;
                     aantalstukken[i] = (int)(resterendBedrag / muntstukken[i].waarde);
                //if (aantalstukken[i] > 0)
                berekenWisselgeld=  "\n" + aantalstukken[i].ToString() + muntstukken[i].geldstuk;
                     hulp = resterendBedrag - (aantalstukken[i] * muntstukken[i].waarde);
             }

            return berekenWisselgeld;
         }*/


            //1 - dient compacter !!
            resterendBedrag = terug;
            int aantalStukken = (int)(resterendBedrag / muntstukken[0].waarde);
            if (aantalStukken > 0)
                berekenWisselgeld = aantalStukken.ToString() + muntstukken[0].geldstuk;

            //2
            resterendBedrag -= (aantalStukken * muntstukken[0].waarde);
            aantalStukken = (int)(resterendBedrag / muntstukken[1].waarde);
            if (aantalStukken > 0)
                berekenWisselgeld += "\n" + aantalStukken.ToString() + muntstukken[1].geldstuk;

            //3
            resterendBedrag -= (aantalStukken * muntstukken[1].waarde);
            aantalStukken = (int)(resterendBedrag / muntstukken[2].waarde);
            if (aantalStukken > 0)
                berekenWisselgeld += "\n" + aantalStukken.ToString() + muntstukken[2].geldstuk;

            //4
            resterendBedrag -= (aantalStukken * muntstukken[2].waarde);
            aantalStukken = (int)(resterendBedrag / muntstukken[3].waarde);
            if (aantalStukken > 0)
                berekenWisselgeld += "\n" + aantalStukken.ToString() + muntstukken[3].geldstuk;

            //5
            resterendBedrag -= (aantalStukken * muntstukken[3].waarde);
            aantalStukken = (int)(resterendBedrag / muntstukken[4].waarde);
            if (aantalStukken > 0)
                berekenWisselgeld += "\n" + aantalStukken.ToString() + muntstukken[4].geldstuk;

            //6
            resterendBedrag -= (aantalStukken * muntstukken[4].waarde);
            aantalStukken = (int)(resterendBedrag / muntstukken[5].waarde);
            if (aantalStukken > 0)
                berekenWisselgeld += "\n" + aantalStukken.ToString() + muntstukken[5].geldstuk;
            return
            berekenWisselgeld;
        }
    }

 }

    


       

















