using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomiTest : MonoBehaviour
{
    public Animation m_Anim;
    // Start is called before the first frame update
    void Start()
    {
        m_Anim = GetComponentInChildren<Animation>();

        foreach(AnimationState state in m_Anim)
        {
            Debug.Log("Somimi" + state.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_Anim.Play("idle ");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_Anim.Play("soar ");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_Anim.Play("flap ");
        }
    }
}
