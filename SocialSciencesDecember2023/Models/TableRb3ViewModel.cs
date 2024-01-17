//вопрос 1 - если мы сделали у radiobutton комманду и даже параметр (commandparameter), надо ли нам в ViewModel делать помимо самой команды еще специальный метод bool _Checked

using Microsoft.EntityFrameworkCore;    // для ToListAsync и FirstOrDefaultAsync
using SocialSciencesEF2024.TableRb3;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using System.ComponentModel;
using System.Windows.Input;

namespace SocialSciencesEF2024.TableRb3
{
	public class TableRb3ViewModel : INotifyPropertyChanged
    {
        private TableRB3 currentQuestion;
        public ICommand RadioButtonIsCheckedCommand { get; set; }
        public Command ButtonConfirmClickedCommand { get; }

        private string _option1;
        private string _option2;
        private string _option3;

        private int _answerNr;
        private int _indexOfSelectedRb;

        private string _ifRight;
        private string _ifWrong;




        public event PropertyChangedEventHandler PropertyChanged;

        public string Option1
        {
            get { return currentQuestion.option1; }
            set
            {
                _option1 = value;
                OnPropertyChanged("Option1");
            }
        }
        public string Option2
        {
            get { return currentQuestion.option1; }
            set
            {

                _option2 = value;
                OnPropertyChanged("Option2");
            }

        }
        public string Option3
        {
            get { return currentQuestion.option1; }
            set
            {

                _option3 = value;
                OnPropertyChanged("Option2");
            }
        }

        public int AnswerNr
        {
            get { return currentQuestion.answerNr; }
            set
            {

                _answerNr = value;
                OnPropertyChanged("AnswerNr");
            }
        }

        public string IfRight
        {
            get { return currentQuestion.ifRight; }
            set
            {

                _ifRight = value;
                OnPropertyChanged("_ifRight");
            }
        }

        public string IfWrong
        {
            get { return currentQuestion.ifWrong; }
            set
            {

                _ifWrong = value;
                OnPropertyChanged("_ifWrong");
            }
        }


        public TableRb3ViewModel()
        {




            RadioButtonIsCheckedCommand = new Command((object? commandParameter) =>
                    {
                        var indexOfSelectedRb = commandParameter;
                        int _indexOfSelectedRb = Convert.ToInt32(indexOfSelectedRb);


                    });

            ButtonConfirmClickedCommand = new Command((object? args) =>
            {
                //тут надо проверить, чтобы хотя бы одна радиокнопка была нажата... 
		//то есть надо сделать проверку на null. Какой объект надо проверить ? Нельзя ли полученный _indexOfSelectedRb сравнить на null? 
		//if (_intOfSelectedRb != null)

  
  			{
  				//процесс сравнения соответствия / несоответствия с БД
  			}

    // else 
     { 
     //какое-то действие. Например, появление на экране строки "Выберите вариант ответа"
     }
     

            });

        }


    private void OnPropertyChanged(string propertyname)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }

        public void QuizActivity()
        {
            TableRB3Context db = new TableRB3Context();
            var itemOfQuestions = db.questionList.ToList();
            foreach (var item in itemOfQuestions)
            {

                //к этому моменту уже сделана привязка к БД в конструкторе
                //надо включить команду нажатия на кнопку
                //в команде будет проверка истиннности нажатой кнопки, затем получение индекса нажатой радиокнопки (чере отдельный) класс
                //затем будет вызываться метод checkAnswer();
                //в методе будут условия if(true)  и if(false)

                //теперь надо вызвать команды ButtonConfirmClickedCommand
                //потом RadioButtonIsCheckedCommand
                //затем провести следующее сравнение:
                if (_indexOfSelectedRb == _answerNr)
                {
                    //во всплывающем окне должен быть привязан текст из ifRight


                    //переделать через паттерн  MVVM
                    var popupifRight = new Popup()
                    {

                        Content = new VerticalStackLayout
                        {
                            Children =
                        {
                            new Label
                            {
                                Text = _ifRight
                            }
                        }
                        }
                    };


                }

                else
                {

                    //переделать через паттерн  MVVM
                    var popupIfWrong = new Popup()
                    {

                        Content = new VerticalStackLayout
                        {
                            Children =
                        {
                            new Label
                            {
                                Text = _ifWrong
                            }
                        }
                        }
                    };

                }

                if (currentQuestion.id < itemOfQuestions.Count)
                {
                    item.id++;
                    //или continue;?
                    //вообще кажется, что инкремент не нужен, потому что это же цикл foreach, он снова должен запуститься, разве нет ???

                }
                else
                {
                    finishQuiz();
                }

            }

        }

        private async void finishQuiz()
        {
            //логика закрытия quiz - переход к новому экрану, где кнопки либо возврат в главное меню, либо к след уровнюon.

        }

    }



}
      

