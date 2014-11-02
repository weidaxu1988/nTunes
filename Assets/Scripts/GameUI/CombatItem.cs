using UnityEngine;
using System.Collections;

public class CombatItem : MonoBehaviour
{
    public UISprite lockSprite;

    UIButton mButton;
    public bool Unlocked { get { return mButton.isEnabled; } }

    void Awake()
    {
        mButton = GetComponent<UIButton>();
        mButton.isEnabled = false;
    }

    public void UnlockItem()
    {
        lockSprite.gameObject.SetActive(false);
        rigidbody2D.isKinematic = false;
        mButton.isEnabled = true;
    }
}
