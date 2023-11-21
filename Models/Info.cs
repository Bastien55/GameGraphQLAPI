namespace GameGraphQLAPI.Models
{
    /// <summary>
    /// Class for the information data and pagination
    /// </summary>
    [GraphQLDescription("Class for the information data and pagination")]
    public class Info
    {
        [GraphQLDescription("Represent the number of elements that is present in a list")]
        public int Count { get; set; }

        [GraphQLDescription("Represent the total number of pages")]
        public int Pages { get; set; }

        [GraphQLDescription("Represent the number of the next page (current page + 1)")]
        public int? Next { get; set; }

        [GraphQLDescription("Represent the number of the previous page (current page - 1)")]
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
