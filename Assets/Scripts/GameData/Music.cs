using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	protected readonly int mMusicId;
	
	protected int mProfileIndex = 0;
	protected string mName = "unknow music";
	protected string mArtist = "unknow artist";

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

	public string Artist
	{
		set { mArtist = value; }
		get { return mArtist; }
	}
	
	public Music(int id, string name, int profile, string artist)
	{
		mMusicId = id;
		mName = name;
		mProfileIndex = profile;
		mArtist = artist;
	}
}
