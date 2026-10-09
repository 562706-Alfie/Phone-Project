using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 
            PlayButton(); // If the player touches anywhere on the screen, load the next scene
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
