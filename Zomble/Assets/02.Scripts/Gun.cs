using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ����
public class Gun : MonoBehaviour
{
    // ���� ���¸� ǥ���ϴµ� ����� Ÿ���� ����
    public enum State { Ready, Empty, Reloading }
    
    // ���� ���� ����
    public State state { get; private set; }

    // ź���� �߻�� ��ġ
    public Transform fireTransform;

    public ParticleSystem muzzleFlashEffect; // �ѱ� ȭ��
    public ParticleSystem shellEjectEffect; // ź�� ����

    // ź�� ������ �׸��� ���� ������
    private LineRenderer bulletLineRenderer;
    private AudioSource gunAudioPlayer; // �ѼҸ� �����

    //public AudioClip shotClip; // �߻� �Ҹ�
    //public AudioClip reloadClip; // ������ �Ҹ�
    //public float damage = 25; // ���ݷ�
    //public int ammoRemain = 100; // ���� ��ü ź��
    //public int magCapacity = 25; // źâ �뷮

    // ���� ���� ������
    public GunData gunData;

    private float fireDistance = 50f; // �����Ÿ�
    public int ammoRemain = 100; // ���� ��ü ź��
    public int magAmmo; // ���� źâ�� ���� �ִ� ź��

    //public float timeBetFire = 0.12f;
    //public float reloadTime = 1.8f;
    // ���� ���������� �߻��� ����
    private float lastFireTime;

    private void Awake()
    {
        // ����� ������Ʈ�� ���� ��������
        gunAudioPlayer = GetComponent<AudioSource>();
        bulletLineRenderer = GetComponent<LineRenderer>();

        // ����� ���� �� ���� ����
        bulletLineRenderer.positionCount = 2;
        // ���� �������� ��Ȱ��ȭ
        bulletLineRenderer.enabled = false;
    }

    private void OnEnable()
    {
        // ��ü ���� ź�� ���� �ʱ�ȭ
        ammoRemain = gunData.startAmmoRemain;
        // ���� źâ�� ���� ä���
        magAmmo = gunData.magCapacity;
        // ���� ���� ���¸� ���� �� �غ� �� ���·� ����
        state = State.Ready;
        // ���������� ���� �� ������ �ʱ�ȭ
        lastFireTime = 0;
    }

    public void Fire() // �߻� �õ�
    {

    }

    private void Shot() // ���� �߻� ó��
    {

    }

    private IEnumerator ShotEffect(Vector3 hitposition)
    {
        // �ѱ� ȭ�� ȿ�� ���
        muzzleFlashEffect.Play();
        // ź�� ���� ȿ�� ���
        shellEjectEffect.Play();

        // �Ѱ� �Ҹ� ���
        gunAudioPlayer.PlayOneShot(gunData.shotClip);

        // ���� �������� �ѱ��� ��ġ
        bulletLineRenderer.SetPosition(0, fireTransform.position);
        // ���� ������ �Է����� ���� �浹 ��ġ
        bulletLineRenderer.SetPosition(1, hitposition);
        // ���� �������� Ȱ��ȭ�Ͽ� ź�� ������ �׸�
        bulletLineRenderer.enabled = true;

        // 0.03�� ���� ��� ó���� ���
        yield return new WaitForSeconds(0.03f);

        // ���� �������� ��Ȱ���Ͽ� ź�� ������ ����
        bulletLineRenderer.enabled = false;
    }

    public bool Reload() // ������ �õ�
    {
        return false;
    }

    // ���� ������ ó���� ����
    private IEnumerator ReloadRoutine()
    {
        // ���� ���¸� ������ �� ���·� ��ȯ
        state = State.Reloading;

        // ������ �ҿ� �ð���ŭ ó�� ����
        yield return new WaitForSeconds(gunData.reloadTime);

        // ���� ���� ���¸� �߻� �غ�� ���·� ����
        state = State.Ready;
    }
}
