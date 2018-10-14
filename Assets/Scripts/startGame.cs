using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{

    private AudioSource audioSource;


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void playAudio()
    {
        audioSource.Play();

    }

    public void playGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");

    }





}
