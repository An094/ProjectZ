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
    [SerializeField] Transform Middleground1;
    [SerializeField] float Middleground1Velocity;
    private PlayerInputHandler playerInput;

    private float CurrentBackgroundXPos;
    private float CurrentMiddlegroundXPos;
    private float CurrentMiddleground1XPos;
    private float TargetBackgroundXPos;
    private float TargetMiddlegroundXPos;
    private float TargetMiddleground1XPos;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputHandler>();
        CurrentBackgroundXPos = Background.position.x;
        CurrentMiddlegroundXPos = Middleground.position.x;
        CurrentMiddleground1XPos = Middleground1.position.x;
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

            CurrentMiddleground1XPos = Middleground1.position.x;
            TargetMiddleground1XPos = CurrentMiddleground1XPos + direction * Middleground1Velocity * Time.deltaTime;


            Background.position = new Vector2(TargetBackgroundXPos, Background.position.y);
            Middleground.position = new Vector2(TargetMiddlegroundXPos, Middleground.position.y);
            Middleground1.position = new Vector2(TargetMiddleground1XPos, Middleground1.position.y);
        }

    }

}
