using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats
{
    public event Action<float> OnDamaged;
    public event Action OnDead;

    public float MaxHp;
    public float CurrentHp;

    public PlayerStats(float maxHp, float currentHp)
    {
        this.MaxHp = maxHp;
        this.CurrentHp = currentHp;
    }

    public void DecreaseHp(float amount)
    {
        CurrentHp -= amount;

        OnDamaged?.Invoke(CurrentHp);

        if(CurrentHp <= 0)
        {
            OnDead?.Invoke();
            OnDead = null;
            OnDamaged = null;
        }
    }
}
