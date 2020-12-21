using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UIStuff script;
    private Animator anim;
    private bool dead;
    float killTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    } 

    public void beforeDeath()
    {
        anim.SetBool("beforeDead", true);
        script.increaseScore();
        Destroy(gameObject, killTime);
        dead = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.tag != "Player")
        {
            beforeDeath();
        }
    } 

    public bool isDead()
    {
        return dead;
    }

}
