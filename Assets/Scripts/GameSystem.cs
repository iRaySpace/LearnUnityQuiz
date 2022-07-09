using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSystem : MonoBehaviour
{
    [System.Serializable]
    public struct Question
    {
        public string title;
        public string answer;
    }

    public TMP_Text questionText;
    public TMP_Text feedbackText;
    public Question[] questions;

    private Question currentQuestion;
    private ArrayList answeredQuestions;

    // Start is called before the first frame update
    void Start()
    {
        int randIndex = Random.Range(0, questions.Length);
        Question question = questions[randIndex];
        currentQuestion = question;

        questionText.text = currentQuestion.title;

        answeredQuestions = new ArrayList();
        answeredQuestions.Add(randIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NextQuestion()
    {
        if (answeredQuestions.Count == questions.Length)
        {
            return;
        }

        int randIndex = Random.Range(0, questions.Length);
        while (answeredQuestions.IndexOf(randIndex) != -1)
        {
            randIndex = Random.Range(0, questions.Length);
        }
        Question question = questions[randIndex];
        currentQuestion = question;

        questionText.text = currentQuestion.title;
        answeredQuestions.Add(randIndex);
    }

    private void CorrectAnswer()
    {
        feedbackText.text = "Correct";
        NextQuestion();
    }

    private void WrongAnswer()
    {
        feedbackText.text = "Wrong";
        NextQuestion();
    }

    public void HandleYes()
    {
        if (currentQuestion.answer == "YES")
        {
            CorrectAnswer();
        } else
        {
            WrongAnswer();
        }
    }

    public void HandleNo()
    {
        if (currentQuestion.answer == "NO")
        {
            CorrectAnswer();
        } else
        {
            WrongAnswer();
        }
    }
}
