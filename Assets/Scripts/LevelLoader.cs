using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Ensure the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Get the current scene name
            string currentSceneName = SceneManager.GetActiveScene().name;

            // Extract the level number from the current scene name
            int currentLevelNumber;
            if (int.TryParse(currentSceneName.Replace("level", ""), out currentLevelNumber))
            {
                // Calculate the next level number
                int nextLevelNumber = currentLevelNumber + 1;

                // Generate the next scene name
                string nextSceneName = "level" + nextLevelNumber;

                // Check if the next scene is in the build settings
                if (Application.CanStreamedLevelBeLoaded(nextSceneName))
                {
                    // Load the next scene
                    SceneManager.LoadScene(nextSceneName);
                }
                else
                {
                    Debug.LogWarning("Next level not found: " + nextSceneName);
                }
            }
            else
            {
                Debug.LogError("Current scene name is not in the expected format: " + currentSceneName);
            }
        }
    }

}
