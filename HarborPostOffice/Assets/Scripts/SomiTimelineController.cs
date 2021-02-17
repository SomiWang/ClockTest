using CinemaDirector;
using UnityEngine;
using UnityEngine.Playables;

[ExecuteInEditMode]
public class SomiTimelineController : MonoBehaviour
{
    [SerializeField]
    bool IsSync;
    [SerializeField]
    PlayableDirector[] m_PlayableDirectors;
    PlayableDirector playableDirector;
    [SerializeField]
    Cutscene m_Cutscene;

    private void OnEnable()
    {
        playableDirector = GetComponent<PlayableDirector>();
        if (!Application.isPlaying)
        {
            m_PlayableDirectors = FindObjectsOfType<PlayableDirector>();
        }
    }

    private void Update()
    {
        if (!Application.isPlaying && IsSync)
        {
            m_Cutscene.ScrubToTime((float)playableDirector.time);
            foreach (var i in m_PlayableDirectors)
            {
                i.time = playableDirector.time;
            }
        }
    }
}
