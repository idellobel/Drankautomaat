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
using DrankAutomaatLib;
using System.Diagnostics;
using Microsoft.Win32;
using System.Media;

namespace WpfDrankAutomaat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Drankenautomaat automaat = new Drankenautomaat();
        Button eurocentbutton;
        Button eurobutton;
        

        public MainWindow()
        {
            InitializeComponent();
        }

        
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Kies();
            Inworp();
        }
      
       private void Kies()
        {
            foreach (Drankje keuze in automaat.dranken)
            {
               Button drankbutton = new Button();
                
                spMaakEenKeuze.IsEnabled = true;
                drankbutton.Content = keuze;
               
                drankbutton.Click += drankbutton_Click;
                spMaakEenKeuze.Children.Add(drankbutton);
                drankbutton.Width = 100;
                drankbutton.Height = 20;
                drankbutton.Margin = new Thickness(5, 0, 10, 55);
            }
            lbStatus.Content = Status.Kies;
       }

        public void Inworp()
        {
            foreach (Wisselgeld geld in automaat.euro)
            {
                eurobutton = new Button();
                eurobutton.Content = geld;
                eurobutton.Click += eurobutton_Click;
                spInworpEuro.Children.Add(eurobutton);
                spInworpEuro.IsEnabled = false;
                eurobutton.Width = 215;
                eurobutton.Height = 20;
                eurobutton.Margin = new Thickness(5, 0, 10, 10);
            }

            foreach (Wisselgeld geld in automaat.cent)
            {
                eurocentbutton = new Button();
                eurocentbutton.Content = geld;
                eurocentbutton.Click += eurocentbutton_Click;
                spInworpEuroCent.Children.Add(eurocentbutton);
                spInworpEuroCent.IsEnabled = false;
                eurocentbutton.Width = 100;
                eurocentbutton.Height = 20;
                eurocentbutton.Margin = new Thickness(5, 0, 10, 65);
            }
        }
        public void drankbutton_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer Drankbutton = new SoundPlayer(Resource2.Drank);
            Drankbutton.Play();
            Drankje c = (sender as Button).Content as Drankje;
            automaat.automaatDrankprijs = c.Drankprijs;
            lbDrankkeuze.Content = automaat.HuidigeKeuze(c);
            lbStatus.Content = Status.Betaal;
            spInworpEuro.IsEnabled = true;
            spInworpEuroCent.IsEnabled = true;
            spMaakEenKeuze.IsEnabled = false;
        }

        public void eurobutton_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer Eurobutton = new SoundPlayer(Resource2.Munt);
            Eurobutton.Play();
            Wisselgeld a = (sender as Button).Content as Wisselgeld;
            automaat.automaatInworp = a.Geldwaarde;
            lbIngeworpenBedrag.Content = "€ " + automaat.TotaleInworp(a);
            Kopen();
        }

        private void eurocentbutton_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer Eurocentbutton = new SoundPlayer(Resource2.Munt);
            Eurocentbutton.Play();

            Wisselgeld a = (sender as Button).Content as Wisselgeld;
            automaat.automaatInworp = a.Geldwaarde;
            lbIngeworpenBedrag.Content = "€ " + automaat.TotaleInworp(a);
            Kopen();
        }

        private void btKopen__Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer Kopenbutton = new SoundPlayer(Resource2.Jackpot);
            Kopenbutton.Play();
            lbStatus.Content = Status.Neem;
            btAnnuleren.IsEnabled = false;
            btNeemDrankje.Visibility = Visibility;
            btNeemDrankje.IsEnabled = true;
            lbMdedelingInhoud.Content = ("Neem uw " + automaat.automaatDranknaam
                   + "\nterug € " + automaat.BerekenTerug()
                   + "\n" + automaat.BerekenWisselGeld(automaat.terug)
                   + "\n");
          
            img01.Source = new BitmapImage(new Uri("/images/"+ automaat.automaatDranknaam +".png", UriKind.Relative));
            img01.Visibility = Visibility.Visible;
            btnKopen.IsEnabled = false;
        }
        
        private void Kopen()
        {
            if (automaat.totaleInworp >= automaat.automaatDrankprijs)
            {
                btnKopen.IsEnabled = true;
                lbStatus.Content = Status.Koop;
                spInworpEuro.IsEnabled = false;
                spInworpEuroCent.IsEnabled = false;
            }
        }
        private void btAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer Annulerenbutton = new SoundPlayer(Resource2.Annuleren);
            Annulerenbutton.Play();
            Annuleren();
        }
        private void Annuleren()
        {
            spMaakEenKeuze.Children.Clear();
            lbDrankkeuze.Content = "";
            lbIngeworpenBedrag.Content = "€ 0.00";
            automaat.AnnulerenInworp();
            automaat.berekenWisselgeld = "";
            btnKopen.IsEnabled = false;
            btAnnuleren.IsEnabled = true;
            lbMdedelingInhoud.Content = "";
            btNeemDrankje.Visibility = Visibility.Hidden;
            Kies();
        }

        private void btNeemDrankje_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer Neembutton = new SoundPlayer(Resource2.Neem);
            Neembutton.Play();
            img01.Visibility = Visibility.Hidden;
            Annuleren();
        }
       
    }

}
