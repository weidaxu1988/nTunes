using UnityEngine;
using System.Collections;

public class ConfirmControl : MonoBehaviour
{
    public void OnPlayBtnClick()
    {
        Debug.Log("Load Main Scene!");
        LoadingManager.Instance.LoadMainScene();
    }

    public void OnBackBtnClick()
    {
        Debug.Log("Back to Menu Scene!");
        LoadingManager.Instance.LoadMenuScene();
    }
}
