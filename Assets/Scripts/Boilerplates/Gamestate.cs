using Isekai.Interface;


public class Gamestate : Singleton<Gamestate>
{
    private Gamestates _currentState;

    public static Gamestates CurrentState { get => _Instance._currentState; }

    private void Start()
    {
        TryToChangeState(Gamestates.Play);
    }

    public static void TryToChangeState(Gamestates newState)
    {
        if (CurrentState == newState) return;

        switch (newState)
        {
            case Gamestates.Menu:
                {
                    break;
                }
            case Gamestates.Options:
                {
                    break;
                }
            case Gamestates.Play:
                {
                    if(CurrentState != Gamestates.Pause)
                    {

                    }
                    break;
                }
            case Gamestates.Pause:
                {
                    break;
                }
            case Gamestates.Inventory:
                {
                    break;
                }
            case Gamestates.Assigment:
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

    }
}
