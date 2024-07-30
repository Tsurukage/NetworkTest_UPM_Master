using UnityEngine;

namespace Assets.Scripts
{
    public class SwitchBool : MonoBehaviour
    {
        public bool picked = false;

        public void BoolToogle()
    {
        picked = !picked;
    }
    }
}