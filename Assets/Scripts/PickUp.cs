using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PickUp : MonoBehaviour
    {
        [SerializeField] private Transform handSpot;

        bool handIsOccupied;

        void Start()
        {
            handIsOccupied = false;
        }
        //void Update()
        //{
        //    if (!handIsOccupied)

        //        //Collider is true
        //        handSpot.GetComponent<BoxCollider>().enabled = true;

        //    else

        //        //Collider is false
        //        handSpot.GetComponent<BoxCollider>().enabled = false;
        //}

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "PickableObject")
            {
                if (!handIsOccupied)
                {
                    other.transform.parent = handSpot;
                    other.transform.localPosition = Vector3.zero;
                    handIsOccupied = true;
                }
                else
                {
                    Debug.Log("Item in hand");
                }

            }

            if (other.tag == "Respawn")
            {
                if (handIsOccupied)
                {
                    handSpot.GetChild(0).position = other.transform.position;
                    handSpot.GetChild(0).parent = other.transform.parent;
                    handIsOccupied = false;
                }
                else
                {
                    Debug.Log("Hand is empty");
                }

            }
        }

        IEnumerator SwitchBool()
        {
            yield return new WaitForSeconds(1f);
            handIsOccupied = true;
        }


    }
}