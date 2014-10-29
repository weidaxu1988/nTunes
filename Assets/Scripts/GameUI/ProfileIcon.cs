using UnityEngine;
using System.Collections;

public class ProfileIcon : MonoBehaviour
{
    
    public int profileIndex = 1;

    UISprite mSprite;

    public int ProfileIndex
    {
        set
        {
            profileIndex = value;
            if (profileIndex > GameFields.PROFILE_COUNT || profileIndex < 1)
                profileIndex = 1;
            setProfile();
        }
    }

    void Awake()
    {
        mSprite = GetComponent<UISprite>();
    }

    void Start()
    {
        setProfile();
    }

    void setProfile()
    {
        mSprite.spriteName = GameFields.PROFILE_HEAD + profileIndex;
    }
}
