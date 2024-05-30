using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public event Action<float> OnDamaged;

    public float CurrentHp;

    public PlayerStats(float currentHp)
    {
        this.CurrentHp = currentHp;
    }

    public void DecreaseHp(float amount)
    {
        CurrentHp -= amount;

        OnDamaged?.Invoke(CurrentHp);

        if(CurrentHp <= 0)
        {
            OnDamaged = null;
        }
    }
}
