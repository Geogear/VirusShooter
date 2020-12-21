using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheWorld : MonoBehaviour
{
    // Start is called before the first frame update 
    public Transform background;
    public Transform camerra;
    public Transform sship;

    public float worldSpeed = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        background.position = new Vector2(background.position.x, background.position.y + (worldSpeed * Time.deltaTime));
        sship.position = new Vector2(sship.position.x, sship.position.y + (worldSpeed * Time.deltaTime));
    }

    private void LateUpdate()
    {
        camerra.position = new Vector3(background.position.x, background.position.y, camerra.position.z);
    }
}
