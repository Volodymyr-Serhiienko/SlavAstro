using Astro;

//var myAstro = new AstroObject(DateTime.Now);
var myAstro = new AstroObject(new DateTime(1982, 8, 26, 4, 0, 0));

//var myNumero = new NumeroObject(DateTime.Now);
var myNumero = new NumeroObject(new DateTime(1982, 8, 26, 4, 0, 0));

//var person = new Person(DateTime.Now, "Volodymyr", "Serhiienko");
var person = new Person(new DateTime(1982, 8, 26, 4, 0, 0), "Volodymyr", "Serhiienko");

Console.WriteLine(myAstro);
Console.WriteLine(myNumero);
Console.WriteLine(person);
//Console.WriteLine(myNumero.Slav.ToString());