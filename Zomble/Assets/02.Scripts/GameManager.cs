using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// �̱��� ���ٿ� ������Ƽ
    /// </summary>
    public static GameManager instance
    {
        get
        {
            // ���� �̱��� ������ ���� ������Ʈ�� �Ҵ���� �ʾҴٸ�
            if(m_instance == null)
            {
                // ������ GameManager ������Ʈ�� ã�Ƽ� �Ҵ�
                m_instance = FindObjectOfType<GameManager>();
            }
            // �̱��� ������Ʈ ��ȯ
            return m_instance;
        }
    }

    private static GameManager m_instance; // �̱����� �Ҵ�� static ����

    private int score = 0; // ���� ���� ����
    public bool isGameover { get; private set; } // ���ӿ��� ����

    private void Awake()
    {
        // ���� �̱��� ������Ʈ�� �� �ٸ� GameManager ������Ʈ�� �ִٸ�
        if(instance != this)
        {
            // �ڽ��� �ı�
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // �÷��̾� ĳ������ ��� �̺�Ʈ �߻� �� ���ӿ���
        FindObjectOfType<PlayerHealth>().onDeath += EndGame;
    }

    /// <summary>
    /// ������ �߰��ϰ� UI ����
    /// </summary>
    /// <param name="newScore"></param>
    public void AddScore(int newScore)
    {
        // ���ӿ����� �ƴ� ���¿����� ���� �߰� ����
        if (!isGameover)
        {
            // ���� �߰�
            score += newScore;
            // ���� UI �ؽ�Ʈ ����
            UIManager.instance.UpdateScoreText(score);
        }
    }

    /// <summary>
    /// ���ӿ��� ó��
    /// </summary>
    public void EndGame()
    {
        // ���ӿ��� ���¸� ������ ����
        isGameover = true;
        // ���ӿ��� UI Ȱ��ȭ
        UIManager.instance.SetActiveGameOverUI(true);
    }
}
