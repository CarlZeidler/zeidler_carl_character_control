using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EvillakController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpHeight = 5f;
    public float doubleJumpHeight = 6;
    public float airControl = 2f;
    public float bulletVelocity = 20f;

    public bool isGrounded;
    public float xInput;
    private float yInput;
    private bool cameraFollow = false;
    private bool doubleJump;
    private float initialYPos;
    private float yPos;

    public Camera mainCamera;
    public GameObject bullet;
    private Rigidbody2D rb2d;
    public RestartScript restarter;
    public UISceneJump sceneUI;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initialYPos = transform.position.y;
    }

    void Update()
    {
        yPos = transform.position.y;
        RegisterInput();
        MovementControl();
        JumpingControl();
        CameraControl();
        FallCheck();
    }

    private void RegisterInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    private void MovementControl()
    {
        float moving = Mathf.Abs(xInput);

        if (moving > 0)
        {
            if (isGrounded)
            {
                rb2d.velocity = new Vector2(xInput * moveSpeed, rb2d.velocity.y);
            }
            else if (!isGrounded)
            {
                rb2d.velocity = new Vector2(xInput * moveSpeed, rb2d.velocity.y);
            }
        }
    }

    private void JumpingControl()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
            doubleJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, doubleJumpHeight);
            doubleJump = false;
        }
    }

    private void CameraControl()
    {
        if (mainCamera.transform.position.x > transform.position.x && !cameraFollow)
        {
            mainCamera.transform.position = mainCamera.transform.position;
        }
        else if (mainCamera)
        {
            cameraFollow = true;
            mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y, transform.position.z -10);
        }
    }

    private void FallCheck()
    {
        if (transform.position.y < initialYPos - 5)
        {
            Destroy(gameObject);
            sceneUI.GameOverDisplay();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
    }
}
