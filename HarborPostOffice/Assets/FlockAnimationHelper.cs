using System.Collections;
using UnityEngine;

public class FlockAnimationHelper : MonoBehaviour
{
    [SerializeField]
    private string m_FlapClipName;
    [SerializeField]
    private Vector2 m_DelayTimeRange;

    void OnEnable()
    {
        var _anims = GetComponentsInChildren<Animator>();
        foreach (var i in _anims)
        {
            if (i.gameObject == this.gameObject) continue;
            var _sec = Random.Range(m_DelayTimeRange.x, m_DelayTimeRange.y);
            StartCoroutine(_DelayToPlay(i, _sec));
        }
    }

    private IEnumerator _DelayToPlay(Animator anim, float sec)
    {
        yield return new WaitForSeconds(sec);
        anim.Play(m_FlapClipName);
    }
}
