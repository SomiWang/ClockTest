using UnityEngine;

namespace CinemaDirector.Extension
{
    [CutsceneItem("Effect", "Play clock dissolve effect", CutsceneItemGenre.GlobalItem)]
    public class PlayClockEffectEvent : CinemaGlobalEvent
    {
        [SerializeField]
        DissolveEffect m_DissolveEffect;

        public override void Trigger()
        {
            m_DissolveEffect?.Play();
        }
    }
}