using UnityEngine;
using UnityEngine.Animations;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float Distance = 5f;

    private (float min, float max) Rotation = (10f, 80f);
    private const float RotSensitive = 3f;
    private const float SmoothTime = 0.12f;

    private (float x, float y) Axis;
    private Vector3 TargetRotation;
    private Vector3 CurVel;

    private void Update()
    {
        //if  (Player != null)
        //{
        //    transform.position = Player.transform.position;
        //    transform.Translate(Distance);
        //}
    }

    private void LateUpdate()
    {
        Axis.y += Input.GetAxis("Mouse X") * RotSensitive;
        Axis.x -= Input.GetAxis("Mouse Y") * RotSensitive;

        Axis.x = Mathf.Clamp(Axis.x, Rotation.min, Rotation.max);

        TargetRotation = Vector3.SmoothDamp(TargetRotation, new Vector3(Axis.x, Axis.y), ref CurVel, SmoothTime);
        transform.eulerAngles = TargetRotation;

        transform.position = Player.transform.position - (transform.forward * Distance);
    }
}
