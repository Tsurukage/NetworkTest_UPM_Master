using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core;
using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core.BackchannelTypes;
using UnityEngine;

namespace Assets.Plugin_.Easy_WiFi_Controller.Scripts.ClientBackchannel
{

    [AddComponentMenu("EasyWiFiController/Client/Backchannels/Double Backchannel")]
    public class DoubleClientBackchannel : MonoBehaviour, IClientBackchannel
    {

        public string controlName = "Double1";
        public string notifyMethod = "yourMethod";

        //runtime variables
        DoubleBackchannelType doubleBackchannel = new DoubleBackchannelType();
        string backchannelKey;

        void Awake()
        {
            backchannelKey = EasyWiFiController.registerControl(EasyWiFiConstants.BACKCHANNELTYPE_DOUBLE, controlName);
            doubleBackchannel = (DoubleBackchannelType)EasyWiFiController.controllerDataDictionary[backchannelKey];
        }

        // Update is called once per frame
        void Update()
        {
            //if we have a populated server key then we know where to look in the data structure
            if (doubleBackchannel.serverKey != null)
            {
                mapDataStructureToMethod();
            }
        }


        public void mapDataStructureToMethod()
        {
            SendMessage(notifyMethod, doubleBackchannel, SendMessageOptions.DontRequireReceiver);
        }
    }

}
