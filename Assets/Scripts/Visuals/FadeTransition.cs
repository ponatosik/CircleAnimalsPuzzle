using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : SceneTransition
{
    [SerializeField]
    private Image _sprite;


    private Sequence _fadeInTweener;
    private Sequence _fadeOutTweener;


    public override void BeginTransition()
    {
        _fadeInTweener.Play();
    }

    public override void EndTransition()
    {
        _fadeOutTweener.Play();
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _fadeInTweener = DOTween.Sequence();
        _fadeInTweener.TogglePause();
        _fadeInTweener.SetUpdate(true);
        _fadeInTweener.Append(_sprite.DOFade(0, 0));
        _fadeInTweener.Append(_sprite.DOFade(1, TransitionTime));

        _fadeOutTweener = DOTween.Sequence();
        _fadeOutTweener.TogglePause();
        _fadeOutTweener.SetUpdate(true);
        _fadeOutTweener.Append(_sprite.DOFade(0, TransitionTime));
        _fadeOutTweener.OnComplete(() => Destroy(gameObject));
    }

}
