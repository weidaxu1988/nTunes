using UnityEngine;
using System.Collections;

public class DisplaySize {

    static float width = 0;
    public static float NGUIWidth 
    {
        get
        {
            if (width == 0)
                CalculateSize();
            return width;
        }
    }
    static float height = 0;
    public static float NGUIHeight
    {
        get
        {
            if (height == 0)
                CalculateSize();
            return height;
        }
    }

    public static void CalculateSize()
    {
        UIRoot mRoot = GameObject.FindObjectOfType<UIRoot>();

        float ratio = (float)mRoot.activeHeight / Screen.height;

        width = Mathf.Ceil(Screen.width * ratio);
        height = Mathf.Ceil(Screen.height * ratio);
    }
}
