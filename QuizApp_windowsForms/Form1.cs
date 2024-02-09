using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QuizApp
{
    public partial class QuizApp : Form
    {
        public class ProgrammingQuestion
        {
            public string Question { get; set; }
            public string[] Options { get; set; }
            public char CorrectAnswerLetter { get; set; }
        }
        public class Quiz
        {
            public static ProgrammingQuestion[] GetQuestions()
            {
                return new ProgrammingQuestion[]
                {
            new ProgrammingQuestion
            {
                Question = "What does CSS stand for?",
                Options = new string[] { "Computer Style Sheets", "Creative Style Sheets", "Cascading Style Sheets", "Colorful Style Sheets" },
                CorrectAnswerLetter= 'C'
            },
            new ProgrammingQuestion
            {
                Question = "Which programming language is commonly used for building web pages?",
                Options = new string[] { "Java", "Python", "HTML", "JavaScript" },
                CorrectAnswerLetter= 'D'
            },
            new ProgrammingQuestion
            {
                Question = "What is the result of 2 + 2 * 3?",
                Options = new string[] { "8", "12", "6", "14" },
                CorrectAnswerLetter= 'A'
            },
            new ProgrammingQuestion
            {
                Question = "Which of the following is a data type in C#?",
                Options = new string[] { "String", "Loop", "Function", "Array" },
                CorrectAnswerLetter= 'A'
            },
            new ProgrammingQuestion
            {
                Question = "What is the file extension for a C# source code file?",
                Options = new string[] { ".cs", ".cpp", ".java", ".csharp" },
                CorrectAnswerLetter= 'A'
            },
            new ProgrammingQuestion
            {
                Question = "What does API stand for?",
                Options = new string[] { "Application Programming Interface", "Advanced Program Interaction", "Automated Programming Interface", "Application Process Integration" },
                CorrectAnswerLetter= 'A'
            },
            new ProgrammingQuestion
            {
                Question = "Which of the following is a relational database management system?",
                Options = new string[] { "MongoDB", "SQLite", "Redis", "Elasticsearch" },
                CorrectAnswerLetter= 'B'
            },
            new ProgrammingQuestion
            {
                Question = "In C#, how do you declare a variable that cannot be modified?",
                Options = new string[] { "const", "readonly", "immutable", "unchangeable" },
                CorrectAnswerLetter= 'B'
            },
            new ProgrammingQuestion
            {
                Question = "What is the purpose of the 'finally' block in a try-catch-finally statement?",
                Options = new string[] { "To handle exceptions", "To ensure a block of code is always executed", "To define custom exceptions", "To ignore exceptions" },
                CorrectAnswerLetter= 'B'
            },
            new ProgrammingQuestion
            {
                Question = "Which programming language is known for its use in artificial intelligence and machine learning?",
                Options = new string[] { "Java", "Python", "C++", "Ruby" },
                CorrectAnswerLetter= 'B'
            }
                };
            }
        }

        public QuizApp()
        {
            InitializeComponent();
        }

        private void QuizApp_Paint(object sender, PaintEventArgs e)
        {
            ///// Color 
            Color mainColor = Color.White;
            Pen mainPen = new Pen(mainColor);
            mainPen.Width = 2;


            mainPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            mainPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;


            e.Graphics.DrawEllipse(mainPen, 555, 7, 90, 90);

        }

        ///////  ----------------------------------------       Variables       ---------------------------------------------------

        ProgrammingQuestion[] questionSource = Quiz.GetQuestions();


        char trueAnswerLetter = '-', userAnswerLetter = '-';
        byte currentRoundNum = 1, playerScore = 0, timeDuration = 30;
        const byte totalRoundsNum = 10;

        ///////  ----------------------------------------     //Variables//     ---------------------------------------------------

        ///////  ----------------------------------------       OnLoad       ---------------------------------------------------

        private void QuizApp_Load(object sender, EventArgs e)
        {
            welcomeForm welcomeForm = new welcomeForm();

            welcomeForm.ShowDialog();

            updateStatus();

        }


        ///////  ----------------------------------------     //OnLoad//     ---------------------------------------------------


        ///////  ----------------------------------------       Status Methods        ---------------------------------------------------

        private void increasePlayerScore()
        {
            if (currentRoundNum >= totalRoundsNum + 1)
            {
                return;
            }
            else
            {
                playerScore++;

            }



        }

        private void resetPlayerScore()
        {
            playerScore = 0;

        }

        private void increaseRoundNum()
        {
            if (checkIfQuizEnd())
            {

            }
            else
            {
                currentRoundNum++;
            }
        }

        private void resetRoundNum()
        {
            currentRoundNum = 1;
        }

        private bool isAnswerTrue()
        {
            return userAnswerLetter == trueAnswerLetter;
        }

        private void resetUserAnswerLetter()
        {
            userAnswerLetter = '-';
        }

        private void updateTrueAnswerLetter()
        {
            trueAnswerLetter = questionSource[currentRoundNum - 1].CorrectAnswerLetter;

        }
        private void updateStatus()
        {
            if (checkIfQuizEnd())
            {
                stopCounter();
                showFinalResultUI();
                endTheQuiz();
                return;
            }

            startCounter();
            resetUserAnswerLetter();
            showCurrentRoundQuestionUI();
            showCurrentRoundQuestionNumberUI();
            updateTrueAnswerLetter();
            increaseRoundNum();





        }

        private void resetAnswersBtns()
        {
            answer1.Enabled = true;
            answer2.Enabled = true;
            answer3.Enabled = true;
            answer4.Enabled = true;
        }

        ///////  ----------------------------------------     //Status Methods //     ---------------------------------------------------


        ///////  ----------------------------------------       Time & counters        ---------------------------------------------------

        private void startCounter()
        {
            timer1.Enabled = true;
        }

        private void stopCounter()
        {
            timer1.Enabled = false;
        }

        private void resetCounter()
        {
            timeCounter.Text = "30";
            timeDuration = 30;
        }

        ///////  ----------------------------------------     //Time & counters //     ---------------------------------------------------


        ///////  ----------------------------------------       Quiz UI        ---------------------------------------------------

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeCounter.Text = (timeDuration--).ToString();
            if (timeCounter.Text == "0")
            {
                stopCounter();
                showTrueAnswerDesignUI();
                updateStatus();
            }

        }

        private void showTrueAnswerDesignUI()
        {
            if (trueAnswerLetter == 'A')
            {
                answer1.BackColor = Color.Green;
                button3.BackColor = Color.Green;
            }
            else if (trueAnswerLetter == 'B')
            {
                answer2.BackColor = Color.Green;
                button4.BackColor = Color.Green;
            }
            else if (trueAnswerLetter == 'C')
            {
                answer3.BackColor = Color.Green;
                button5.BackColor = Color.Green;
            }
            else
            {
                answer4.BackColor = Color.Green;
                button6.BackColor = Color.Green;
            }
        }

        private void showWrongAnswerDesignUI()
        {
            if (userAnswerLetter == 'A')
            {
                answer1.BackColor = Color.Red;
                button3.BackColor = Color.Red;
            }
            else if (userAnswerLetter == 'B')
            {
                answer2.BackColor = Color.Red;
                button4.BackColor = Color.Red;
            }
            else if (userAnswerLetter == 'C')
            {
                answer3.BackColor = Color.Red;
                button5.BackColor = Color.Red;
            }
            else
            {
                answer4.BackColor = Color.Red;
                button6.BackColor = Color.Red;
            }
        }

        private void resetTrueAnswerDesignUI()
        {

            answer1.BackColor = Color.DarkSlateBlue;
            answer2.BackColor = Color.DarkSlateBlue;
            answer3.BackColor = Color.DarkSlateBlue;
            answer4.BackColor = Color.DarkSlateBlue;


            button3.BackColor = Color.DarkSlateBlue;
            button4.BackColor = Color.DarkSlateBlue;
            button5.BackColor = Color.DarkSlateBlue;
            button6.BackColor = Color.DarkSlateBlue;


        }

        private void showFinalResultUI()
        {
            MessageBox.Show("Your Score is " + playerScore + " / 10 ", "Score");
        }

        private void showCurrentRoundQuestionUI()
        {
            if (checkIfQuizEnd())
                return;

            else
            {
                questionContainer.Text = questionSource[currentRoundNum - 1].Question;
                answer1.Text = questionSource[currentRoundNum - 1].Options[0];
                answer2.Text = questionSource[currentRoundNum - 1].Options[1];
                answer3.Text = questionSource[currentRoundNum - 1].Options[2];
                answer4.Text = questionSource[currentRoundNum - 1].Options[3];
            }

        }

        private void showCurrentRoundQuestionNumberUI()
        {
            if (checkIfQuizEnd())
                return;

            currentRoundNum1.Text = (currentRoundNum).ToString();
            if ((currentRoundNum < 10))
            {
                currentRoundNum1.Text = "0" + currentRoundNum1.Text;
            }
            currentRoundNum2.Text = (currentRoundNum).ToString();
            if ((Convert.ToByte(currentRoundNum2.Text) < 10))
            {
                currentRoundNum2.Text = "0" + currentRoundNum2.Text;
            }
        }

        ///////  ----------------------------------------     //Quiz UI //     ---------------------------------------------------



        ///////  ----------------------------------------       Events Methods        ---------------------------------------------------


        private void checkAnswer()
        {
            stopCounter();

            if (isAnswerTrue())
            {
                increasePlayerScore();
                showTrueAnswerDesignUI();
                MessageBox.Show("Right Answer", "Message");
            }
            else
            {
                showWrongAnswerDesignUI();
                showTrueAnswerDesignUI();
                MessageBox.Show("Wrong Answer", "Message");
            }

            resetTrueAnswerDesignUI();
            resetCounter();

        }

        private void answer1_Click(object sender, EventArgs e)
        {
            userAnswerLetter = 'A';
            checkAnswer();
            updateStatus();
        }

        private void answer2_Click(object sender, EventArgs e)
        {
            userAnswerLetter = 'B';
            checkAnswer();
            updateStatus();
        }

        private void answer3_Click(object sender, EventArgs e)
        {
            userAnswerLetter = 'C';
            checkAnswer();
            updateStatus();
        }

        private void answer4_Click(object sender, EventArgs e)
        {
            userAnswerLetter = 'D';
            checkAnswer();
            updateStatus();
        }


        ///////  ----------------------------------------     //Events Methods //     ---------------------------------------------------

        private void resetTheQuiz()
        {
            resetCounter();
            resetPlayerScore();
            resetRoundNum();
            resetTrueAnswerDesignUI();
            resetUserAnswerLetter();
            resetAnswersBtns();
            updateStatus();

        }
        private void endTheQuiz()
        {
            stopCounter();
            answer1.Enabled = false;
            answer2.Enabled = false;
            answer3.Enabled = false;
            answer4.Enabled = false;

            bool tryAgain = (MessageBox.Show("The Quiz was Ended\nDo you want to try again? ", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)) == DialogResult.OK;

            if (tryAgain)
            {
                resetTheQuiz();
            }
            else
            {
                this.Close();
            }


        }
        private bool checkIfQuizEnd()
        {
            return currentRoundNum >= 11;
        }


    }
}
