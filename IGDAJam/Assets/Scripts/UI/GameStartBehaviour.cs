using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameStartBehaviour : MonoBehaviour
    {
        [SerializeField] private string gameplaySceneName;

        // todo: add logic for loading a save (which will probably replace the need for gameplaySceneName
        // todo: screen transition over async load
        
        public void StartGame()
        {
            SceneManager.LoadScene(gameplaySceneName);
        }
    }
}