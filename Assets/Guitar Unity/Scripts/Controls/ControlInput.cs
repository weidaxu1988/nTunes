using UnityEngine;
using System.Collections;

public class ControlInput : MonoBehaviour
{
    //This constant is only used in this class and cannot be adjusted to work with more or less strings
    //This feature is planned for the future
    public const int NumStrings = 4;

    //Stores if the button is held down
    protected bool[] ButtonsPressed;

    //Stores if the button was just pressed in this frame
    protected bool[] ButtonsJustPressed;

    //The five button objects in the scene
    //protected GameObject[] StringButtons;

    void Start()
    {
        ButtonsPressed = new bool[NumStrings];
        ButtonsJustPressed = new bool[NumStrings];

        for (int i = 0; i < NumStrings; ++i)
        {
            ButtonsPressed[i] = false;
            ButtonsJustPressed[i] = false;
        }

        //SaveReferencesToStringButtons();
    }

    void LateUpdate()
    {
        ResetButtonsJustPressedArray();
    }

    //void SaveReferencesToStringButtons()
    //{
    //    StringButtons = new GameObject[NumStrings];

    //    for (int i = 0; i < NumStrings; ++i)
    //    {
    //        StringButtons[i] = GameObject.Find("StringButton" + (i + 1));
    //    }
    //}

    protected void ResetButtonsJustPressedArray()
    {
        for (int i = 0; i < NumStrings; ++i)
        {
            ButtonsJustPressed[i] = false;
        }
    }

    protected int GetNumButtonsPressed()
    {
        int pressed = 0;

        for (int i = 0; i < NumStrings; ++i)
        {
            if (ButtonsPressed[i])
            {
                pressed++;
            }
        }

        return pressed;
    }

    public bool IsButtonPressed(int index)
    {
        return ButtonsPressed[index];
    }

    public bool WasButtonJustPressed(int index)
    {
        return ButtonsJustPressed[index];
    }

    public void OnStringChange(int stringIndex, bool pressed)
    {
        if (pressed == IsButtonPressed(stringIndex))
        {
            return;
        }

        //Vector3 stringButtonPosition = StringButtons[stringIndex].transform.Find("Paddle").transform.position;

        if (pressed)
        {
            //Only press this if less then two buttons are already pressed
            //The keyboard limits multiple key presses arbitrarily, sometimes its 2, sometimes 3
            //So I locked it to a maximum of two key presses at the same time for consistency
            if (GetNumButtonsPressed() < 2)
            {
                //Move the paddle upwards
                //stringButtonPosition.y = 0.16f;

                //Enable the light
                //StringButtons[stringIndex].transform.Find("Light").light.enabled = true;

                //Update key state
                ButtonsPressed[stringIndex] = true;
                ButtonsJustPressed[stringIndex] = true;
            }
        }
        else
        {
            //Move paddle down
            //stringButtonPosition.y = -0.06f;

            //Disable light
            //StringButtons[stringIndex].transform.Find("Light").light.enabled = false;

            //Update key state
            ButtonsPressed[stringIndex] = false;
        }

        //Set paddle position
        //StringButtons[stringIndex].transform.Find("Paddle").transform.position = stringButtonPosition;
    }

    public GameObject GetStringButton(int index)
    {
        //return StringButtons[index];
        return null;
    }
}
