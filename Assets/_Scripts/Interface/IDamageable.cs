using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeDetails
{
    public float Dmg;
    public Transform ObjectAttackPosition;

    public DamgeDetails(float dmg, Transform objectAttackPosition)
    {
        Dmg = dmg;
        ObjectAttackPosition = objectAttackPosition;
    }
}

public interface IDamageable
{
    bool Damage(DamgeDetails attackDetail);
}
