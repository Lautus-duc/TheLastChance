using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CinematicEntranceScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("GameScene");
    }
}
