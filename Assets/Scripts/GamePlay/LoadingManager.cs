using UnityEngine;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    //static private LoadingManager _singleton;
    //static public LoadingManager Instance
    //{
    //    get
    //    {
    //        if (_singleton == null)
    //        {
    //            _singleton = (LoadingManager)FindObjectOfType(typeof(LoadingManager));
    //        }
    //        return _singleton;
    //    }
    //}

    private AsyncOperation mAsync;
    //private float mProgess = 0;

    public float Progess
    {
        get
        {
            if (mAsync != null)
                return mAsync.progress;
            else
                return 0;
        }
    }

    public void LoadStartScene()
    {
        StartCoroutine(LoadScene(GameFields.START_SCENE_STR));
    }

    public void LoadCharCreationScene()
    {
        StartCoroutine(LoadScene(GameFields.CHAR_CREATION_SCENE_STR));
    }

    public void LoadMenuScene()
    {
        StartCoroutine(LoadScene(GameFields.MENU_SCENE_STR));
    }

    public void LoadConfirmScene()
    {
        StartCoroutine(LoadScene(GameFields.CONFIRM_SCENE_STR));
    }

    public void LoadMainScene()
    {
        StartCoroutine(LoadScene(GameFields.MAIN_SCENE_STR));
    }

    public void LoadSummaryScene()
    {
        StartCoroutine(LoadScene(GameFields.SUMMARY_SCENE_STR));
    }

    private IEnumerator LoadScene(string sceneStr)
    {
        mAsync = Application.LoadLevelAsync(sceneStr);
        DontDestroyOnLoad(gameObject);

        yield return mAsync;
        Debug.Log("Load Complete: " + sceneStr);
    }
}
