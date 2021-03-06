﻿using UnityEngine;
using System.Collections;

public class CharCreationControl : MonoBehaviour
{
    public UIInput mNameInput;
    public UICenterOnChild mObjectFinder;

    public void OnNextBtnClick()
    {
        if (CreatePlayer())
        {
            GameManager.Instance.LoadMenuScene();
            Debug.Log("Load menu scene!");
        }
    }

    public void OnBackBtnClick()
    {
        Debug.Log("Back to start scene!");
        //if (GameManager.Instance.CurPlayer)
        //    LoadingManager.Instance.LoadMenuScene();
        //else
        GameManager.Instance.LoadStartScene();
    }

    bool CreatePlayer()
    {
        bool result = false;

        string name = mNameInput.value;
        if (!string.IsNullOrEmpty(name))
        {
            GameManager.Instance.SetCurPlayer(0, name, mObjectFinder.centeredObject.GetComponent<ProfileIcon>().profileIndex);

            //Move to GameManager

            //Player p = new Player(0, name);            
            //set profile
            //p.ProfileIndex = mObjectFinder.centeredObject.GetComponent<ProfileIcon>().profileIndex;
            //GameManager.Instance.CurPlayer = p;
            result = true;
        }

        return result;
    }
}
