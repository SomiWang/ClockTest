using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DissolveEffect))]
public class DissolveEffectEditor : Editor
{
    private DissolveEffect Target;

    private void OnEnable()
    {
        Target = target as DissolveEffect;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (Target.isUpdate) Target.SetCutoff(Target.DissolveCutoff);        
        
        if (GUILayout.Button("Play"))
        {
            Target.Play();
        }
    }
}
