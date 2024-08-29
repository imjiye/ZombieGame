using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리자 관련 코드
using UnityEngine.UI; // UI 관련 코드

// 필요한 UI에 즉시 접근하고 변경할 수 있도록 허용하는 UI 매니저
public class UIManager : MonoBehaviour 
{
    // 싱글톤 접근용 프로퍼티
    public static UIManager instance
    {
        get
        {
            //get은 외부에서 불리면 생성됨
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
                //이게 실행되려면 UIManager를 가지고 있는 게임오브젝트가 하이어라키 창에 있어야 함
                //없으면 찾을 수 없어서 계속 null로 남아있게 됨
            }
            return m_instance;
        }
    }

    private static UIManager m_instance; // 싱글톤이 할당될 변수

    public Text ammoText; // 탄약 표시용 텍스트
    public Text scoreText; // 점수 표시용 텍스트
    public Text waveText; // 적 웨이브 표시용 텍스트
    public GameObject gameoverUI; // 게임 오버시 활성화할 UI 

    // 탄약 텍스트 갱신
    public void UpdateAmmoText(int magAmmo, int remainAmmo) 
    {
        ammoText.text = magAmmo + "/" + remainAmmo;
    }

    // 점수 텍스트 갱신
    public void UpdateScoreText(int newScore) 
    {
        scoreText.text = "Score : " + newScore;
    }

    // 적 웨이브 텍스트 갱신
    public void UpdateWaveText(int waves, int count) 
    {
        waveText.text = "Wave : " + waves + "\nEnemy Left : " + count;
    }

    // 게임 오버 UI 활성화
    public void SetActiveGameoverUI(bool active) 
    {
        gameoverUI.SetActive(active);
    }

    // 게임 재시작
    public void GameRestart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.GetActiveScene().name : 현재 씬의 이름을 가져오는 것!
    }
}