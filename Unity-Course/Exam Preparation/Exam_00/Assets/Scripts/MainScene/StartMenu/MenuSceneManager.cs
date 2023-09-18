using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitMenuScene()
    {
        Debug.Log("Exit");
        Debug.Log(@"I'd want to express my gratitude for making every effort to show us everything you could in our limited time, even if it was just once a week. Since I'm defending a C# Web project next month, I wasn't able to practice much. 
I put my best efforts into catching up and learning as much as I could during the past two weeks, but this is still accomplished by practice, not just watching videos.
But I'm not going to stop here:)!!!");
        Debug.Log(@"I am aware that my exam answer is nowhere near satisfactory, but once the main course is through, I will undoubtedly keep practicing because I enjoy the entire process of developing even our smallest demo projects.
Thank you once again for this brief journey, and I hope to meet you in person sometime.
Take care and sending you my warmest regards! :)!!");
    }
}
