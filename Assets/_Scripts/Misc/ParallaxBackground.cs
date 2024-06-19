using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Windows;

public class ParallaxBackground : MonoBehaviour
{
    [Header("Background")]
    [SerializeField] Transform Background;
    [SerializeField] float BackgroundVelocity;
    [SerializeField] Transform Middleground;
    [SerializeField] float MiddlegroundVelocity;
    private PlayerInputHandler playerInput;

    private float CurrentBackgroundXPos;
    private float CurrentMiddlegroundXPos;
    private float TargetBackgroundXPos;
    private float TargetMiddlegroundXPos;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
        CurrentBackgroundXPos = Background.position.x;
        CurrentBackgroundXPos = Middleground.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float CamXVelocity = camera.velocity.x;

        if (CamXVelocity != 0 && Mathf.Abs(CamXVelocity) > 1)
        {
            int direction = CamXVelocity > 0 ? 1 : -1;

            CurrentBackgroundXPos = Background.position.x;
            TargetBackgroundXPos = CurrentBackgroundXPos + direction * BackgroundVelocity * Time.deltaTime;

            CurrentMiddlegroundXPos = Middleground.position.x;
            TargetMiddlegroundXPos = CurrentMiddlegroundXPos + direction * MiddlegroundVelocity * Time.deltaTime;

            Background.position = new Vector2(TargetBackgroundXPos, Background.position.y);
            Middleground.position = new Vector2(TargetMiddlegroundXPos, Middleground.position.y);
        }

    }

}
