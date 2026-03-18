using Kozos;
//5.feladat
KeresztrejtvenyRacs aktualis = new KeresztrejtvenyRacs("kr1.txt");
Console.WriteLine("5. feladat: A keresztrejtvény mérete");
Console.WriteLine($"\tSorok száma: {aktualis.SorokDb-2}");
Console.WriteLine($"\tOszlopok száma: {aktualis.OszlopokDb-2}");
//6.feladat
for (int i = 0; i < aktualis.SorokDb - 2; i++)
{
    for (int j = 0; j < aktualis.OszlopokDb - 2; j++)
    {
        if(aktualis.RacsAdatok[i + 1, j + 1]=='-')
        Console.Write("[]");
        else Console.Write("##");
    }
    Console.WriteLine();
}
//7.feladat
int leghosszabb = 0;
for (int i = 1; i < aktualis.OszlopokDb - 2; i++)
{
    for (int j = 1; j < aktualis.SorokDb - 2; j++)
    {
        if (aktualis.RacsAdatok[j + 1, i + 1] == '-')
        {
            int hossza = 0;
            while (j < aktualis.SorokDb - 2 && aktualis.RacsAdatok[j + 1, i + 1] == '-')
            {
                hossza++;
                j++;
            }
            if (hossza > leghosszabb)
                leghosszabb = hossza;
        }
    }
}
Console.WriteLine($"7. feladat: A leghoszabb függőleges: {leghosszabb} karakter");
//8.feladat
Console.WriteLine("8. feladat: Vízszintes szavak statisztikája");
List<int> stat = new List<int>();
for (int i = 1; i < aktualis.SorokDb - 1; i++)
{
    int j = 1;
    while (j < aktualis.OszlopokDb - 1)
    {
        if (aktualis.RacsAdatok[i, j] == '-')
        {
            int hossz = 0;
            while (j < aktualis.OszlopokDb - 1 && aktualis.RacsAdatok[i, j] == '-')
            {
                hossz++;
                j++;
            }
            if (hossz >= 2) stat.Add(hossz);
        }
        else
        {
            j++;
        }
    }
}
for (int i = 2; i < aktualis.OszlopokDb - 2; i++)
{
    int db = stat.Count(x => x == i);
    if (db > 0) Console.WriteLine($"\t{i} betűs: {db} darab");
}
//9.feladat
Console.WriteLine("9. feladat: A keresztrejtvény számokkal");
aktualis.Sorszamoz();
for (int i = 1; i < aktualis.RacsAdatok.GetLength(0) - 1; i++)
{
    string sor = "";
    for (int j = 1; j < aktualis.RacsAdatok.GetLength(1) - 1; j++)
    {
        char c = aktualis.RacsAdatok[i, j];
        int sz = aktualis.SorszamokAdatok[i, j];
        if (c == '#')sor += "##";
        else if (sz > 0)sor += sz.ToString("D2");
        else sor += "[]";
    }
    Console.WriteLine(sor);
}

