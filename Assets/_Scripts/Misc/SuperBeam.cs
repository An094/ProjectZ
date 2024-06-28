using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBeam : MonoBehaviour
{
    [SerializeField] private LayerMask WhatIsPlayer;
    private BoxCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        collider.enabled = false;
    }

    public void DisableBeam()
    {
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }

    public void TriggerBeam()
    {
        collider.enabled = true;
    }

    public void EnableCollider()
    {
        collider.enabled = true;
        GameManager.Instance.PlaySFX("Shot2");
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
