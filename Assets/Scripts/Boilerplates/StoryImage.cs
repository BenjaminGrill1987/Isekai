using UnityEngine;

[CreateAssetMenu(fileName = "Story to Image", menuName = "Story/Story to Image", order = 1)]
public class StoryImage : ScriptableObject
{
    [SerializeField] private Sprite _character;
    [SerializeField] private string _story;

    public Sprite Chracter => _character;
    public string Story => _story;

}
