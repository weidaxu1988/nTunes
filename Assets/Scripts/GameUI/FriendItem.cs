using UnityEngine;
using System.Collections;

public class FriendItem : MonoBehaviour
{
    public UISprite mIconSprite;
    public UILabel mNameLabel;
    public UILabel mScoreLabel;
    public UILabel statusLabel;
    public GameObject inviteBtn;
    public GameObject invitedLabel;

    public TweenAlpha mAlpha;

    Friend mFriend;

    void OnEnable()
    {
        if (inviteBtn)
            inviteBtn.SetActive(true);
        if (invitedLabel)
            invitedLabel.SetActive(false);
    }

    public void SetFriend(Friend f)
    {
        mFriend = f;
        UpdateContent();

    }

    public void Fadding(bool fade)
    {
        if (fade)
            mAlpha.PlayForward();
        else
            mAlpha.PlayReverse();
    }

    public void UpdateContent()
    {
        SetProfile(mFriend.ProfileIndex);
        SetName(mFriend.Name);
        SetScore(mFriend.Score);
        SetStatus();
    }

    void SetProfile(int i)
    {
        mIconSprite.spriteName = GameFields.PROFILE_HEAD + i;
    }

    void SetName(string n)
    {
        mNameLabel.text = n;
    }

    void SetScore(int s)
    {
        if (mScoreLabel)
            mScoreLabel.text = "" + s;
    }

    void SetStatus()
    {

    }

    public void OnInviteBtnClick()
    {
        if (GameManager.Instance.CurGame.AddFriend(mFriend))
        {
            inviteBtn.SetActive(false);
            invitedLabel.SetActive(true);
        }
        else
        {
            GameManager.Instance.SetWarningContent("invited more than 2 friends");
        }

    }
}
