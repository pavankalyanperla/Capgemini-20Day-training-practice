using System.Text.RegularExpressions;

// TODO 1: ZIP code pattern - test "12345", "12345-6789", "1234"
string zipPattern = @"^\d{5}(-\d{4})?$";
Console.WriteLine($"ZIP \"12345\": {Regex.IsMatch("12345", zipPattern)} | " +
                   $"\"12345-6789\": {Regex.IsMatch("12345-6789", zipPattern)} | " +
                   $"\"1234\": {Regex.IsMatch("1234", zipPattern)}");

// TODO 2: username pattern - test "user_1", "1user", "ab"
// 3-16 chars total, letters/digits/underscore only, must not start with a digit.
string usernamePattern = @"^[A-Za-z_][A-Za-z0-9_]{2,15}$";
Console.WriteLine($"Username \"user_1\": {Regex.IsMatch("user_1", usernamePattern)} | " +
                   $"\"1user\": {Regex.IsMatch("1user", usernamePattern)} | " +
                   $"\"ab\": {Regex.IsMatch("ab", usernamePattern)}");

// TODO 3: hex color pattern - test "#1A2B3C", "#GGGGGG", "1A2B3C"
string hexColorPattern = @"^#[0-9A-Fa-f]{6}$";
Console.WriteLine($"Hex \"#1A2B3C\": {Regex.IsMatch("#1A2B3C", hexColorPattern)} | " +
                   $"\"#GGGGGG\": {Regex.IsMatch("#GGGGGG", hexColorPattern)} | " +
                   $"\"1A2B3C\": {Regex.IsMatch("1A2B3C", hexColorPattern)}");

// TODO 4: password strength check - test "password", "Password1", "pass1"
// Chose separate checks combined with && instead of one giant pattern: each rule
// (length, digit present, uppercase present) reads clearly and is easy to extend later.
static bool IsStrongPassword(string password)
{
    bool longEnough = password.Length >= 8;
    bool hasDigit = Regex.IsMatch(password, @"\d");
    bool hasUpper = Regex.IsMatch(password, @"[A-Z]");
    return longEnough && hasDigit && hasUpper;
}
Console.WriteLine($"Password \"password\": {IsStrongPassword("password")} | " +
                   $"\"Password1\": {IsStrongPassword("Password1")} | " +
                   $"\"pass1\": {IsStrongPassword("pass1")}");

// TODO 5: single-terminator sentence pattern - test "Hello there.", "Wait...", "Really?"
string sentencePattern = @"^[^.!?]*[.!?]$";
Console.WriteLine($"Sentence \"Hello there.\": {Regex.IsMatch("Hello there.", sentencePattern)} | " +
                   $"\"Wait...\": {Regex.IsMatch("Wait...", sentencePattern)} | " +
                   $"\"Really?\": {Regex.IsMatch("Really?", sentencePattern)}");

// Bonus: combine username and password patterns into a signup validator.
static List<string> ValidateSignup(string username, string password)
{
    var errors = new List<string>();
    string usernamePattern = @"^[A-Za-z_][A-Za-z0-9_]{2,15}$";
    if (!Regex.IsMatch(username, usernamePattern))
        errors.Add("Username must be 3-16 characters, letters/digits/underscore only, and cannot start with a digit.");

    if (!IsStrongPassword(password))
        errors.Add("Password must be at least 8 characters and contain at least one digit and one uppercase letter.");

    return errors;
}

var signupErrors = ValidateSignup("1user", "weak");
Console.WriteLine($"\nValidateSignup(\"1user\", \"weak\") errors: {signupErrors.Count}");
foreach (var error in signupErrors)
    Console.WriteLine($" - {error}");

var validSignupErrors = ValidateSignup("user_1", "Password1");
Console.WriteLine($"ValidateSignup(\"user_1\", \"Password1\") errors: {validSignupErrors.Count} (empty = valid)");
