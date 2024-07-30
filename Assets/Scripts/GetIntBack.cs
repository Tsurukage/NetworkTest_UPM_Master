using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core.BackchannelTypes;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GetIntBack : MonoBehaviour
    {
        [SerializeField]
        private Text intHere;

        // Start is called before the first frame update
        void Start()
    {
        intHere = this.gameObject.GetComponent<Text>();
    }

        public void UpdateInt(IntBackchannelType intChannel)
    {
        intHere.text = intChannel.INT_VALUE.ToString();
    }
    }
}