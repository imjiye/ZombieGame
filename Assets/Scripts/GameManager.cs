using UnityEngine;

// 점수와 게임 오버 여부를 관리하는 게임 매니저
public class GameManager : MonoBehaviour 
{
    // 싱글톤 접근용 프로퍼티
    //싱글톤은 하나만 존재할 수 있기 때문에 싱글톤이라고 함
    public static GameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static GameManager m_instance; // 싱글톤이 할당될 static 변수

    private int score = 0; // 현재 게임 점수
    //밖에서 바로 접근 불가. AddScore()함수를 이용해서만 접근 가능함.
    public bool isGameover { get; private set; } // 게임 오버 상태
    //프로퍼티 사용한 것

    private void Awake() 
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        //instance는 기존에 있던 이전것이고 this는 지금 새로 만든 새로운 것
        //비교해서 지금것이랑 이전것이랑 다르다면
        if (instance != this)
        {
            // 자신을 파괴
            //지금 새로 만든 것을 파괴하는것!
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        // 플레이어 캐릭터의 사망 이벤트 발생시 게임 오버
        FindObjectOfType<PlayerHealth>().onDeath += EndGame;
        //onDeath는 델리게이트
        //지금 여기서 onDeath안에 EndGame이라는 함수이름을 집어넣어주는 것
        //LivingEntity안에 있음
        //onDeath가 불리면 자동으로 EndGame이 실행됨
        //느슨한 커플링
    }

    // 점수를 추가하고 UI 갱신
    public void AddScore(int newScore) 
    {
        // 게임 오버가 아닌 상태에서만 점수 증가 가능
        if (!isGameover)
        {
            // 점수 추가
            score += newScore;
            // 점수 UI 텍스트 갱신
            UIManager.instance.UpdateScoreText(score);
            //클래스변수를 바로 불러서 집어넣어주는 것.
            //처음불릴때 바로 만들어져서 초기화까지 완성됨.(처음 한 번만!) => 그게 싱글톤!
        }
    }

    // 게임 오버 처리
    public void EndGame() 
    {
        // 게임 오버 상태를 참으로 변경
        isGameover = true;
        // 게임 오버 UI를 활성화
        UIManager.instance.SetActiveGameoverUI(true);
        //여기서는 세부구현을 신경쓰지 않아도 됨
        //클래스는 미리 많이 만들어두면 세부는 신경쓰지않고 가져다쓰기 편하기 때문에 사용하는 것!
    }
}