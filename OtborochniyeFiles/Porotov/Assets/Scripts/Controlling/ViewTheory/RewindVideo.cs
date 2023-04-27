using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RewindVideo : MonoBehaviour
{
    [SerializeField] private RawImage videoImage;  // Определяем компонент RawImage для отображения видео
    [SerializeField] private VideoPlayer videoPlayer;  // Определяем компонент VideoPlayer для воспроизведения видео
    public static VideoPlayer videoPlayerForOtherScripts;

    [SerializeField] private GameObject playButton;  // Определяем игровой объект для кнопки воспроизведения видео
    [SerializeField] private GameObject pauseButton;  // Определяем игровой объект для кнопки паузы видео
    [SerializeField] private Slider videoDurationBar;  // Определяем компонент Slider для отображения длительности видео
    public static float videoLength;

    void Start()
    {
        videoPlayerForOtherScripts = videoPlayer;
        // Устанавливаем режим воспроизведения видео
        videoPlayerForOtherScripts.renderMode = VideoRenderMode.RenderTexture;
        
        // Создаём RenderTexture нужного размера и привязываем её к VideoPlayer
        videoPlayerForOtherScripts.targetTexture = new RenderTexture(1280, 720, 24);
        
        // Устанавливаем созданную RenderTexture для отображения видео в компоненте RawImage
        videoImage.texture = videoPlayerForOtherScripts.targetTexture;
            
        // Устанавливаем максимальное значение Slider, соответствующее длительности видео
        videoLength = (float)videoPlayerForOtherScripts.length;
        videoDurationBar.maxValue = videoLength;

        PlayVideo();
        PauseVideo();

        videoPlayerForOtherScripts.loopPointReached += OnVideoEnd;
    }
    private void OnDestroy() {
        videoPlayerForOtherScripts.loopPointReached -= OnVideoEnd;
    }
    private void Update() {
        videoDurationBar.value = (float)videoPlayerForOtherScripts.time;
        videoDurationBar.maxValue = videoLength;
    }

    public void PlayVideo(){
        videoPlayerForOtherScripts.Play();

        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void PauseVideo(){
        videoPlayerForOtherScripts.Pause();

        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }
    public void Rewind(){
        videoPlayerForOtherScripts.time = videoDurationBar.value;
    }

    private void OnVideoEnd(VideoPlayer vp){
        PauseVideo();
    }
}
