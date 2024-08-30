namespace TestProject {
    public class NumberTests {

        private NumberLogic.Numbers logic;

        [SetUp]
        public void Setup() {
            logic = new NumberLogic.Numbers();
        }

        private struct TestCase {
            public string Value { get; }
            public string Expected { get; }
            public TestCase(string value, string expected) {
                Value = value;
                Expected = expected;
            }
        }

        [Test]
        public void WholeNumbers() {


            TestCase[] tests = new TestCase[] {
         new TestCase("10230", "Ten Thousand Two Hundred and Thirty"),
        new TestCase("2013", "Two Thousand and Thirteen"),
        new TestCase("0", "Zero"),
        new TestCase("1", "One"),
        new TestCase("10", "Ten"),
        new TestCase("11", "Eleven"),
        new TestCase("100", "One Hundred"),
        new TestCase("200", "Two Hundred"),
        new TestCase("300", "Three Hundred"),
        new TestCase("1000", "One Thousand"),
        new TestCase("2000", "Two Thousand"),
        new TestCase("2012", "Two Thousand and Twelve"),
        new TestCase("10079", "Ten Thousand and Seventy Nine"),
        new TestCase("30293281", "Thirty Million Two Hundred Ninety Three Thousand Two Hundred and Eighty One"),
        new TestCase("239340349", "Two Hundred Thirty Nine Million Three Hundred Forty Thousand Three Hundred and Forty Nine"),
        new TestCase("2147483647", "Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred and Forty Seven"),// Max Int
        new TestCase("2147483648", "Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred and Forty Eight"),
        new TestCase("4294967295", "Four Billion Two Hundred Ninety Four Million Nine Hundred Sixty Seven Thousand Two Hundred and Ninety Five"),
        new TestCase("9,223,372,036,854,775,807","Nine Quintillion Two Hundred Twenty Three Quadrillion Three Hundred Seventy Two Trillion Thirty Six Billion Eight Hundred Fifty Four Million Seven Hundred Seventy Five Thousand Eight Hundred and Seven")
      };


            RunTests(tests, false);
        }

        [Test]
        public void NegativeNumbersNumbers() {


            TestCase[] tests =  {
        new TestCase("-0", "Zero"),
        new TestCase("-1", "Negative One"),
        new TestCase("-10", "Negative Ten"),
        new TestCase("-11", "Negative Eleven"),
        new TestCase("-100", "Negative One Hundred"),
        new TestCase("-200", "Negative Two Hundred"),
        new TestCase("-1000", "Negative One Thousand"),
        new TestCase("-2012", "Negative Two Thousand and Twelve"),
        new TestCase("-2013", "Negative Two Thousand and Thirteen"),
        new TestCase("-10230", "Negative Ten Thousand Two Hundred and Thirty"),
        new TestCase("-30293281", "Negative Thirty Million Two Hundred Ninety Three Thousand Two Hundred and Eighty One"),
        new TestCase("-239340349", "Negative Two Hundred Thirty Nine Million Three Hundred Forty Thousand Three Hundred and Forty Nine"),
        new TestCase("-2147483647", "Negative Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred and Forty Seven"),
        new TestCase("-4294967295", "Negative Four Billion Two Hundred Ninety Four Million Nine Hundred Sixty Seven Thousand Two Hundred and Ninety Five"),
        new TestCase("-9,223,372,036,854,775,807", "Negative Nine Quintillion Two Hundred Twenty Three Quadrillion Three Hundred Seventy Two Trillion Thirty Six Billion Eight Hundred Fifty Four Million Seven Hundred Seventy Five Thousand Eight Hundred and Seven"),
      };

            RunTests(tests, false);
        }

        [Test]
        public void PartialNumbersNumbers() {


            TestCase[] tests = new TestCase[] {
        new TestCase("0.17", "Zero Point One Seven"),
        new TestCase(".18", "Point One Eight"),
        new TestCase("173.159", "One Hundred and Seventy Three Point One Five Nine"),
      };

            RunTests(tests, false);
        }

        [Test]
        public void Currency() {
            TestCase[] tests = {
                new TestCase("100.173", "One Hundred Dollars and Seventeen Cents"),
                new TestCase("0.50", "Fifty Cents"),
                new TestCase("0.00", "Zero Dollars"),
                new TestCase(".18", "Eighteen Cents"),
                new TestCase("173.159", "One Hundred and Seventy Three Dollars and Fifteen Cents"),
              };

            RunTests(tests, true);
        }


        private void RunTests(TestCase[] tests, bool Currency) {

            string result;
            foreach (var test in tests) {
                result = logic.Convert(test.Value, Currency);
                if (test.Expected != result) {
                    System.Console.WriteLine($"{test.Value} is not correct. Expected : '{test.Expected}' but got '{result}'");
                    Assert.Fail();
                    return;
                } else {
                    System.Console.WriteLine($"{test.Value} is correct : {result}");
                }

            }

        }


        [Test]
        public void LargeNumbers() {

            TestCase[] tests = new TestCase[] {
         new TestCase("9,999", "Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999", "Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999", "Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999", "Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999", "Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999", "Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999", "Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999,999", "Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999,999,999", "Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999,999,999,999", "Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999,999,999,999,999", "Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),

        new TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Quindecillion Nine Hundred Ninety Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Sexdecillion Nine Hundred Ninety Nine Quindecillion Nine Hundred Ninety Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Septendecillion Nine Hundred Ninety Nine Sexdecillion Nine Hundred Ninety Nine Quindecillion Nine Hundred Ninety Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Octodecillion Nine Hundred Ninety Nine Septendecillion Nine Hundred Ninety Nine Sexdecillion Nine Hundred Ninety Nine Quindecillion Nine Hundred Ninety Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Novemdecillion Nine Hundred Ninety Nine Octodecillion Nine Hundred Ninety Nine Septendecillion Nine Hundred Ninety Nine Sexdecillion Nine Hundred Ninety Nine Quindecillion Nine Hundred Ninety Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),
        new TestCase("9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999", "Nine Vigintillion Nine Hundred Ninety Nine Novemdecillion Nine Hundred Ninety Nine Octodecillion Nine Hundred Ninety Nine Septendecillion Nine Hundred Ninety Nine Sexdecillion Nine Hundred Ninety Nine Quindecillion Nine Hundred Ninety Nine Quattuordecillion Nine Hundred Ninety Nine Tredecillion Nine Hundred Ninety Nine Duodecillion Nine Hundred Ninety Nine Undecillion Nine Hundred Ninety Nine Decillion Nine Hundred Ninety Nine Nonillion Nine Hundred Ninety Nine Octillion Nine Hundred Ninety Nine Septillion Nine Hundred Ninety Nine Sextillion Nine Hundred Ninety Nine Quintillion Nine Hundred Ninety Nine Quadrillion Nine Hundred Ninety Nine Trillion Nine Hundred Ninety Nine Billion Nine Hundred Ninety Nine Million Nine Hundred Ninety Nine Thousand Nine Hundred and Ninety Nine"),


      };


            RunTests(tests, false);
        }


        [Test]
        public void InvalidNumbers() {
            string[] invalid = new string[] {
        "5.34.23",
        "5clic",
        "9,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999,999" // Bigger than currently allowed
      };

            foreach (var test in invalid) {
                try {
                    var result = logic.Convert(test, false);
                    Assert.Fail($"{test} should have thrown an error, but resulted in : {result}");
                    return;
                } catch (Exception ex) {
                    System.Console.WriteLine($"{test} threw error : '{ex.Message}'");
                }
            }
        }
    }
}