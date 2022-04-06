using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corutines : MonoBehaviour
{
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CleaningHouse()); // A
        StartCoroutine("CleaningHouse"); // B

        Invoke("Test", 10f);
    }

    // Update is called once per frame
    void Update()
    {
        int time = (int)Time.deltaTime;
        Debug.Log("Time : " + time);
    }

    void Test()
    {
        Debug.Log("Invoke B Room");
    }

    IEnumerator CleaningHouse()
    {
        Debug.Log("A Room");
        // A�� û��
        yield return new WaitForSeconds(10f); // 10�� ���� ����
        Debug.Log("B Room");
        // B�� û��
        yield return new WaitForSeconds(20f); // 20�� ���� ����
        // C�� û��
        Debug.Log("C Room");
    }
}
