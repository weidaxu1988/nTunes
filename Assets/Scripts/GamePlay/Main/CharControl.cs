using UnityEngine;
using System.Collections;

public class CharControl : MonoBehaviour
{
    Animator mAnimator;

    void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }

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
        int streak = (int)CombatManager.Instance.Streak;

        mAnimator.SetInteger("Score", streak);

        if (streak % 20 == 0 && streak > 0)
            mAnimator.SetTrigger("Jump");
    }
}
