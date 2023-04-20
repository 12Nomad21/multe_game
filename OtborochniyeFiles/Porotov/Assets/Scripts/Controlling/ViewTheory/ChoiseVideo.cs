using UnityEngine;
using UnityEngine.Video;

public class ChoiseVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer targetVideoPlayer;
    private VideoPlayer currentVideoPlayer;

    private void Start() {
        currentVideoPlayer = GetComponent<VideoPlayer>();
    }

    public void ClickForChoiseVideo(){
        targetVideoPlayer.clip = currentVideoPlayer.clip;
        RewindVideo.videoLength = (float)targetVideoPlayer.length;
    }
}
