using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBeam : MonoBehaviour
{
    [SerializeField] private LayerMask WhatIsPlayer;
    private BoxCollider2D collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;
    }
    public void DisableBeam()
    {
        gameObject.SetActive(false);
    }

    public void TriggerBeam()
    {
        //collider.bounds
        //Collider2D[] hits = Physics2D.OverlapAreaAll(TopLeft.position, BottomRight.position, WhatIsPlayer);

        //foreach (Collider2D collider in hits)
        //{

        //    if (collider.TryGetComponent(out IDamageable playerDamageable))
        //    {
        //        playerDamageable.Damage(new DamgeDetails(20f, transform));//TODO
        //    }

        //    //if (collider.TryGetComponent(out IKnockBackable playerKnockbackable))
        //    //{
        //    //    playerKnockbackable.KnockBack(new KnockBackDetails(Enemy.FacingDirection, EnemyData.AttackDamage));//TODO
        //    //}
        //}
        collider.enabled = true;
    }

    public void EnableCollider()
    {
        collider.enabled = true;
    }

    public void DisableCollider()
    {
        collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            if (collision.TryGetComponent(out IDamageable playerDamageable))
            {
                playerDamageable.Damage(new DamgeDetails(20f, transform));//TODO
            }
        }

    }
}
