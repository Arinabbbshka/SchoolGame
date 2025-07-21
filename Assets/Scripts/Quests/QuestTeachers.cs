using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestTeachers : MonoBehaviour
{
    private int currentQuestIndex; // Индекс текущего вопроса
    static public int correctAnswersCount; // Счетчик правильных ответов
    static public int correctQuestionCount;
    private bool isQuizPassed; // Флаг прохождения викторины
    public PlayerMovement player;

    public TextMeshProUGUI lineQuestion; // Ссылка на TMP для отображения вопроса
    public GameObject panelQuiz; // Панель викторины
    public Button btnReply1; // Кнопка первого ответа
    public Button btnReply2; // Кнопка второго ответа
    public Button btnReply3; // Кнопка третьего ответа

    public TextMeshProUGUI btnAnswerText1; // Текст кнопки первого ответа
    public TextMeshProUGUI btnAnswerText2; // Текст кнопки второго ответа
    public TextMeshProUGUI btnAnswerText3; // Текст кнопки третьего ответа


    //public GameObject itemPrefab; // Prefab предмета (назназначить нужно в инспекторе)


    #region Массив вопросов
    private class Question
    {
        public string questionText; //Текст вопроса
        public string[] options; //Массив вариантов ответов
        public int correctAnswerIndex; //Индекс правильного ответа (-1, если правильного ответа нет)

        public Question(string text, string[] opts, int correctIndex)
        {
            questionText = text;
            options = opts;
            correctAnswerIndex = correctIndex;
        }
    }

    private Question[] questions =
    {
        new Question("Кто является автором романа Мастер и Маргарита?",
            new string[] { "Михаил Булгаков", "Федор Достоевский", "Лев Толстой" }, 0),
        new Question("Какой крем использовала Маргарита, чтобы преобразиться перед полетом?",
            new string[] {"Крем Азазелло", "Крем Воланда", "Крем Бегемота"}, 0),
        new Question("Сколько глав в романе посвящено евангельским страницам?",
            new string[] {"2", "4" , "6"}, 1),
        new Question("Как вы думаете, что по мнению Воланда, испортило москвичей?",
            new string[] {"Деньги", "Власть", "Квартиный вопрос"}, 2),       
        new Question("Кто является автором романа Война и мир",
            new string[] { "Лев Толстой", "Федор Достоевский", "Nван Тургенев" }, 0)      
    };
    #endregion

    private void Start()
    {
        isQuizPassed = false;
        panelQuiz.SetActive(false); // Отключаем панель викторины при старте
        correctQuestionCount = questions.Length;


    }

    // Метод для начала викторины
    public void StartQuiz()
    {
        player.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        if (!isQuizPassed)
        {
            currentQuestIndex = 0; // Начинаем с первого вопроса
            correctAnswersCount = 0; // Обнуляем счетчик правильных ответов
            panelQuiz.SetActive(true); // Включаем панель викторины
            DisplayQuestion(); // Показываем первый вопрос
            isQuizPassed = true; // Ставим флажок того, что викторина пройдена
        }
    }

    // Метод для отображения текущего вопроса
    private void DisplayQuestion()
    {
        // Проверяем, не закончились ли вопросы
        if (currentQuestIndex >= questions.Length)
        {
            EndQuiz(); // Завершаем викторину
            return;
        }

        // Получаем текущий вопрос
        Question currentQuestion = questions[currentQuestIndex];

        // Устанавливаем текст вопроса
        lineQuestion.text = currentQuestion.questionText;

        // Заполняем текст кнопок
        if (currentQuestion.options.Length > 0)
            btnAnswerText1.GetComponent<TMP_Text>().text = currentQuestion.options[0];
        else
            btnReply1.interactable = false;

        if (currentQuestion.options.Length > 1)
            btnAnswerText2.GetComponent<TMP_Text>().text = currentQuestion.options[1];
        else
            btnReply2.interactable = false;

        if (currentQuestion.options.Length > 2)
            btnAnswerText3.GetComponent<TMP_Text>().text = currentQuestion.options[2];
        else
            btnReply3.interactable = false;
    }

    // Метод для проверки ответа
    public void CheckAnswer(int selectedAnswerIndex)
    {
        // Получаем текущий вопрос
        Question currentQuestion = questions[currentQuestIndex];

        // Если вопрос имеет правильный ответ
        if (currentQuestion.correctAnswerIndex != -1)
        {
            // Проверяем правильность ответа
            if (selectedAnswerIndex == currentQuestion.correctAnswerIndex)
            {
                correctAnswersCount++; // Увеличиваем счетчик правильных ответов
                Debug.Log("Правильный ответ!");
            }
            else
            {
                Debug.Log("Неправильный ответ.");
            }
        }

        // Переходим к следующему вопросу или завершаем викторину
        currentQuestIndex++;

        if (currentQuestIndex >= questions.Length)
        {
            EndQuiz(); // Завершаем викторину
           

        }
        else
        {
            DisplayQuestion(); // Показываем следующий вопрос
        }
    }

    // Метод для завершения викторины
    private void EndQuiz()
    {
        panelQuiz.SetActive(false); // Отключаем панель викторины
        
        Debug.Log($"Викторина завершена! Правильных ответов: {correctAnswersCount} из {questions.Length}");
        DialoqueQuests.count +=1;
    }

    
}
