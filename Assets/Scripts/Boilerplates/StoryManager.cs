using Isekai.Interface;
using Isekai.Utility;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StoryManager : Singleton<StoryManager>
{
    [SerializeField] private GameObject _storyCanvas;
    [SerializeField] private Image _storyImage;
    [SerializeField] private TextMeshProUGUI _storyText;
    [SerializeField] private List<Plot> _storyPlot = new List<Plot>();

    private int _storyIndex = 0, _storyPlotIndex = 0;
    private bool _storyIsPlaying = false;

    private void OnEnable()
    {
        InputManager.Input.UI.Submit.performed += StoryTelling;
    }

    private void Start()
    {
        _storyIsPlaying = true;
    }

    private void FixedUpdate()
    {
        if (_storyIsPlaying && Gamestate.CurrentState != Gamestates.StoryPlay)
        {
            Debug.Log("Start");

            Gamestate.TryToChangeState(Gamestates.StoryPlay);
            StoryTelling();
        }

        if (!_storyIsPlaying && Gamestate.CurrentState == Gamestates.StoryPlay)
        {
            Debug.Log("End");
            Gamestate.TryToChangeState(Gamestates.Play);
            CloseStoryBoard();
        }
    }

    private void StoryTelling(InputAction.CallbackContext context)
    {
        Debug.Log("Hurra");
        if (Gamestate.CurrentState != Gamestates.StoryPlay) return;

        if (_storyPlot[_storyPlotIndex].Story.Count == _storyIndex)
        {
            _storyIsPlaying = false;
            return;
        }

        _storyImage.sprite = _storyPlot[_storyPlotIndex].Story[_storyIndex].Chracter;
        _storyText.text = _storyPlot[_storyPlotIndex].Story[_storyIndex].Story;

        _storyIndex++;
    }

    private void CloseStoryBoard()
    {
        _storyIndex = 0;
        _storyPlotIndex++;
        _storyCanvas.SetActive(false);
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