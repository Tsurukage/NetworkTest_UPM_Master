using UnityEngine;

namespace Assets.Scripts
{

    public class PickItem : MonoBehaviour
    {
        [SerializeField]
        private Transform targetIK, targetObj, oriPosition, patch;
        public static bool leftIsPicked, rightIsPicked, isDown;

        RaycastHit hit;

        void Start()
        {
            if (patch != null)
            {
                patch.localScale = Vector3.zero;
            }
        }

        public void HandToTarget()
        {
            if (targetIK.childCount == 0)
            {
                iTween.MoveTo(targetIK.gameObject, iTween.Hash("position", targetObj.position, "time", 2.0f, "oncomplete", "ChangeBool", "oncompletetarget", gameObject));

            }
            else if (targetIK.childCount == 1)
            {
                print("One item at one time only");
            }
        }
        public void MoveToPatch()
        {
            iTween.MoveTo(targetIK.gameObject, iTween.Hash("position", patch.position, "time", 2.0f, "oncomplete", "ChangeBool", "oncompletetarget", gameObject));
        }

        void ChangeBool()
        {
            if (targetIK.name.Contains("RH"))
            {
                if (targetIK.position == transform.position)
                {
                    if (!rightIsPicked)
                    {
                        targetObj.parent = targetIK;
                        targetObj.localPosition = Vector3.zero;
                        iTween.MoveTo(targetIK.gameObject, iTween.Hash("position", oriPosition.position, "time", 2.0f));

                        patch.localScale = new Vector3(0.1f, 0.01f, 0.1f);
                        rightIsPicked = true;
                        print(rightIsPicked);
                    }
                    else
                    {
                        targetObj.parent = patch.parent;
                        targetObj.localPosition = patch.localPosition;
                        iTween.MoveTo(targetIK.gameObject, iTween.Hash("position", oriPosition.position, "time", 2.0f));
                        patch.localScale = Vector3.zero;
                        rightIsPicked = false;
                        print(rightIsPicked);
                    }
                }
            }
            if (targetIK.name.Contains("LF"))
            {
                if (targetIK.position == transform.position)
                {
                    if (!leftIsPicked)
                    {
                        targetObj.parent = targetIK;
                        targetObj.localPosition = Vector3.zero;
                        iTween.MoveTo(targetIK.gameObject, iTween.Hash("position", oriPosition.position, "time", 2.0f));
                        patch.localScale = new Vector3(0.1f, 0.01f, 0.1f);
                        leftIsPicked = true;
                        print(leftIsPicked);
                    }
                    else
                    {
                        targetObj.parent = patch.parent;
                        targetObj.localPosition = patch.localPosition;
                        iTween.MoveTo(targetIK.gameObject, iTween.Hash("position", oriPosition.position, "time", 2.0f));
                        patch.localScale = Vector3.zero;
                        //rb.isKinematic = false;
                        leftIsPicked = false;
                        print(leftIsPicked);
                    }
                }
            }
        }

    }
}