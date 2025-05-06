using Larin_M2;

using System.Text.RegularExpressions;
namespace TestProject1
{
    public static class DataValidator
    {
        public static bool ValidatePhone(string phone) =>
            Regex.IsMatch(phone, @"^\+7\d{10}$");

        public static bool ValidateEmail(string email) =>
            Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

        public static bool ValidateRating(string value, out int rating)
        {
            if (int.TryParse(value, out rating) && rating >= 0 && rating <= 10)
                return true;
            rating = -1;
            return false;
        }

        public static bool ValidateINN(string inn) =>
            long.TryParse(inn, out _) && (inn.Length == 10 || inn.Length == 12);

        public static bool ValidateDirectorName(string name) =>
            !string.IsNullOrWhiteSpace(name) && name.Trim().Length >= 3;

        public static bool ValidateRequired(params string[] fields)
        {
            foreach (var f in fields)
                if (string.IsNullOrWhiteSpace(f)) return false;
            return true;
        }
    }

    [TestFixture]
    public class DataValidatorNUnitTests
    {
        // 1-5: Phone tests
        [TestCase("+71234567890", ExpectedResult = true)]
        [TestCase("71234567890", ExpectedResult = false)]
        [TestCase("+7123456789", ExpectedResult = false)]
        [TestCase("+7abcdefghij", ExpectedResult = false)]
        [TestCase("+79991234567", ExpectedResult = true)]
        public bool ValidatePhoneTests(string phone) =>
            DataValidator.ValidatePhone(phone);

        // 6-10: Email tests
        [TestCase("test@example.com", ExpectedResult = true)]
        [TestCase("user.name+tag@domain.co", ExpectedResult = true)]
        [TestCase("user@", ExpectedResult = false)]
        [TestCase("@domain.com", ExpectedResult = false)]
        [TestCase("user@domain", ExpectedResult = false)]
        public bool ValidateEmailTests(string email) =>
            DataValidator.ValidateEmail(email);

        // 11-20: Rating tests
        [TestCase("0", ExpectedResult = true)]
        [TestCase("10", ExpectedResult = true)]
        [TestCase("5", ExpectedResult = true)]
        [TestCase("-1", ExpectedResult = false)]
        [TestCase("11", ExpectedResult = false)]
        [TestCase("abc", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase(" ", ExpectedResult = false)]
        [TestCase("7.5", ExpectedResult = false)]
        public bool ValidateRatingTests(string input) =>
            DataValidator.ValidateRating(input ?? string.Empty, out _);

        // 21-25: INN tests
        [TestCase("1234567890", ExpectedResult = true)]
        [TestCase("123456789012", ExpectedResult = true)]
        [TestCase("123456789", ExpectedResult = false)]
        [TestCase("12345678901", ExpectedResult = false)]
        [TestCase("abcdefghij", ExpectedResult = false)]
        public bool ValidateINNTests(string inn) =>
            DataValidator.ValidateINN(inn);

        // 26-28: Director name tests
        [TestCase("Ivanov Ivan", ExpectedResult = true)]
        [TestCase("AB", ExpectedResult = false)]
        [TestCase("   ", ExpectedResult = false)]
        public bool ValidateDirectorNameTests(string name) =>
            DataValidator.ValidateDirectorName(name);

        // 29-30: Required fields tests
        [Test]
        public void ValidateRequired_AllFilled_ReturnsTrue() =>
            Assert.IsTrue(DataValidator.ValidateRequired("a", "b", "c"));

        [Test]
        public void ValidateRequired_HasEmpty_ReturnsFalse() =>
            Assert.IsFalse(DataValidator.ValidateRequired("a", "", "c"));
    }
}