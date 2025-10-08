using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Math = System.Math;

public class Player : MonoBehaviour
{

    [SerializeField]private float speed;
    private Transform t;
    private Vector2 pos;
    private Vector2 vel;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        
        vel = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") ) * (Time.deltaTime * speed);
        pos += vel;

        float theta = Mathf.Atan2(mousePos.x, mousePos.y);

        t.rotation = new Quaternion(0,theta,0,0);
        t.position = new Vector3(pos.x, pos.y, 0);
    }
    
    
}
