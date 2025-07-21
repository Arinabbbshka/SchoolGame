using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;


public class DialoqueQuests : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI line;
    public PlayerMovement player;

    static public int count;

    public Button next;

    public bool isOrder; //Первым говорит студент
    private int indexLine = 0;

    private string[] Dialoguess =
    {
        "Ученик: Погода сегодня прекрасная, можно выйти на переменку?",
        "Учитель: Да, но для этого нужно решить квест",
        "Ученик: Хорошо",
        "Учитель: Тест по литературе, надеюсь ты готов?",
         "Ученик: Даа!",
        "Учитель: Давайте начнем"
    };
      
    
    private void Start()
    {
        count = 0;
    }
    private void Update()
    {
        player = GetComponentInChildren<PlayerMovement>();
        
        StartDialogue();
    }
    private void StartDialogue()
    {
        if (count == 0)
        {
            Vector3 rayCenterScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray = Camera.main.ScreenPointToRay(rayCenterScreen);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Teacher") && Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Работает");
                    panel.SetActive(true);                    
                    player.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    ActivateDialogue();
                }
            }
        }
        else if (count == 1)
        {
            panel.SetActive(true);           
            TextTeachers();

        }
    }
    private void TextTeachers()
    {
        int one = QuestTeachers.correctAnswersCount;
        int two = QuestTeachers.correctQuestionCount;

        string textToDisplay;

        if (one == two)
        {
            if (indexLine == 0) // Проверка на indexLine нужна, так как textTeac и textTeac1 имеют только один элемент
            {
                textToDisplay = $"Результат неплохой = {QuestTeachers.correctAnswersCount} из {QuestTeachers.correctQuestionCount}, " +
                                "но лучше подготовиться! Можете идти на перемену, но не забудьте забрать свой дневник и рюкзак!";
                line.text = textToDisplay;
            }
            else
            {
                EndDialogue(); // Переместили код завершения диалога в отдельную функцию
            }
        }
        else
        {
            if (indexLine == 0) // Проверка на indexLine нужна, так как textTeac и textTeac1 имеют только один элемент
            {
                textToDisplay = $"Так держать! Правильных ответов: {QuestTeachers.correctAnswersCount} из {QuestTeachers.correctQuestionCount}! " +
                                "Можете идти на перемену, но не забудьте забрать свой дневник и рюкзак!";
                line.text = textToDisplay;
            }
            else
            {
                EndDialogue(); // Переместили код завершения диалога в отдельную функцию
            }
        }
    }
    private void EndDialogue()
    {
        OpenTheDoor openTheDoor = FindObjectOfType<OpenTheDoor>();
        openTheDoor.OpenDoorEffect(); 
       
        count = 5;
        Debug.Log("диалог 2 пройден");
        player.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        panel.SetActive(false);
    }
    private void ActivateDialogue()
    {
        if (indexLine <= Dialoguess.Length - 1)
        {
            line.text = Dialoguess[indexLine];
        }
        else
        {
            Debug.Log("диалог 1 пройден");
            indexLine = 0;
            //player.enabled = true;
            //Cursor.lockState = CursorLockMode.Locked;
            panel.SetActive(false);
            QuestTeachers quizManager = FindObjectOfType<QuestTeachers>();

            if (quizManager != null)
            {
                quizManager.StartQuiz(); // Запускаем викторину
            }
        }
    }

    public void NextBtn()
    {
        indexLine++;
        if (count == 0)
        {
            ActivateDialogue();
        }
        else if (count == 1)
        {
            TextTeachers();
        }
    }





}
