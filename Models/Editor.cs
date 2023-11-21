using System;
using System.Collections.Generic;

namespace GameGraphQLAPI.Models;

/// <summary>
/// Editor of a game
/// </summary>
[GraphQLDescription("Editor of a game")]
public partial class Editor
{
    [GraphQLDescription("ID of the editor")]
    public int EditorId { get; set; }

    [GraphQLDescription("Name of the editor")]
    public string Name { get; set; } = null!;

    [GraphQLDescription("A list of game made by the editor")]
    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
