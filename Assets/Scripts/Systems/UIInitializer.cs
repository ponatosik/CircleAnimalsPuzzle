using UnityEngine;
using UnityEngine.Serialization;

public class UIInitializer : MonoBehaviour
{
	[SerializeField]
	private GameObject _UIPrefab;

	private void Awake()
	{
		if (!GameObject.FindGameObjectWithTag(_UIPrefab.tag)) 
		{
			Instantiate(_UIPrefab);
		}
	}
}
