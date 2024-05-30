using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour, IDamageable, IKnockBackable
{
    private Player player;
    public void Damage(DamgeDetails damageDetail)
    {
        player.playerStat.DecreaseHp(damageDetail.Dmg);
    }

    public void KnockBack(KnockBackDetails details)
    {
    }

    private void Start()
    {
        player = GetComponent<Player>();

    }
}
