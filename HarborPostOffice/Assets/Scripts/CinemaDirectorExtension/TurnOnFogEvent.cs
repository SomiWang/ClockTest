using UnityEngine;

namespace CinemaDirector.Extension
{
    [CutsceneItem("Effect", "Turn on fog", CutsceneItemGenre.GlobalItem)]
    public class TurnOnFogEvent : CinemaGlobalEvent
    {
        [SerializeField]
        Color m_FogColor;

        public override void Trigger()
        {
            RenderSettings.fogColor = m_FogColor;
            RenderSettings.fog = true;
        }
    }
}