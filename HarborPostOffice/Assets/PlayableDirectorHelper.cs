using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayableDirector))]
public class PlayableDirectorHelper : MonoBehaviour
{
    private void Start()
    {
        var director = GetComponent<PlayableDirector>();
        director.played += OnPlayed;
        director.stopped += OnStop;
    }

    private void OnPlayed(PlayableDirector obj)
    {
        //if (obj.gameObject.name == "UnderWaterDirector")
            //SceneManager.LoadSceneAsync
    }

    private void OnStop(PlayableDirector obj)
    {
        //if (obj.gameObject.name == "UnderWaterDirector")



    }
}
