using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Player player;
    private PlayerStats PlayerStats;

    private E_Ranger Ranger;

    [SerializeField] ProgressBar PlayerHpBar;
    [SerializeField] ProgressBar RangerHpBar;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

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
        AudioManager.Instance.PlayMusic("Village");

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

    public void PlayerAttackSFX(bool bIsAccurate, int AttackCounter)
    {
        string SFXName = "Sword_";
        if (bIsAccurate)
        {
            SFXName += "Release";
        }
        else
        {
            SFXName += "Charge";
        }

        SFXName += AttackCounter;

        PlaySFX(SFXName);
        
    }

    public void PlayerMoveSFX(int StepCounter)
    {
        string SFXName = "Step" + StepCounter.ToString();
        PlaySFX(SFXName);
    }

    public void PlayHitSFX()
    {
        PlaySFX("Hit");
    }

    public void PlaySFX(string  SFXName)
    {
        AudioManager.Instance.PlaySFX(SFXName);
    }
}
