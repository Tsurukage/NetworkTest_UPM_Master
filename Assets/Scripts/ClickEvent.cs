using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core.ControllerTypes;
using UnityEngine;

namespace Assets.Scripts
{
    public class ClickEvent : MonoBehaviour
    {
        bool isPressed;

        void Clicker(ButtonControllerType button)
    {
        isPressed = button.BUTTON_STATE_IS_PRESSED;

        if (isPressed)
        {
            //ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            Input.GetButtonDown("Fire1");
        }
    }
    }
}