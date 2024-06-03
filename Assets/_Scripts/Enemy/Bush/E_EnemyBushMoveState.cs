using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_EnemyBushMoveState : EnemyState
{
    E_EnemyBush EnemyBush;
    Transform AttackPosition;
    bool HasAttacked;
    public E_EnemyBushMoveState(EnemyStateMachine stateMachine, E_EnemyBush enemy, string animName, EnemyData enemyData, Transform attackPostion) : base(stateMachine, enemy, animName, enemyData)
    {
        EnemyBush = enemy;
        AttackPosition = attackPostion;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        HasAttacked = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Enemy.SetVelocityX(EnemyData.moveSpeed * Enemy.FacingDirection);

        if( Enemy.FacingDirection == -1 && Enemy.transform.position.x <= EnemyBush.PatrolFinishPosiion.position.x
            || Enemy.FacingDirection == 1 && Enemy.transform.position.x >= EnemyBush.PatrolFinishPosiion.position.x)
        {
            StateMachine.ChangeState(EnemyBush.DigState);
        }
        else
        {

            Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(AttackPosition.position, EnemyData.AttackRadius, EnemyData.WhatIsPlayer);

            foreach (Collider2D collider in detectedObjects)
            {
                if (collider.gameObject.layer.Equals(LayerMask.NameToLayer("Player")) && !HasAttacked)
                {
                    HasAttacked = true;
                    //Use IDamageable 
                    if (collider.TryGetComponent(out IDamageable playerDamageable))
                    {
                        //player.Damage();
                        if (!playerDamageable.Damage(new DamgeDetails(EnemyData.AttackDamage, Enemy.transform)))
                        {
                            Enemy.KnockBack(new KnockBackDetails(-Enemy.FacingDirection, 1f));
                        }
                    }

                    if (collider.TryGetComponent(out IKnockBackable playerKnockbackable))
                    {
                        playerKnockbackable.KnockBack(new KnockBackDetails(Enemy.FacingDirection, EnemyData.AttackDamage));
                    }
                }
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
