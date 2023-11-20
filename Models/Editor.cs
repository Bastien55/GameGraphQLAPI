using System;
using System.Collections.Generic;

namespace GameGraphQLAPI.Models;

public partial class Editor
{
    public int EditorId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
