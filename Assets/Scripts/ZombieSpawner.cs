using System.Collections.Generic;
using UnityEngine;

// ���� ���� ������Ʈ�� �ֱ������� ����
public class ZombieSpawner : MonoBehaviour
{
    public Zombie zombiePrefab; // ������ ���� ���� ������

    public ZombieData[] zombieDatas; // ����� ���� �¾� �����͵�
    public Transform[] spawnPoints; // ���� AI�� ��ȯ�� ��ġ��

    private List<Zombie> zombies = new List<Zombie>(); // ������ ������� ��� ����Ʈ
    //<>�ȿ� Ÿ���� ���� ��!(���ø��̶�� ��)

    private int wave; // ���� ���̺�

    private void Update()
    {
        // ���� ���� �����϶��� �������� ����
        if (GameManager.instance != null && GameManager.instance.isGameover)
        {
            return;
        }

        // ���� ��� ����ģ ��� ���� ���� ����
        if (zombies.Count <= 0)
        {
            SpawnWave();
        }

        // UI ����
        UpdateUI();
    }

    // ���̺� ������ UI�� ǥ��
    private void UpdateUI()
    {
        // ���� ���̺�� ���� �� �� ǥ��
        UIManager.instance.UpdateWaveText(wave, zombies.Count);
    }

    // ���� ���̺꿡 ���� ������� ����
    private void SpawnWave()
    {
        // ���̺� 1 ����
        wave++;

        // ���� ���̺� * 1.5�� �ݿø��� ����ŭ ���� ����
        int spawnCount = Mathf.RoundToInt(wave * 1.5f);

        // spawnCount��ŭ ���� ����
        for(int i = 0; i < spawnCount; i++)
        {
            // ���� ���� ó�� ����
            CreateZombie();
        }
    }

    // ���� �����ϰ� ������ ���񿡰� ������ ����� �Ҵ�
    private void CreateZombie()
    {
        // ����� ���� ������ �������� ����
        ZombieData zombieData = zombieDatas[Random.Range(0, zombieDatas.Length)];

        // ������ ��ġ�� �������� ����
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // ���� ���������κ��� ���� ����
        Zombie zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);

        // ������ ������ �ɷ�ġ ����
        zombie.Setup(zombieData);

        // ������ ���� ����Ʈ�� �߰�
        zombies.Add(zombie);

        // ������ onDeath �̺�Ʈ�� �͸� �޼��� ���
        //�̰Ŵ� �͸��Լ�(Anonymous Function)��� �θ�.
        //�̸� �������� �ʰ� �������� �ڵ� ������ �Ｎ���� �ǽð����� �����ϴ� �Լ�.
        //�ǽð����� ��ȸ�� �޼��带 �����ϰ� �̺�Ʈ�� ��� ����.
        //������ �Լ��� ������ �� ���!
        //�̰� �����ϴ�(ǥ���ϴ�) ����� ���ٽ��̶�� ��.
        // ����� ���� ����Ʈ���� ����
        zombie.onDeath += () => zombies.Remove(zombie);
        // ����� ���� 10�� �ڿ� �ı�
        //���⼭�� ����Ʈ���� �����ϸ鼭 �ѹ��� ���ӿ�����Ʈ���� �����ϴ� ��!
        zombie.onDeath += () => Destroy(zombie.gameObject, 10f);
        // ���� ��� �� ���� ���
        zombie.onDeath += () => GameManager.instance.AddScore(100);        
    }
}