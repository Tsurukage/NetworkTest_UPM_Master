using Assets.Nurface.DemoAssets.Scripts;
using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core.ControllerTypes;
using UnityEngine;

namespace Assets.Scripts
{
    public class PutHere : MonoBehaviour
    {
        [SerializeField]
        private Transform targetIK, oriPos, desPos;
        bool isPressed;

        void HandMove(ButtonControllerType button)
    {
        isPressed = button.BUTTON_STATE_IS_PRESSED;
        if (isPressed)
        {
            MoveToDes();
        }
        else
        {
            MoveBackFromDes();
        }
    }

        void MoveToDes()
    {
        iTween.MoveTo(targetIK.gameObject, iTween.Hash("position", desPos.position, "time", 2.0f));
    }
        void MoveBackFromDes()
    {
        iTween.MoveTo(targetIK.gameObject, iTween.Hash("position", oriPos.position, "time", 2.0f));
    }
    }
}