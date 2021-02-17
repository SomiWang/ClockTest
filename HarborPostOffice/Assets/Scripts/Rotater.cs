using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AxisDir
{
    None,
    Up,
    Right,
    Forward
}
public class Rotater : MonoBehaviour
{

    [SerializeField]
    private float m_Speed;
    public bool IsRotating;
    [SerializeField]
    private bool m_IsVertical = true;
    [SerializeField]
    private AxisDir m_Axis;

    public void SetSpeed(float sp)
    {
        m_Speed = sp;
    }

    public void SetAxis(AxisDir dir)
    {
        m_Axis = dir;
    }

    void Update()
    {
        if (IsRotating)
        {
            Vector3 dir = Vector3.up;
            switch (m_Axis)
            {
                case AxisDir.None:
                    dir = m_IsVertical ? Vector3.up : Vector3.right;
                    break;
                case AxisDir.Up:
                    dir = Vector3.up;
                    break;
                case AxisDir.Right:
                    dir = Vector3.right;
                    break;
                case AxisDir.Forward:
                    dir = Vector3.forward;
                    break;
            }
            var rotate = Quaternion.AngleAxis(45, dir);
            var newRotation = transform.rotation * rotate;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, m_Speed * Time.deltaTime);
        }
    }
}
