using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private InputActionReference jumpButton;
    [SerializeField] private float jumpHeight = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private CharacterController _characterController;
    private Vector3 _playerVelocity;

    private void Awake() => _characterController = GetComponent<CharacterController>();

    private void OnEnable() => jumpButton.action.performed += Jumping;

    private void OnDisable() => jumpButton.action.performed -= Jumping;

    // Update is called once per frame
    private void Jumping(InputAction.CallbackContext obj)
    {
        if (!_characterController.isGrounded) return;
        _playerVelocity.y += Mathf.Sqrt(f: jumpHeight * -3.0f  * gravityValue);
    }
    private void Update()
    {
        if(!_characterController.isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }
        _playerVelocity.y += gravityValue * Time.deltaTime;
        _characterController.Move(motion:_playerVelocity * Time.deltaTime);
    }
}
