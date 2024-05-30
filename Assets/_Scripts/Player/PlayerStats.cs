using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public event Action<bool> OnDamaged;

    public float currentHp;

    public PlayerStats(float currentHp)
    {
        this.currentHp = currentHp;
    }

    public void DecreaseHp(float amount)
    {
        currentHp -= amount;

        if(currentHp <= 0)
        {
            OnDamaged?.Invoke(true);//Dead
            OnDamaged = null;
        }
        else
        {
            OnDamaged?.Invoke(false);
        }
    }
}
