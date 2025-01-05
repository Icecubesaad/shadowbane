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
        transform.Translate(horizontal * _movementSpeedHorizontal * Time.deltaTime, 0, vertical * movementSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("walkingForward", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _animator.SetBool("walkingBackward", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("strafingRight", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("strafingLeft", true);
        }
        else
        {
            _animator.SetBool("strafingRight", false);
            _animator.SetBool("strafingLeft", false);
            _animator.SetBool("walkingForward", false);
            _animator.SetBool("walkingBackward", false);
            waitForIdle();
        }
    }

    IEnumerator waitForIdle()
    {
        while (!checkIfMoving())
        {
            yield return new WaitForSeconds(3);
            _animator.SetBool("idle", true);
        }
    }

    bool checkIfMoving()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            return true;
        }
        return false;
    }
}
