using UnityEngine;
using System.Collections;

public class SummaryControl : MonoBehaviour
{
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

}
