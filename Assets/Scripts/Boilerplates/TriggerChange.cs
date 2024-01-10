using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChange : MonoBehaviour
{
    [SerializeField] private AssigmentLetter _assigmentLetter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) _assigmentLetter.ChangeCanBeInteract(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) _assigmentLetter.ChangeCanBeInteract(false);
    }

}
