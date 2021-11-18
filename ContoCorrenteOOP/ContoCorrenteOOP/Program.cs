using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContoCorrenteOOP
{
    class ContoCorrente
    {
        protected double saldo { get; set; }
        public double getSaldo()
        {
            bool controllo;
            double soldiInseriti;
            do
            {
                Console.WriteLine("Inserisci il tuo saldo in denaro: ");
                string a = Convert.ToString(Console.ReadLine());
                controllo = double.TryParse(a, out soldiInseriti);
            } while (!controllo || soldiInseriti < 0);
            saldo = soldiInseriti;
            return saldo;
        }
        public double versamento()
        {
            double soldiVersati;
            bool controllo;
            do
            {
                Console.WriteLine("Inserisci la quantità di soldi da versare: ");
                string a = Convert.ToString(Console.ReadLine());
                controllo = double.TryParse(a, out soldiVersati);
            } while (!controllo || soldiVersati < 0);
            saldo += soldiVersati;
            return saldo;
        }
        public double prelievo()
        {
            double soldiPrelevati;
            bool controllo;
            do
            {
                Console.WriteLine("Inserisci la quantità di soldi da prelevare: ");
                string a = Convert.ToString(Console.ReadLine());
                controllo = double.TryParse(a, out soldiPrelevati);
            } while (!controllo || soldiPrelevati < 0);
            saldo -= soldiPrelevati;
            return saldo;
        }
        public void mostraSaldo()
        {
            Console.WriteLine("Il saldo corrente è: {0}", saldo);
        }
    }
    class ContoSpeciale : ContoCorrente
    {
        protected double limite = 3000;
        new public double versamento()
        {
            double soldiVersati;
            bool controllo;
            do
            {
                Console.WriteLine("I conti corrente speciali non possono versare più di 3000 euro");
                Console.WriteLine("Inserisci la quantità di soldi da versare: ");
                string a = Convert.ToString(Console.ReadLine());
                controllo = double.TryParse(a, out soldiVersati);
            } while (!controllo || soldiVersati < 0 || soldiVersati > 3000);
            saldo += soldiVersati;
            return saldo;
        }
        new public double prelievo()
        {
            double soldiPrelevati;
            bool controllo;
            do
            {
                Console.WriteLine("I conti corrente speciali non possono prelevare più di 3000 euro");
                Console.WriteLine("Inserisci la quantità di soldi da prelevare: ");
                string a = Convert.ToString(Console.ReadLine());
                controllo = double.TryParse(a, out soldiPrelevati);
            } while (!controllo || soldiPrelevati < 0 || soldiPrelevati > 3000);
            saldo -= soldiPrelevati;
            return saldo;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            menùPrincipale();
            Console.ReadKey();
        }
        static void menùPrincipale()
        {
            Console.WriteLine("Menù principale");
            string risposta;
            do
            {
                Console.WriteLine("Premi 1 per aprire un conto corrente\nPremi 2 per aprire un conto speciale\nPremi 3 per uscire dal programma\n");
                risposta = Console.ReadLine();
                switch (risposta)
                {
                    case "1":
                        Console.WriteLine("Hai aperto un conto corrente");
                        ContoCorrente contoCorrente = new ContoCorrente();
                        contoCorrente.getSaldo(); 
                        gestisciContoCorrente(contoCorrente); break;
                    case "2":
                        Console.WriteLine("Hai aperto un conto corrente speciale");
                        ContoSpeciale contoSpeciale = new ContoSpeciale();
                        contoSpeciale.getSaldo();
                        gestisciContoSpeciale(contoSpeciale); break;
                    case "3": Environment.Exit(0); break;
                }
            } while (risposta != "1" && risposta != "2" && risposta != "3");          
        }
        static void gestisciContoCorrente(ContoCorrente contoCorrente)
        {         
            string scelta;
            do
            {
                Console.WriteLine("Inserisci:\n1 per fare un versamento\n2 per fare un prelievo\n3 per mostare il saldo corrente\n4 per tornare al menù principale\n");
                scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1": contoCorrente.versamento(); gestisciContoCorrente(contoCorrente); break;
                    case "2": contoCorrente.prelievo(); gestisciContoCorrente(contoCorrente); break;
                    case "3": contoCorrente.mostraSaldo(); gestisciContoCorrente(contoCorrente); break;
                    case "4": menùPrincipale(); break;
                }
            } while (scelta != "1" && scelta != "2" && scelta != "3" && scelta != "4");           
        }
        static void gestisciContoSpeciale(ContoSpeciale contoSpeciale)
        {
            string scelta;
            do
            {
                Console.WriteLine("Inserisci:\n1 per fare un versamento\n2 per fare un prelievo\n3 per mostare il saldo corrente\n4 per tornare al menù principale\n");
                scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1": contoSpeciale.versamento(); gestisciContoSpeciale(contoSpeciale); break;
                    case "2": contoSpeciale.prelievo(); gestisciContoSpeciale(contoSpeciale); break;
                    case "3": contoSpeciale.mostraSaldo(); gestisciContoSpeciale(contoSpeciale); break;
                    case "4": menùPrincipale(); break;
                }
            } while (scelta != "1" && scelta != "2" && scelta != "3" && scelta != "4");
        }
    }
}