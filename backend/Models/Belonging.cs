using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

public class Belonging
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string AgeRange { get; set; }
    public IEnumerable<Picture> Pictures { get; set; }
}