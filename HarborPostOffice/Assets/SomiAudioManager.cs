using UnityEngine;
using UnityEngine.Playables;

public class SomiAudioManager : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector[] m_Directors;

    private void Awake()
    {
        var objs = FindObjectsOfType<SomiAudioManager>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        foreach (var i in m_Directors)
        {
            if (i.gameObject.name != PlayableDirectorManager.CurrentScene.ToString())
                i.Stop();
            else i.Play();
        }
    }
}


