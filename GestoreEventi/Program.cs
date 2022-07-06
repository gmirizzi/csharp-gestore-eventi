using GestoreEventi;

Console.Write("Inserisci il nome dell'evento ");
string name = Console.ReadLine();
Console.Write("Inserisci la data dell'evento (gg/mm/yyyy) ");
DateTime date = DateTime.Parse(Console.ReadLine());
Console.Write("Inserisci il numero di posti totali ");
int posti = int.Parse(Console.ReadLine());
Evento newEvent = new Evento(posti, name, date);
Console.Write("Quanti posti desideri prenotare? ");
int prenotazioni = int.Parse(Console.ReadLine());
newEvent.PrenotaPosti(prenotazioni);
Console.WriteLine();
Console.WriteLine($"Numero di posti prenotati: {newEvent.Prenotazioni}");
Console.WriteLine($"Numero di posti disponibili: {newEvent.PostiTotali - newEvent.Prenotazioni}");
Console.WriteLine();
bool disdici = true;
do
{
    Console.Write("Vuoi disdire dei posti (sì/no)? ");
    string scelta = Console.ReadLine();
    if (scelta== "sì")
    {
        Console.Write("Indica il numero di posti da disdire ");
        prenotazioni = int.Parse(Console.ReadLine());
        newEvent.DisdiciPosti(prenotazioni);
        Console.WriteLine();
        Console.WriteLine($"Numero di posti prenotati: {newEvent.Prenotazioni}");
        Console.WriteLine($"Numero di posti disponibili: {newEvent.PostiTotali - newEvent.Prenotazioni}");
        Console.WriteLine();
    }
    else
    {
        disdici = false;
    }

} while (disdici);