using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ActivityTimer : MonoBehaviour
    {
        [SerializeField]
        private Text tCounter;
        [SerializeField]
        private float timerCount;
        [SerializeField]
        bool beginTimer;

        // Start is called before the first frame update
        void Start()
    {
        if(tCounter != null)
        {
            //Do nothing
        }
        tCounter.text = timerCount.ToString("00:00");
        //DisplayTime(timerCount);
    }

        // Update is called once per frame
        void Update()
    {
        if (!beginTimer)
        {
            //SendTimerCount();
        }
        else
        {
            StartTimer();
        }
    }
        public void StartTimer()
    {
        timerCount += Time.deltaTime;
        DisplayTime(timerCount);
    }
        void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        tCounter.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
        public void SendTimerCount()
    {
        if (beginTimer)
        {

        }
        else
        {
            print(tCounter.text + "Sent!");
        }
    }
        public void StartPause()
    {
        beginTimer = !beginTimer;

        if (!beginTimer)
        {
            GameObject.Find("/TimerSwitches/Start").GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            GameObject.Find("/TimerSwitches/Start").GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }
        public void Resettimer()
    {
        if (beginTimer)
        {

        }
        else
        {
            timerCount = 0;
            tCounter.text = timerCount.ToString("00:00");
        }
    }
    }
}