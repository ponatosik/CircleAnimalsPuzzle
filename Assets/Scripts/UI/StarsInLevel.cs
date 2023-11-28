using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Starsinlevel : MonoBehaviour
{

    public static void OutputCollectedNumber()
    {
        int collectedNumber = GameManager.Instance.Collectables.GetCollectedNumber();
        Debug.Log($"Number of collectibles: {collectedNumber}");
    }

    [SerializeField]
    private GameObject yellowStarPrefab;  
    private GameObject emptyStarPrefab;

    public void DisplayCollectedNumber(int collectedNumber)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Display stars based on the collectedNumber
        for (int i = 0; i < 3; i++)
        {
            GameObject star;

            if (i < collectedNumber)
            {
                star = Instantiate(yellowStarPrefab, transform);
            }
            else
            {
                star = Instantiate(emptyStarPrefab, transform);
            }

            Image starImage = star.GetComponent<Image>();
            RectTransform rectTransform = star.GetComponent<RectTransform>();

            rectTransform.sizeDelta = new Vector2(300f, 289f) * 0.25f;

            float xPos = 0f;
            float yPos = 0f;

            if (i == 0)
            {
                xPos = -70f;
                yPos = -20f;
            }
            else if (i == 1)
            {
                xPos = 0f;
                yPos = -70f;
            }
            else if (i == 2)
            {
                xPos = 70f;
                yPos = -20f;
            }

            rectTransform.localPosition = new Vector3(xPos, yPos, 0f);
        }
    }
}