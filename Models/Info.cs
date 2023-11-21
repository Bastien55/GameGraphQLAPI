namespace GameGraphQLAPI.Models
{
    public class Info
    {
        public int Count { get; set; }

        public int Pages { get; set; }

        public int? Next { get; set; }

        public int? Previous { get; set; }

        public Info()
        {
            
        }

        public Info(int count, int page)
        {
            Count = count;
            Pages = page;
        }
    }
}
