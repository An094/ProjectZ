using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackDetails
{
    //public Transform AttackPostion;
    public int Direction;
    public float Strength;

    public KnockBackDetails(int direction, float strength)
    {
        //AttackPostion = attackPostion;
        Direction = direction;
        Strength = strength;
    }
}

public interface IKnockBackable
{
    void KnockBack(KnockBackDetails details);
}
