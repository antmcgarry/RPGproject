using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    PlayerManager playerManager;
    CharacterStats tagetStats;
    CharacterCombat playerCombat;

    public float combatRadius = 1.0f;
    public bool inCombat = false;

    private Transform targetPos;


    // Use this for initialization
    void Start () {
        playerManager = PlayerManager.instance;
        playerCombat = playerManager.player.GetComponent<CharacterCombat>(); 
    }
	
	// Update is called once per frame
	void Update () {

        if (targetPos == null) return;
        float distance = Vector3.Distance(targetPos.position, transform.position);

        if (distance <= combatRadius)
        {
            if (inCombat)
            {
                if (tagetStats.currentHealth > 0)
                {
                    playerCombat.Attack(tagetStats);
                }
                else
                {
                    cancelCombat();
                }
            }
        }
        else
        {
            cancelCombat();
        }

	}

    void cancelCombat()
    {
        inCombat = false;
        targetPos = null;
        tagetStats = null;
        targetPos = null;
    }

    public void GetTarget(CharacterStats target, Transform targetPosition)
    {
        tagetStats = target;
        targetPos = targetPosition;
        inCombat = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, combatRadius);
    }

}
