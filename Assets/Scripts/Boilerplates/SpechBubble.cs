using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpechBubble : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name, _speech;
    [SerializeField] Image _image;

    public void Init(string newName, string newSpeech, Sprite newSprite)
    {
        _name.text = $"{newName}:";
        _speech.text = newSpeech;
        _image.sprite = newSprite;
    }
}
