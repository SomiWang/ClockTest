using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 1.0f)]
    public float DissolveCutoff;
    [SerializeField]
    private AnimationCurve m_DissolveCurve;
    [SerializeField]
    private float m_Duration;
    [SerializeField]
    private ParticleSystem m_ParticleSystem;
    [SerializeField]
    [Range(0, 1)]
    private float m_ParticleFireTime;
    public bool isUpdate;
    [SerializeField]
    private bool m_ParticleSystemIsPlaying;
    private Coroutine decreasingCoroutine;

    private void Start()
    {
        m_ParticleSystem.Stop();
    }

    private void Update()
    {
        if(isUpdate)
        {
            SetCutoff(DissolveCutoff);
        }
    }

    public void Play()
    {
        m_ParticleSystem.Stop();
        m_ParticleSystemIsPlaying = false;

        if (decreasingCoroutine != null)
        {
            StopCoroutine(decreasingCoroutine);
            decreasingCoroutine = null;
        }
        //var _isLoop = m_ParticleSystem.main.loop;
        //_isLoop = true;
        decreasingCoroutine = StartCoroutine(IncreasingDissolveCutoff());
    }

    private IEnumerator IncreasingDissolveCutoff()
    {
        float _elapsedTime = 0.0f;
        while (materials[0].GetFloat("_cutoff") < 1.0f)
        {
            float _time = _elapsedTime / m_Duration;
            SetCutoff(m_DissolveCurve.Evaluate(_time));
            if (_time >= m_ParticleFireTime && !m_ParticleSystemIsPlaying)
            {
                m_ParticleSystem.Play();
                m_ParticleSystemIsPlaying = true;
                Debug.Log("Gear clock particle system is playing.");
            }
            _elapsedTime += Time.deltaTime;
            yield return null;
        }

        StopCoroutine(decreasingCoroutine);
        decreasingCoroutine = null;
        SetCutoff(0.0f);
        //var _isLoop = m_ParticleSystem.main.loop;
        //_isLoop = false;
    }

    private List<Material> materials
    {
        get
        {
            if (_materials == null)
            {
                _materials = new List<Material>();
                var renders = GetComponentsInChildren<Renderer>();
                foreach (var i in renders)
                {
                    if (i.gameObject.tag != "ClockParticles")
                        _materials.Add(i.sharedMaterial);
                }
            }
            return _materials;
        }
    }
    private List<Material> _materials;

    public void SetCutoff(float value)
    {
        foreach (var i in materials)
        {
            i.SetFloat("_cutoff", value);
            DissolveCutoff = value;
        }
    }
    private void OnValidate()
    {
#if UNITY_EDITOR
        if (!Application.isPlaying)
        {
            SetCutoff(DissolveCutoff);
        }
#endif
    }
}
