public class Friend
{
    protected readonly int mPlayerId;

    protected int mProfileIndex = 0;
    protected string mName = "unknow player";

    protected int mCoin;
    protected int mScore;

    public int ProfileIndex
    {
        set { mProfileIndex = value; }
        get { return mProfileIndex; }
    }

    public string Name
    {
        set { mName = value; }
        get { return mName; }
    }

    public int Coin
    {
        set { mCoin = value; }
        get { return mCoin; }
    }

    public int Score
    {
        set { mScore = value; }
        get { return mScore; }
    }

    public Friend(int id, string name, int profile, int coin, int score)
    {
        mPlayerId = id;
        mName = name;
        mProfileIndex = profile;
        mCoin = coin;
        mScore = score;
    }
}
