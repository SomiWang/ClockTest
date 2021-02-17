using UnityEngine;

public class RotaterRandomController : MonoBehaviour
{
    private Rotater[] rotaters;
    [SerializeField]
    private float m_Speed;

    private void Start()
    {
        rotaters = GetComponentsInChildren<Rotater>();
        foreach (var i in rotaters)
        {
            i.SetAxis((AxisDir)Random.Range(1, 4));
            i.SetSpeed(m_Speed);
            i.IsRotating = true;
        }
    }
}
