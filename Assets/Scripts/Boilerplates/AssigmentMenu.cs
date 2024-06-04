using TMPro;
using UnityEngine;

public class AssigmentMenu : MonoBehaviour
{
    [SerializeField] private GameObject _assigmentPanel;
    [SerializeField] private Transform _content;
    [SerializeField] private TextMeshProUGUI _assigmentValue;

    private void OnEnable()
    {
        foreach (var entry in AssigmentSystem.GetAssigmentList())
        {
            var panel = Instantiate(_assigmentPanel, _content);
            panel.GetComponent<AssigmentPanel>().SetPanelText(entry.Name, entry.DescriptionText, entry.AssigmentReward, entry.AssigmentValue, entry.GetItemData().Id, entry.Type);
        }

        _assigmentValue.text = $"{AssigmentSystem.AssigmentListCount()}/3";
    }

    private void OnDisable()
    {
        foreach (Transform child in _content)
        {
            Destroy(child.gameObject);
        }
    }
}
