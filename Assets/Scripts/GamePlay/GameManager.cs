using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    LoadingManager mLoadingManager;

    Player mPlayer;
    public Player CurPlayer { get { return mPlayer; } }

    GameRound mGame;
    public GameRound CurGame { get { return mGame; } }

    public List<Music> exampleMusicList = new List<Music>();

    void Awake()
    {
        Screen.SetResolution(1280, 800, false);

        mLoadingManager = GetComponent<LoadingManager>();

        Debug.Log("Get player data from file!");
        //DataManager.LoadBuildinDataCenter();
        //DataManager.LoadDataCenters();
        
        //offline test
        exampleMusicList.Add(new Music(0, "What Does The Fox Say", 1, "Vegard Ylvisåker&Bård Ylvisåker"));
        exampleMusicList.Add(new Music(1, "Red Light", 2, "f(x)"));
        exampleMusicList.Add(new Music(2, "We Are Never Ever Getting Back Together", 3, "Taylor Swift"));

        //test only
        //SetCurPlayer(02, "haha", 4);
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

    public void LoadStartScene()
    {
        mLoadingManager.LoadStartScene();
    }

    public void LoadCharCreationScene()
    {
        mLoadingManager.LoadCharCreationScene();
    }

    public void LoadMenuScene()
    {
        mLoadingManager.LoadMenuScene();
        mGame = new GameRound();
    }

    public void LoadConfirmScene()
    {
        mLoadingManager.LoadConfirmScene();
    }

    public void LoadMainScene()
    {
        mLoadingManager.LoadMainScene();
    }

    public void LoadSummaryScene()
    {
        mLoadingManager.LoadSummaryScene();
    }

    public void SetCurPlayer(int id, string name, int profileIndex)
    {
        Player p = new Player(0, name);            
        //set profile
        p.ProfileIndex = profileIndex;
        mPlayer = p;
    }
}
