using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
    public float speed = 12.0f;
    public float vertical;
    public float horizontal;
    private CharacterController _characterController;
    // gravity
    private float _fallGravity = 100.0f;
    private float _defaultGravity = 9.8f;
    private float _gravity;
    // jump
    private float jumpSpeed = 50.0f;
    private float _fallTime;
    private float _maxFallTime = 150.0f;

    Vector3 movement = Vector3.zero;

    // Start is called before the first frame update
    void Start() {
        _gravity = _defaultGravity;
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        if (_characterController.isGrounded) {
            float deltaZ = Input.GetAxis("Vertical") * speed;
            float deltaX = Input.GetAxis("Horizontal") * speed;

            movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed); //ограничение скорости по диагоняли
            movement = transform.TransformDirection(movement); //преобразование к глобальным координатам
            
            animator.SetFloat("vertical", Mathf.Abs(deltaX));
            animator.SetFloat("horizontal", Mathf.Abs(deltaZ));
            
            if (Input.GetButton("Jump")) {
                movement.y = jumpSpeed;
                _fallTime = _maxFallTime;
            }
        } else {
            _fallTime--;
            if (_fallTime < 0) {
                _gravity = _fallGravity;
            } else { 
                _gravity = _defaultGravity; 
            }
        }

        movement.y -= _gravity * Time.deltaTime;
        _characterController.Move(movement * Time.deltaTime);
    }
}
