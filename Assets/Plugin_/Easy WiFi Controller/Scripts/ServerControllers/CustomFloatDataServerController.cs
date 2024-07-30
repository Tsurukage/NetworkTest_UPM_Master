using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core;
using Assets.Plugin_.Easy_WiFi_Controller.Scripts.Core.BackchannelTypes;
using UnityEngine;

namespace Assets.Plugin_.Easy_WiFi_Controller.Scripts.ServerControllers
{

    [AddComponentMenu("EasyWiFiController/Server/DataControls/Custom Float")]
    public class CustomFloatDataServerController : MonoBehaviour, IServerController
    {

        public string control = "FloatData1";
        public EasyWiFiConstants.PLAYER_NUMBER player = EasyWiFiConstants.PLAYER_NUMBER.Player1;
        public string notifyMethod = "yourMethod";


        //runtime variables
        //we reuse the backchannel data types even though this is a forward channel
        FloatBackchannelType[] floatController = new FloatBackchannelType[EasyWiFiConstants.MAX_CONTROLLERS];
        int currentNumberControllers = 0;

        void OnEnable()
        {
            EasyWiFiController.On_ConnectionsChanged += checkForNewConnections;

            //do one check at the beginning just in case we're being spawned after startup and after the callbacks
            //have already been called
            if (floatController[0] == null && EasyWiFiController.lastConnectedPlayerNumber >= 0)
            {
                EasyWiFiUtilities.checkForClient(control, (int)player, ref floatController, ref currentNumberControllers);
            }
        }

        void OnDestroy()
        {
            EasyWiFiController.On_ConnectionsChanged -= checkForNewConnections;
        }

        // Update is called once per frame
        void Update()
        {
            //iterate over the current number of connected controllers
            for (int i = 0; i < currentNumberControllers; i++)
            {
                if (floatController[i] != null && floatController[i].serverKey != null && floatController[i].logicalPlayerNumber != EasyWiFiConstants.PLAYERNUMBER_DISCONNECTED)
                {
                    mapDataStructureToAction(i);
                }
            }
        }


        public void mapDataStructureToAction(int index)
        {
            SendMessage(notifyMethod, floatController[index], SendMessageOptions.DontRequireReceiver);
        }

        public void checkForNewConnections(bool isConnect, int playerNumber)
        {
            EasyWiFiUtilities.checkForClient(control, (int)player, ref floatController, ref currentNumberControllers);
        }
    }

}
