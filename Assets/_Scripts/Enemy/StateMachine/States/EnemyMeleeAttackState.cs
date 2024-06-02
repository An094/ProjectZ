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
            if (collider.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
            {
                //Use IDamageable 
                if (collider.TryGetComponent(out IDamageable playerDamageable))
                {
                    //player.Damage();
                    if(!playerDamageable.Damage(new DamgeDetails(EnemyData.AttackDamage, Enemy.transform)))
                    {
                        Enemy.KnockBack(new KnockBackDetails(-Enemy.FacingDirection, 1f));
                    }
                }

                if(collider.TryGetComponent(out IKnockBackable playerKnockbackable))
                {
                    playerKnockbackable.KnockBack(new KnockBackDetails(Enemy.FacingDirection, EnemyData.AttackDamage));
                }
            }
        }
    }
}
