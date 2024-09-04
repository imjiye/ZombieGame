﻿using UnityEngine;

// 총알을 충전하는 아이템
public class AmmoPack : MonoBehaviour, IItem 
{
    public int ammo = 30; // 충전할 총알 수

    public void Use(GameObject target) 
    {
        // 전달 받은 게임 오브젝트로부터 PlayerShooter 컴포넌트를 가져오기 시도
        PlayerShooter playerShooter = target.GetComponent<PlayerShooter>();

        // PlayerShooter 컴포넌트가 있으며, 총 오브젝트가 존재하면
        if (playerShooter != null && playerShooter.gun != null)
        {
            // 총의 남은 탄환 수를 ammo 만큼 더한다
            playerShooter.gun.ammoRemain += ammo;
            //playershooter에서  update()로 계속 매프레임마다 UpdateUI를 하고 있기에 알아서 바뀜.
        }

        // 사용되었으므로, 자신을 파괴
        Destroy(gameObject);
    }
}