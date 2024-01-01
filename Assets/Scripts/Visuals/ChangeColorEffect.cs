using UnityEngine;

namespace CircleAnimalsPuzzle.Visuals
{
	public class ChangeColorEffect : ObjectEffect
	{
		[SerializeField]
		private SpriteRenderer _sprite;
		[SerializeField]
		private Color _color;

		private Color _defaultColor;

		public override void Activate()
		{
			_sprite.color = _color;
		}

		public override void Deactivate()
		{
			_sprite.color = _defaultColor;
		}

		void Awake()
		{
			_defaultColor = _sprite.color;
		}
	}
}