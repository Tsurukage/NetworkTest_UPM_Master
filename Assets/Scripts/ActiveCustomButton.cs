using Assets.Plugin_.Easy_WiFi_Controller.Scripts.ServerControllers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class ActiveCustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        void Start()
    {
        if(this.GetComponent<CustomButtonServerController>() != null)
            this.GetComponent<CustomButtonServerController>().enabled = false;
    }

        public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<CustomButtonServerController>().enabled = true;
    }

        public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<CustomButtonServerController>().enabled = false;
    }
    }
}