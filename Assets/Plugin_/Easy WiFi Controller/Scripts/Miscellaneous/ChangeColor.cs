using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core.ControllerTypes;
using UnityEngine;

namespace Assets.Plugin_.Easy_WiFi_Controller.Scripts.Miscellaneous
{
    [AddComponentMenu("EasyWiFiController/Miscellaneous/ChangeColor")]
    public class ChangeColor : MonoBehaviour {

        MeshRenderer myRenderer;
        Material myMaterial;
        Color originalColor;
        bool isPressed;

        void Start() 
    {
        myRenderer = this.GetComponent<MeshRenderer>();
        myMaterial = myRenderer.material;
        originalColor = myMaterial.color;
    }

        void changeColor(ButtonControllerType button)
    {
        isPressed = button.BUTTON_STATE_IS_PRESSED;

        if (isPressed)
        {
            myMaterial.color = Color.green;
        }
        else
            myMaterial.color = originalColor;

    }
    }
}