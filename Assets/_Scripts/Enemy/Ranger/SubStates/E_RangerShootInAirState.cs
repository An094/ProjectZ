using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class E_RangerShootInAirState : E_PlayerNearState
{
    private Vector2 ShootingPosition;
    private Transform PorjectTilePosition;
    protected GameObject ProjectileObj;
    protected Projectile Projectile;

    public E_RangerShootInAirState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData, Transform shootingPosition) : base(stateMachine, enemy, animName, enemyData)
    {
        PorjectTilePosition = shootingPosition;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        float Angle = Vector2.Angle((Ranger.Player.transform.position - PorjectTilePosition.transform.position).normalized, Vector2.right * Ranger.FacingDirection);

        float FinalAngle = Ranger.FacingDirection > 0 ? -1 * Angle : Angle - 180;

        GameObject Projectile = RandomlyPickProjectile();
        
        ProjectileObj = GameObject.Instantiate(Projectile, PorjectTilePosition.position, 
            Quaternion.Euler(0f, 0f, FinalAngle));
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

        ShootingPosition = Ranger.transform.position;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override bool IsOnCooldown()
    {
        return Time.time < LastTimeFinish + EnemyData.DodgeAndShootCooldown;
        //return Time.time < LastTimeFinish + 10.0f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        
        if(isAnimationFinished)
        {
            Ranger.SetVelocityX(- Ranger.FacingDirection * 3.0f);
            StateMachine.ChangeState(Ranger.inAirState);
        }
        else
        {
            Ranger.SetVelocityX(0);
            Ranger.SetVelocityY(0);
            Ranger.transform.position = ShootingPosition;
        }

    }

    private GameObject RandomlyPickProjectile()
    {
        int rand = Random.Range(0, 10);

        if (rand < 2)
        {
            return EnemyData.EntangleProjectile;
        }
        else if (rand < 4)
        {
            return EnemyData.PoisonProjectile;
        }
        else
        {
            return EnemyData.ProjectilePref;
        }
    }
}
