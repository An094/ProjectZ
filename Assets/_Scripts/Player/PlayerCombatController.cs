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
        return false;
    }

    public void KnockBack(KnockBackDetails details)
    {
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
}
