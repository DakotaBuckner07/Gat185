using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [Range(0, 20)]public float speed = 1;
    [Range(0, 20)] public float jump = 1;
    [Range(-20, 20)] public float gravity = -9.8f;
    public Animator animator;
    public Perception perception;
    public Slendermanne enemy;
    public Weapon weapon;
    public eSpace space = eSpace.World;
    public eMovement movement = eMovement.Free;
    public float turnRate = 3;

    public enum eSpace
    {
        World, 
        Camera,
        Object
    }

    public enum eMovement
    {
        Free,
        Tank,
        Strafe
    }

    bool onGround = false;
    Vector3 inputDirection;
    Vector3 velocity;
    Health health;
    CharacterController characterController;
    Transform cameraTransform;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        weapon = GetComponent<Weapon>();
        enemy = GetComponent<Slendermanne>();
        health = GetComponent<Health>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        //if (animator.GetBool("Death")) return;

        //Debug.Log("Perception");

        Debug.Log("We are getting there");

            Debug.Log("Where do you go?");
        onGround = characterController.isGrounded;
        if(onGround && velocity.y < 0)
        {
            velocity.y = 0;
        }
        // ***

        Quaternion orientation = Quaternion.identity;
        switch (space)
        {
            case eSpace.Camera:
                Vector3 forward = cameraTransform.forward;
                forward.y = 0;
                orientation = Quaternion.LookRotation(forward);
                break;
            case eSpace.Object:
                orientation = transform.rotation;
                break;
            default:
                break;
        }

        Vector3 direction = Vector3.zero;
        Quaternion rotation = Quaternion.identity;
        switch (movement)
        {
            case eMovement.Free:
                direction = orientation * inputDirection;
                rotation = (direction.sqrMagnitude > 0) ? Quaternion.LookRotation(direction) : transform.rotation;
                break;
            case eMovement.Tank:
                direction.z = inputDirection.z;
                direction = orientation * direction;

                rotation = orientation * Quaternion.AngleAxis(inputDirection.x, Vector3.up);
                break;
            case eMovement.Strafe:
                direction = orientation * inputDirection;
                rotation = Quaternion.LookRotation(orientation * Vector3.forward);

                break;
            default:
                break;
        }

        //***
        characterController.Move(direction * speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnRate * Time.deltaTime);
        

        animator.SetFloat("Speed", inputDirection.magnitude);
        animator.SetBool("onGround", onGround);
        animator.SetFloat("VelocityY", velocity.y);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        Debug.Log("Just seen is fucking up");
        EnemyIsSeen();
        //if(health.health <= 0)
        //{
        //    animator.SetBool("GameReset", false);
        //    animator.SetBool("Death", true);
        //}
        //else
        //{
        //    animator.SetBool("GameReset", true);
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            GameController.Instance.OnGameOverScreen();
        }
    }

    public void OnJump()
    {
        if(onGround)
        {
            velocity.y += jump;
        }
    }

    public void OnPunch()
    {
        animator.SetTrigger("Punch");
    }

    public void OnDeath()
    {
        animator.SetTrigger("Death");
    }

    public void OnThrow()
    {
        animator.SetTrigger("Throw");
    }
    
    public void onFire()
    {
        weapon.Fire(transform.forward);
        Debug.Log("Fire");
    }

    public void OnMove(InputValue input)
    {
        Vector2 v2 = input.Get<Vector2>();
        inputDirection.x = v2.x;
        inputDirection.z = v2.y;
        Debug.Log("Moving");
    }

    public void EnemyIsSeen()
    {
        GameObject Enemy = Perception.GetGameObjectFromTag(perception.GetGameObjects(), "Enemy");
        if (Enemy != null)
        {
            enemy.isSeen = true;
        }
        else
        {
            enemy.isSeen = false;
        }
        Debug.Log("out of else");
    }
}
