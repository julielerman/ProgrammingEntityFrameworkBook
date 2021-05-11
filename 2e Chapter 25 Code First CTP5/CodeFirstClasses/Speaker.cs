using System.Collections.Generic;

namespace CodeFirstClasses
{
  public  class Speaker
  {
    public int SpeakerId { get; set; }
    public   string FirstName { get; set;}
    public   string LastName { get; set;}
    

    public string Name
    {
      get { return FirstName.TrimEnd() + " " + LastName; }
    }
    

    public   string Title { get; set;}

    public   string City { get; set;}

    public   string Country { get; set;}

    public   string Expertise { get; set;}

    public   string Bio { get; set;}
    public   ICollection<Session> Sessions { get; set;}


   
  }
}
