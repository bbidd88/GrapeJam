using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 3f;
    [SerializeField] private float LifeTime = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0f)
            return;

        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Moster"))
        {
            Destroy(gameObject);
        }        
    }
}