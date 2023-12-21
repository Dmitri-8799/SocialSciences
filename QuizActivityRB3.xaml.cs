namespace SocialSciencesDecember2023.RadioButtons3;

public partial class QuizActivityRB3 : ContentPage
{

    private List<TableRB3> questionList;
    private TableRB3 currentQuestion;

  

    TableRB3 item = new TableRB3();
    private Label textOfQuestion; //текст вопроса, может лучше взять другой объект??

    private int chosenAnswerNr; // значение выбранной радиокнопки

    //радиокнопки. Надо ли присваивать групповое имя?
    private RadioButton rb1;
    private RadioButton rb2;
    private RadioButton rb3;


    private int answerNr; //интовое значение, взятое с БД (столбец answerNR)

    private Label displayIfRight; // два объекта Label для всплывающих окон, но они ведь не нужны.
    private Label displayIfWrong;


    private int score;
    private int totalcounter;
    private Button buttonConfirmNext; //при нажатии на кнопку будет осуществляться проверка нажатия на радиокнопку, а затем проверка правильности ответа
    private Label scoreLine; //строка с переменными score и totalcounter

    private bool answered;


    public QuizActivityRB3()
    {

        Label scoreLine = new Label
        {
            TextColor = Colors.Violet 
        };


        Label question = new Label
        {
            Text = item.question, // можно ли в конструкторе делать привязку таким образом??
            TextColor = Colors.Violet
        };

        RadioButton rb1 = new RadioButton
        {
            GroupName = "asnwers",
            Content = item.Option1,
            TextColor = Colors.BlueViolet

        };
        RadioButton rb2 = new RadioButton
        {
            GroupName = "asnwers",
            Content = item.Option2,
            TextColor = Colors.BlueViolet

        };
        RadioButton rb3 = new RadioButton
        {
            GroupName = "asnwers",
            Content = item.Option3,
            TextColor = Colors.BlueViolet
        };

        Button buttonConfirmNext = new Button
        {
            Text = "Ответить",
            BorderColor = Colors.Violet,
            TextColor = Colors.Violet

        };
        buttonConfirmNext.Clicked += PressChosenButton_Clicked;


        StackLayout stackLayoutRB3 = new StackLayout() { scoreLine, question, rb1, rb2, rb3, buttonConfirmNext };
        Frame frameRB3 = new Frame
        {
            HeightRequest = 100, // рандомные значения
            WidthRequest = 200,

            CornerRadius = 5,
            Margin = 5,
            BorderColor = Color.FromArgb("#800080")
        };

        frameRB3.Content = stackLayoutRB3;
        Content = stackLayoutRB3;

    }



    private void QuizLogic()
    {
        //начинаем с id = 1 (1 строка). Или надо это оформить по-другому??
        currentQuestion.Id = 1;
        //надо ли здесь снова делать привязку в самом начале метода ??

        //сделал цикл for, а можно ли было исопльзовать foreach? Например, foreach (var item.id in TableRB3) ??
        //можно ли обойтись без циклов ? Как сделать перебор строк в таблице с помощью IEnumerable/IEnumerator ? Мне вообще кажется,  что рекурсия - это самый экономичный вриант здесь.


        for (int i = 1; i < questionList.Count; i++) //нельзя первый параметр цикла сделать так: int i = currentQuestion.Id = 1??
        {
          

            scoreLine.Text = "Общий счет" + i + " / " + questionList.Count;

            ShowNextQuestion(); // сразу вызываем этот метод или сначала привязка для первой строки таблицы и потом уже вызов метода ?


            //обработка нажатия кнопки - надо ли дублировать
            EventHandler OnButtonClicked = null;
            buttonConfirmNext.Clicked += OnButtonClicked;
        }
    }



