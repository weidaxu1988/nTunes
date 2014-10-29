using UnityEngine;
using System.Collections;

public class MusicItem : MonoBehaviour
{
    void OnClick()
    {
        Debug.Log("Load confirm scene");
        LoadingManager.Instance.LoadConfirmScene();
    }

}
