using Assets.Nurface.DemoAssets.Scripts;
using UnityEngine;

namespace Assets.Scenes
{
    public class RotateBody : MonoBehaviour
    {
        public Transform vrMainObject;
        public float cameraOffsetXZ, cameraOffsetY;
        public float bodyTurningAngle = 30f;
        private Vector3 vrRot, myRot;
        private Transform vrCamera;
        private float x, z;

        [SerializeField]
        private Transform oriLF, oriRH, ikLF, ikRH;

        // Start is called before the first frame update
        void Start()
    {
        vrCamera = Camera.main.transform;
    }

        // Update is called once per frame
        void Update()
    {
        vrRot = vrCamera.rotation.eulerAngles;
        myRot = transform.rotation.eulerAngles;

        if(Mathf.DeltaAngle(vrRot.y, myRot.y) > bodyTurningAngle)
        {
            if (!gameObject.GetComponent<iTween>())
            {
                //Debug.Log("Turn LEFT!");
                iTween.RotateTo(gameObject, new Vector3(myRot.x, vrRot.y, myRot.z), 1f);
                ikLF.localPosition = oriLF.localPosition;
                ikRH.localPosition = oriRH.localPosition;
            }
        }
        else if (Mathf.DeltaAngle(vrRot.y, myRot.y) < -bodyTurningAngle)
        {
            if (!gameObject.GetComponent<iTween>())
            {
                //Debug.Log("Turn RIGHT!");
                iTween.RotateTo(gameObject, new Vector3(myRot.x, vrRot.y, myRot.z), 0.5f);
                ikLF.localPosition = oriLF.localPosition;
                ikRH.localPosition = oriRH.localPosition;
            }
        }
    }
        void LateUpdate()
    {
        x = cameraOffsetXZ * Mathf.Sin(vrCamera.rotation.eulerAngles.y * Mathf.Deg2Rad);
        z = cameraOffsetXZ * Mathf.Cos(vrCamera.rotation.eulerAngles.y * Mathf.Deg2Rad);
        vrMainObject.position = transform.position + new Vector3(x, cameraOffsetY, z);
    }
    }
}