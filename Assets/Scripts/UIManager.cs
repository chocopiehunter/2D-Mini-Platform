using UnityEngine;
using UnityEngine.SceneManagement; // 씬 재시작

public class UIManager : MonoBehaviour
{
    // Restart 버튼을 누르면 실행될 메서드
    public void OnClickRestart()
    {
        // 현재 열려있는 활성화된 씬의 이름을 가져와서 다시 로드 (처음부터 재시작)
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void OnClickQuit()
    {

#if UNITY_EDITOR
        // 유니티 에디터 상에서 테스트할 때 꺼지도록 처리
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 빌드된 진짜 게임 파일에서 꺼지도록 처리
        Application.Quit();
#endif
    }
}