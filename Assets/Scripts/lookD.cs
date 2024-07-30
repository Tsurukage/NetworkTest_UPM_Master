using UnityEngine;

namespace Assets.Scripts
{
    public class lookD : MonoBehaviour
    {
        public Transform vrCamera;
        public float toggleAngle = 20.0f;
        public float speed = 2.0f;
        public bool moveForward;
        private CharacterController cc;
        public float mangni;

        void Start()
    {
        cc = GetComponent<CharacterController>();
    }

        void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            moveForward = !moveForward;
        }

        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForward = true;
            mangni = cc.velocity.magnitude;
        }
        else
        {
            moveForward = false;
            mangni = 0;
        }

        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }

    }
    }
}