using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private GameObject BossFightingCam;
    [SerializeField] private ParticleSystem CrushedStoneParticle;
    private CinemachineImpulseSource impulseSource;

    private void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playableDirector.Play();
            BossFightingCam.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void ShakeCamera()
    {
        impulseSource.GenerateImpulseWithForce(0.5f);
        CrushedStoneParticle.Play();
    }
}
