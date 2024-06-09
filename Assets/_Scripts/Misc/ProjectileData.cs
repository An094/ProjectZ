using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum ProjectileType
{
    Normal,
    Entangle,
    Poison,
    Thorn
}

[CreateAssetMenu(fileName = "New Projectile", menuName = "Data/Projectile")]
public class ProjectileData : ScriptableObject
{
    public ProjectileType Type;
    public Sprite ProjectileSprite;
    public GameObject ThornPref;
}
