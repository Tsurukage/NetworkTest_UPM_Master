using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectsDistance : MonoBehaviour
    {
        [SerializeField] private Transform origin;
        [SerializeField] private Transform destination;

        void Start()
    {
        float dist = Vector3.Distance(origin.position, destination.position);
        if(destination !=  null)
            Debug.Log($"The distance between {origin.name} and {destination.name} is {dist}");
    }
    }
}