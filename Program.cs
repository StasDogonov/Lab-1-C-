using laborat._4;
using static System.Net.Mime.MediaTypeNames;

string line = "________________________________________________________________________";

Person person1 = new Person("Vanya", "Kirpich", new DateTime(2003, 6, 5));
Person person2 = new Person("Alex", "Ponchik", new DateTime(2006, 2, 17));
Person person3 = new Person("Stas", "Dohonov", new DateTime(2004, 11, 23));
Cyclist cyclist1 = new Cyclist();
cyclist1.PPerson = person1;
Cyclist cyclist2 = new Cyclist();
cyclist2.PPerson = person2;
Cyclist cyclist3 = new Cyclist();
cyclist3.PPerson = person3;
Cyclist cyclist4 = new Cyclist();
CyclistCollection collection1 = new CyclistCollection();
CyclistCollection collection2 = new CyclistCollection();

collection1.CollectionName = "Collection 1";
collection2.CollectionName = "Collection 2";

Journal journal1 = new Journal();
Journal journal2 = new Journal();

//collection1.CyclistsCountChanged += journal1.HandleCyclistsCountChanged;
//collection1.CyclistReferenceChanged += journal1.HandleCyclistsReferenceChanged;

//collection1.CyclistReferenceChanged += journal2.HandleCyclistReferenceChanged;
//collection2.CyclistReferenceChanged += journal2.HandleCyclistReferenceChanged;

collection1.CyclistsCountChanged += journal1.HandleCyclistsCountChanged;
collection1.CyclistReferenceChanged += journal1.HandleCyclistReferenceChanged;

collection1.CyclistReferenceChanged += journal2.HandleCyclistReferenceChanged;
collection2.CyclistReferenceChanged += journal2.HandleCyclistReferenceChanged;

collection1.AddDefaults(1);
collection2.AddDefaults(2);
collection1.AddCyclists(cyclist1, cyclist2);
collection2.AddCyclists(cyclist3);

collection1.Remove(2);
collection2.Remove(0);

collection2[0] = new Cyclist();
collection1[0] = new Cyclist();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"Journal 1 Entries:{line}") ;
Console.WriteLine(journal1.ToString());

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Journal 2 Entries:{line}");
Console.WriteLine(journal2.ToString());

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"{line}");