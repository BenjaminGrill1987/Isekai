using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Isekai.Interface;
using UnityEngine.EventSystems;

public class PanelController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _assigmentTitle, _assigmentDescription, _assigmentReward, _assigmentGoal;

    private AssigmentData _assigmentData;

    public void InitPanel(AssigmentData assigmentData)
    {
        _assigmentData = assigmentData;
        _assigmentTitle.text = _assigmentData.Name;
        _assigmentDescription.text = _assigmentData.DescriptionText;
        _assigmentReward.text = _assigmentData.AssigmentReward.ToString();
        _assigmentGoal.text = _assigmentData.AssigmentValue.ToString();
    }

    public void OnClick()
    {
        if (Gamestate.CurrentState != Gamestates.Assigment) return;
        if (AssigmentSystem.AssigmentListCount() < 3)
        {
            AssigmentSystem.AddAssigment(_assigmentData);
            Destroy(gameObject);
            if (transform.parent.gameObject.transform.childCount == 1) return;
            EventSystem.current.SetSelectedGameObject(transform.parent.gameObject.transform.GetChild(1).gameObject);
        }
    }
}
