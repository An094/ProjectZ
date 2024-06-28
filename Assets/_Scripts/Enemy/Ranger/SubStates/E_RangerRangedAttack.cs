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

        GameManager.Instance.PlaySFX("Shot");
        RandomlyFireProjectile();
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        //GameManager.Instance.PlaySFX("Draw");
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

    private void RandomlyFireProjectile()
    {
        int rand = Random.Range(0, 12);
        float TravelDistance = EnemyData.TravelDistance;

        GameObject Projectile;

        if(rand < 2)
        {
            Projectile =  EnemyData.EntangleProjectile;
        }
        else if(rand < 4)
        {
            Projectile =  EnemyData.PoisonProjectile;
        }
        else if(rand < 6)
        {
            TravelDistance = EnemyData.TravelDistance * 0.3f;
            Projectile =  EnemyData.ThornProjectile;
        }
        else
        {
            Projectile =  EnemyData.ProjectilePref;
        }

        ///ProjectileObj = GameObject.Instantiate(Projectile, AttackPosition.position, AttackPosition.rotation);
        ProjectileObj = ObjectPoolManager.SpawnObject(Projectile, AttackPosition.position, AttackPosition.rotation);
        
        if (ProjectileObj.TryGetComponent<Projectile>(out Projectile projectile))
        {
            projectile.FireProjectile(EnemyData.ProjectileSpeed, TravelDistance, EnemyData.ProjectileDamage);
        }
    }
}
