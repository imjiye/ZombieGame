using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/GunData", fileName = "Gun Data")]
public class GunData : ScriptableObject
{
    //이 스크립트는 초기값으로 세팅하기 위해 사용하는것!
    //공통적으로 쓸 데이터로 사용됨(하나만 있음)
    //Gun 스크립트에서 변수로 종속되어 있음
    //여기에는 MonoBehaviour가 없기 때문에 컴포넌트로 사용 불가함
    //컴포넌트로 쓸 일이 없기 때문에 MonoBehaviour를 상속받지 않은 것!(받아도 상관없긴 함)
    public AudioClip shotClip; // 발사 소리
    public AudioClip reloadClip; // 재장전 소리

    public float damage = 25; // 공격력

    public int startAmmoRemain = 100; // 처음에 주어질 전체 탄약
    public int magCapacity = 25; // 탄창 용량

    public float timeBetFire = 0.12f; // 총알 발사 간격
    public float reloadTime = 1.8f; // 재장전 소요 시간
}