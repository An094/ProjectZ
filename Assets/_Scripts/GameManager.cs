using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;
    private PlayerStats PlayerStats;

    [SerializeField] ProgressBar HpBar;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        PlayerStats = player.PlayerStats;
    }

    private void OnEnable()
    {
        PlayerStats.OnDamaged += OnPlayerDamaged;
    }

    private void OnDisable()
    {
        PlayerStats.OnDamaged -= OnPlayerDamaged;
    }

    private void Start()
    {
        HpBar.Init(PlayerStats.CurrentHp);
    }

    private void OnPlayerDamaged(float CurrentHp)
    {
        HpBar.SetCurrentValue(CurrentHp);
    }
}
