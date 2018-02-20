using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

    public float attackSpeed = 1f; // move to character stats
    public float attackDelay = .6f; // maybe move to character stats
    public float attackCooldown = 0f;

    public event System.Action OnAttack;

    CharacterStats myStats;
    CharacterStats target;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (target)
        {
            Transform TargetPos = target.GetComponentInParent<Transform>();
            float distance = Vector3.Distance(TargetPos.position, transform.position);

            if (distance <= myStats.attackRange.GetValue())
            {
                Attack(target);
            }
            else
            {
                target = null;
            }

        }
    }


    /// <summary>
    /// This methods handles the attack and takes in the paramters the characters stats of the object being attacked
    /// </summary>
    public void Attack(CharacterStats targetStats)
    {
        if(attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            this.target = targetStats;
            if(OnAttack != null)
            {
                OnAttack();
            }

            attackCooldown = 1f / attackSpeed; // greater the attack speed the shorter cool down

        }
    }

    IEnumerator DoDamage (CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());
    }
}
