using System;
using System.Collections.Generic;

namespace GameGraphQLAPI.Models;

/// <summary>
/// A studio whose made video games
/// </summary>
[GraphQLDescription("A studio whose made video games")]
public partial class Studio
{
    [GraphQLDescription("Represent the ID of a studio")]
    public int StudioId { get; set; }

    [GraphQLDescription("Name of the studio, it can be null")]
    public string Name { get; set; } = null!;

    [GraphQLDescription("A list of game made by the studio")]
    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
