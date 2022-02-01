using System.Collections.Generic;

public class PlayerBuilder
{
    List<BoughtUtencil> utencils;

    public PlayerBuilder()
    {
        this.utencils = new List<BoughtUtencil>();
    }

    public PlayerBuilder WithUtencils (params BoughtUtencil[] utencils)
    {
        this.utencils = new List<BoughtUtencil>(utencils);
        return this;
    }

    public Player Build ()
    {
        return new Player()
        {
            utencils = this.utencils
        };
    }

    public static implicit operator Player (PlayerBuilder playerBuilder)
    {
        return playerBuilder.Build ();
    }
}
