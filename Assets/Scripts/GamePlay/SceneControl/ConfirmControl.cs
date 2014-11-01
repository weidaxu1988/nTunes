using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConfirmControl : MonoBehaviour
{
    public MusicItem musicItem;
    public GameObject friendParent;

    Dictionary<Friend, FriendItem> friendDict = new Dictionary<Friend, FriendItem>();

    void OnEnable()
    {
        musicItem.SetMusic(GameManager.Instance.CurGame.music);

        buildFriendList();
    }
    
    public void OnPlayBtnClick()
    {
        Debug.Log("Load Main Scene!");
        GameManager.Instance.LoadMainScene();
    }

    public void OnBackBtnClick()
    {
        Debug.Log("Back to Menu Scene!");
        GameManager.Instance.LoadMenuScene();
    }

    void buildFriendList()
    {
        foreach (Friend f in GameManager.Instance.CurGame.invitedList)
        {
            FriendItem item = GameFactory.GetFriendStatusItem(friendParent, f);
            friendDict.Add(f, item);
        }
    }
}
