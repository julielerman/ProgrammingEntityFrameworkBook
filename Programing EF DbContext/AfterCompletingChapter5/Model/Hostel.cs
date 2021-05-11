namespace Model
{
  public class Hostel : Lodging
  {
    public int MaxPersonsPerRoom { get; set; }
    public bool PrivateRoomsAvailable { get; set; }
  }
}