using UnityEngine;
using System.Collections;

public class MusicItem : MonoBehaviour
{
	public UISprite mIconSprite;
	public UILabel mNameLabel;
	public UILabel mArtistLabel;
	
	public TweenAlpha mAlpha;
	
	Music mMusic;
	
	public void SetMusic(Music m)
	{
		mMusic = m;
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
		SetProfile(mMusic.ProfileIndex);
		SetName(mMusic.Name);
		SetScore(mMusic.Artist);
	}
	
	void SetProfile(int i)
	{
		mIconSprite.spriteName = GameFields.ALBUM_HEAD + i;
	}
	
	void SetName(string n)
	{
		mNameLabel.text = n;
	}
	
	void SetScore(string s)
	{
		mArtistLabel.text = s;
	}

    public void OnPlayBtnClick()
    {
        GameManager.Instance.CurGame.music = mMusic;
        GameManager.Instance.LoadConfirmScene();
    }

}
