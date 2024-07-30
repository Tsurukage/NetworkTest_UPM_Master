namespace Assets.Plugin_.Easy_WiFi_Controller.Scripts.ServerControllers
{

    interface IServerController
    {
        void mapDataStructureToAction(int index);
        void checkForNewConnections(bool isConnect, int playerNumber);
    }

}
