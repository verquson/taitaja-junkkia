using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public PlayerData data;

    [Header("Movement")]
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    [Header("Shooting")]
    public ParticleSystem muzzleFlash; //Muzzle flash effect
    public WeaponData equippedWeaponData;
    public Transform firePoint;
    bool fireOnCD = false;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    AudioSource AS;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        AS = GetComponent<AudioSource>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Awake()
    {
        GameManager.Instance.Player = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.PauseGame();
        }

        CalculateMovement();
        
        if (Input.GetKey(KeyCode.Mouse0) && !fireOnCD)
        {
            Fire();
        }
    }

    void CalculateMovement()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            AudioManager.Instance.PlayClipOnce(data.JumpSound, this.gameObject);
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    void Fire()
    {
        Instantiate(equippedWeaponData.bulletPrefab, firePoint.position, firePoint.rotation);
        fireOnCD = true;
        AudioManager.Instance.PlayClipOnce(equippedWeaponData.fireSoundEffect, this.gameObject);
        muzzleFlash.Play();
        Invoke("ResetFireCD",equippedWeaponData.fireRate);
    }

    void ResetFireCD()
    {
        fireOnCD = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Jos osutaan portaaliin niin kutsutaan BeginTeleport toiminto
        if (other.GetComponent<Portal>())
        {
            characterController.enabled = false;
            other.GetComponent<Portal>().BeginTeleport(this.gameObject, characterController.velocity.magnitude, false);
            characterController.enabled = true;
        }
        
    }
}
