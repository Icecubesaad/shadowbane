using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] private float _movementSpeedHorizontal = 2f;
    Animator _animator;
    private bool _isMoving;
    private bool _stopCoroutine;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Move the character
        transform.Translate(horizontal * _movementSpeedHorizontal * Time.deltaTime, 0,
            vertical * movementSpeed * Time.deltaTime);

        // Check if moving forward
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Moving Forward");
            _animator.SetBool("walkingForward", true);
        }
        else
        {
            _animator.SetBool("walkingForward", false);
        }

        // Check if moving backward
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Moving Backward");
            _animator.SetBool("walkingBackward", true);
        }
        else
        {
            _animator.SetBool("walkingBackward", false);
        }

        // Handle strafing if needed
        // if (Input.GetKey(KeyCode.D))
        // {
        //     _animator.SetBool("strafingRight", true);
        // }
        // else
        // {
        //     _animator.SetBool("strafingRight", false);
        // }

        // if (Input.GetKey(KeyCode.A))
        // {
        //     _animator.SetBool("strafingLeft", true);
        // }
        // else
        // {
        //     _animator.SetBool("strafingLeft", false);
        // }
    }

}
