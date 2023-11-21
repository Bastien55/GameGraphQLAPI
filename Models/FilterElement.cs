namespace GameGraphQLAPI.Models
{
    /// <summary>
    /// Class for filter element in a list depending on one or severals properties
    /// </summary>
    [GraphQLDescription("Class allow to have severals property that can be use as a filter")]
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
