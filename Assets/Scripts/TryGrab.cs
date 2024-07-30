using Assets.Nurface.DemoAssets.Scripts;
using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core.ControllerTypes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class TryGrab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        bool isPressed;
        bool gazeAt;
        [SerializeField]
        private Transform targetIK, handBone, oriSpot, desSpot, posPatch;

        public void OnPointerEnter(PointerEventData eventData)
    {
        gazeAt = true;
    }
        public void OnPointerExit(PointerEventData eventData)
    {
        gazeAt = false;
    }

        // Start is called before the first frame update
        void Start()
    {
        posPatch.localScale = Vector3.zero;
    }

        // Update is called once per frame
        void Update()
    {
        
    }
        void HandToItem(ButtonControllerType button)
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
        if(handBone.childCount == 1)
        {
            Debug.Log("Put down the item in your hand 1st");
        }
        else if(handBone.childCount == 0)
        {
            this.transform.SetParent(handBone, true);
            this.transform.localPosition = Vector3.zero;
            posPatch.localScale = new Vector3(0.1f, 0.01f, 0.1f);
        }
    }
    }
}