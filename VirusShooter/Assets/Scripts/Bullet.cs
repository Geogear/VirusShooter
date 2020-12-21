using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float diesIn = 1.5f; 
    //first 1.0f is world speed
    private float bulletSpeed = 2.5f;
    private float worldSpeed = 1.0f;

    private bool penetrativeBullet = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, diesIn);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + ((bulletSpeed+worldSpeed) * Time.deltaTime));
    } 

    public bool isPenetrative() { return penetrativeBullet; } 
    
    public void SetPenetrative(bool val) { penetrativeBullet = val; }
}
