using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����� �Է¿� ���� �÷��̾� ĳ���͸� �����̴� ��ũ��Ʈ
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // �յ� �������� �ӵ�
    [SerializeField] private float rotateSpeed = 180f; // �¿� ȸ�� �ӵ�

    private PlayerInput playerInput; // �÷��̾� �Է��� �˷��ִ� ������Ʈ
    private Rigidbody playerRigidbody; // �÷��̾� ĳ������ ������ٵ�
    private Animator playerAnimator; // �÷��̾� ĳ������ �ִϸ�����

    void Start() // ����� ������Ʈ���� ���� ��������
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // FixedUpdate�� ���� ���� �ֱ⿡ ���� �����
    private void FixedUpdate()
    {
        // ���� ���� �ֱ⸶�� ������, ȸ��, �ִϸ��̼� ó�� ����
        Rotate(); // ȸ�� ����
        Move(); // ������ ����

        // �Է°��� ���� �ִϸ������� Move �Ķ���Ͱ� ����
        playerAnimator.SetFloat("Move", playerInput.move);
    }

    // �Է°��� ���� ĳ���͸� �յڷ� ������
    private void Move()
    {
        // ��������� �̵��� �Ÿ� ���
        Vector3 moveDistance = playerInput.move * 
            transform.forward * moveSpeed * 
            Time.deltaTime;
        // ������ٵ� �̿��� ���� ������Ʈ ��ġ ����
        playerRigidbody.MovePosition(
            playerRigidbody.position + moveDistance);
        //transform.position += moveDistance;
    }

    // �Է°��� ���� ĳ���͸� �¿�� ȸ��
    private void Rotate()
    {
        // ��������� ȸ���� ��ġ ���
        float turn = playerInput.rotate * 
            rotateSpeed * Time.deltaTime;
        // ������ٵ� �̿��� ���� ������Ʈ ȸ�� ����
        playerRigidbody.rotation = 
            playerRigidbody.rotation * 
            Quaternion.Euler(0, turn, 0);
    }
}
