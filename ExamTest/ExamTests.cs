using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamApp; 

[TestClass]
public class ExamTests
{
    [TestMethod]
    public void CalculateGrade_MaxScores_Returns5()
    {
        var vm = new MainViewModel
        {
            Score1 = 25,
            Score2 = 25,
            Score3 = 25,
            Score4 = 25
        };

        vm.Calculate();

        Assert.AreEqual("Сумма: 100\nОценка: 5", vm.ResultText);
    }

    [TestMethod]
    public void Validate_ScoreAbove25_ClampsTo25()
    {
        var vm = new MainViewModel();

        vm.Score1 = 30;

        Assert.AreEqual(25, vm.Score1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Calculate_InvalidScores_ThrowsException()
    {
        var vm = new MainViewModel();
        typeof(MainViewModel).GetProperty("Score1").SetValue(vm, -5, null);

        vm.Calculate();
    }
}