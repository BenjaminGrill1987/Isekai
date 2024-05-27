using Isekai.Interface;
using UnityEngine;

namespace Isekai.Utility
{

    public class Gamestate : Singleton<Gamestate>
    {
        private Gamestates _currentState;

        public static Gamestates CurrentState { get => _Instance._currentState; }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _currentState = Gamestates.Init;
        }

        public static void TryToChangeState(Gamestates newState)
        {
            if (CurrentState == newState) return;

            switch (newState)
            {
                case Gamestates.Init:
                    {
                        break;
                    }
                case Gamestates.Menu:
                    {
                        MapManager.Mapchange("Menu");
                        break;
                    }
                case Gamestates.Options:
                    {
                        break;
                    }
                case Gamestates.Play:
                    {
                        if (CurrentState == Gamestates.Menu)
                        {
                            MapManager.Mapchange("TeleportCircle");
                        }
                        break;
                    }
                case Gamestates.Pause:
                    {
                        break;
                    }
                case Gamestates.PlayerMenu:
                    {
                        break;
                    }
                case Gamestates.Magic:
                    {
                        break;
                    }
                case Gamestates.Assigment:
                    {
                        break;
                    }
                case Gamestates.NPCSpeaking:
                    {
                        break;
                    }
                case Gamestates.StoryPlay:
                    {
                        break;
                    }
                case Gamestates.Quit:
                    {
                        MapManager.GameQuit();
                        break;
                    }
            }

            _Instance._currentState = newState;

            Debug.LogWarning($"New State: {_Instance._currentState}");
        }
    }
}