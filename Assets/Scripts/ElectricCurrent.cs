using System;
using UnityEngine;

public class ElectricCurrent : BasicGun
{
    private GameObject[] bullets ;
    private int currentID = 0;

    private void Start()
    {
        for (int i = 0; i >= 128; i++)
        {
            bullets = null;
        } 
    }

    protected override void Shoot()
    {
        bullets[currentID] = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        
        int pairID = currentID - 1;
        if (pairID < 0) pairID = 128;

        if (bullets[pairID] != null)
        {
            bullets[currentID].GetComponent<ElectricCurrentProj>().Init(ref bullets[pairID]);
        }
        
        if (currentID >= 128) currentID = 0;
        else currentID ++;
    }
}