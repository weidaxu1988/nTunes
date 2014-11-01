using System.Collections.Generic;

public class GameRound
{
    public delegate void StatusChange();

    public StatusChange StatusChangeHandler;

    public Music music;
    public List<Friend> invitedList = new List<Friend>();
    public List<Friend> accpetedList = new List<Friend>();

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
}
