using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour
{
    public enum MenuState
    {
        Friend,
        Music,
    }

    public MenuState menuState = MenuState.Friend;
    public TweenPosition tweenPos;

    public FriendControl friendControl;
    public MusicControl musicControl;

    void OnEnable()
    {
        SetMenu(menuState);
    }

    public void SetMenu(MenuState s)
    {
        menuState = s;

        if (menuState == MenuState.Friend)
        {
            tweenPos.PlayReverse();
            friendControl.SetMenuActive(true);
            musicControl.SetMenuActive(false);

        }
        else
        {
            tweenPos.PlayForward();
            friendControl.SetMenuActive(false);
            musicControl.SetMenuActive(true);
        }
    }
}
