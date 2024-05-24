using UnityEngine;

public class BlackBoard : MonoBehaviour
{
    [SerializeField] GameObject _content, _assigmentPanel;

   // private void OnEnable()
   // {
   //     Debug.Log("Aktiv");
   //     for(int i = 0;i<3;i++)
   //     {
   //         var panel = Instantiate(_assigmentPanel,_content.transform);
   //
   //     }
   // }
   //
   // private void OnDisable()
   // {
   //     foreach(Transform child  in _content.transform)
   //     {
   //         Destroy(child.gameObject);
   //     }
   //     Debug.Log("Deaktiviert");
   // }
}
