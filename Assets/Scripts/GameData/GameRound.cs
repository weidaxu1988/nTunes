using System.Collections.Generic;

public class GameRound
{
    public delegate void StatusChange();

    public StatusChange StatusChangeHandler;

    public Music music;
    public List<Friend> invitedList = new List<Friend>();
    public List<Friend> accpetedList = new List<Friend>();

    //Game state variables
    float mScore = 0f;
    public float Score { get { return mScore; } }

    float mStreak = 0;
    public float Streak { get { return mStreak; } }

    float mMaxStreak = 0;
    public float MaxStreak { get { return mMaxStreak; } }

    float mNumNotesHit = 0;
    public float NumNotesHit { get { return mNumNotesHit; } }

    float mNumNotesMissed = 0;
    public float NumNotesMissed { get { return mNumNotesMissed; } }

    public bool AddFriend(Friend mFriend)
    {
        bool result = false;

        if (invitedList.Count < GameFields.MAX_INVITE_FRIEND)
        {
            invitedList.Add(mFriend);
            HandleStatusChange();
            result = true;
        }

        return result;
    }

    void HandleStatusChange()
    {
        if (StatusChangeHandler != null)
            StatusChangeHandler();
    }

    public void Setsummary(float ms, float s, float hit, float missed, float score)
    {
        mMaxStreak = ms;
        mStreak = s;
        mNumNotesHit = hit;
        mNumNotesMissed = missed;
        mScore = score;
    }
}
