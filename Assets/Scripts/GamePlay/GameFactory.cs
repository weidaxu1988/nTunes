using UnityEngine;
using System.Collections;

public class GameFactory {
    public static SongNote GetSongNote(GameObject root, Note noteData)
    {
        SongNote note = NGUITools.AddChild(root, (GameObject)Resources.Load("Prefabs/" + "GameUI/" + "Element-SongNote")).GetComponent<SongNote>();
        note.SetNote(noteData);
        return note;
    }
}
