using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core.ControllerTypes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class SimulateClicker : MonoBehaviour
    {
        bool isPressed;

        void ClickSimulate(ButtonControllerType button)
    {
        isPressed = button.BUTTON_STATE_IS_PRESSED;
        if (isPressed)
        {
            ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
        }        
    }
    }
}