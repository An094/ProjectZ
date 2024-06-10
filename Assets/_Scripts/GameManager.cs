using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Player player;
    private PlayerStats PlayerStats;

    private E_Ranger Ranger;

    [SerializeField] ProgressBar PlayerHpBar;
    [SerializeField] ProgressBar RangerHpBar;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        PlayerStats = player.PlayerStats;

        Ranger = FindObjectOfType<E_Ranger>().GetComponent<E_Ranger>();
    }

    private void OnEnable()
    {
        PlayerStats.OnDamaged += OnPlayerDamaged;
        Ranger.OnDamaged += OnRangerDamaged;
    }

    private void OnDisable()
    {
        PlayerStats.OnDamaged -= OnPlayerDamaged;
        Ranger.OnDamaged -= OnRangerDamaged;
    }

    private void Start()
    {
        PlayerHpBar.Init(PlayerStats.CurrentHp);
        RangerHpBar.Init(Ranger.CurrentHp);
    }

    private void OnPlayerDamaged(float CurrentHp)
    {
        PlayerHpBar.SetCurrentValue(CurrentHp);
    }

    private void OnRangerDamaged(float CurrentHp)
    {
        RangerHpBar.SetCurrentValue(CurrentHp);
    }
}
