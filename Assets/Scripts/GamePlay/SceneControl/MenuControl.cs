using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour
{
    public void OnFriendConfirmBtnClick()
    {
        Debug.Log("Load confirm scene");
        LoadingManager.Instance.LoadConfirmScene();
    }

    public void OnMusicConfirmBtnClick()
    {
        Debug.Log("Load confirm scene");
        LoadingManager.Instance.LoadConfirmScene();
    }

    public void OnBackBtnClick()
    {
        Debug.Log("Load Start scene");
        LoadingManager.Instance.LoadStartScene();
    }
}
