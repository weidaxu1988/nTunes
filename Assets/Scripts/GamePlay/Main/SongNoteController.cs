using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SongNoteController : MonoBehaviour
{
	public int[] yPositions;

    List<SongNote> noteList = new List<SongNote>();

    void Awake()
    {
        CombatManager.Instance.songStartHandler += CreateNotes;
    }

    void Update()
    {
        if (CombatManager.Instance.Player.IsPlaying())
        {
            ActiveNotes();
        }
    }

    void OnDestroy()
    {
        if (CombatManager.Instance)
            CombatManager.Instance.songStartHandler -= CreateNotes;
    }

    void ActiveNotes()
    {
        foreach (SongNote note in noteList)
        {
            if (note.CanBeActive())
            {
                if (!note.gameObject.activeSelf)
                    note.gameObject.SetActive(true);
            }
        }
    }

    void CreateNotes()
    {
        noteList.Clear();

        foreach (Note n in CombatManager.Instance.combatSong.Notes)
        {
            if (n.StringIndex > 3) continue;

            SongNote note = GameFactory.GetSongNote(gameObject, n);
			//note.transform.localPosition = new Vector3(-n.StringIndex * 150, DisplaySize.NGUIHeight, 0);

			note.transform.localPosition = new Vector3(yPositions[n.StringIndex], DisplaySize.NGUIHeight, 0);

            note.gameObject.SetActive(false);
            noteList.Add(note);
        }
    }
}
