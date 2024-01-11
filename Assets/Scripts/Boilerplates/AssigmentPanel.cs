using Isekai.Interface;
using TMPro;
using UnityEngine;

public class AssigmentPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title, _description, _reward, _goal;

    private int _amount;

    public void SetPanelText(string newTitle, string newDescription, int newReward, int newGoal, int newIDd, AssigmentType newType)
    {
        _title.text = newTitle;
        _description.text = newDescription;
        _reward.text = newReward.ToString();

        if (newType == AssigmentType.collect)
        {
            SetAmount(InventorySystem.GetItemAmount(newIDd));
        }

        _goal.text = $"{_amount}/{newGoal.ToString()}";
    }

    public void SetAmount(int newAmount)
    {
        _amount = newAmount;
    }
}
