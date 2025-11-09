using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 4f;
    [SerializeField] private float JumpSpeed = 4f;
    [SerializeField] private int MaxJumpCount = 3;

    private Vector3 MoveDirection = Vector3.zero;
    private int JumpCount = 0;

    public void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext InContext)
    {
        var mainCamera = GameObject.Find("@MainCamera");
        if (!mainCamera)
            return;

        MoveDirection = InContext.ReadValue<Vector3>();

        //float angle = Vector3.SignedAngle(Vector3.up, mainCamera.transform.position, transform.position);
        float angle = mainCamera.transform.eulerAngles.y;
        transform.Rotate(Vector3.up, angle);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        var rigidbody = GetComponent<Rigidbody>();
        // 처음 눌린 순간에만 실행되도록 함
        if (context.phase == InputActionPhase.Started && (JumpCount < MaxJumpCount))
        {
            JumpCount++;
            rigidbody.linearVelocity = new Vector3(
                rigidbody.linearVelocity.x,
                JumpSpeed,
                rigidbody.linearVelocity.y);
        }
    }

    private void Move()
    {
        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody)
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
            JumpCount = 0;
        }
    }
}
