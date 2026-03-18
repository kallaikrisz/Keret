namespace Kozos
{
    public class KeresztrejtvenyRacs
    {

        private List<string> Adatsorok;
        private char[,] Racs;
        private int[,] Sorszamok;

        public int OszlopokDb => Racs?.GetLength(1) ?? 0;
        public int SorokDb => Racs.GetLength(0);
        public char[,] RacsAdatok => Racs;
        public int[,] SorszamokAdatok => Sorszamok;

        public KeresztrejtvenyRacs(string forras)
        {
            Adatsorok = new List<string>();
            BeolvasAdatsorok(forras);
            FeltoltRacs();
        }

        public void BeolvasAdatsorok(string forras)
        {
            Adatsorok = File.ReadAllLines(forras).ToList();
        }
        public void FeltoltRacs()
        {
            int sorDb = Adatsorok.Count;
            int oszlopDb = Adatsorok[0].Length;
            Racs = new char[sorDb+2, oszlopDb+2];
            Sorszamok = new int[sorDb+2, oszlopDb+2];
            for (int i = 0; i < sorDb + 2; i++)
            {
                for (int j = 0; j < oszlopDb + 2; j++)
                {
                    Racs[i, j] = '#';
                }
            }
            for (int i = 0; i < sorDb; i++)
            {
                for (int j = 0; j < oszlopDb; j++)
                {
                    Racs[i+1, j+1] = Adatsorok[i][j];
                }
            }
        }
        public void Sorszamoz()
        {
            int sorszam = 1;
            for (int i = 1; i < Racs.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < Racs.GetLength(1) - 1; j++)
                {
                    if (Racs[i, j] != '-') continue;
                    bool vizszintesKezdet =Racs[i, j - 1] == '#' && Racs[i, j + 1] == '-'; 
                    bool fuggolegesKezdet =Racs[i - 1, j] == '#' && Racs[i + 1, j] == '-';
                    if (vizszintesKezdet || fuggolegesKezdet)
                    {
                        Sorszamok[i, j] = sorszam;
                        sorszam++;
                    }
                }
            }
        }
    }
}
