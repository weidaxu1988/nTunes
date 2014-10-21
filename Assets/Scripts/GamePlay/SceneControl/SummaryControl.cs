using UnityEngine;
using System.Collections;

public class SummaryControl : MonoBehaviour
{
    public void OnReplayBtnClick()
    {
        Debug.Log("reload confirm scene");
        LoadingManager.Instance.LoadConfirmScene();
    }

    public void OnbackBtnClick()
    {
        Debug.Log("back to menu scene");
        LoadingManager.Instance.LoadMenuScene();
    }

}
