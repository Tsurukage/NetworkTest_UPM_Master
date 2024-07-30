using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneChange : MonoBehaviour
    {
    
        public void ToSC_Scene()
    {
        SceneManager.LoadScene("SmartphoneControllerScene");
    }
    
        public void ToDG_Scene()
    {
        SceneManager.LoadScene("DwellGazeScene");
    }

        public void ReturnToMM()
    {
        SceneManager.LoadScene("MainMenu");
    }
    }
}