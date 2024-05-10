using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject DestroyVirtualCamera;

    void Start()
    {
        director.stopped += OnDirectorStopped;  // Timelineが終了したらイベントを追加
        director.Play();  // Timelineを再生
    }

    private void OnDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
        {
            SetCameraTargets();  // Timelineの演出が終了したらカメラターゲットを設定
        }
    }

    void OnDestroy()
    {
        director.stopped -= OnDirectorStopped;  // イベントハンドラを削除
    }

    void SetCameraTargets()
    {
        Destroy(DestroyVirtualCamera);
        DestroyVirtualCamera = null;
    }
}