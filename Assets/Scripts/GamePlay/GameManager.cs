using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    static private GameManager _singleton;
    static public GameManager Instance
    {
        get
        {
            if (_singleton == null)
            {
                _singleton = (GameManager)FindObjectOfType(typeof(GameManager));
            }
            return _singleton;
        }
    }

    Player mPlayer;
    public Player CurPlayer
    {
        get { return mPlayer; }
    }

    void Awake()
    {
        Screen.SetResolution(1280, 800, false);
        Debug.Log("Get player data from file!");
        //DataManager.LoadBuildinDataCenter();
        //DataManager.LoadDataCenters();
    }

    public void SetErrorContent(string str)
    {
        GameStatus.ErrorTxtList.Add(str);
        GameStatus.SetGameState(GameEnum.State.Error);
    }

    public void SetWarningContent(string str)
    {
        GameStatus.WarningTxtList.Add(str);
        GameStatus.SetGameState(GameEnum.State.Warning);
    }
}
