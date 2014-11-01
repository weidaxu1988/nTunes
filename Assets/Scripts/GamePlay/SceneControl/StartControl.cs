using UnityEngine;
using System.Collections;

public class StartControl : MonoBehaviour
{
    public void OnStartBtnClick()
    {
        Debug.Log("Load char creation scene!");
        //if (GameManager.Instance.CurPlayer)
        //    LoadingManager.Instance.LoadMenuScene();
        //else
        GameManager.Instance.LoadCharCreationScene();
    }
}
