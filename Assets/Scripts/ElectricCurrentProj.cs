using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class ElectricCurrentProj : Bullet
{
    [Header("Beam Settings")]
    [SerializeField] private float maxBeamDistance = 10f;
    [SerializeField] private LayerMask hitMask;

    private GameObject pairProjectile;
    private LineRenderer lr;

    public void Init(ref GameObject pair)
    {
        pairProjectile = pair;
    }

    protected override void Start()
    {
        base.Start(); // Calls Bullet.Start() to set Rigidbody velocity
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    protected override void Update()
    {
        base.Update(); // Keeps Bullet lifetime countdown

        if (pairProjectile == null)
        {
            lr.enabled = false;
            return;
        }

        float dist = math.distance(transform.position, pairProjectile.transform.position);

        if (dist <= maxBeamDistance)
        {
            lr.enabled = true;

            Vector3 start = transform.position;
            Vector3 end = pairProjectile.transform.position;

            // Optional: Check for obstacles between projectiles
            RaycastHit2D hit = Physics2D.Raycast(start, (end - start).normalized, dist, hitMask);
            if (hit.collider != null)
                end = hit.point;

            lr.positionCount = 2;
            lr.SetPosition(0, start);
            lr.SetPosition(1, end);
        }
        else
        {
            lr.enabled = false;
        }
    }
}