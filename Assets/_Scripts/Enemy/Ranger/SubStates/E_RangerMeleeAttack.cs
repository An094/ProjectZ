using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerMeleeAttack : E_PlayerNearState
{
    private Transform AttackPosition;
    public E_RangerMeleeAttack(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData, Transform meleeAttackPosition) : base(stateMachine, enemy, animName, enemyData)
    {
        CheckIfShouldFlip = false;
        AttackPosition = meleeAttackPosition;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        IsDone = true;
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
                    if (!playerDamageable.Damage(new DamgeDetails(EnemyData.AttackDamage, Enemy.transform)))
                    {
                        //Enemy.KnockBack(new KnockBackDetails(-Enemy.FacingDirection, 1f));
                    }
                }

                if (collider.TryGetComponent(out IKnockBackable playerKnockbackable))
                {
                    playerKnockbackable.KnockBack(new KnockBackDetails(Enemy.FacingDirection, EnemyData.AttackDamage));
                }
            }
        }
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!IsExiting)
        {
            Ranger.SetZeroVelocity();
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
