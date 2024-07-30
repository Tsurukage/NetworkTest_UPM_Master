using UnityEngine;

namespace Assets.Plugin_.Easy_WiFi_Controller.Scripts.Miscellaneous
{
    [AddComponentMenu("EasyWiFiController/Miscellaneous/CameraFollowBall")]
    public class CameraFollowBall : MonoBehaviour {

        public GameObject objectToFollow;

        Transform objectTransform;
        Vector3 newPosition;

        // Use this for initialization
        void Start () {

        objectTransform = objectToFollow.transform;
    }
	
        // Update is called once per frame
        void Update () {
        newPosition = objectTransform.position;
        newPosition.z -= 5f;

        this.transform.position = newPosition;
    }
    }
}