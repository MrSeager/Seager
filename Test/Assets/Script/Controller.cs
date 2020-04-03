using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Vector3 hitObjPos1, hitObjPos2, hitObjPos3;

    public GameObject hitObj;

    public int hitObjCount = 3;// Кол-во объйктов которых нужно сбить на уровне

    public EnemyMovement speed;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        hitObjCount = 3;        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (speed.speed - 1).ToString(); // Текст номера уровня (скорости объйкта который ловит шар)

        if (hitObjCount == 0)
        {
            Instantiate(hitObj, hitObjPos1, Quaternion.identity); // Можно было спавнить через for, но объектов всего 3 так что и так нормально
            Instantiate(hitObj, hitObjPos2, Quaternion.identity);
            Instantiate(hitObj, hitObjPos3, Quaternion.identity);
            hitObjCount = 3;
            speed.speed += 1; // Изменение скорости объйкта который ловит шар
        }
    }

    public void OnClickPouse(float speed) // Кнопка паузы и наоборот
    {
        Time.timeScale = speed;
    }

    public void OnClickExit() // Выход
    {
        Application.Quit();
    }
}
