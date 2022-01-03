using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefScore : MonoBehaviour
{
    bool mute = false;


    // Start is called before the first frame update
    void Start()
    {
        //Give the PlayerPrefs some values to send over to the next Scene
        PlayerPrefs.SetFloat("Score", 0);

        //Give the PlayerPrefs some values to send over to the next Scene
        PlayerPrefs.SetFloat("Deaths", 0);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void muteSound()
    {

        
            if (mute)
            {
                mute = false;
                AudioListener.pause = false;
                AudioListener.volume = 1f;
            }
            else
            {
                mute = true;
                AudioListener.pause = true;
                AudioListener.volume = 0f;
            }
        

    }

}