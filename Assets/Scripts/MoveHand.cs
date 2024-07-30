using Assets.Nurface.DemoAssets.Scripts;
using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core.ControllerTypes;
using UnityEngine;

namespace Assets.Scripts
{
    public class MoveHand : MonoBehaviour
    {

        bool isPressed;
        [SerializeField]
        private bool isPicked = false;
        [SerializeField]
        private Transform targetIK, oriPos, desPos, posPatch;

        void Start()
    {
        posPatch.localScale = Vector3.zero;
    }
        void Update()
    {
        
    }
        void RightHandMove(ButtonControllerType button)
    {
        isPressed = button.BUTTON_STATE_IS_PRESSED;
        if (isPressed)
        {
            MoveToDes();
        }
        else if(this.transform.parent.name.Contains("hand") || !isPressed || this.transform.parent == null)
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
        iTween.MoveTo(targetIK.gameObject, iTween.Hash("position", oriPos.position, "oncomplete", "ChangeBool", "oncompletetarget", gameObject));
    }

        void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Hand"))
        {
            if (!isPicked)
            {
                transform.parent = other.transform;
                transform.localPosition = Vector3.zero;
            }
            else
            {
                Debug.Log("Item in hand");
            }
        }
        if (other.tag == "Respawn")
        {
            if (!isPicked)
            {
                Debug.Log("");
            }
            else
            {
                transform.parent = other.transform.parent;
                transform.localPosition = Vector3.zero;
            }
        }
    }
        void ChangeBool()
    {
        if (transform.parent.name.Contains("Hand"))
        {
            posPatch.localScale = new Vector3(0.1f, 0.01f, 0.1f);
            isPicked = true;
        }
        if (transform.parent.name.Contains("Pos"))
        {
            posPatch.localScale = Vector3.zero;
            isPicked = false;
        }
    }
    }
}