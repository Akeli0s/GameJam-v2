using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonLogic : MonoBehaviour
{
    public GameObject[] objectsToShow; // Array of GameObjects to show/hide
    public GameObject backButtonObject; // Reference to the back button GameObject

    private List<GameObject> clickedObjects = new List<GameObject>(); // Keep track of clicked objects
    private bool buttonPressed = false; // Flag to track whether a button has been pressed

    private void Start()
    {
        // Ensure all objects are initially hidden
        if (objectsToShow != null)
        {
            foreach (var obj in objectsToShow)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }

        // Hide the back button initially
        if (backButtonObject != null)
        {
            backButtonObject.SetActive(false);
        }
        else
        {
            Debug.LogError("BackButtonObject is not assigned in the inspector.");
        }
    }

    public void StartButtonClicked()
    {
        // Load the scene named "Present"
        SceneManager.LoadSceneAsync("Present");
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

    public void ShowObjectOnClick(int index)
    {
        // Check if the index is valid
        if (index >= 0 && index < objectsToShow.Length)
        {
            // Toggle the active state of the specified object
            if (objectsToShow[index] != null)
            {
                GameObject clickedObject = objectsToShow[index];

                // Check if the object is already clicked
                if (clickedObjects.Contains(clickedObject))
                {
                    // Object is clicked, so disable it
                    clickedObjects.Remove(clickedObject);
                    clickedObject.SetActive(false);

                    // Enable the back button since a button has been pressed
                    buttonPressed = true;

                    // Show the back button
                    if (backButtonObject != null)
                    {
                        backButtonObject.SetActive(true);
                    }
                }
                else
                {
                    // Object is not clicked, so enable it
                    clickedObjects.Add(clickedObject);
                    clickedObject.SetActive(true);

                    // Enable the back button since a button has been pressed
                    buttonPressed = true;

                    // Show the back button
                    if (backButtonObject != null)
                    {
                        backButtonObject.SetActive(true);
                    }
                }
            }
            else
            {
                Debug.LogError($"Object at index {index} is not assigned in the inspector.");
            }
        }
        else
        {
            Debug.LogError($"Invalid index {index}. Make sure it's within the range of objectsToShow array.");
        }
    }

    public void BackButtonClicked()
    {
        // Check if any button has been pressed before enabling the back button
        if (buttonPressed)
        {
            // Disable all clicked objects
            foreach (var obj in clickedObjects)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }

            // Clear the list of clicked objects
            clickedObjects.Clear();
            buttonPressed = false;

            // Hide the back button again
            if (backButtonObject != null)
            {
                backButtonObject.SetActive(false);
            }
        }
    }
}
