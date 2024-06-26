using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour, IDamageable, IKnockBackable
{
    private Player player;

    [SerializeField] private Transform DefendPostion;
    public bool IsShieldActive = false;
    public bool Damage(DamgeDetails damageDetail)
    {
        if(!IsAttackBlocked(damageDetail.ObjectAttackPosition))
        {
            player.PlayerStats.DecreaseHp(damageDetail.Dmg);
            return true;
        }

        GameManager.Instance.PlaySFX("Block");
        return false;
    }

    public void KnockBack(KnockBackDetails details)
    {
        player.SetVelocity(details.Strength, new Vector2(1f, 1f), details.Direction);
    }

    private void Start()
    {
        player = GetComponent<Player>();

    }

    private bool IsAttackBlocked(Transform attackSourcePosition)
    {
        if (!IsShieldActive) return false;

        float PlayerToDefendPostionDistance = player.transform.position.x - DefendPostion.position.x;
        float AttackSourceToDefendPostionDistance = attackSourcePosition.position.x - DefendPostion.position.x;

        return PlayerToDefendPostionDistance * AttackSourceToDefendPostionDistance < 0;
    }

    public void KnockBack()
    {
        player.SetVelocity(20f, new Vector2(2f, 1f), - player.FacingDirection);
        player.IsAllowChangeVelocity = false;
        player.StateMachine.ChangeState(player.HurtState);
    }
}
