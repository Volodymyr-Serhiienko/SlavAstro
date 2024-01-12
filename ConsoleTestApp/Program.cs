using Astro;

//var myBirthday = new AstroObject(DateTime.Now);
var myBirthday = new AstroObject(new DateTime(1982, 8, 26, 4, 0, 0));
Console.WriteLine(myBirthday.DateInfo.Slav.ToString());