using UnityEngine;
using System.Collections;

public class GameFactory {
    public static SongNote GetSongNote(GameObject root, Note noteData)
    {
        SongNote note = NGUITools.AddChild(root, (GameObject)Resources.Load("Prefabs/" + "GameUI/" + "Element-SongNote")).GetComponent<SongNote>();
        note.SetNote(noteData);
        return note;
    }

    public static FriendItem GetFriendStatusItem(GameObject container, Friend f)
    {
        FriendItem item = NGUITools.AddChild(container, (GameObject)Resources.Load("Prefabs/" + "GameUI/" + "Item-Friend_status")).GetComponent<FriendItem>();
        item.SetFriend(f);
        return item;
    }

    public static FriendItem GetFriendItem(GameObject container, Friend f)
    {
        FriendItem item = NGUITools.AddChild(container, (GameObject)Resources.Load("Prefabs/" + "GameUI/" + "Item-Friend")).GetComponent<FriendItem>();
        item.SetFriend(f);
        return item;
    }

    public static FriendItem GetFriendSummaryItem(GameObject container, Friend f)
    {
        FriendItem item = NGUITools.AddChild(container, (GameObject)Resources.Load("Prefabs/" + "GameUI/" + "Item-Friend_summary")).GetComponent<FriendItem>();
        item.SetFriend(f);
        return item;
    }

    public static MusicItem GetMusicItem(GameObject container, Music f)
    {
        MusicItem item = NGUITools.AddChild(container, (GameObject)Resources.Load("Prefabs/" + "GameUI/" + "Item-Music")).GetComponent<MusicItem>();
        item.SetMusic(f);
        return item;
    }
}
