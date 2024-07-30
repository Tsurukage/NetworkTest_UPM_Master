using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core;
using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core.BackchannelTypes;
using UnityEngine;

namespace Assets.Plugin_.Easy_WiFi_Controller.Scripts.ClientBackchannel
{

    [AddComponentMenu("EasyWiFiController/Client/Backchannels/Decimal Backchannel")]
    public class DecimalClientBackchannel : MonoBehaviour, IClientBackchannel
    {

        public string controlName = "Decimal1";
        public string notifyMethod = "yourMethod";

        //runtime variables
        DecimalBackchannelType decimalBackchannel = new DecimalBackchannelType();
        string backchannelKey;

        void Awake()
        {
            backchannelKey = EasyWiFiController.registerControl(EasyWiFiConstants.BACKCHANNELTYPE_DECIMAL, controlName);
            decimalBackchannel = (DecimalBackchannelType)EasyWiFiController.controllerDataDictionary[backchannelKey];
        }

        // Update is called once per frame
        void Update()
        {
            //if we have a populated server key then we know where to look in the data structure
            if (decimalBackchannel.serverKey != null)
            {
                mapDataStructureToMethod();
            }
        }


        public void mapDataStructureToMethod()
        {
            SendMessage(notifyMethod, decimalBackchannel, SendMessageOptions.DontRequireReceiver);
        }
    }

}
