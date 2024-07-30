using UnityEngine;

namespace Assets.Scripts
{
    public class DistanceBtwObjects : MonoBehaviour
    {
        [SerializeField]
        private Transform pickObj;

        // Start is called before the first frame update
        void Start()
    {
        
    }

        // Update is called once per frame
        void Update()
    {
        float dist = Vector3.Distance(pickObj.position, transform.position);
        //print("Distance to other: " + Mathf.Round(dist * 100)/100f);

        if(dist < 0.1)
        {
            transform.GetComponent<BoxCollider>().enabled = false;
        }
        else if (dist > 0.25)
        {
            transform.GetComponent<BoxCollider>().enabled = true;
        }

        if(transform.parent.childCount > 1)
        {
            transform.localScale = Vector3.zero;
        }
        else if(transform.parent.childCount == 1)
        {
            transform.localScale = new Vector3(0.1f, 0.0f, 0.1f);
        }
    }
    }
}