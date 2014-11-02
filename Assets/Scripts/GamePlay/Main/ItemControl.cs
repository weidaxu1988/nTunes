using UnityEngine;
using System.Collections;

public class ItemControl : MonoBehaviour
{
    public int itemOne = 10;
    public int itemTwo = 3;
    public int itemThree = 200;

    public CombatItem[] combatItems;

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
        if (CombatManager.Instance.NumNotesHit > itemOne &&  !combatItems[0].Unlocked)
            combatItems[0].UnlockItem();

        if (CombatManager.Instance.Streak > itemTwo && !combatItems[1].Unlocked)
            combatItems[1].UnlockItem();

        if (CombatManager.Instance.Streak > itemTwo && !combatItems[2].Unlocked)
            combatItems[2].UnlockItem();
    }
}
