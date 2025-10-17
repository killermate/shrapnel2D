using UnityEngine;

public class ElectricCurrent : BasicGun
{
    private GameObject[] bullets;
    private int currentID = 0;

    private void Start()
    {
        bullets = new GameObject[128];
    }

    protected override void Shoot()
    {
        bullets[currentID] = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);

        int pairID = currentID - 1;
        if (pairID < 0) pairID = bullets.Length - 1;

        if (bullets[pairID] != null)
        {
            var currentProj = bullets[currentID].GetComponent<ElectricCurrentProj>();
            if (currentProj != null)
                currentProj.Init(ref bullets[pairID]);
        }

        currentID++;
        if (currentID >= bullets.Length)
            currentID = 0;
    }
}