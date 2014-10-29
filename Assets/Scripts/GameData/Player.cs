using System.Collections.Generic;

public class Player : Friend
{
    List<GameRound> gameList = new List<GameRound>();

    public Player(int id, string name)
        : base(id, name, 1, 0, 0)
    {
    }

    public void addGameRecord(GameRound gr)
    {
        gameList.Add(gr);
    }
}
