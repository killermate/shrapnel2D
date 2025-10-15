using Unity.VisualScripting;
using UnityEngine;

public class ElectricCurrentProj : Bullet
{
    GameObject pairProjectile = null;

    public void Init(ref GameObject pair)
    {
        pairProjectile = pair;
    }

    protected override void Update()
    {
        base.Update();
        Debug.DrawRay(transform.position, pairProjectile.transform.position, Color.red);
    }
}