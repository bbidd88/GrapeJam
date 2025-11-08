using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Gun Gun;
    [SerializeField] private float MoveSpeed = 4f;
    [SerializeField] private float JumpSpeed = 4f;

    private Vector3 MoveDirection = Vector3.zero;
    private bool isJumping = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext InContext)
    {
        MoveDirection = InContext.ReadValue<Vector3>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        var rigidbody = GetComponent<Rigidbody>();
        // 처음 눌린 순간에만 실행되도록 함
        if (context.phase == InputActionPhase.Started && !isJumping)
        {
            isJumping = true;
            rigidbody.linearVelocity = new Vector3(
                rigidbody.linearVelocity.x,
                JumpSpeed,
                rigidbody.linearVelocity.y);
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (Gun == null)
            return;

        if (context.phase == InputActionPhase.Started)
        {
            Gun.Shoot();
        }
    }

    private void Move()
    {
        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            var velocity = MoveDirection * MoveSpeed;
            velocity.y = rigidbody.linearVelocity.y;

            rigidbody.linearVelocity = velocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
