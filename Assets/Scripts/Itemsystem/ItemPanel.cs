using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Isekai.Itemsystem
{

    public class ItemPanel : MonoBehaviour
    {
        [SerializeField] private Image _sprite;
        [SerializeField] private TextMeshProUGUI _textMeshPro;


        public void BuildPanel(Sprite newSprite, int value)
        {
            _sprite.sprite = newSprite;
            _textMeshPro.text = value.ToString();
        }
    }
}