using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �־��� Gun ������Ʈ�� ��ų� ������
// �˸��� �ִϸ��̼��� ����ϰ� IK�� �����
// ĳ���� ����� �ѿ� ��ġ�ϵ��� ����
public class PlayerShooter : MonoBehaviour
{
    public Gun gun; // ����� ��
    public Transform gunPivot; // �� ��ġ�� ������
    public Transform leftHandMount; // ���� ���� ������, �޼��� ��ġ�� ����
    public Transform rightHandMount; // ���� ������ ������, �������� ��ġ�� ����

    private PlayerInput playerInput; // �÷��̾��� �Է�
    private Animator playerAnimator; // �ִϸ����� ������Ʈ


    void Start() // ����� ������Ʈ ��������
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
    }

    private void OnEnable() // ���Ͱ� Ȱ��ȭ�� �� �ѵ� �Բ� Ȱ��ȭ
    {
        gun.gameObject.SetActive(true);
    }

    private void OnDisable() // ���Ͱ� ��Ȱ��ȭ�� �� �ѵ� �Բ� ��Ȱ��ȭ
    {
        gun.gameObject.SetActive(false);
    }

    void Update() // �Է��� �����ϰ� ���� �߻��ϰų� ������
    {

    }

    private void UpdateUI() // ź�� UI ����
    {
        if(gun != null && UIManager.instance != null)
        {
            // UI �Ŵ����� ź�� �ؽ�Ʈ�� źâ�� ź�˰� ���� ��ü ź�� ǥ��
            UIManager.instance.UpdateAmmoText(gun.magAmmo, gun.ammoRemain);
        }
    }

    private void OnAnimatorIK(int layerIndex) // �ִϸ������� IK ����
    {
        
    }
}
