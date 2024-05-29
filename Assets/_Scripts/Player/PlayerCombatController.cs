using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour, IDamageable
{
    private Player player;
    public void Damage(DamgeDetails attackDetail)
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        player = GetComponent<Player>();

    }
}
