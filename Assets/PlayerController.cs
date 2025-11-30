using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private InputAction m_myButton = new("Button pressed", InputActionType.Value);
    private Vector3 _input;

    private void OnEnable()
    {
        m_myButton.Enable();
    }

    private void OnDisable()
    {
        m_myButton.Disable();
    }

    void Update(){
    GatherInput();
    Look();
   }

   void FixedUpdate(){
    Move();
   }

  void GatherInput() {
        var inputVector = m_myButton.ReadValue<Vector2>();
        _input = new Vector3(inputVector.x, 0, inputVector.y);
    float move = m_myButton.ReadValue<Vector2>().x;
    Debug.Log(move);
    _rb.velocity = new Vector2(move * _speed, _rb.velocity.y);
  }

  void Look() {
    if (_input != Vector3.zero) {
        var relative = (transform.position + _input) - transform.position;
        var rot = Quaternion.LookRotation(relative, Vector3.up);

        transform.rotation = rot;
    }
  
  }

  void Move() {
    if (_input.magnitude < 0.1f) { return; }
    _rb.MovePosition(transform.position + transform.forward * _speed * Time.deltaTime);
    _rb.transform.eulerAngles = new(0,_rb.transform.eulerAngles.y,0);
  
  }
}
