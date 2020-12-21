using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmHandler : MonoBehaviour
{
    public GameObject prefab;
    public Transform basePos; 
    public Transform left;
    public Transform right;
    public Transform up;
    public Transform down;
    public int spawnAmnt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border")
        {
            transform.position = basePos.position;
            //Spawn();
        }
    } 

    /*public void Spawn()
    {
        Vector3 v3 = new Vector3(Random.Range(left.position.x, right.position.x), Random.Range(down.position.y, up.position.y), 0);
        Instantiate(prefab, v3);
    }*/
}
