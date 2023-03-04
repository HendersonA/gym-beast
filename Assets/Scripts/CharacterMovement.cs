using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed = 0.15f;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        MoveByJoystick(joystick.Horizontal, joystick.Vertical);
    }

    private void MoveByJoystick(float inputHorizontal, float inputVertical)
    {
        Vector3 direction = new Vector3(inputHorizontal * moveSpeed, 0, inputVertical * moveSpeed);
        _characterController.Move(direction * Time.fixedDeltaTime);
        if (direction != Vector3.zero)
        {
            transform.LookAt(transform.position + direction);
        }
    }
}
