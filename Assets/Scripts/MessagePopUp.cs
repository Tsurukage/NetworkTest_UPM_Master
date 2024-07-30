using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class MessagePopUp : MonoBehaviour
    {
        private static MessagePopUp instance;
        [SerializeField] private Transform text_container;
        [SerializeField] private Text text_message;

        private static Transform Text_container { get; set; }
        private static Text Text_message { get; set; }
    
        public void Display(bool display) => Text_container.gameObject.SetActive(display);

        void Start()
    {
        instance = this;
        Text_container = text_container;
        Text_message = text_message;

        Display(false);
    }

        public static void PopUpMessage(string message)
    {
        Text_message.text = message;
        instance.Display(true);
    }

        public static void ClosePopUp()
    {
        instance.Display(false);
    }
    }
}