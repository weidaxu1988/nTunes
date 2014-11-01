using UnityEngine;
using System.Collections;

public class ProfileDetail : MonoBehaviour
{
    public UILabel name;
    public UILabel score;
    public ProfileIcon icon;
    public UILabel friendCound;

    void OnEnable()
    {
        GameManager.Instance.CurGame.StatusChangeHandler += inviteFriendChange;

        name.text = GameManager.Instance.CurPlayer.Name;
        score.text = GameManager.Instance.CurPlayer.Score + "";
        icon.ProfileIndex = GameManager.Instance.CurPlayer.ProfileIndex;
        friendCound.text = "0/" + GameFields.MAX_INVITE_FRIEND;
    }

    void OnDisable()
    {
        GameManager.Instance.CurGame.StatusChangeHandler -= inviteFriendChange;
    }

    void inviteFriendChange()
    {
        friendCound.text = GameManager.Instance.CurGame.invitedList.Count + "/" + GameFields.MAX_INVITE_FRIEND;
    }
}
