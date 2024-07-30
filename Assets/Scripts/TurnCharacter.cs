using UnityEngine;

namespace Assets.Scripts
{
    public class TurnCharacter : MonoBehaviour
    {
        public Transform vrCamera, vrBody;
        public float toggleAngle = 60.0f;
        public bool turnLeft;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            vrBody.rotation = Quaternion.Euler(0f, vrCamera.eulerAngles.y, 0f);

        }
    }
}