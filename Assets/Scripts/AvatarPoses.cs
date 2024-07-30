using UnityEngine;

namespace Assets.Scripts
{
    public class AvatarPoses : MonoBehaviour
    {
        [SerializeField]
        private Transform targetTransform, hintTransform;

        // Start is called before the first frame update
        void Start()
    {
        
    }

        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            targetTransform.localPosition = Vector3.one;
            hintTransform.localPosition = Vector3.one;
        }
    }
    }
}