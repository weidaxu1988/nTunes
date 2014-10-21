using UnityEngine;
using System.Collections;

public class SongPlayer : MonoBehaviour
{
    public delegate void OnSongFinished();
    public OnSongFinished HandleSongFinished;
	public SongData Song;

	protected float SmoothAudioTime = 0f;
	protected bool AudioStopEventFired = false;
	protected bool WasPlaying = false;
	protected bool IsSongPlaying = false;

	void Update()
	{
		if( IsPlaying() )
		{
			AudioStopEventFired = false;
			WasPlaying = true;
			UpdateSmoothAudioTime();
		}
	}

	protected void OnSongStopped()
	{
		if( !audio.clip )
		{
			return;
		}


		
		//I want to check if the song has finished playing automatically.
		//Sometimes this is triggered when the song is at the end, 
		//and sometimes it has already been reset to the beginning of the song.
		if( audio.time == audio.clip.length
		 || ( WasPlaying && audio.time == 0 ) )
		{
			IsSongPlaying = false;
            if (GetComponent<GuitarGameplay>())
                GetComponent<GuitarGameplay>().OnSongFinished();
            if (HandleSongFinished != null)
                HandleSongFinished();
		}
	}

	protected void UpdateSmoothAudioTime()
	{
		//Smooth audio time is used because the audio.time has smaller discreet steps and therefore the notes wont move
		//as smoothly. This uses Time.deltaTime to progress the audio time
		SmoothAudioTime += Time.deltaTime;

		if( SmoothAudioTime >= audio.clip.length )
		{
			SmoothAudioTime = audio.clip.length;
			OnSongStopped();
		}

		//Sometimes the audio jumps or lags, this checks if the smooth audio time is off and corrects it
		//making the notes jump or lag along with the audio track
		if( IsSmoothAudioTimeOff() )
		{
			CorrectSmoothAudioTime();
		}
	}

	protected bool IsSmoothAudioTimeOff()
	{
		//Negative SmoothAudioTime means the songs playback is delayed
		if( SmoothAudioTime < 0 )
		{
			return false;
		}

		//Dont check this at the end of the song
		if( SmoothAudioTime > audio.clip.length - 3f )
		{
			return false;
		}

		//Check if my smooth time and the actual audio time are of by 0.1
		return Mathf.Abs( SmoothAudioTime - audio.time ) > 0.1f;
	}

	protected void CorrectSmoothAudioTime()
	{
		SmoothAudioTime = audio.time;
	}

	public void Play()
	{
		IsSongPlaying = true;

		if( SmoothAudioTime < 0 )
		{
			StartCoroutine( PlayDelayed( Mathf.Abs( SmoothAudioTime ) ) );
		}
		else
		{
			audio.Play();
			SmoothAudioTime = audio.time;
		}
	}

	protected IEnumerator PlayDelayed( float delay )
	{
		yield return new WaitForSeconds( delay );

		audio.Play();
	}

	public void Pause()
	{
		IsSongPlaying = false;
		audio.Pause();
	}

	public void Stop()
	{
		audio.Stop();
		WasPlaying = false;
		IsSongPlaying = false;
	}

	public bool IsPlaying()
	{
		return IsSongPlaying;
	}

	public void SetSong( SongData song )
	{
		Song = song;
		gameObject.audio.time = 0;
		gameObject.audio.clip = Song.BackgroundTrack;
		gameObject.audio.pitch = 1;

		SmoothAudioTime = MyMath.BeatsToSeconds( -Song.AudioStartBeatOffset, Song.BeatsPerMinute );
	}

	public float GetCurrentBeat( bool songDataEditor = false )
	{
		if( songDataEditor )
		{
			SmoothAudioTime = audio.time;
		}

		return MyMath.SecondsToBeats( SmoothAudioTime, Song.BeatsPerMinute ) - Song.AudioStartBeatOffset;
	}
}