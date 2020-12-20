using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDriver : MonoBehaviour
{
    [HideInInspector]
    public struct INPUT
    {
        public bool _left, _right;
        public bool _up, _down;
        public bool _fire;
    }

    [HideInInspector]
    public INPUT m_Input;

    public void Init_Input()
    {
        m_Input._left = m_Input._right = m_Input._up = m_Input._down = m_Input._fire = false;
    }


    public void CheckInputs()
    {
        m_Input._left = Input.GetKey(KeyCode.A);
        m_Input._right = Input.GetKey(KeyCode.D);
        m_Input._up = Input.GetKey(KeyCode.W);
        m_Input._down = Input.GetKey(KeyCode.S);
        m_Input._fire = Input.GetMouseButton(0);
    }
}
