using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStatus
{
    public delegate void StatusChange();

    public static StatusChange StateChangeHandler;
    public static StatusChange StageChangeHandler;
    public static StatusChange GuideStageChangeHandler;

    //public static bool OnBuilding;
    public static List<string> WarningTxtList = new List<string>();
    public static List<string> ErrorTxtList = new List<string>();

    static GameEnum.State mState = GameEnum.State.Run;
    static GameEnum.Stage mStage = GameEnum.Stage.DataCenter;
    static GameEnum.Stage mLastStage = GameEnum.Stage.DataCenter;
    static GameEnum.GuideStage mGuideStage = GameEnum.GuideStage.SelectContainer;

    static List<GameEnum.Stage> mStageList = new List<GameEnum.Stage>();

    public static GameEnum.State GameState { get { return mState; } }

    public static GameEnum.Stage GameStage { get { return mStage; } }

    public static GameEnum.Stage LastStage { get { return mLastStage; } }

    public static GameEnum.GuideStage GuideStage { get { return mGuideStage; } }

    public static bool IsStageDetail
    {
        get
        {
            if (mStage == GameEnum.Stage.Server || mStage == GameEnum.Stage.Switch)
                return true;
            return false;
        }
    }

    public static void SetGameState(GameEnum.State s)
    {
        mState = s;
        if (StateChangeHandler != null)
            StateChangeHandler();
    }

    public static void SetGameStage(GameEnum.Stage s)
    {
        mLastStage = mStage;
        mStage = s;
        mStageList.Add(mStage);
        if (StageChangeHandler != null)
            StageChangeHandler();
    }

    public static void SetPerviousStage(int index)
    {
        mLastStage = mStage;

        if (mStageList.Count > index + 1)
        {
            mStage = mStageList[index];
            mStageList.RemoveRange(index + 1, mStageList.Count - index - 1);
        }
        else
            return;

        if (StageChangeHandler != null)
            StageChangeHandler();
    }

    public static void SetPerviousStage()
    {
        if (mStageList.Count > 1)
            SetPerviousStage(mStageList.Count - 2);
    }

    public static int GetPreviousStageIndex(GameEnum.Stage stage)
    {
        if (mStageList.Contains(stage))
            return mStageList.IndexOf(stage);
        return -1;
    }

    public static void SetGuideStage(GameEnum.GuideStage gs)
    {
        mGuideStage = gs;
        if (GuideStageChangeHandler != null)
            GuideStageChangeHandler();
    }
}
