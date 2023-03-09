using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour, IPlayer
{
    // private readonly 
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed = 0.15f;
    private Animator _animator;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
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
        Vector3 direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        direction = direction.normalized * moveSpeed * Time.deltaTime;
        _rigidbody.MovePosition(transform.position + direction);
        if (direction != Vector3.zero)
        {
            transform.LookAt(transform.position + direction);
        }
    }

    //TODO Separar o if
    private void OnTriggerEnter(Collider other)
    {
        IEnemy enemy = other.GetComponent<IEnemy>();
        if (enemy != null && !enemy.isDead())
        {
            PunchAnimation();
            enemy.OnDeath();
        }
        else if (enemy != null && enemy.isDead())
        {
            enemy.CanStack = true;
        }
    }
}
