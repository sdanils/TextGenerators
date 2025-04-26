namespace Programm.Tests;
using TextBG;
using TextFW;
using Program;


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestGenBGOne()
    {
        TextGeneratorBG genBG = new TextGeneratorBG("../../../../data_source/bgramm_data.txt");
        string textBG = genBG.GenerateText(1000);
        int expected = 1000;
        Assert.AreEqual(expected, textBG.Length);
    }
    [TestMethod]
    public void TestGenBGTwo()
    {
        TextGeneratorBG genBG = new TextGeneratorBG("../../../../data_source/bgramm_data.txt");
        string textBG = genBG.GenerateText(100001);
        int expected = 100001;
        Assert.AreEqual(expected, textBG.Length);
    }
    [TestMethod]
    public void TestSaveBGOne()
    {
        TextGeneratorBG genBG = new TextGeneratorBG("../../../../data_source/bgramm_data.txt");
        string textBG = genBG.GenerateText(100001);
        SaverFile.SaveText(textBG, "../../../testsFiles/testSave1.txt");
        string text = File.ReadAllText("../../../testsFiles/testSave1.txt");
        int expected = 100001;
        Assert.AreEqual(expected, text.Length);
    }
    [TestMethod]
    public void TestSaveBGTwo()
    {
        TextGeneratorBG genBG = new TextGeneratorBG("../../../../data_source/bgramm_data.txt");
        string textBG = genBG.GenerateText(1024);
        SaverFile.SaveText(textBG, "../../../testsFiles/testSave2.txt");
        string text = File.ReadAllText("../../../testsFiles/testSave2.txt");
        int expected = 1024;
        Assert.AreEqual(expected, text.Length);
    }
    [TestMethod]
    public void TestGenFWOne()
    {
        TextGeneratorFW genFW = new TextGeneratorFW("../../../../data_source/frequenc_word.txt");
        string textFW = genFW.GenerateText(1000);
        string[] parts = textFW.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int expected = 1000;
        Assert.AreEqual(expected, parts.Length);
    }
    [TestMethod]
    public void TestGenFWTwo()
    {
        TextGeneratorFW genFW = new TextGeneratorFW("../../../../data_source/frequenc_word.txt");
        string textFW = genFW.GenerateText(28);
        string[] parts = textFW.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int expected = 28;
        Assert.AreEqual(expected, parts.Length);
    }
    [TestMethod]
    public void TestSaveFWOne()
    {
        TextGeneratorFW genFW = new TextGeneratorFW("../../../../data_source/frequenc_word.txt");
        string textFW = genFW.GenerateText(28);
        SaverFile.SaveText(textFW, "../../../testsFiles/testSave3.txt");
        string text = File.ReadAllText("../../../testsFiles/testSave3.txt");
        string[] parts = textFW.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int expected = 28;
        Assert.AreEqual(expected, parts.Length);
    }
    [TestMethod]
    public void TestSaveFWTwo()
    {
        TextGeneratorBG genBG = new TextGeneratorBG("../../../../data_source/bgramm_data.txt");
        string textFW = genBG.GenerateText(100001);
        SaverFile.SaveText(textFW, "../../../testsFiles/testSave4.txt");
        string text = File.ReadAllText("../../../testsFiles/testSave4.txt");
        string[] parts = textFW.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int expected = 100001;
        Assert.AreEqual(expected, text.Length);
    }
    [TestMethod]
    public void TestGenBGThree()
    {
        TextGeneratorBG genBG = new TextGeneratorBG("../../../../data_source/bgramm_data.txt");
        string textBG = genBG.GenerateText(1);
        int expected = 1;
        Assert.AreEqual(expected, textBG.Length);
    }
    [TestMethod]
    public void TestGenFWThree()
    {
        TextGeneratorFW genFW = new TextGeneratorFW("../../../../data_source/frequenc_word.txt");
        string textFW = genFW.GenerateText(1);
        string[] parts = textFW.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int expected = 1;
        Assert.AreEqual(expected, parts.Length);
    }
    [TestMethod]
    public void TestGenBGFour()
    {
        TextGeneratorBG genBG = new TextGeneratorBG("../../../../data_source/bgramm_data.txt");
        string textBG = genBG.GenerateText(0);
        int expected = 0;
        Assert.AreEqual(expected, textBG.Length);
    }
}