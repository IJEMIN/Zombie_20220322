using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� ������Ʈ�� �ֱ������� ����
public class ZombieSpawner : MonoBehaviour
{
    public Zombie zombiePrefab; // ������ ���� ���� ������

    public ZombieData[] zombieDatas; // ����� ���� �¾� ������
    public Transform[] spawnPoints; // ���� AI�� ��ȯ�� ��ġ

    private List<Zombie> zombies = new List<Zombie>(); // ������ ���� ��� ����Ʈ
    private int wave; // ���� ���̺�

    // Update is called once per frame
    void Update()
    {
        // ���ӿ��� ������ ���� �������� ����
        if (GameManager.instance != null && GameManager.instance.isGameover)
        {
            return;
        }

        // ���� ��� ����ģ ��� ���� ���� ����
        if(zombies.Count <= 0)
        {
            SpawnWave();
        }
        UpdateUI(); // UI ����
    }

    // ���̺� ������ UI�� ǥ��
    private void UpdateUI()
    {
        // ���� ���̺�� ���� ���� �� ǥ��
        UIManager.instance.UpdateWaveText(wave, zombies.Count);
    }

    // ���� ���̺꿡 ���� ���� ����
    private void SpawnWave()
    {

    }

    // ���� �����ϰ� ���� ������ ��� �Ҵ�
    private void CreateZombie()
    {

    }
}
