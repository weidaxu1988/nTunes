using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendControl : MonoBehaviour {
	public GameObject clickArea;

	List<FriendItem> friendList = new List<FriendItem>();

	MenuControl.MenuState state = MenuControl.MenuState.Friend;

	void Start()
	{
		CreateFriendItems ();
	}

	void CreateFriendItems()
	{
		FriendItem[] friends = GetComponentsInChildren<FriendItem> ();
		friendList.AddRange (friends);
	}

	public void SetMenuActive(bool active)
	{
		clickArea.SetActive(!active);
		foreach (FriendItem item in friendList) {
			item.Fadding(!active);


				}
	}

}
