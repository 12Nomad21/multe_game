using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RewindVideo : MonoBehaviour
{
    [SerializeField] private RawImage videoImage;  // Определяем компонент RawImage для отображения видео
    [SerializeField] private VideoPlayer videoPlayer;  // Определяем компонент VideoPlayer для воспроизведения видео

    [SerializeField] private GameObject playButton;  // Определяем игровой объект для кнопки воспроизведения видео
    [SerializeField] private GameObject pauseButton;  // Определяем игровой объект для кнопки паузы видео
    [SerializeField] private Slider videoDurationBar;  // Определяем компонент Slider для отображения длительности видео
    public static float videoLength;

    void Start()
    {
        // Устанавливаем режим воспроизведения видео
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        
        // Создаём RenderTexture нужного размера и привязываем её к VideoPlayer
        videoPlayer.targetTexture = new RenderTexture(1280, 720, 24);
        
        // Устанавливаем созданную RenderTexture для отображения видео в компоненте RawImage
        videoImage.texture = videoPlayer.targetTexture;
            
        // Устанавливаем максимальное значение Slider, соответствующее длительности видео
        videoLength = (float)videoPlayer.length;
        videoDurationBar.maxValue = videoLength;

        videoPlayer.loopPointReached += OnVideoEnd;
    }
    private void OnDestroy() {
        videoPlayer.loopPointReached -= OnVideoEnd;
    }
    private void Update() {
        videoDurationBar.value = (float)videoPlayer.time;
        videoDurationBar.maxValue = videoLength;
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

    private void OnVideoEnd(VideoPlayer vp){
        PauseVideo();
    }


}
