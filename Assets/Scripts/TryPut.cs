using Assets.Nurface.DemoAssets.Scripts;
using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core.ControllerTypes;
using UnityEngine;

namespace Assets.Scripts
{
    public class TryPut : MonoBehaviour
    {
        bool isPressed;
        [SerializeField]
        private Transform targetIK, handBone, oriSpot, desSpot, targetObject;
        //private Demography handy;

        // Start is called before the first frame update
        void Start()
        {
            //handy = Demography.leftHand;
        }

        // Update is called once per frame
        void Update()
        {
            /*switch (handy)

             case Demography.leftHand:
                    targetIK = transform.Find("");
                    handBone = transform.Find("");
                    break;
                case Demography.rightHand:
                    targetIK = transform.Find("");
                    handBone = transform.Find("");
                    break;
            }*/

        }
        void HandToPatch(ButtonControllerType button)
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
            iTween.MoveTo(targetIK.gameObject, iTween.Hash("position", desSpot.position, "time", 2.0f));
        }
        void MoveBackFromDes()
        {
            iTween.MoveTo(targetIK.gameObject, iTween.Hash("position", oriSpot.position, "time", 2.0f, "onupdate", "ToggleParents", "onupdatetarget", gameObject));
        }
        void ToggleParents()
        {
            targetObject.SetParent(this.transform.parent, true);
            targetObject.localPosition = desSpot.localPosition;
            this.transform.localScale = Vector3.zero;
        }

    }
    public enum Demography
    {
        leftHand,
        rightHand
    }
}