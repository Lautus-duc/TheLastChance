using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CinematicEndingScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    void Start()
    {
        Time.timeScale = 0f;
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("PrincipalMenu");
    }
}
