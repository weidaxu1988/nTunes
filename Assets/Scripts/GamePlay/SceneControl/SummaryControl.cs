using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SummaryControl : MonoBehaviour
{
    public CombatUI combatUI;
    public GameObject friendParent;

    Dictionary<Friend, FriendItem> friendDict = new Dictionary<Friend, FriendItem>();

    void Start()
    {
        combatUI.SetValue();
        buildFriendList();
    }

    public void OnReplayBtnClick()
    {
        Debug.Log("reload confirm scene");
        GameManager.Instance.LoadConfirmScene();
    }

    public void OnbackBtnClick()
    {
        Debug.Log("back to menu scene");
        GameManager.Instance.LoadMenuScene();
    }

    void buildFriendList()
    {
        foreach (Friend f in GameManager.Instance.CurGame.invitedList)
        {
            FriendItem item = GameFactory.GetFriendSummaryItem(friendParent, f);
            friendDict.Add(f, item);
        }

    }

}
