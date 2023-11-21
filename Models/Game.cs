using System;
using System.Collections.Generic;

namespace GameGraphQLAPI.Models;

/// <summary>
/// A class that represent a video game
/// </summary>
[GraphQLDescription("A video game")]
public partial class Game
{
    [GraphQLDescription("ID of a video game")]
    public int GameId { get; set; }

    [GraphQLDescription("Name of the video game, it can be null")]
    public string Name { get; set; } = null!;

    [GraphQLDescription("Airdate of the video game")]
    public DateTime? PublicationDate { get; set; }

    [GraphQLDescription("Platforms where we can play the video game")]
    public string? Platform { get; set; }

    [GraphQLDescription("Categories of the video game like : FPS, Sandbox, MMORPG...")]
    public string? Genres { get; set; }

    [GraphQLDescription("A list of editors which made the video game")]
    public virtual ICollection<Editor> Editors { get; set; } = new List<Editor>();

    [GraphQLDescription("A list of studios which made the video game")]
    public virtual ICollection<Studio> Studios { get; set; } = new List<Studio>();
}
