using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicControl : MonoBehaviour
{
    public GameObject clickArea;
    public GameObject musicParent;

    Dictionary<Music, MusicItem> musicDict = new Dictionary<Music, MusicItem>();

    void Start()
    {
        BuildMusicItems();
    }

    public void SetMenuActive(bool active)
    {
        clickArea.SetActive(!active);
        foreach (MusicItem item in musicDict.Values)
        {
            item.Fadding(!active);
        }
    }

    void BuildMusicItems()
    {
        foreach (Music m in GameManager.Instance.exampleMusicList)
        {
            Debug.Log(m.Name);
            MusicItem item = GameFactory.GetMusicItem(musicParent, m);
            //item.mAlpha.GetComponent<UISprite>().alpha = 0;
            if (clickArea.activeSelf)
                item.mAlpha.PlayForward();
            else
                item.mAlpha.PlayReverse();
            musicDict.Add(m, item);
        }
        musicParent.GetComponent<UIGrid>().Reposition();
    }
}
