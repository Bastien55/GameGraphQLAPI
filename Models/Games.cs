namespace GameGraphQLAPI.Models
{
    /// <summary>
    /// Class that contain information for the pagination and a list of all games
    /// </summary>
    [GraphQLDescription("Class that contain information for the pagination and a list of all games")]
    public class Games
    {
        [GraphQLDescription("Information of pagination")]
        public Info Info { get; set; }

        [GraphQLDescription("A list of all games that are available")]
        public List<Game> AllGame { get; set; }

        public Games() 
        { 

        }
    }
}
