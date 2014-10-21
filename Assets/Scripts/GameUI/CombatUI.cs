using UnityEngine;
using System.Collections;

public class CombatUI : MonoBehaviour
{
    public UILabel scoreLabel;
    public UILabel streakLabel;
    public UILabel maxStreakLabel;
    public UILabel totalHitLabel;
    public UILabel totalMissedLabel;

    void Start()
    {
        CombatManager.Instance.valueChangeHandler += OnValueChange;
    }

    void OnDestroy()
    {
        if (CombatManager.Instance)
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
}
