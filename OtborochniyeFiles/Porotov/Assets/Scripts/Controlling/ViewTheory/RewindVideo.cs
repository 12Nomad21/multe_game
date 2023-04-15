using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RewindVideo : MonoBehaviour
{
    [SerializeField] private RawImage videoImage;
    [SerializeField] private VideoPlayer videoPlayer;

    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private Slider videoDurationBar;

    void Start()
    {
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = new RenderTexture(1280, 720, 24);
        videoImage.texture = videoPlayer.targetTexture;
        
        videoDurationBar.maxValue = (float)videoPlayer.length;
    }
    private void Update() {
        videoDurationBar.value = (float)videoPlayer.time;
    }

    public void PlayVideo(){
        videoPlayer.Play();

        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void PauseVideo(){
        videoPlayer.Pause();

        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void Rewind(){
        videoPlayer.time = videoDurationBar.value;
    }
}
