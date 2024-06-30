using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] private CinemachineVirtualCamera FollowingCamera;
    private CinemachineImpulseSource ImpulseSource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void SlightShakeCamera()
    {
        ImpulseSource.GenerateImpulseWithForce(0.3f);
    }
}
