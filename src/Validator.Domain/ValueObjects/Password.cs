using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Validator.Domain.ValueObjects
{
    public class Password
    {
        private const string PasswordPattern = @"^(?!.*([A-Za-z\d!@#$%^&*\(\)-+])\1{1})(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*\(\)-+])[A-Za-z\d!@#$%^&*\(\)-+]{9,}$";
        private readonly Regex _regex;

        public Password(string value)
        {
            Value = value;
            _regex = new Regex(PasswordPattern);
        }

        public string Value { get; private set; }

        public bool IsValid()
        {
            IEnumerable<char> characters = Value.ToList();
            characters = characters.OrderBy(c => c);
            string password = CharactersListToString(characters);
            return _regex.IsMatch(password);
        }

        private string CharactersListToString(IEnumerable<char> characters)
        {
            return new string(characters.ToArray());
        }
    }
}