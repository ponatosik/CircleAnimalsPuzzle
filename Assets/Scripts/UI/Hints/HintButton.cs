using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintButton : MonoBehaviour
{

    public void DisplayRandomHint() 
    {
		HintManager hintManager = HintManager.Instance;
		hintManager.DisplayRandomHint();
		if (hintManager.HintsLeft == 0)
		{
			Hide();
		}
	}

	public void Start()
	{
		if (HintManager.Instance.HintsLeft == 0) 
		{
			Hide();
		}
	}

	private void Hide() 
	{
		gameObject.SetActive(false);
	}
}
