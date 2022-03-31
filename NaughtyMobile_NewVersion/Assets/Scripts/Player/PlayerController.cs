//ref case study
#region BugAndroid Controller

/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Manager;
public class PlayerController : MonoBehaviour
{
    #region SetFromInspector
    
    [Header("Character Prefab")]
    [SerializeField] private JennieCharacter jennieCharacter;
    [SerializeField] private JohnCharacter johnCharacter;
    
    [Space]
    [Header("Character Info")]
    [SerializeField] private CharacterInfo player;
    [SerializeField] private CharacterInfo jennieCharacterInfo;
    [SerializeField] private CharacterInfo johnCharacterInfo;
    
    [Space]
    [Header("Controller")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float rotationSpeed;
    
    #endregion

    #region PrivateValue
    
    private Transform cameraTransform;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool isAttack = true;
    private float gravityValue = Physics.gravity.y;
    private float cooldownTimeAttack = 3;

    #endregion

    private void Awake()
    {
        Debug.Assert(playerInput != null, "playerInput cannot be null");
        Debug.Assert(controller != null, "controller cannot be null");
        Debug.Assert(rotationSpeed > 0, "rotationSpeed has to be more than zero");
    }

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        RaycastHit hit;
        Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit);
            
        Move();
        
        if (playerInput.actions["Attack"].triggered)
        {
            StartCoroutine(OnAttack(hit));
        }
        
        if (playerInput.actions["Open"].triggered)
        {
            Open();
        }
    }

    private void Move()
    {
        groundedPlayer = controller.isGrounded;
        
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movementInput = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
        move = move.x * cameraTransform.right + move.z * cameraTransform.forward;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * player.Speed);
        
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (movementInput != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg +
                                cameraTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }

    private void Open()
    {
        if (player.Name == jennieCharacterInfo.Name)
        {
            jennieCharacter.Open();
            return;
        }

        if (player.Name == johnCharacterInfo.Name)
        {
            johnCharacter.Open();
        }
    }

    private IEnumerator OnAttack(RaycastHit hit)
    {
        if (isAttack)
        {
            transform.LookAt(hit.point);
            
            if (player.Name == jennieCharacterInfo.Name)
            {
                jennieCharacter.Attack();
            }

            if (player.Name == johnCharacterInfo.Name)
            {
                johnCharacter.Attack();
            }
            isAttack = false;
            yield return new WaitForSeconds(cooldownTimeAttack);
            isAttack = true;
        }
    }
}
*/

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region SetFromInspector
    
    [Header("Character Prefab")]
    [SerializeField] private JennieCharacter jennieCharacter;
    [SerializeField] private JohnCharacter johnCharacter;
    
    [Space]
    [Header("Character Info")]
    [SerializeField] private CharacterInfo player;
    [SerializeField] private CharacterInfo jennieCharacterInfo;
    [SerializeField] private CharacterInfo johnCharacterInfo;
    
    [Space]
    [Header("Controller")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Animator anim;
    
    #endregion

    #region PrivateValue
    
    private InputActions playerInput;
    private Transform cameraTransform;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool isAttack = true;
    private float gravityValue = Physics.gravity.y;
    private float cooldownTimeAttack = 3;
    private float animationBlendDamp = .05f;

    #endregion

    private void Awake()
    {
        playerInput = new InputActions();
    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Move.performed += context => { SoundManager.Instance.Play(SoundClip.Sound.Walk); };
        playerInput.Player.Move.canceled += context => { SoundManager.Instance.Stop(SoundClip.Sound.Walk); };
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        /*RaycastHit hit;
        Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit);*/
            
        Move();
        
        if (playerInput.Player.Attack.triggered)
        {
            StartCoroutine(OnAttack());
        }
        
        if (playerInput.Player.Open.triggered)
        {
            Open();
        }
    }

    private void Move()
    {
        groundedPlayer = controller.isGrounded;
        
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movementInput = playerInput.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
        move = move.x * cameraTransform.right + move.z * cameraTransform.forward;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * player.Speed);
        
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        anim.SetFloat ("Blend", movementInput.sqrMagnitude, animationBlendDamp, Time.deltaTime);
        
        if (move.sqrMagnitude == 0)
        {
            anim.SetBool("isMove", false);
        }
        else
        {
            anim.SetBool("isMove", true);
        }
        
        if (movementInput != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg +
                                cameraTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }

    private void Open()
    {
        SoundManager.Instance.Play(SoundClip.Sound.Click);
        if (player.Name == jennieCharacterInfo.Name)
        {
            jennieCharacter.Open();
            return;
        }

        if (player.Name == johnCharacterInfo.Name)
        {
            johnCharacter.Open();
        }
    }

    private IEnumerator OnAttack()
    {
        if (isAttack)
        {
            //transform.LookAt(hit.point);
            
            anim.Play("OnFire");
            
            SoundManager.Instance.Play(SoundClip.Sound.Fire);
            
            if (player.Name == jennieCharacterInfo.Name)
            {
                jennieCharacter.Attack();
            }

            if (player.Name == johnCharacterInfo.Name)
            {
                johnCharacter.Attack();
            }
            
            isAttack = false;
            yield return new WaitForSeconds(cooldownTimeAttack);
            isAttack = true;
        }
    }
}

