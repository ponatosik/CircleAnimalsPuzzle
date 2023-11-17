using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class StartLevel : MonoBehaviour
{

    public List<ButtonInfo> buttons;

    [System.Serializable]
    public class ButtonInfo
    {
        public Button button; 
        public Image buttonImage; 
        public Sprite lockedSprite; 
        public Sprite buttonSprite; 
        public Level initialLevel; 
        private Image lockImage;

        public void Initialize()
        {
            if (initialLevel != null && !initialLevel.Unlocked)
            {
                SetButtonSprite();
            }

            button.onClick.AddListener(() => StartThisLevel(initialLevel));
        }

        public void StartThisLevel(Level level)
        {
            if (level != null && level.Unlocked)
            {
                LevelSystem.Instance.LoadLevel(level);
            }
        }

        private void SetButtonSprite()
        {
            if (buttonImage != null && lockedSprite != null)
            {
                buttonImage.sprite = buttonSprite;

                AddLockImage();
            }
            else
            {
                Debug.LogError("Button Image component or locked sprite not assigned.");
            }
        }

        private void AddLockImage()
        {
            GameObject lockObject = new GameObject("Lock");
            lockObject.transform.SetParent(buttonImage.transform);

            lockImage = lockObject.AddComponent<Image>();

            lockImage.sprite = lockedSprite;

            lockImage.rectTransform.localPosition = new Vector3(50f, -50f, 0f);
            lockImage.rectTransform.rotation = Quaternion.Euler(0f, 0f, 45f);
            lockImage.rectTransform.sizeDelta = new Vector2(130f, 164f);
            lockImage.rectTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    void Start()
    {
        foreach (var buttonInfo in buttons)
        {
            buttonInfo.Initialize();
        }
    }
}