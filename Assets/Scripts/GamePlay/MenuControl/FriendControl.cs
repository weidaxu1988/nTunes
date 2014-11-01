using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendControl : MonoBehaviour
{
    public GameObject clickArea;
    public GameObject friendParent;

    Dictionary<Friend, FriendItem> friendDict = new Dictionary<Friend, FriendItem>();

    void Start()
    {
        buildFriendList();
    }

    public void SetMenuActive(bool active)
    {
        clickArea.SetActive(!active);
        foreach (FriendItem item in friendDict.Values)
        {
            item.Fadding(!active);
        }
    }

    void buildFriendList()
    {
        foreach (Friend f in GameManager.Instance.CurPlayer.friendList)
        {
            FriendItem item = GameFactory.GetFriendItem(friendParent, f);
            friendDict.Add(f, item);
        }
        friendParent.GetComponent<UIGrid>().Reposition();
    }

}
