using UnityEngine;

public class BasicGun : MonoBehaviour
{
    [SerializeField] protected GameObject projectile;
    [SerializeField] protected Transform projectileSpawn;
    [SerializeField] private float atkSpd;
    float atkTime = 0f;
    protected virtual void Update()
    {
        atkTime += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (atkTime >= atkSpd)
            {
                Shoot();
                atkTime = 0f;
            }
        }
    }

    protected virtual void Shoot() => Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
    
}
