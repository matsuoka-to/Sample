using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

using System;

public class FadeManager : SingletonMonoBehaviour<FadeManager>
{
    [SerializeField]
    Image fade;

    const float speed = 1.0f;

    public void FadeIn(Action callback = null)
    {
        fade.color = new Color(0, 0, 0, 1.0f);
        fade.DOFade(0, speed).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public void FadeOut(Action callback = null)
    {
        fade.color = new Color(0, 0, 0, 0.0f);
        fade.DOFade(1, speed).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            callback?.Invoke();
        });
    }

}
