using MarksConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyProject.Tests
{
    [TestClass]
    public class UnitTestCase
    {
        //The below test cases checks the expected grades with the grades getting defined by the application
        [TestMethod]
        public void TestGetGrade()
        {
            int[] marks = { 80, 70, 60, 50, 40, 30, 20, 10, 0, -10 };

            Assert.AreEqual(Program.OutputGradeProfile(marks[0]), "A");
            Assert.AreEqual(Program.OutputGradeProfile(marks[1]), "B");
            Assert.AreEqual(Program.OutputGradeProfile(marks[2]), "C");
            Assert.AreEqual(Program.OutputGradeProfile(marks[3]), "D");
            Assert.AreEqual(Program.OutputGradeProfile(marks[4]), "E");
            Assert.AreEqual(Program.OutputGradeProfile(marks[5]), "F");
            Assert.AreEqual(Program.OutputGradeProfile(marks[6]), "F");
            Assert.AreEqual(Program.OutputGradeProfile(marks[7]), "F");
            Assert.AreEqual(Program.OutputGradeProfile(marks[8]), "F");
            Assert.AreEqual(Program.OutputGradeProfile(marks[9]), "F");
        }
    }
}

