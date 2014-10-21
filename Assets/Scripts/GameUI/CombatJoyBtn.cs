using UnityEngine;
using System.Collections;

public class CombatJoyBtn : MonoBehaviour
{
    public int stringIndex = 0;

    bool isHold;

    void Update()
    {
        if (isHold && CombatManager.Instance.ControlInput.IsButtonPressed(stringIndex) == false)
            CombatManager.Instance.ControlInput.OnStringChange(stringIndex, true);
    }

    void OnPress(bool isDown)
    {
        isHold = isDown;
        //Debug.Log("pressed: " + isDown);
        CombatManager.Instance.ControlInput.OnStringChange(stringIndex, isDown);
    }



}
