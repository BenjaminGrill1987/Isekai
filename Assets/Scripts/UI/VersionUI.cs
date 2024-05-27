using UnityEngine;
using TMPro;

namespace Isekai.UI
{
    public class VersionUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textField;
        
        private void Start()
        {
            _textField.text = $"Version: {Application.version}";
        }
    }
}