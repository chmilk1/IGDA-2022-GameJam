using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ReturnToMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private string mainMenuSceneName;

        // todo: write current save data to disk
        // todo: screen transition over async load
        
        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}