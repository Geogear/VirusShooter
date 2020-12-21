using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public InputDriver id;
    public SpaceShipController ssc;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            HandleBorderFirst();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SetTrue();
        }
    }


    private void HandleBorderFirst()
    {
        if (id.m_Input._down)
        {
            id.m_Input._down = false;
            ssc.canGo[0] = false;
        }else if (id.m_Input._up)
        {
            id.m_Input._up = false;
            ssc.canGo[1] = false;
        }

        if (id.m_Input._right)
        {
            id.m_Input._right = false;
            ssc.canGo[3] = false; ;
        }
        else if (id.m_Input._left)
        {
            id.m_Input._left = false;
            ssc.canGo[2] = false;
        }

    }  

    private void SetTrue()
    {
        for(int i = 0; i < 4; i++)
        {
            ssc.canGo[i] = true;
        }
    }
}
