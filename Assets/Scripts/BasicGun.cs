using UnityEngine;

public class BasicGun : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform projectileSpawn;
    [SerializeField] private float atkSpd = 0.01f;
    float atkTime = 0f;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (atkTime >= atkSpd)
            {
                Shoot();
                atkTime = 0f;
            }
            atkTime += Time.deltaTime;
        }
        
    }

    void Shoot() => Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
    
}
