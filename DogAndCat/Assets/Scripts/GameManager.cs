using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform CarPoint;
    public GameObject Car;
    public Transform BallPoint;
    public GameObject Ball;
    public float AddTime = 10f;

    public static bool IsDie;
    public static int GameOverNumer;

    public Animator CatUI01;

    public GameObject CatWin;
    public GameObject DogWin;

    bool isCatPlayUI;
    // Start is called before the first frame update
    void Start()
    {
        IsDie = false;
        StartCoroutine(AddCar());
        StartCoroutine(AddBall());
        CatWin.SetActive(false);
        DogWin.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.IsDie)
        {
            StartCoroutine(Restart());
        }
        
    }


    IEnumerator AddCar()
    {
        yield return new WaitForSeconds(AddTime);
        Instantiate(Car, CarPoint.position, CarPoint.rotation);
        AddTime = Random.Range(10, 15);
        StartCoroutine(AddCar());
    }

    IEnumerator AddBall()
    {
        yield return new WaitForSeconds(30f);
        Instantiate(Ball, BallPoint.position, BallPoint.rotation);
        StartCoroutine(AddBall());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2f);
        if (aiming2.DogDieNumber >= 2)
        {
            DogWin.SetActive(true);
            StartCoroutine(TitleScene());
        }
        else if (aiming.CatDieNumber >= 2)
        {
            CatWin.SetActive(true);
            StartCoroutine(TitleScene());
        }
        else
        {
            SceneManager.LoadScene("DogAndCat");
        }
    }

    IEnumerator TitleScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Start_Scene");
    }
}
