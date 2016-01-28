﻿using System;
using System.Collections.Generic;

namespace JustEnoughVi
{
    public class StringUtils
    {
        private StringUtils() { }

        // FIXME: make configurable
        static readonly List<char> nonWordChars = new List<char>(new char[]{ '(', ')', '[', ']', '{', '}', '<', '>', ';', ':', ',', '.', '"', '\'' });

        public static int NextWordOffset(string searchText, int offset)
        {
            int endOffset = offset;

            if (nonWordChars.Contains(searchText[offset]))
            {
                while (endOffset < searchText.Length && nonWordChars.Contains(searchText[endOffset]))
                    endOffset++;
            }
            else
            {
                while (endOffset < searchText.Length && !Char.IsWhiteSpace(searchText[endOffset]) && !nonWordChars.Contains(searchText[endOffset]))
                    endOffset++;
            }

            if (Char.IsWhiteSpace(searchText[endOffset]) || Char.IsControl(searchText[endOffset]))
            {
                while (endOffset < searchText.Length && (Char.IsWhiteSpace(searchText[endOffset]) || Char.IsControl(searchText[endOffset])))
                    endOffset++;
            }

            return endOffset;
        }

        public static int PreviousWordOffset(string searchText, int offset)
        {
            int endOffset = offset - 1;

            if (Char.IsWhiteSpace(searchText[endOffset]) || Char.IsControl(searchText[endOffset]))
            {
                while (endOffset > 0 && (Char.IsWhiteSpace(searchText[endOffset]) || Char.IsControl(searchText[endOffset])))
                    endOffset--;
            }

            if (nonWordChars.Contains(searchText[endOffset]))
            {
                while (endOffset > 0 && nonWordChars.Contains(searchText[endOffset]))
                    endOffset--;
            }
            else
            {
                while (endOffset > 0 && !Char.IsWhiteSpace(searchText[endOffset]) && !nonWordChars.Contains(searchText[endOffset]))
                    endOffset--;
            }

            return endOffset + 1;
        }
    }
}

