using UnityEngine;

namespace CircleAnimalsPuzzle.Visuals
{
	public abstract class ObjectEffect : MonoBehaviour
	{
		public abstract void Activate();
		public abstract void Deactivate();
		public void SetEffectActive(bool activate)
		{
			if (activate)
			{
				Activate();
			}
			else
			{
				Deactivate();
			}
		}
	}
}