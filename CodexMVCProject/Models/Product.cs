namespace CodexMVCProject.Models;

public class Product
{
    public int Id { get; set; }
    public string Naziv { get; set; } = null!;
    public string Opis { get; set; } = null!;
    public int Kolicina { get; set; } 
    public int Iznos { get; set; }
    public DateTime Datum { get; set; }

}
