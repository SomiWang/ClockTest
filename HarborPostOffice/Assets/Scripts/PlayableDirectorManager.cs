using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[ExecuteInEditMode]
public class PlayableDirectorManager : MonoBehaviour
{
    [SerializeField]
    private SceneType m_CurrentSceneType;
    [SerializeField]
    private List<DirectorConfig> m_DirectorConfigs;
    [SerializeField]
    private PlayableDirector[] m_PlayableDirectors;
    [SerializeField]
    private GameObject[] m_Animals;
    public static SceneType CurrentScene;

    public static PlayableDirectorManager Instance;

    private void Awake()
    {
        Instance = this;
        CurrentScene = m_CurrentSceneType;
        m_PlayableDirectors = FindObjectsOfType<PlayableDirector>();
        foreach (var i in m_PlayableDirectors)
        {
            i.Stop();
            i.initialTime = 0.0f;
        }
    }
    private void OnEnable()
    {
        if (!Application.isPlaying)
            m_PlayableDirectors = FindObjectsOfType<PlayableDirector>();
        else if (m_DirectorConfigs != null && _TryGetDirector(m_CurrentSceneType, out DirectorConfig director))
        {
            foreach (var j in m_Animals)
            {
                j.SetActive(director.HasAnimals);
            }

            foreach (var i in director.Directors)
            {
                i.Play();
            }
        }
    }

    private bool _TryGetDirector(SceneType type, out DirectorConfig director)
    {
        director = m_DirectorConfigs.Find(x => x.Type == type);
        return director != null;
    }
}

[System.Serializable]
public class DirectorConfig
{
    public SceneType Type;
    public PlayableDirector[] Directors;
    public bool HasAnimals;
}
public enum SceneType
{
    Clock,
    UnderWater,
    Ending
}



