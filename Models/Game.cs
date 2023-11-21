using System;
using System.Collections.Generic;

namespace GameGraphQLAPI.Models;

public partial class Game
{
    public int GameId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? PublicationDate { get; set; }

    public string? Platform { get; set; }

    public string? Genres { get; set; }

    public virtual ICollection<Editor> Editors { get; set; } = new List<Editor>();

    public virtual ICollection<Studio> Studios { get; set; } = new List<Studio>();
}
