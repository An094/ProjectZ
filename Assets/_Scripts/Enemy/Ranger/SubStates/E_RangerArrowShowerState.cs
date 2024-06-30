using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_RangerArrowShowerState : E_PlayerNearState
{
    Tween FireTween;
    float FireYPos;
    Transform ProjectTilePosition;
    protected GameObject ProjectileObj;
    //Sequence FireSequence;
    // bool IsGrounded;
    public E_RangerArrowShowerState(EnemyStateMachine stateMachine, E_Ranger enemy, string animName, EnemyData enemyData, Transform projectilePos) : base(stateMachine, enemy, animName, enemyData)
    {
        ProjectTilePosition  = projectilePos;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        //float Angle = Ranger.FacingDirection > 0 ? - 75f : -105f;
        ////float Angle = -90f;
        //GameObject ProjectileObj = GameObject.Instantiate(EnemyData.ProjectilePref, ProjectTilePosition.position,
        //    Quaternion.Euler(0f, 0f, Angle));
        //if (ProjectileObj.TryGetComponent<Projectile>(out Projectile projectile))
        //{
        //    projectile.FireProjectile(EnemyData.ProjectileSpeed, EnemyData.TravelDistance, EnemyData.ProjectileDamage);
        //}

        RandomlyFireProjectile();
    }

    public override void DoCheck()
    {
        base.DoCheck();
        //IsGrounded = Ranger.IsGrounded();
    }

    public override void Enter()
    {
        IsAllowCheckFlip = false;
        base.Enter();

        Ranger.SetVelocityX(7f * Ranger.FacingDirection);
        Ranger.SetVelocityY(15.0f);

        FireTween =  DOVirtual.DelayedCall(0.5f, () =>
        {
            FireYPos = Ranger.transform.position.y;
            Ranger.StartCoroutine(FireSequece());
        });
    }

    public override void Exit()
    {
        base.Exit();
        FireTween.Kill();
        //FireSequence.Kill();
    }

    public override bool IsOnCooldown()
    {
        return Time.time < LastTimeFinish + EnemyData.ArrowShowerCooldown;
    }

    public override void LogicUpdate()
    {
        //base.LogicUpdate();
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    private IEnumerator FireSequece()
    {
        Ranger.Flip();

        Ranger.Animator.SetBool("InAir", false);
        float defaultGS = Ranger.Rb.gravityScale;
        Ranger.Rb.gravityScale = 0;

        for (int i = 0; i < 7; i++)
        {
            Ranger.transform.position = new Vector2(Ranger.transform.position.x, FireYPos);
            Ranger.SetVelocityY(0f);
            Ranger.SetVelocityX(-5f * Ranger.FacingDirection);
            Ranger.Animator.SetBool("QuickShot", true);
            yield return new WaitForSeconds(0.2f);
            Ranger.Animator.SetBool("QuickShot", false);
        }

        Ranger.SetVelocityX(10f * Ranger.FacingDirection);
        Ranger.Rb.gravityScale = defaultGS;
        Ranger.Animator.SetBool("InAir", true);

        if (!IsGrounded)
        {
            StateMachine.ChangeState(Ranger.inAirState);
        }
        else
        {
            StateMachine.ChangeState(Ranger.landState);
        }
    }

    private void RandomlyFireProjectile()
    {
        int rand = Random.Range(0, 10);
        float TravelDistance = EnemyData.TravelDistance;

        GameObject Projectile;

        if (rand < 4)
        {
            Projectile = EnemyData.EntangleProjectile;
        }
        else if (rand < 8)
        {
            Projectile = EnemyData.PoisonProjectile;
        }
        else
        {
            TravelDistance = EnemyData.TravelDistance * 0.1f;
            Projectile = EnemyData.ThornProjectile;
        }

        float Angle = Ranger.FacingDirection > 0 ? -45f : -135f;

        ProjectileObj = ObjectPoolManager.SpawnObject(Projectile, ProjectTilePosition.position, Quaternion.Euler(0f, 0f, Angle));
        if (ProjectileObj.TryGetComponent<Projectile>(out Projectile projectile))
        {
            projectile.FireProjectile(EnemyData.ProjectileSpeed, TravelDistance, EnemyData.ProjectileDamage);
        }
    }
}
