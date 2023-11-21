namespace GameGraphQLAPI.Models
{
    public class FilterElement
    {
        public int? Page { get; set; }

        public string? Genders { get; set; }

        public string? Platforms { get; set; }

        public string? Studio { get; set; }

        public FilterElement()
        {
            
        }
    }
}
