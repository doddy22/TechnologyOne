using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace TestProject {
    public class NumberTests {

        private NumberLogic.NumbersToWords logic;

        [SetUp]
        public void Setup() {
            logic = new NumberLogic.NumbersToWords();
        }


        /// <summary>
        /// Test Case 1 - Check that integers convert correctly
        /// </summary>
        [Test]
        [TestCase("0", "Zero")]
        [TestCase("1", "One")]
        [TestCase("0000001", "One")]
        [TestCase("10", "Ten")]
        [TestCase("11", "Eleven")]
        [TestCase("100", "One Hundred")]
        [TestCase("300", "Three Hundred")]
        [TestCase("1000", "One Thousand")]
        [TestCase("2012", "Two Thousand and Twelve")]
        [TestCase("2013", "Two Thousand and Thirteen")]
        [TestCase("10079", "Ten Thousand and Seventy Nine")]
        [TestCase("30293281", "Thirty Million Two Hundred Ninety Three Thousand Two Hundred and Eighty One")]
        [TestCase("239340349", "Two Hundred Thirty Nine Million Three Hundred Forty Thousand Three Hundred and Forty Nine")]
        [TestCase("2147483647", "Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred and Forty Seven")]
        [TestCase("2147483648", "Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred and Forty Eight")]
        [TestCase("4294967295", "Four Billion Two Hundred Ninety Four Million Nine Hundred Sixty Seven Thousand Two Hundred and Ninety Five")]
        [TestCase("9,223,372,036,854,775,807", "Nine Quintillion Two Hundred Twenty Three Quadrillion Three Hundred Seventy Two Trillion Thirty Six Billion Eight Hundred Fifty Four Million Seven Hundred Seventy Five Thousand Eight Hundred and Seven")]
        public void WholeNumbers(string Input, string Expected) {
            RunTests(Input, Expected, false);
        }

        /// <summary>
        /// Test Case 2 - Check Decimals are converting correctly
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="Expected"></param>
        [Test]
        [TestCase("123.45", "One Hundred and Twenty Three Point Four Five")]
        [TestCase("0.17", "Zero Point One Seven")]
        [TestCase(".18", "Point One Eight")]
        [TestCase("173.159", "One Hundred and Seventy Three Point One Five Nine")]
        public void DecimalNumbers(string Input, string Expected) {
            RunTests(Input, Expected, false);
        }

        /// <summary>
        /// Test Case 3 - Check Large Numbers are Converting Properly
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="Expected"></param>
        [Test]
        [TestCase("9,999", "Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999", "Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999", "Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999", "Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999", "Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999", "Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999", "Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999", "Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999,999", "Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999,999,999", "Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999,999,999,999", "Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Quindecillion Nine Hundred Ninety Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Sexdecillion Nine Hundred Ninety Nine Quindecillion Nine Hundred Ninety Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Septendecillion Nine Hundred Ninety Nine Sexdecillion Nine Hundred Ninety Nine Quindecillion Nine Hundred Ninety Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Octodecillion Nine Hundred Ninety Nine Septendecillion Nine Hundred Ninety Nine Sexdecillion Nine Hundred Ninety Nine Quindecillion Nine Hundred Ninety Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Novemdecillion Nine Hundred Ninety Nine Octodecillion Nine Hundred Ninety Nine Septendecillion Nine Hundred Ninety Nine Sexdecillion Nine Hundred Ninety Nine Quindecillion Nine Hundred Ninety Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        [TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Vigintillion Nine Hundred Ninety Nine Novemdecillion Nine Hundred Ninety Nine Octodecillion Nine Hundred Ninety Nine Septendecillion Nine Hundred Ninety Nine Sexdecillion Nine Hundred Ninety Nine Quindecillion Nine Hundred Ninety Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine")]
        public void LargeNumbers(string Input, string Expected) {
            RunTests(Input, Expected, false);
        }


        /// <summary>
        /// Test Case 4 - Negative Numbers
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="Expected"></param>
        [Test]
        [TestCase("-0", "Zero")]
        [TestCase("-1", "Negative One")]
        [TestCase("-0000001", "Negative One")]
        [TestCase("-10", "Negative Ten")]
        [TestCase("-11", "Negative Eleven")]
        [TestCase("-100", "Negative One Hundred")]
        [TestCase("-200", "Negative Two Hundred")]
        [TestCase("-1000", "Negative One Thousand")]        
        [TestCase("-2012", "Negative Two Thousand and Twelve")]
        [TestCase("-2013", "Negative Two Thousand and Thirteen")]
        [TestCase("-10230", "Negative Ten Thousand Two Hundred and Thirty")]
        [TestCase("-30293281", "Negative Thirty Million Two Hundred Ninety Three Thousand Two Hundred and Eighty One")]
        [TestCase("-239340349", "Negative Two Hundred Thirty Nine Million Three Hundred Forty Thousand Three Hundred and Forty Nine")]
        [TestCase("-2147483647", "Negative Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred and Forty Seven")]
        [TestCase("-4294967295", "Negative Four Billion Two Hundred Ninety Four Million Nine Hundred Sixty Seven Thousand Two Hundred and Ninety Five")]
        [TestCase("-9,223,372,036,854,775,807", "Negative Nine Quintillion Two Hundred Twenty Three Quadrillion Three Hundred Seventy Two Trillion Thirty Six Billion Eight Hundred Fifty Four Million Seven Hundred Seventy Five Thousand Eight Hundred and Seven")]
        public void NegativeNumbers(string Input, string Expected) {
            RunTests(Input, Expected, false);
        }


        /// <summary>
        /// Test Case 5 - Check Invalid Input
        /// </summary>
        /// <param name="Input"></param>
        [Test]
        [TestCase("abc")]
        [TestCase("5.34.23")]
        [TestCase("5clic")]
        [TestCase("")]
        [TestCase("jksfsdf.fsdf")]
        [TestCase("google")]
        [TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999")]// Bigger than currently allowed
        public void InvalidNumbers(string Input) {
            try {
                var result = logic.Convert(Input, false);
                Assert.Fail($"{Input} should have thrown an error, but resulted in : {result}");
                return;
            } catch (Exception ex) {
                System.Console.WriteLine($"{Input} threw error : '{ex.Message}'");
            }            
        }

        /// <summary>
        /// Test Case 6 - Check Currency Mode is Displaying Correctly
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="Excepted"></param>
        [Test]
        [TestCase("100.173", "One Hundred Dollars and Seventeen Cents")]
        [TestCase("0.50", "Fifty Cents")]
        [TestCase("123.45", "One Hundred and Twenty Three Dollars and Forty Five Cents")]
        [TestCase("0.00", "Zero Dollars")]
        [TestCase(".18", "Eighteen Cents")]
        [TestCase("173.159", "One Hundred and Seventy Three Dollars and Fifteen Cents")]
        [TestCase("123.459", "One Hundred and Twenty Three Dollars and Forty Five Cents")]
        public void Currency(string Input, string Excepted) {
            RunTests(Input, Excepted, true);
        }



        private void RunTests(string Input, string Expected, bool Currency) {      
            var result = logic.Convert(Input, Currency);
            if (Expected != result) {
                System.Console.WriteLine($"{Input} is not correct. Expected : '{Expected}' but got '{result}'");
                Assert.Fail();
                return;
            } else {
                System.Console.WriteLine($"{Input} is correct : {result}");
            }            

        }







        /// <summary>
        /// Test Case 12 - Measure the response time for converting large amount of numbers
        /// </summary>
        [Test]        
        public void CheckPerformance() {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();

            for (var i = 0; i < 1000000; i++) {
                logic.Convert(i.ToString(), false);
            }

            timer.Stop();

            int elapsedSeconds = timer.Elapsed.Seconds;
            Console.WriteLine("Time in seconds to convert all numbers from zero to one million: " + elapsedSeconds);
            bool ExecutionTimeLessThanFiveSeconds = (elapsedSeconds < 5);
            Assert.IsTrue(ExecutionTimeLessThanFiveSeconds, "Should take less than five seconds");
        }

    }
}