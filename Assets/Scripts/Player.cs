using System;
using UnityEngine;
using Math = System.Math;

public class Player : MonoBehaviour
{
    [SerializeField] private float spd;
    [SerializeField] private float rotSpd;
  
    private Vector2 pos;
    private Vector2 vel;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Movement
        vel = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * (spd * Time.deltaTime);
        pos += vel;
        transform.position = new Vector3(pos.x, pos.y, 0);

        // Rotation toward mouse
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position);
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        float currentAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, rotSpd * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
    }
}