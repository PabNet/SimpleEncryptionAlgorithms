using System;
using System.Collections.Generic;

namespace SimpleEncryptionAlgorithms.Implementation.EncryptionMethods.RailwayFence
{
    public abstract class RailwayFenceEncryption : IRailwayFenceEncryption
    {
        private protected readonly byte _key;
        private protected static byte _letterIndex;
        private protected string _word;
        private protected List<List<char>> _letterList;


        public RailwayFenceEncryption(byte key, string word)
        {
            this._key = key;
            this._word = word;
            this._letterList = new List<List<char>>();
            _letterIndex = 0;
        }


        public string GetWord()
        {
            ProcessWord();
            this._word = this._word.Remove(0, this._word.Length);
            PutTogetherTheWord();
            return this._word;
        }

        private protected void FillListOfCharacters(char symbol)
        {
            IRailwayFenceEncryption.Flag = (_letterIndex is 0) || (_letterIndex != this._key - 1)
                && IRailwayFenceEncryption.Flag;


            List<char> columnLetterList = new List<char>();
            for (byte i = 0; i < this._key; i++)
            {
                columnLetterList.Add(IRailwayFenceEncryption.EmptySymbol);
            }

            columnLetterList[(IRailwayFenceEncryption.Flag) ? (_letterIndex++) : (_letterIndex--)] = symbol;


            this._letterList.Add(columnLetterList);
            
        }

        public void PrintEncryptionScheme()
        {
            for (byte i = 0; i < this._key; i++)
            {
                foreach (var column in this._letterList)
                {
                    Console.Write((column[i] is not IRailwayFenceEncryption.EmptySymbol) ? column[i] : " ");
                }
                Console.WriteLine();
            }
        }

        private protected abstract void ProcessWord();
        
        private protected abstract void PutTogetherTheWord();

        public byte Key => _key;

    }
}