using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 PlayerPosition;
    public float CurrentHp;

    public GameData()
    {
        PlayerPosition = new Vector3(62.87f, -5.36f, 0f);
        CurrentHp = 150f;
    }
}
