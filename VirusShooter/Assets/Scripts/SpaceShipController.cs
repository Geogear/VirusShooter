using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField]
    float spaceShip_Speed = 10f;

  /*  [SerializeField]
    private float rotationSpeed = 5000f;

    private float rotationValue = 0f;

    [SerializeField]
    public float smoothingTime = 6f;

    [SerializeField]
    private float smoothingRatio = 1.2f;

    [SerializeField]
    [Range(0.1f, 3f)]
    private float toleranceValue = 3f;*/

    private InputDriver m_InputDriver;

    private Vector3 lastPosition;

    void Start()
    {
        m_InputDriver = GetComponent<InputDriver>();
        m_InputDriver.Init_Input();
    }

    void Update()
    {
        m_InputDriver.CheckInputs();
        SpaceShipMove();
    }

    void SpaceShipMove()
    {
        if (m_InputDriver.m_Input._left)
        {
            //lastPosition = transform.position;
            transform.position = new Vector2(transform.position.x-(spaceShip_Speed * Time.deltaTime), transform.position.y);
            //lastPosition = transform.position - lastPosition;
            //lastPosition.x = -1;
            //transform.rotation = Quaternion.Euler(Vector2.up * lastPosition.x * rotationSpeed * Mathf.Deg2Rad);
            //RotateSpaceShip(lastPosition);
        }
        if (m_InputDriver.m_Input._right)
        {
            //lastPosition = transform.position;
            transform.position = new Vector2(transform.position.x + (spaceShip_Speed * Time.deltaTime), transform.position.y);
            //lastPosition = transform.position - lastPosition;
            //lastPosition.x = +1;
           // transform.rotation = Quaternion.Euler(Vector2.up *lastPosition.x *rotationSpeed * Mathf.Deg2Rad);
        }
        if (m_InputDriver.m_Input._up)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + (spaceShip_Speed * Time.deltaTime));
        }
        if (m_InputDriver.m_Input._down)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - (spaceShip_Speed * Time.deltaTime));
        }
        if (m_InputDriver.m_Input._fire)
        {
           //TO DO FIRE
        }
    }
    /*
     * Rotation
    public void RotateSpaceShip(Vector3 delta)
    {
        //TO DO **SOME INTERPOLATION COULD BE ADDED HERE
        rotationValue = Mathf.Lerp(rotationValue, delta.x * rotationSpeed * Mathf.Deg2Rad, smoothingTime * Time.deltaTime);
        transform.Rotate(Vector2.up, -rotationValue);
        if (rotationValue > rotationSpeed * Mathf.Deg2Rad * toleranceValue)
        {
            ResetRotationValue();
        }
    }

    public bool ResetRotationValue()
    {
        return (rotationValue = 0) == 0;
    }
    */
}
