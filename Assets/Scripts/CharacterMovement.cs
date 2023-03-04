using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed = 0.15f;

    private CharacterController _characterController;
    private Animator _animator;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        MoveByJoystick();
        WalkAnimation();
    }

    public void PunchAnimation()
    {
        _animator.SetTrigger("Punch");
    }

    private void WalkAnimation()
    {
        if ((joystick.Horizontal != 0 || joystick.Vertical != 0))
        {
            _animator.SetBool("Move", true);
        }
        else
        {
            _animator.SetBool("Move", false);
        }
    }

    private void MoveByJoystick()
    {
        Vector3 direction = new Vector3(joystick.Horizontal * moveSpeed, 0, joystick.Vertical * moveSpeed);
        _characterController.Move(direction * Time.fixedDeltaTime);
        if (direction != Vector3.zero)
        {
            transform.LookAt(transform.position + direction);
        }
    }
}
