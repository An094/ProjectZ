using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackState : EnemyAttackState
{
    public EnemyMeleeAttackState(EnemyStateMachine stateMachine, Enemy enemy, string animName, EnemyData enemyData, Transform attackPostion) : base(stateMachine, enemy, animName, enemyData, attackPostion)
    {
    }
    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(AttackPosition.position, EnemyData.AttackRadius, EnemyData.WhatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            if (collider.CompareTag("Player"))
            {
                //Use IDamageable 
                if (collider.TryGetComponent(out Player player))
                {
                    //player.Damage();
                }
            }
        }
    }
}
