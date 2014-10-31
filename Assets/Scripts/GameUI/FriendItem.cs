using UnityEngine;
using System.Collections;

public class FriendItem : MonoBehaviour
{
    public UISprite mIconSprite;
    public UILabel mNameLabel;
    public UILabel mScoreLabel;

	public TweenAlpha mAlpha;

    Friend mFriend;

    public void SetFriend(Friend f)
    {
        mFriend = f;
        UpdateContent();

    }

	public void Fadding(bool fade)
	{
		if (fade)
						mAlpha.PlayForward ();
		else
			mAlpha.PlayReverse ();
		}

    public void UpdateContent()
    {
        SetProfile(mFriend.ProfileIndex);
        SetName(mFriend.Name);
        SetScore(mFriend.Score);
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
        mScoreLabel.text = "" + s;
    }

	public void OnInviteBtnClick()
	{
		Debug.Log ("invite friend");
	}
}
