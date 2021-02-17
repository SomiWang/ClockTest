using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CausticController : MonoBehaviour
{
    [SerializeField]
    private Projector m_Caustic;
    private Material mat;
    public float m_Strength;

    private void Start()
    {
        var mat = m_Caustic.material;
    }

    private void Update()
    {
        if (mat == null) mat = m_Caustic.material;

        if (mat.GetFloat("_ColorStrength") != m_Strength)
            mat.SetFloat("_ColorStrength", m_Strength);
    }
}
