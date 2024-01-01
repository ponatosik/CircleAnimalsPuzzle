using DG.Tweening;
using UnityEngine;

namespace CircleAnimalsPuzzle.Visuals
{
	public class UIFadeEffect : TransitionEffect
	{
		[SerializeField]
		private CanvasGroup _uiGroup;

		private Sequence _fadeInTweener;
		private Sequence _fadeOutTweener;

		public override void BeginTransition()
		{
			Debug.Log("Begin");
			_fadeInTweener.Rewind();
			_fadeInTweener.Play();
		}

		public override void EndTransition()
		{
			Debug.Log("End");
			_fadeOutTweener.Rewind();
			_fadeOutTweener.Play();
		}

		private void Awake()
		{
			DontDestroyOnLoad(gameObject);

			_fadeInTweener = DOTween.Sequence().SetAutoKill(false);
			_fadeInTweener.Pause();
			_fadeInTweener.SetUpdate(true);
			_fadeInTweener.Append(_uiGroup.DOFade(0, 0));
			_fadeInTweener.Append(_uiGroup.DOFade(1, TransitionTime));
			_fadeInTweener.AppendCallback(() =>
			{
				_uiGroup.blocksRaycasts = true;
				_uiGroup.interactable = true;
			});

			_fadeOutTweener = DOTween.Sequence().SetAutoKill(false);
			_fadeOutTweener.Pause();
			_fadeOutTweener.SetUpdate(true);
			_fadeOutTweener.Append(_uiGroup.DOFade(0, TransitionTime));
			_fadeOutTweener.AppendCallback(() =>
			{
				_uiGroup.blocksRaycasts = false;
				_uiGroup.interactable = false;
			});

		}

	}
}