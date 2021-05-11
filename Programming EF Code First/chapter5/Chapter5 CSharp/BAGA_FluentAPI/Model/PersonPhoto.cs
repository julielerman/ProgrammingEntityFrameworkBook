namespace Model
{
  public class PersonPhoto
  {
    public int PersonId { get; set; }
    public byte[] Photo { get; set; }
    public string Caption { get; set; }
    public Person PhotoOf { get; set; }
  }
}