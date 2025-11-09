using UnityEngine;
using static Bullet;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform Muzzle;
    [SerializeField] private Bullet Bullet;

    public void Shoot(AttackFunction attackFunction)
    {
        if (Muzzle != null && Bullet != null)
        {
            var bullet = Instantiate(Bullet, Muzzle.position, transform.parent.rotation);
            if (bullet)
            {
                bullet.SetAttachFunction(attackFunction);
            }
        }
    }
}
