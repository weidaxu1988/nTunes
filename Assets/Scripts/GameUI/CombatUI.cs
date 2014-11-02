using UnityEngine;
using System.Collections;

public class CombatUI : MonoBehaviour
{
    public UILabel scoreLabel;
    public UILabel streakLabel;
    public UILabel maxStreakLabel;
    public UILabel totalHitLabel;
    public UILabel totalMissedLabel;

    public bool autoUpdate;

    void Start()
    {
        if (autoUpdate)
        CombatManager.Instance.valueChangeHandler += OnValueChange;
    }

    void OnDestroy()
    {
        if (autoUpdate && CombatManager.Instance)
            CombatManager.Instance.valueChangeHandler -= OnValueChange;
    }

    void OnValueChange()
    {
        if (CombatManager.Instance.Score.ToString() != scoreLabel.text)
            scoreLabel.text = CombatManager.Instance.Score.ToString();
        if (CombatManager.Instance.Streak.ToString() != streakLabel.text)
            streakLabel.text = CombatManager.Instance.Streak.ToString();
        if (CombatManager.Instance.MaxStreak.ToString() != maxStreakLabel.text)
            maxStreakLabel.text = CombatManager.Instance.MaxStreak.ToString();
        if (CombatManager.Instance.NumNotesHit.ToString() != totalHitLabel.text)
            totalHitLabel.text = CombatManager.Instance.NumNotesHit.ToString();
        if (CombatManager.Instance.NumNotesMissed.ToString() != totalMissedLabel.text)
            totalMissedLabel.text = CombatManager.Instance.NumNotesMissed.ToString();
    }

    public void SetValue()
    {
        if (GameManager.Instance.CurGame.Score.ToString() != scoreLabel.text)
            scoreLabel.text = GameManager.Instance.CurGame.Score.ToString();
        if (GameManager.Instance.CurGame.MaxStreak.ToString() != maxStreakLabel.text)
            maxStreakLabel.text = GameManager.Instance.CurGame.MaxStreak.ToString();
        if (GameManager.Instance.CurGame.NumNotesHit.ToString() != totalHitLabel.text)
            totalHitLabel.text = GameManager.Instance.CurGame.NumNotesHit.ToString();
        if (GameManager.Instance.CurGame.NumNotesMissed.ToString() != totalMissedLabel.text)
            totalMissedLabel.text = GameManager.Instance.CurGame.NumNotesMissed.ToString();
    }
}
