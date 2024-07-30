using UnityEngine;

namespace Assets.Scripts
{
    public class FollowMouseCursor : MonoBehaviour
    {
        Vector3 temp;

        void Start()
    {
    }
        // Update is called once per frame
        void Update()
    {

        temp = Input.mousePosition;

        temp.z = 1.0f;
        if (Input.GetKeyDown(KeyCode.Plus))
        {
            temp.z++;
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            temp.z--;
        }

        transform.position = Camera.main.ScreenToWorldPoint(temp);
    }
    }
}