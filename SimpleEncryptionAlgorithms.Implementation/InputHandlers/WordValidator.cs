using System;

namespace SimpleEncryptionAlgorithms.Implementation.InputHandlers
{
    public class WordValidator
    {
        private protected bool CheckEnteredWord(string word)
        {
            bool check = true;
            
            foreach (var letter in word)
            {
                if ((letter is >= 'А' and <= 'Я') || (letter is >= 'а' and <= 'я')
                                                  || letter == Convert.ToChar(" ")
                                                  || (letter is 'ё' or 'Ё') 
                                                  || letter == '-')
                {
                    continue;
                }
                else
                {
                    check = false;
                }
            }

            return check;
        }
    }
}