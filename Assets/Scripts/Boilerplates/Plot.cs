using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plot", menuName = "Story/Plot",order = 1)]
public class Plot : ScriptableObject
{
    [SerializeField] private List<StoryImage> _story = new List<StoryImage>();

    public List<StoryImage> Story => _story;
}