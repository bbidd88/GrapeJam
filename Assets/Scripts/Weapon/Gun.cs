using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform Muzzle;
    [SerializeField] private Bullet Bullet;

    public void Shoot()
    {
        if (Muzzle != null && Bullet != null)
        {
            Instantiate(Bullet, Muzzle.position, transform.parent.rotation);
        }
    }
}
