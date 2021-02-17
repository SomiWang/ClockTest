using UnityEngine;

namespace CinemaDirector.Extension
{
    [CutsceneItem("Effect", "Turn off fog", CutsceneItemGenre.GlobalItem)]
    public class TurnOffFogEvent : CinemaGlobalEvent
    {
        public override void Trigger()
        {
            RenderSettings.fog = false;
        }
    }
}