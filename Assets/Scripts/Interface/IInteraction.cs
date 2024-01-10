using UnityEngine.InputSystem;

namespace Isekai.Interface
{

    interface IInteraction
    {
        bool CanBeInteract { get; }

        void ChangeCanBeInteract(bool newState);

        void Submit();

        void Cancel(InputAction.CallbackContext context);
    }
}