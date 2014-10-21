using UnityEngine;
using System.Collections;

public class SongNote : MonoBehaviour
{
    //static string SPRITE_NAME_TAP = "tap_note";
    //static string SPRITE_NAME_SWIPE_1 = "swipe_note1";
    //static string SPRITE_NAME_SWIPE_2 = "swipe_note2";

    SongPlayer mPlayer;
    Note mNote;
    bool isClosed;

    void Awake()
    {
        mPlayer = CombatManager.Instance.Player;
    }

    void Update()
    {
        UpdatePosition();
        CheckHit();
    }

    public void UpdatePosition()
    {
        float progress = (mNote.Time - mPlayer.GetCurrentBeat() - 0.5f) / 6f;

        Vector3 pos = transform.localPosition;
        pos.x = progress * CombatManager.Instance.speed - DisplaySize.NGUIWidth / 1.1f;
        transform.localPosition = pos;
    }

    public bool CanBeActive()
    {
        return (mNote.Time < mPlayer.GetCurrentBeat() + 6) && !isClosed;
    }

    public void SetNote(Note noteData)
    {
        mNote = noteData;
        //SetSprite(mNote.StringIndex);
    }

    public void CheckHit()
    {
        if (IsNoteHit())
        {
            CombatManager.Instance.Score += 10f * CombatManager.Instance.Multiplier;
            CombatManager.Instance.Streak++;
            CombatManager.Instance.NumNotesHit++;

            isClosed = true;
            gameObject.SetActive(false);

            //add effect
        }
        else if (WasNoteMissed())
        {
            CombatManager.Instance.Streak = 0;
            CombatManager.Instance.NumNotesMissed++;

            isClosed = true;
            //this.enabled = false;
            gameObject.SetActive(false);
        }
    }

    bool WasNoteMissed()
    {
        return transform.localPosition.x < -700;
        //Debug.Log(transform.localPosition.x + " is missed: " + !(transform.localPosition.x > -807 && transform.localPosition.x < 802));
        //return !(transform.localPosition.x > -807 && transform.localPosition.x < 802);
    }

    bool IsNoteHit()
    {
        //if (mNote.StringIndex == 1)
        //    Debug.Log("just pressed: " + CombatManager.Instance.ControlInput.WasButtonJustPressed(mNote.StringIndex));

        if (!CombatManager.Instance.ControlInput.WasButtonJustPressed(mNote.StringIndex))
        {
            return false;
        }

        //If a note was already hit on this string during this frame, dont hit this one aswell
        if (CombatManager.Instance.GetHitNoteOnStringIndexThisFrame(mNote.StringIndex))
        {
            return false;
        }

        //When the renderer is disabled, this note was already hit before
        //if (NoteObjects[index].renderer.enabled == false)
        //{
        //    return false;
        //}

        //Check if this note is in the hit zone
        if (IsInHitZone())
        {
            //Set this flag so no two notes are hit with the same button press
            CombatManager.Instance.GetHitNoteOnStringIndexThisFrame(mNote.StringIndex);
            return true;
        }

        //The note is not in the hit zone, therefore cannot be hit
        return false;
    }

    bool IsInHitZone()
    {
        return transform.localPosition.x > -630 && transform.localPosition.x < -500;
    }

    void SetSprite(int index)
    {
        UISprite sprite = GetComponent<UISprite>();
        switch (index)
        {
            case 0:
                sprite.spriteName = "ele-beat_cycle_1";
                break;
            case 1:
                sprite.spriteName = "ele-beat_cycle_2";
                break;
            case 2:
                sprite.spriteName = "ele-beat_cycle_3";
                break;
            case 3:
                sprite.spriteName = "ele-beat_cycle_4";
                break;
        }
    }
}
