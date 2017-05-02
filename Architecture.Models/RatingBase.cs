namespace Architecture.Models
{
    public class RatingBase
    {
        public int Id { get; set; }

        public int Vote { get; set; }

        public string Comment { get; set; }

        public UserBase User { get; set; }
    }
}
