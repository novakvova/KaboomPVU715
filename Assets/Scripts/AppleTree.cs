using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //Шаблон для створення яблука
    public GameObject applePrefab;
    //Швидкість руху 
    public float speed = 1f;

    //Відстань на яку повинно змінюватися напрямок руху яблуні
    public float leftAndRightEnge = 10f;

    //Імовірність случайної зміни напряку руху
    public float changeToChangeDirections = 0.1f;

    //Частота створення екземплярів яблук
    public float secondsBetweenAppleDrops = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Просте переміщення
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEnge)
        {
            speed = Mathf.Abs(speed); //починаємо рухатися в право
        }
        else if (pos.x > leftAndRightEnge)
        {
            speed = -Mathf.Abs(speed); //починаємо рухатися в ліво
        }
    }

    private void FixedUpdate() //визываэться только 50 раз в секунду
    {
        //Тепер випадкова зміна напрямку привязана до часу,
        //тому, що виконується в методі FixedUpdate()
        if (Random.value < changeToChangeDirections)  //починаємо рухатися рандомом, якщо рандом попав
        {
            speed *= -1;
        }
    }

}
