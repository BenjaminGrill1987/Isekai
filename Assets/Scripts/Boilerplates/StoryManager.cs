using Isekai.Input;
using Isekai.Interface;
using Isekai.Utility;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class StoryManager : Singleton<StoryManager>
{
    [SerializeField] private GameObject _storyCanvas;
    [SerializeField] private SpriteRenderer _storyImage;
    [SerializeField] private TextMeshProUGUI _storyText;
    [SerializeField] private List<Plot> _storyPlot = new List<Plot>();

    private Controlls _controller;
    private int _storyIndex = 0, _storyPlotIndex = 0;
    private bool _storyIsPlaying = false;

    private void OnEnable()
    {
        _controller.UI.Submit.performed += StoryTelling;
    }

    private void FixedUpdate()
    {
        if (_storyIsPlaying && Gamestate.CurrentState != Gamestates.StoryPlay)
        {
            Gamestate.TryToChangeState(Gamestates.StoryPlay);
            StoryTelling();
        }

        if (!_storyIsPlaying && Gamestate.CurrentState == Gamestates.StoryPlay)
        {
            Gamestate.TryToChangeState(Gamestates.Play);
        }
    }

    private void StoryTelling(InputAction.CallbackContext context)
    {
        if (Gamestate.CurrentState != Gamestates.StoryPlay) return;

        _storyImage.sprite = _storyPlot[_storyPlotIndex].Story[_storyIndex].Chracter;
        _storyText.text = _storyPlot[_storyPlotIndex].Story[_storyIndex].Story;

        _storyIndex++;
    }

    private void StoryTelling()
    {
        if (!_storyCanvas.activeSelf)
        {
            _storyCanvas.SetActive(true);
        }

        _storyImage.sprite = _storyPlot[_storyPlotIndex].Story[_storyIndex].Chracter;
        _storyText.text = _storyPlot[_storyPlotIndex].Story[_storyIndex].Story;

        _storyIndex++;
    }

    public void IsPlaying(bool isPlaying)
    {
        _storyIsPlaying = isPlaying;
    }
}
