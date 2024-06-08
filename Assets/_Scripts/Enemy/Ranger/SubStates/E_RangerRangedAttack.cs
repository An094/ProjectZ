using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerRangedAttack : E_PlayerFarState
{
    protected GameObject ProjectileObj;
    protected Projectile Projectile;
    private Transform AttackPosition;
    public E_RangerRangedAttack(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData, Transform attackPosition) : base(stateMachine, enemy, animName, enemyData)
    {
        AttackPosition = attackPosition;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        ProjectileObj = GameObject.Instantiate(EnemyData.ProjectilePref, AttackPosition.position, AttackPosition.rotation);
        if (ProjectileObj.TryGetComponent<Projectile>(out Projectile projectile))
        {
            projectile.FireProjectile(EnemyData.ProjectileSpeed, EnemyData.TravelDistance, EnemyData.ProjectileDamage);
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
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
