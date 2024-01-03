using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SkinsShop : MonoBehaviour
{
    [System.Serializable]
    public class ButtonInfo
    {
        public Button mainButton;
        public Button greyButton;
        public int requiredStars;
        public string animalName;
        public TextMeshProUGUI buttonTextMeshPro;
    }

    public List<ButtonInfo> buttonList;

    private void Start()
    {
        string selectedAnimal = PlayerPrefs.GetString("SelectedAnimal", "");
        if (!string.IsNullOrEmpty(selectedAnimal))
        {
            foreach (var buttonInfo in buttonList)
            {
                if (buttonInfo.animalName == selectedAnimal)
                {
                    if (buttonInfo.buttonTextMeshPro != null)
                    {
                        buttonInfo.buttonTextMeshPro.text = "Selected";
                    }
                }
                else
                {
                    if (buttonInfo.buttonTextMeshPro != null)
                    {
                        buttonInfo.buttonTextMeshPro.text = "Select";
                    }
                }
            }

        }

        UpdateButtonStates();
    }


    private void UpdateButtonStates()
    {
        foreach (var buttonInfo in buttonList)
        {
            if (LevelSystem.Instance.TotalStarsCollected >= buttonInfo.requiredStars)
            {
                buttonInfo.mainButton.interactable = true;
                buttonInfo.greyButton.gameObject.SetActive(false);

                buttonInfo.mainButton.onClick.RemoveAllListeners();
                buttonInfo.mainButton.onClick.AddListener(() => SelectAnimal(buttonInfo));
            }
            else
            {
                buttonInfo.mainButton.interactable = false;
                buttonInfo.greyButton.gameObject.SetActive(true);
            }
        }
    }

    private void SelectAnimal(ButtonInfo selectedButtonInfo)
    {
        foreach (var buttonInfo in buttonList)
        {
            if (buttonInfo.buttonTextMeshPro != null)
            {
                buttonInfo.buttonTextMeshPro.text = "Select";
            }
        }

        PlayerPrefs.SetString("SelectedAnimal", selectedButtonInfo.animalName);
        PlayerPrefs.Save();

        if (selectedButtonInfo.buttonTextMeshPro != null)
        {
            selectedButtonInfo.buttonTextMeshPro.text = "Selected";
        }

    }
}
