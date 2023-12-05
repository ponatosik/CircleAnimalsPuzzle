using UnityEngine;

public class Starsinlevel : MonoBehaviour
{

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public static Starsinlevel instance;

    private void Awake()
    {
        instance = this;
    }

    public static void OutputCollectedNumber()
    {
        int collectedNumber = GameManager.Instance.Collectables.GetCollectedNumber();
        Debug.Log($"Number of collectibles: {collectedNumber}");

        ActivateStars(collectedNumber);
    }

    private static void ActivateStars(int collectedNumber)
    {
        if (collectedNumber >= 1)
        {
            instance.star1.SetActive(true);
        }
        if (collectedNumber >= 2)
        {
            instance.star2.SetActive(true);
        }
        if (collectedNumber >= 3)
        {
            instance.star3.SetActive(true);
        }
    }

}