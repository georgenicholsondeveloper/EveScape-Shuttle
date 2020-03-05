using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour {

    [SerializeField] private FPSViewScript mouseLook;
    private CharacterController player;
    private Camera fpsCamera;
    private Vector3 move = Vector3.zero;
    private Vector2 moveInput;
    private Vector2 look;
    private Texture2D crosshair;
    private bool jumpTick, climbLadder = false;
    private float gravityHolder;

    public float fallSpeedMax;
    public float moveSpeed;
    public float jumpForce;
    public float gravity;
    public float playerHealth;
    public bool dead;

    public static bool paused;
    public static bool deathMenuActive;
    public static bool freeMouse;

	void Start ()
    {
        player = gameObject.GetComponent<CharacterController>();
        fpsCamera = Camera.main;
        mouseLook.Initialisation(transform, fpsCamera.transform);
	}
	
	
	void Update ()
    {
        Movement();
        Rotate();
	}

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveInput = new Vector2(horizontal, vertical);

        if(moveInput.sqrMagnitude > 1)
        {
            moveInput.Normalize();
        }

        Vector3 moveDirection = Vector3.zero;

        if (!climbLadder)
        {
            moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
        }
        if (climbLadder)
        {
            moveDirection = transform.right * moveInput.x;
            move.y = vertical * moveSpeed / 4;
        }
        

        move.x = moveDirection.x * moveSpeed;
        move.z = moveDirection.z * moveSpeed;

        if (player.isGrounded)
        {
            move.y = 0;
            jumpTick = false;
        }
        else
        {
            move.y -= gravity * Time.deltaTime;
        }

        if (Input.GetButton("Jump") && jumpTick == false)
        {
            move.y = jumpForce;
            jumpTick = true;
        }

        player.Move(move);
        mouseLook.UpdateCursorLock();
    }

    void Rotate()
    {
        mouseLook.LookRotation(transform, fpsCamera.transform);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 5, 5), "");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            gravityHolder = gravity;
            gravity = 0;
            climbLadder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            gravity = gravityHolder;
            climbLadder = false;
        }
    }
}
