using UnityEngine;

namespace CircleAnimalsPuzzle.Visuals
{
	public abstract class TransitionEffect : ObjectEffect
	{
		[field: SerializeField]
		public float TransitionTime { get; set; } = 1f;
		public abstract void BeginTransition();
		public abstract void EndTransition();

		public override void Activate()
		{
			BeginTransition();
		}

		public override void Deactivate()
		{
			EndTransition();
		}
	}
}