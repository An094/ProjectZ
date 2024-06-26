using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingShield : MonoBehaviour
{
    [SerializeField] private LayerMask WhatIsPlayer;
    [SerializeField] private float BaseRadius = 1f;
    [SerializeField] private float Dmg = 10f;

    private bool HittedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        HittedPlayer = false;
        transform.DOScale(1.5f, 1f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        }).startValue.Set(0f, 0f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!HittedPlayer)
        {
            HittedPlayer = true;

            Collider2D damageHit = Physics2D.OverlapCircle(transform.position, BaseRadius * transform.localScale.x, WhatIsPlayer);

            if (damageHit.TryGetComponent<IKnockBackable>(out IKnockBackable playerConbatController))
            {
                playerConbatController.KnockBack();
            }
        }
        
    }
}
