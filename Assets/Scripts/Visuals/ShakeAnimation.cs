using UnityEngine;

namespace CircleAnimalsPuzzle.Visuals
{
	[RequireComponent(typeof(Animator))]
	public class ShakeAnimation : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem _shakeParticles;
		[SerializeField]
		private bool _playOnStart = true;
		private Animator _animator;

		private void Start()
		{
			_animator = GetComponent<Animator>();
			if (_playOnStart)
			{
				Shake();
			}
		}


		// Update is called once per frame
		public void TrigerParticle()
		{
			if (_shakeParticles != null)
			{
				_shakeParticles.Play();
			}
		}

		public void Shake()
		{
			_animator.Play("Shake");
		}
	}
}