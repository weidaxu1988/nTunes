using System.Collections.Generic;

public class Player : Friend
{
    public List<Friend> friendList = new List<Friend>();

    List<GameRound> gameList = new List<GameRound>();

    public Player(int id, string name)
        : base(id, name, 1, 0, 0)
    {
        addFriend(new Friend(1011, "mat", 2, 100, 350));
        addFriend(new Friend(1012, "weida", 1, 103, 1350));
        addFriend(new Friend(1013, "jian", 4, 105, 450));
        addFriend(new Friend(1014, "ying", 5, 102, 360));
        addFriend(new Friend(1015, "wang", 3, 200, 500));
    }

    public void addGameRecord(GameRound gr)
    {
        gameList.Add(gr);
    }

    public void addFriend(Friend f)
    {
        friendList.Add(f);
    }
}
