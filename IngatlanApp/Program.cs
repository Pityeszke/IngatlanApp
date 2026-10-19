using IngatlanApp;
using System.Xml.Serialization;

List<Ingatlan> ingatlanok_lista = new List<Ingatlan>();
int hibasSorokSzama = 0;

foreach (var sor in File.ReadLines(@"C:\Users\fazek\source\repos\IngatlanApp\IngatlanApp\bin\Debug\net8.0\ingatlanok.txt").Skip(1))
{
    if (string.IsNullOrWhiteSpace(sor))
    {
        hibasSorokSzama++;
        continue;
    }

    string[] adatok = sor.Split('|');
    string tipus = adatok[0];
    string helyrajz = adatok[1];
    int alapterulet;
    int extra;

    if(adatok.Count() != 4)
    {
        hibasSorokSzama++;
        continue;
    }

    if( tipus != "I" && tipus != "L" || tipus == "")
    {
        hibasSorokSzama++;
        continue;
    }

    if (!(int.TryParse(adatok[2], out alapterulet)) || !(int.TryParse(adatok[3], out extra)))
    {
        hibasSorokSzama++;
        continue;
    }

    if( tipus == "I")
    {
        Ingatlan ingatlan = new Ingatlan(helyrajz, alapterulet);
        ingatlanok_lista.Add(ingatlan);
    }
    else if (tipus == "L")
    {
        Lakas lakas = new Lakas(helyrajz, alapterulet, extra);
        ingatlanok_lista.Add(lakas);
    }

}

Console.WriteLine($"Sikeresen beolvasott ingatlanok: {ingatlanok_lista.Count()} db");
Console.WriteLine($"Kiszűrt hibás sorok száma: {hibasSorokSzama} db");
Console.WriteLine();
Console.WriteLine("Beolvasott ingatlanok listája:");
foreach (var item in ingatlanok_lista)
{
    Console.WriteLine(item);
}
Console.WriteLine();
Console.WriteLine("Lakások külön elemzése:");
foreach (var item in ingatlanok_lista)
{
    if( item is Lakas l)
    {
        Console.WriteLine($"- {l.Helyrajziszam} lakás a(z) {l.Emelet}. emeleten található");
    }
}

Console.WriteLine();
Console.WriteLine($"Teljes portfólió becsült értéke: {ingatlanok_lista.Sum(i => i.BecsultErtek())} Ft");
Console.WriteLine($"Ingatlan példányok száma (static): {Ingatlan.OsszesIngatlanSzama} db");