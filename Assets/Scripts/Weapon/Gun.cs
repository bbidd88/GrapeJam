using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform Muzzle;
    [SerializeField] private Bullet Bullet;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (Muzzle != null && Bullet != null)
        {
            Instantiate(Bullet, Muzzle.position, transform.parent.rotation);
        }
    }
}
