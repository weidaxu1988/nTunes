using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour
{
    static CombatManager _instance;
    public static CombatManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<CombatManager>();
            return _instance;
        }
    }

    public delegate void OnStatusChanged();
    public OnStatusChanged songStartHandler;
    public OnStatusChanged valueChangeHandler;

    //setting
    public int speed = 2000;
    public int stringCount = 3;

    public SongData combatSong;

    SongPlayer mPlayer;
    public SongPlayer Player { get { return mPlayer; } }

    ControlInput mControlInput;
    public ControlInput ControlInput { get { return mControlInput; } }

    bool[] mHitNoteOnStringIndexThisFrame;

    //Game state variables
    float mScore = 0f;
    public float Score
    {
        get { return mScore; }
        set
        {
            mScore = value;
            HandleValueChanged();
        }
    }
    float mMultiplier = 1f;
    public float Multiplier
    {
        get { return mMultiplier; }
    }
    float mStreak = 0;
    public float Streak
    {
        get { return mStreak; }
        set
        {
            mStreak = value;
            if (mStreak > mMaxStreak)
                mMaxStreak = mStreak;
            UpdateMultipier();
            HandleValueChanged();
        }
    }
    float mMaxStreak = 0;
    public float MaxStreak
    {
        get { return mMaxStreak; }
    }
    float mNumNotesHit = 0;
    public float NumNotesHit
    {
        get { return mNumNotesHit; }
        set
        {
            mNumNotesHit = value;
            HandleValueChanged();
        }
    }
    float mNumNotesMissed = 0;
    public float NumNotesMissed
    {
        get { return mNumNotesMissed; }
        set
        {
            mNumNotesMissed = value;
            HandleValueChanged();
        }
    }

    void Awake()
    {
        mPlayer = GetComponent<SongPlayer>();
        mControlInput = GetComponent<ControlInput>();
    }

    void Start()
    {
        mHitNoteOnStringIndexThisFrame = new bool[stringCount];
        mPlayer.HandleSongFinished += OnSongFinished;
        StartPlay();
    }

    void Update()
    {
        if (Player.IsPlaying())
        {
            ResetHasHitNoteOnStringIndexArray();
            HandleInput();
        }
    }

    void OnDestroy()
    {
        mPlayer.HandleSongFinished -= OnSongFinished;
    }

    public void StartPlay()
    {
        ResetValues();

        if (songStartHandler != null)
            songStartHandler();

        mPlayer.SetSong(combatSong);
        mPlayer.Play();
    }

    public bool GetHitNoteOnStringIndexThisFrame(int index)
    {
        if (mHitNoteOnStringIndexThisFrame != null && mHitNoteOnStringIndexThisFrame.Length > index)
            return mHitNoteOnStringIndexThisFrame[index];
        return false;
    }

    public void SetHitNoteOnStringIndexThisFrame(int index)
    {
        if (mHitNoteOnStringIndexThisFrame != null && mHitNoteOnStringIndexThisFrame.Length > index)
            mHitNoteOnStringIndexThisFrame[index] = true;
    }

    void OnSongFinished()
    {
        Debug.Log("finished");
        Debug.Log("Load summary Scene");
        LoadingManager.Instance.LoadSummaryScene();
    }

    void ResetHasHitNoteOnStringIndexArray()
    {
        for (int i = 0; i < stringCount; ++i)
        {
            mHitNoteOnStringIndexThisFrame[i] = false;
        }
    }

    void ResetValues()
    {
        Score = 0;
        mMultiplier = 1;
        Streak = 0;
        mMaxStreak = 0;
        mNumNotesMissed = 0;
        mNumNotesHit = 0;
    }

    void UpdateMultipier()
    {
        if (mStreak == 0)
            mMultiplier = 1;
        else
        {
            mMultiplier = Mathf.Ceil(Streak / 10);
            mMultiplier = Mathf.Clamp(Multiplier, 1, 10);
        }
    }

    void HandleInput()
    {
        CheckKeyCode(KeyCode.Alpha1, 0);
        CheckKeyCode(KeyCode.Alpha2, 1);
        CheckKeyCode(KeyCode.Alpha3, 2);
        CheckKeyCode(KeyCode.Alpha4, 3);
    }

    void CheckKeyCode(KeyCode code, int stringIndex)
    {
        if (Input.GetKeyDown(code))
        {
            mControlInput.OnStringChange(stringIndex, true);
        }
        if (Input.GetKeyUp(code))
        {
            mControlInput.OnStringChange(stringIndex, false);
        }
        if (Input.GetKey(code) && ControlInput.IsButtonPressed(stringIndex) == false)
        {
            mControlInput.OnStringChange(stringIndex, true);
        }
    }

    void HandleValueChanged()
    {
        if (valueChangeHandler != null)
            valueChangeHandler();
    }
}
