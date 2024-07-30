using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ActivityTimer : MonoBehaviour
    {
        [SerializeField]
        private Text text_counter;
        [SerializeField]
        private TextMesh text_start;
        [SerializeField]
        private float timerCount;
        [SerializeField]
        bool beginTimer;

        void Start()
        {
            text_start.text = "Start";
            if (text_counter != null) text_counter.text = timerCount.ToString("00:00");
        }

        void Update()
        {
            if (!beginTimer)
            {
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

            text_counter.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        public void SendTimerCount()
        {
            if (beginTimer)
            {
                print("Please pause the timer.");
            }
            else
            {
                print(text_counter.text + "Sent!");
            }
        }
        public void StartPause()
        {
            beginTimer = !beginTimer;

            if (!beginTimer)
            {
                GameObject.Find("/TimerSwitches/Start").GetComponent<MeshRenderer>().material.color = Color.green;
                text_start.text = "Start";
            }
            else
            {
                GameObject.Find("/TimerSwitches/Start").GetComponent<MeshRenderer>().material.color = Color.yellow;
                text_start.text = "Pause";
            }
        }
        public void Reset_Timer()
        {
            if (beginTimer)
            {

            }
            else
            {
                timerCount = 0;
                text_counter.text = timerCount.ToString("00:00");
            }
        }
    }
}