    public void ShowNextQuestion()
    {

        if (item.Id < questionList.Count)
        {
            //надо ли здесь  повторять эту логику??

            textOfQuestion.SetBinding(Label.BindingContextProperty, item.question.ToString()); //можно ли использовать вместо SetBinding метод SetValue? В чем разница??
            rb1.SetBinding(RadioButton.BindingContextProperty, item.Option1.ToString());
            rb1.GroupName = "asnwers";

            rb2.SetBinding(RadioButton.BindingContextProperty, item.Option2.ToString());
            rb2.GroupName = "asnwers";

            rb3.SetBinding(RadioButton.BindingContextProperty, item.Option3.ToString());
            rb3.GroupName = "asnwers";

            answerNr = (int)item.AnswerNr;

            answered = false;
            buttonConfirmNext.Text = "Ответ";

            item.Id++;
        }

        else
        {//прописать метод для открытия новго окна, где можно открыть настройки, перейти в следующий уровень или вернуться в нлавное меню, сделать эти команды за счет ImageButton
            finishQuiz();

        }

        //инкрементю интовое currentQuestion.Id++, чтоб строки итерировались
        currentQuestion.Id++;


    }



    private void checkAnswer()
    {   
        answerNr = item.AnswerNr; // если  item.AnswerNr - это интовое значение, надо ли конвертировать его дополнительно ?

        chosenAnswerNr = GetIndexOfChosenRb(chosenAnswerNr);

        if (chosenAnswerNr == answerNr)
        {
            int score = 0;
            score++;

            async Task DisplayIfRight(string message, string council)
            {
                await DisplayIfRight(item.IfRight.ToString(), "Далее");

            }

        }

        else
        {
            async Task DisplayIfWrong(string message, string council)
            {
                await DisplayIfWrong(item.IfWrong.ToString(), "Ясно");

            }

        }

        showSolution();
    }

    private static void showSolution()
    {
        //метод для окрашивания радиокнопки красным, надо сделать if/else, чтобы на основе правильного ответа радиокнопка окрашивалась зеленой, а неправильные - красным.
        RadioButton rb1 = new RadioButton();
        rb1.BorderColor = Color.FromArgb("red");

        RadioButton rb2 = new RadioButton();
        rb2.BorderColor = Color.FromArgb("red");

        RadioButton rb3 = new RadioButton();
        rb3.BorderColor = Color.FromArgb("red");


    }

    public int GetIndexOfChosenRb(int indexOfRB) //нужен ли этот параметр ?
    {
        //индексы для поиска 
        RadioButton rbChosen = new RadioButton();


        if (rb1.IsChecked == true)
        {
            rbChosen = rb1;
            indexOfRB = 2; // начинаю с двойки, потому что  столбец под индексом 1 в таблице - это текст вопроса. 
        }

        else if (rb2.IsChecked == true)
        {
            rbChosen = rb2;
            indexOfRB = 3;
        }

        else if (rb3.IsChecked == true)
        {
            rbChosen = rb3;
            indexOfRB = 4;
        }

        return indexOfRB;
        //сработает ли метод? вернет ли он indexOfRB?
    }

    void UsersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedItem = e.SelectedItem as RadioButton;
        if (selectedItem != null)
        {
            int selectedRadioButtonIndex = Convert.ToInt32(selectedItem);

            var selectedRadioButton = selectedItem.GetValue(RadioButton.BindingContextProperty);

        }
    }




    private void PressChosenButton_Clicked(object sender, EventArgs e)
    {
        answered = false;

        //почему-то циклы не работают в тестах
        if (!answered)
        {
            if (rb1.IsChecked || rb2.IsChecked || rb3.IsChecked)
            {
                //самый главный метод всего приложения
                checkAnswer();

            }

            else
            {
                ShowNextQuestion();
            }


        }
    }



    private static void finishQuiz()
    {
        //сделать логику, отмеченную выше в вызове метода finishQuiz();
        Label backToMenu = new Label();
        backToMenu.Text = "Закончили, давай обратно в меню";

        backToMenu.TextColor = Color.FromArgb("green");
        //что это за свойство такое - Color.FromArgb("green"); ?? Раньше было проще - Color.Red;

    }

}
