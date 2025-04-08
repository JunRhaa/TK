using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

public class MainViewModel : INotifyPropertyChanged
{
    private int _score1, _score2, _score3, _score4;
    private string _resultText;

    public int Score1
    {
        get => _score1;
        set { _score1 = Validate(value); OnPropertyChanged(); }
    }

    public int Score2
    {
        get => _score2;
        set { _score2 = Validate(value); OnPropertyChanged(); }
    }

    public int Score3
    {
        get => _score3;
        set { _score3 = Validate(value); OnPropertyChanged(); }
    }

    public int Score4
    {
        get => _score4;
        set { _score4 = Validate(value); OnPropertyChanged(); }
    }

    public string ResultText
    {
        get => _resultText;
        set { _resultText = value; OnPropertyChanged(); }
    }

    public ICommand CalculateCommand { get; }

    public MainViewModel()
    {
        CalculateCommand = new RelayCommand(Calculate);
    }

    public void Calculate()
    {
        int sum = Score1 + Score2 + Score3 + Score4;
        string grade;
        if (sum >= 90) grade = "5";
        else if (sum >= 75) grade = "4";
        else if (sum >= 60) grade = "3";
        else grade = "2";
        ResultText = $"Сумма: {sum}\nОценка: {grade}";
    }

    private int Validate(int value)
    {
        if (value < 0) return 0;
        if (value > 25) return 25;
        return value;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}