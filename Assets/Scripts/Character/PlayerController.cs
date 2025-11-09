using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Gun Gun;
    [SerializeField] private float MoveSpeed = 4f;
    [SerializeField] private float JumpSpeed = 4f;
    [SerializeField] private float ShootTime = 1f;

    private Vector3 MoveDirection = Vector3.zero;
    private bool isJumping = false;
    private float LastShootTime = 0f;

    public void Update()
    {
        if (LastShootTime >= ShootTime)
        {
            Shoot();
            LastShootTime = 0f;
        }

        LastShootTime += Time.deltaTime;
    }

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

    private void Shoot()
    {
        if (Gun == null)
            return;

        Gun.Shoot();
    }

    private void Move()
    {
        // transform.Translate(MoveDirection * MoveSpeed *  Time.deltaTime);
        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            var move = MoveDirection * MoveSpeed * Time.fixedDeltaTime;
            rigidbody.MovePosition(rigidbody.position + move);
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
