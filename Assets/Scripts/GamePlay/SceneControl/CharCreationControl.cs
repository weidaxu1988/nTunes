using UnityEngine;
using System.Collections;

public class CharCreationControl : MonoBehaviour
{
    public void OnNextBtnClick()
    {
        Debug.Log("Load menu scene!");
        //if (GameManager.Instance.CurPlayer)
        //    LoadingManager.Instance.LoadMenuScene();
        //else
        LoadingManager.Instance.LoadMenuScene();
    }

    public void OnBackBtnClick()
    {
        Debug.Log("Back to start scene!");
        //if (GameManager.Instance.CurPlayer)
        //    LoadingManager.Instance.LoadMenuScene();
        //else
        LoadingManager.Instance.LoadStartScene();
    }
}
