using UnityEngine;
using System.Collections;

public class CombatJoyBtn : MonoBehaviour
{
    public int stringIndex = 0;

    public UISpriteAnimation anime;

    bool isHold;

    void Update()
    {
        if (isHold && CombatManager.Instance.ControlInput.IsButtonPressed(stringIndex) == false)
            CombatManager.Instance.ControlInput.OnStringChange(stringIndex, true);
        if (anime && !anime.isPlaying)
            anime.gameObject.SetActive(false);
    }

    void OnPress(bool isDown)
    {
        isHold = isDown;
        //Debug.Log("pressed: " + isDown);
        CombatManager.Instance.ControlInput.OnStringChange(stringIndex, isDown);
    }

    public void PlayAnime()
    {
        if (anime)
        {
            if (!anime.gameObject.activeSelf)
                anime.gameObject.SetActive(true);
            anime.ResetToBeginning();
        }
    }
}
