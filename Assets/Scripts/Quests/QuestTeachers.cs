using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestTeachers : MonoBehaviour
{
    private int currentQuestIndex; // ������ �������� �������
    static public int correctAnswersCount; // ������� ���������� �������
    static public int correctQuestionCount;
    private bool isQuizPassed; // ���� ����������� ���������
    public PlayerMovement player;

    public TextMeshProUGUI lineQuestion; // ������ �� TMP ��� ����������� �������
    public GameObject panelQuiz; // ������ ���������
    public Button btnReply1; // ������ ������� ������
    public Button btnReply2; // ������ ������� ������
    public Button btnReply3; // ������ �������� ������

    public TextMeshProUGUI btnAnswerText1; // ����� ������ ������� ������
    public TextMeshProUGUI btnAnswerText2; // ����� ������ ������� ������
    public TextMeshProUGUI btnAnswerText3; // ����� ������ �������� ������


    //public GameObject itemPrefab; // Prefab �������� (������������ ����� � ����������)


    #region ������ ��������
    private class Question
    {
        public string questionText; //����� �������
        public string[] options; //������ ��������� �������
        public int correctAnswerIndex; //������ ����������� ������ (-1, ���� ����������� ������ ���)

        public Question(string text, string[] opts, int correctIndex)
        {
            questionText = text;
            options = opts;
            correctAnswerIndex = correctIndex;
        }
    }

    private Question[] questions =
    {
        new Question("��� �������� ������� ������ ������ � ���������?",
            new string[] { "������ ��������", "����� �����������", "��� �������" }, 0),
        new Question("����� ���� ������������ ���������, ����� ������������� ����� �������?",
            new string[] {"���� ��������", "���� �������", "���� ��������"}, 0),
        new Question("������� ���� � ������ ��������� ������������ ���������?",
            new string[] {"2", "4" , "6"}, 1),
        new Question("��� �� �������, ��� �� ������ �������, ��������� ���������?",
            new string[] {"������", "������", "��������� ������"}, 2),       
        new Question("��� �������� ������� ������ ����� � ���",
            new string[] { "��� �������", "����� �����������", "N��� ��������" }, 0)      
    };
    #endregion

    private void Start()
    {
        isQuizPassed = false;
        panelQuiz.SetActive(false); // ��������� ������ ��������� ��� ������
        correctQuestionCount = questions.Length;


    }

    // ����� ��� ������ ���������
    public void StartQuiz()
    {
        player.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        if (!isQuizPassed)
        {
            currentQuestIndex = 0; // �������� � ������� �������
            correctAnswersCount = 0; // �������� ������� ���������� �������
            panelQuiz.SetActive(true); // �������� ������ ���������
            DisplayQuestion(); // ���������� ������ ������
            isQuizPassed = true; // ������ ������ ����, ��� ��������� ��������
        }
    }

    // ����� ��� ����������� �������� �������
    private void DisplayQuestion()
    {
        // ���������, �� ����������� �� �������
        if (currentQuestIndex >= questions.Length)
        {
            EndQuiz(); // ��������� ���������
            return;
        }

        // �������� ������� ������
        Question currentQuestion = questions[currentQuestIndex];

        // ������������� ����� �������
        lineQuestion.text = currentQuestion.questionText;

        // ��������� ����� ������
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

    // ����� ��� �������� ������
    public void CheckAnswer(int selectedAnswerIndex)
    {
        // �������� ������� ������
        Question currentQuestion = questions[currentQuestIndex];

        // ���� ������ ����� ���������� �����
        if (currentQuestion.correctAnswerIndex != -1)
        {
            // ��������� ������������ ������
            if (selectedAnswerIndex == currentQuestion.correctAnswerIndex)
            {
                correctAnswersCount++; // ����������� ������� ���������� �������
                Debug.Log("���������� �����!");
            }
            else
            {
                Debug.Log("������������ �����.");
            }
        }

        // ��������� � ���������� ������� ��� ��������� ���������
        currentQuestIndex++;

        if (currentQuestIndex >= questions.Length)
        {
            EndQuiz(); // ��������� ���������
           

        }
        else
        {
            DisplayQuestion(); // ���������� ��������� ������
        }
    }

    // ����� ��� ���������� ���������
    private void EndQuiz()
    {
        panelQuiz.SetActive(false); // ��������� ������ ���������
        
        Debug.Log($"��������� ���������! ���������� �������: {correctAnswersCount} �� {questions.Length}");
        DialoqueQuests.count +=1;
    }

    
}
