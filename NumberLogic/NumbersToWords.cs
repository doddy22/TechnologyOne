﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace NumberLogic {

    /// <summary>
    /// The logic for converting numbers to words
    /// </summary>
    public class NumbersToWords {

        /// <summary>
        /// Large Numbers Sizes
        /// Reference for the numbers - http://sunshine.chpc.utah.edu/Labs/ScientificNotation/ManSciNot1/table.html
        /// </summary>
        private enum NumberSizes {
            Digits = 0, // Anything less than 1000
            Thousand = 1,
            Million = 2,
            Billion = 3,
            Trillion = 4,
            Quadrillion = 5,
            Quintillion = 6,
            Sextillion = 7,
            Septillion = 8,
            Octillion = 9,
            Nonillion = 10,
            Decillion = 11,
            Undecillion = 12,
            Duodecillion = 13,
            Tredecillion = 14,
            Quattuordecillion = 15,
            Quindecillion = 16,
            Sexdecillion = 17,
            Septendecillion = 18,
            Octodecillion = 19,
            Novemdecillion = 20,
            Vigintillion = 21
        }

        /// <summary>
        /// Our base list of Numbers/words
        /// </summary>
        private enum NumberValues {
            Zero = 0,
            // Digits
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            // Teens
            Eleven = 11,
            Twelve = 12,
            Thirteen = 13,
            Fourteen = 14,
            Fifteen = 15,
            Sixteen = 16,
            Seventeen = 17,
            Eighteen = 18,
            Nineteen = 19,
            // Tens
            Ten = 10,
            Twenty = 20,
            Thirty = 30,
            Forty = 40,
            Fifty = 50,
            Sixty = 60,
            Seventy = 70,
            Eighty = 80,
            Ninety = 90,
        }


        /// <summary>
        /// Is part of a bigger number ( each number is broken into 3 digits with their appropriate size notation )
        /// </summary>
        private struct NumberPart {

            public NumberSizes Size;
            public int Value;
        }

        /// <summary>
        /// Converts the Given Number to Words
        /// </summary>
        /// <param name="Number">The Number you want to convert to words</param>
        /// <param name="Dollars">When true, the words are in the form of dollars and cents</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string Convert(string Number, bool Dollars) {
            if (string.IsNullOrEmpty(Number)) {
                throw new Exception("Invalid Number");
            }
            List<string> converted = new List<string>();

            // Split it into the left and right side of the decimal place
            var splits = SplitNumber(Number);

            // Check if it's a negative number
            if (Number.StartsWith("-")) {
                if (splits.left != "0") {
                    converted.Add("Negative");
                }
            }

            if (!string.IsNullOrEmpty(splits.left)) {
                
                if (Dollars) {                    
                    if (splits.left != "0") {
                        converted.Add(ConvertLeftSide(splits.left));
                        converted.Add("Dollars");
                    }
                } else {
                    converted.Add(ConvertLeftSide(splits.left));
                }
            }

            if (!string.IsNullOrEmpty(splits.right)) {
                var right_side = ConvertRightSide(splits.right, Dollars);
                if (!string.IsNullOrEmpty(right_side)) {
                    if (converted.Any()) {
                        converted.Add(Dollars ? "and" : "Point");
                    } else if (!Dollars) {
                        converted.Add("Point");
                    }
                    converted.Add(right_side);

                }
            }
            if (Dollars && (!converted.Any())) {
                return "Zero Dollars";
            }

            return string.Join(" ", converted);

        }

        /// <summary>
        /// Split the Number, so that we have what's on either side of the decimal point
        /// Also does some basic error correcting to minor malformed numbers
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        private (string left, string right) SplitNumber(string Number) {
            // Trim off any other extra's we don't want but might be there ( $, -, ' ' )
            string trimmed = Number.Replace(" ", "").Replace("$", "").Replace("-", "").Replace(",", "");
            string[] splits = trimmed.Split('.');
            if (splits.Length > 2 || splits.Length == 0) {
                throw new Exception("Invalid Number");
            }
            if (splits.Length == 1) {
                if (trimmed.StartsWith('.')) {
                    return ("", splits[0]);
                }
                return (splits[0], "");
            }
            return (splits[0], splits[1]);
        }

        /// <summary>
        /// Converts the left side of the decimal
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        private string ConvertLeftSide(string Number) {

            if (Number.Any(z => !Char.IsDigit(z))) {
                throw new Exception("Invalid Number");
            }

            // Break the number up into groups of 3
            NumberPart[] parts = BreakIntoParts(Number);

            if (parts.Length == 0) {
                return ""; // No Parts? Return an Empty string ie No Words
            } else if (parts.Length == 1) {
                return Convert(parts[0]);
            }

            if (!Enum.IsDefined(parts.First().Size)) {
                throw new Exception("Number is too Large");
            }

            // Convert all the parts to words
            List<string> values = new List<string>();
            foreach (var part in parts) {
                if (part.Value > 0) {
                    values.Add(Convert(part));
                }
            }

            // Insert an 'and' if needed
            if (values.Count > 1) {
                if (parts.Last().Value < 100) {
                    values.Insert(values.Count - 1, "and");
                }
            }
            return string.Join(" ", values);

        }

        /// <summary>
        /// Breaks a Number into groups of 3 digits and tagging them with their appriapte sizing ( millions, billions etc)
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        private NumberPart[] BreakIntoParts(string Number) { 
        
            return Number.Reverse()
              .Select((c, index) => new {
                  value = (int)Char.GetNumericValue(c) * ((int)Math.Pow(10, (index % 3))),
                  grouping = (int)(index / 3M)
              }).GroupBy(x => x.grouping)
              .Select(x => new NumberPart() {
                  Size = (NumberSizes)x.First().grouping,
                  Value = x.Sum(v => v.value)
              }).OrderByDescending(x => x.Size).ToArray();

        }

        /// <summary>
        /// Converts the Right Side of the Decimal Place
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="Dollars">Displays as Cents when true</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string ConvertRightSide(string Number, bool Dollars) {

            if (Dollars) {
                if (string.IsNullOrEmpty(Number)) {
                    return "";
                }

                if (Number.Length == 1) {
                    Number += "0";
                } else if (Number.Length > 2) {
                    Number = Number.Substring(0, 2);
                }
                try {
                    var cents = int.Parse(Number);
                    if (cents > 0) {
                        return $"{Convert(cents)} Cents";
                    }
                } catch (Exception) {
                    throw new Exception("Invalid Cents Value");
                }

            } else {
                List<string> values = new List<string>();
                foreach (char c in Number) {
                    if (Char.IsDigit(c)) {
                        values.Add(Convert((int)Char.GetNumericValue(c)));
                    }
                }
                if (values.Any()) {                    
                    return string.Join(" ", values);
                }
            }
            return "";

        }

        /// <summary>
        /// Number has to be less than 1000
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        private string Convert(NumberPart Number) {
            if (Number.Value < 1000) {
                List<string> converted = new List<string>();

                int tens = Number.Value % 100;

                if (Number.Value >= 100) {
                    converted.Add(Convert(Number.Value / 100) + " Hundred");
                    if (tens == 0) {
                        return converted[0];
                    }
                }

                if (tens >= 0) {
                    converted.Add(Convert(tens));
                }
                if (Number.Size == NumberSizes.Digits) {
                    return String.Join(" and ", converted);
                }
                converted.Add(Number.Size.ToString());
                return String.Join(" ", converted);
            }
            throw new Exception("Invalid Number");
        }


        /// <summary>
        /// Converts a Number that is less that 100 to words
        /// Utility function that does the majority of the conversion
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string Convert(int Number) {

            if (Number < 100) {

                if (Enum.IsDefined(typeof(NumberValues), Number)) {
                    // Is one of the predefined values, so just return the words
                    return ((NumberValues)Number).ToString();
                } else {
                    // Create the words by spliting the value into it's 2 base components
                    int digits = Number % 10;
                    int tens = Number - digits;
                    return $"{Convert(tens)} {Convert(digits)}";
                }
            }
            throw new Exception("Unable to Convert Number");
        }

    }
}
