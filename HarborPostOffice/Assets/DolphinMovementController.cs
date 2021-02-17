using System.Collections;
using UnityEngine;

public class DolphinMovementController : MonoBehaviour
{

    [SerializeField]
    float m_NormalJumpSpeed;
    [SerializeField]
    float m_BigJumpSpeed;
    [SerializeField]
    AnimationCurve m_MovementCurve;
    private Coroutine movingCoroutine;

    public void MoveByJump(AnimationClip clip)
    {
        if (movingCoroutine != null)
        {
            StopCoroutine(movingCoroutine);
            movingCoroutine = null;
        }
        var _speed = m_NormalJumpSpeed;
        if (clip.name.Contains("Big"))
            _speed = m_BigJumpSpeed;
        movingCoroutine = StartCoroutine(Moving(clip.length, _speed));
    }

    private IEnumerator Moving(float total, float speed)
    {
        var time = 0.0f;

        while (time < total)
        {
            float t = m_MovementCurve.Evaluate(time / total) * speed;
            var p = transform.parent;
            p.position = p.position + p.forward * t;
            time += Time.deltaTime;
            yield return null;
        }

        movingCoroutine = null;
    }
}
