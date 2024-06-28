using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] private Transform TopLeft;
    [SerializeField] private Transform BottomRight;
    [SerializeField] private LayerMask WhatIsPlayer;

    public void DisableBeam()
    {
        //gameObject.SetActive(false);
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }

    public void TriggerBeam()
    {
        Collider2D[] hits = Physics2D.OverlapAreaAll(TopLeft.position, BottomRight.position, WhatIsPlayer);

        foreach (Collider2D collider in hits)
        {

                if (collider.TryGetComponent(out IDamageable playerDamageable))
                {
                    playerDamageable.Damage(new DamgeDetails(20f, transform));//TODO
                }
        }
    }
}
