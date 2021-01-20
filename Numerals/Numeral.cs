using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerals
{
    public class Numeral
    {
        /// <summary>
        /// Падеж
        /// </summary>
        public enum Case
        {
            /// <summary>
            /// Именительный
            /// </summary>
            Nominative,
            /// <summary>
            /// Родительный
            /// </summary>
            Genitive,
            /// <summary>
            /// Дательный
            /// </summary>
            Dative,
            /// <summary>
            /// Винительный
            /// </summary>
            Accusative,
            /// <summary>
            /// Творительный
            /// </summary>
            Instrumental,
            /// <summary>
            /// Предложный
            /// </summary>
            Prepositional,
            /// <summary>
            /// Не определен
            /// </summary>
            None
        }
        /// <summary>
        /// Тип числительного (Количественное/Порядковое)
        /// </summary>
        public enum NumeralType
        {
            /// <summary>
            /// Количественное
            /// </summary>
            Cardinal,
            /// <summary>
            /// Порядковое
            /// </summary>
            Ordinal
        }
        /// <summary>
        /// Пол
        /// </summary>
        public enum Gender
        {
            /// <summary>
            /// Мужской
            /// </summary>
            M,
            /// <summary>
            /// Женский
            /// </summary>
            F,
            /// <summary>
            /// Средний
            /// </summary>
            FM,
            /// <summary>
            /// Множественного числа
            /// </summary>
            Plural
        }
        /// <summary>
        /// Одушевленность
        /// </summary>
        public enum Animation
        {
            /// <summary>
            /// Одушевлённое
            /// </summary>
            Animate,
            /// <summary>
            /// Неодушевлённое
            /// </summary>
            Inanimate
        }
        #region внутренние переменные
        private Case _case;
        private NumeralType _numeralType;
        private Gender _gender;
        private Animation _animate;
        private bool isFraction = false; // индикатор дробной части
        private bool isNegative = false; // индикатор отрицательного числа
        #endregion
        public Numeral(Gender numGender, Case numCase, NumeralType numType, Animation numAnimate)
        {
            _case = numCase;
            _numeralType = numType;
            _gender = numGender;
            _animate = numAnimate;
        }
        /// <summary>
        /// Возвращает значение для 0
        /// </summary>
        /// <returns></returns>
        private string GetZero()
        {
            switch (_case)
            {
                case Case.Nominative:
                    {
                        if (_numeralType == NumeralType.Cardinal)
                        { return "ноль"; }
                        else if (_numeralType == NumeralType.Ordinal)
                        {
                            switch (_gender)
                            {
                                case Gender.M: { return "нулевой"; }
                                case Gender.F: { return "нулевая"; }
                                case Gender.FM: { return "нулевое"; }
                                case Gender.Plural: { return "нулевые"; }
                                default: { return ""; }
                            }
                        }
                        break;
                    }
                case Case.Genitive:
                    {
                        if (_numeralType == NumeralType.Cardinal)
                        { return "ноля"; }
                        else if (_numeralType == NumeralType.Ordinal)
                        {
                            switch (_gender)
                            {
                                case Gender.M: { return "нулевого"; }
                                case Gender.F: { return "нулевой"; }
                                case Gender.FM: { return "нулевого"; }
                                case Gender.Plural: { return "нулевых"; }
                                default: { return ""; }
                            }
                        }
                        break;
                    }
                case Case.Dative:
                    {
                        if (_numeralType == NumeralType.Cardinal)
                        { return "нолю"; }
                        else if (_numeralType == NumeralType.Ordinal)
                        {
                            switch (_gender)
                            {
                                case Gender.M: { return "нулевому"; }
                                case Gender.F: { return "нулевой"; }
                                case Gender.FM: { return "нулевому"; }
                                case Gender.Plural: { return "нулевым"; }
                                default: { return ""; }
                            }
                        }
                        break;
                    }
                case Case.Accusative:
                    {
                        if (_numeralType == NumeralType.Cardinal)
                        { return "ноль"; }
                        else if (_numeralType == NumeralType.Ordinal)
                        {
                            switch (_gender)
                            {
                                case Gender.M: { return (_animate == Animation.Inanimate) ? "нулевой" : "нулевого"; }
                                case Gender.F: { return "нулевую"; }
                                case Gender.FM: { return "нулевое"; }
                                case Gender.Plural: { return (_animate == Animation.Inanimate) ? "нулевые" : "нулевых"; }
                                default: { return ""; }
                            }
                        }
                        break;
                    }
                case Case.Instrumental:
                    {
                        if (_numeralType == NumeralType.Cardinal)
                        { return "нолём"; }
                        else if (_numeralType == NumeralType.Ordinal)
                        {
                            switch (_gender)
                            {
                                case Gender.M: { return "нулевым"; }
                                case Gender.F: { return "нулевой"; }
                                case Gender.FM: { return "нулевым"; }
                                case Gender.Plural: { return "нулевыми"; }
                                default: { return ""; }
                            }
                        }
                        break;
                    }
                case Case.Prepositional:
                    {
                        if (_numeralType == NumeralType.Cardinal)
                        { return "ноле"; }
                        else if (_numeralType == NumeralType.Ordinal)
                        {
                            switch (_gender)
                            {
                                case Gender.M: { return "нулевом"; }
                                case Gender.F: { return "нулевой"; }
                                case Gender.FM: { return "нулевом"; }
                                case Gender.Plural: { return "нулевых"; }
                                default: { return ""; }
                            }
                        }
                        break;
                    }
            }
            return "";
        }
        /// <summary>
        /// Возвращает значение прописью для единичного разряда
        /// </summary>
        /// <param name="num">Значение единичного разряда</param>
        /// <returns></returns>
        private string GetUnits(int num, Gender gend, Case pdz, NumeralType numType, Animation anim)
        {
            if (num == 0) { return ""; }
            switch (pdz)
            {
                case Case.Nominative:
                    {
                        switch (num)
                        {
                            case 1:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "один"; }
                                            case Gender.F: { return "одна"; }
                                            case Gender.FM: { return "одно"; }
                                            case Gender.Plural: { return "одни"; }
                                            default: { return ""; }
                                        }
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "первый"; }
                                            case Gender.F: { return "первая"; }
                                            case Gender.FM: { return "первое"; }
                                            case Gender.Plural: { return "первые"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 2:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "два"; }
                                            case Gender.F: { return "две"; }
                                            case Gender.FM: { return "два"; }
                                            case Gender.Plural: { return "два"; }
                                            default: { return ""; }
                                        }
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "второй"; }
                                            case Gender.F: { return "вторая"; }
                                            case Gender.FM: { return "второе"; }
                                            case Gender.Plural: { return "вторые"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 3:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "три";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "третий"; }
                                            case Gender.F: { return "третья"; }
                                            case Gender.FM: { return "третье"; }
                                            case Gender.Plural: { return "третьи"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 4:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "четыре";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "четвёртый"; }
                                            case Gender.F: { return "четвёртая"; }
                                            case Gender.FM: { return "четвёртое"; }
                                            case Gender.Plural: { return "четвёртые"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 5:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "пять";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "пятый"; }
                                            case Gender.F: { return "пятая"; }
                                            case Gender.FM: { return "пятое"; }
                                            case Gender.Plural: { return "пятые"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 6:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "шесть";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "шестой"; }
                                            case Gender.F: { return "шестая"; }
                                            case Gender.FM: { return "шестое"; }
                                            case Gender.Plural: { return "шестые"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 7:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "семь";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "седьмой"; }
                                            case Gender.F: { return "седьмая"; }
                                            case Gender.FM: { return "седьмое"; }
                                            case Gender.Plural: { return "седьмые"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 8:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "восемь";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "восьмой"; }
                                            case Gender.F: { return "восьмая"; }
                                            case Gender.FM: { return "восьмое"; }
                                            case Gender.Plural: { return "восьмые"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 9:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "девять";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "девятый"; }
                                            case Gender.F: { return "девятая"; }
                                            case Gender.FM: { return "девятое"; }
                                            case Gender.Plural: { return "девятые"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            default: return "";
                        }
                    }
                case Case.Genitive:
                    {
                        switch (num)
                        {
                            case 1:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "одного"; }
                                            case Gender.F: { return "одной"; }
                                            case Gender.FM: { return "одного"; }
                                            case Gender.Plural: { return "одних"; }
                                            default: { return ""; }
                                        }
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "первого"; }
                                            case Gender.F: { return "первой"; }
                                            case Gender.FM: { return "первого"; }
                                            case Gender.Plural: { return "первых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 2:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "двух";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "второго"; }
                                            case Gender.F: { return "второй"; }
                                            case Gender.FM: { return "второго"; }
                                            case Gender.Plural: { return "вторых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 3:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "трёх";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "третьего"; }
                                            case Gender.F: { return "третьей"; }
                                            case Gender.FM: { return "третьего"; }
                                            case Gender.Plural: { return "третьих"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 4:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "четырёх";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "четвёртого"; }
                                            case Gender.F: { return "четвёртой"; }
                                            case Gender.FM: { return "четвёртого"; }
                                            case Gender.Plural: { return "четвёртых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 5:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "пяти";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "пятого"; }
                                            case Gender.F: { return "пятой"; }
                                            case Gender.FM: { return "пятого"; }
                                            case Gender.Plural: { return "пятых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 6:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "шести";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "шестого"; }
                                            case Gender.F: { return "шестой"; }
                                            case Gender.FM: { return "шестого"; }
                                            case Gender.Plural: { return "шестых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 7:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "семи";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "седьмого"; }
                                            case Gender.F: { return "седьмой"; }
                                            case Gender.FM: { return "седьмого"; }
                                            case Gender.Plural: { return "седьмых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 8:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "восьми";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "восьмого"; }
                                            case Gender.F: { return "восьмой"; }
                                            case Gender.FM: { return "восьмого"; }
                                            case Gender.Plural: { return "восьмых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 9:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "девяти";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return "девятого"; }
                                            case Gender.F: { return "девятой"; }
                                            case Gender.FM: { return "девятого"; }
                                            case Gender.Plural: { return "девятых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            default: return "";
                        }
                    }
                case Case.Dative:
                    {
                        {
                            switch (num)
                            {
                                case 1:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "одному"; }
                                                case Gender.F: { return "одной"; }
                                                case Gender.FM: { return "одному"; }
                                                case Gender.Plural: { return "одним"; }
                                                default: { return ""; }
                                            }
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "первому"; }
                                                case Gender.F: { return "первой"; }
                                                case Gender.FM: { return "первому"; }
                                                case Gender.Plural: { return "первым"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 2:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "двум";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "второму"; }
                                                case Gender.F: { return "второй"; }
                                                case Gender.FM: { return "второму"; }
                                                case Gender.Plural: { return "вторым"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 3:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "трём";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "третьему"; }
                                                case Gender.F: { return "третьей"; }
                                                case Gender.FM: { return "третьему"; }
                                                case Gender.Plural: { return "третьим"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 4:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "четырём";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "четвёртому"; }
                                                case Gender.F: { return "четвёртой"; }
                                                case Gender.FM: { return "четвёртому"; }
                                                case Gender.Plural: { return "четвёртым"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 5:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "пяти";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "пятому"; }
                                                case Gender.F: { return "пятой"; }
                                                case Gender.FM: { return "пятому"; }
                                                case Gender.Plural: { return "пятым"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 6:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "шести";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "шестому"; }
                                                case Gender.F: { return "шестой"; }
                                                case Gender.FM: { return "шестому"; }
                                                case Gender.Plural: { return "шестым"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 7:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "семи";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "седьмому"; }
                                                case Gender.F: { return "седьмой"; }
                                                case Gender.FM: { return "седьмому"; }
                                                case Gender.Plural: { return "седьмым"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 8:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "восьми";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "восьмому"; }
                                                case Gender.F: { return "восьмой"; }
                                                case Gender.FM: { return "восьмому"; }
                                                case Gender.Plural: { return "восьмым"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 9:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "девяти";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "девятому"; }
                                                case Gender.F: { return "девятой"; }
                                                case Gender.FM: { return "девятому"; }
                                                case Gender.Plural: { return "девятым"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                default: return "";
                            }
                        }
                    }
                case Case.Accusative:
                    {
                        switch (num)
                        {
                            case 1:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return (anim == Animation.Inanimate) ? "один" : "одного"; }
                                            case Gender.F: { return "одну"; }
                                            case Gender.FM: { return "одно"; }
                                            case Gender.Plural: { return (anim == Animation.Inanimate) ? "одни" : "одних"; ; }
                                                //default: { return ""; }
                                        }
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return (anim == Animation.Inanimate) ? "первый" : "первого"; }
                                            case Gender.F: { return "первую"; }
                                            case Gender.FM: { return "первое"; }
                                            case Gender.Plural: { return (anim == Animation.Inanimate) ? "первые" : "первых"; }
                                                //default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 2:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return (anim == Animation.Inanimate) ? "два" : "двух"; }
                                            case Gender.F: { return (anim == Animation.Inanimate) ? "две" : "двух"; }
                                            case Gender.FM: { return "два"; }
                                            case Gender.Plural: { return (anim == Animation.Inanimate) ? "двое" : "двоих"; ; }
                                            default: { return ""; }
                                        }
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return (anim == Animation.Inanimate) ? "второй" : "второго"; }
                                            case Gender.F: { return "вторую"; }
                                            case Gender.FM: { return "второе"; }
                                            case Gender.Plural: { return (anim == Animation.Inanimate) ? "вторые" : "вторых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 3:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return (anim == Animation.Inanimate) ? "три" : "трёх";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return (anim == Animation.Inanimate) ? "третий" : "третьего"; }
                                            case Gender.F: { return "третью"; }
                                            case Gender.FM: { return "третье"; }
                                            case Gender.Plural: { return (anim == Animation.Inanimate) ? "третьи" : "третьих"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 4:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return (anim == Animation.Inanimate) ? "четыре" : "четырёх";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return (anim == Animation.Inanimate) ? "четвёртый" : "четвёртого"; }
                                            case Gender.F: { return "четвёртую"; }
                                            case Gender.FM: { return "четвёртое"; }
                                            case Gender.Plural: { return (anim == Animation.Inanimate) ? "четвёртые" : "четвёртых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 5:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "пять";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return (anim == Animation.Inanimate) ? "пятый" : "пятого"; }
                                            case Gender.F: { return "пятую"; }
                                            case Gender.FM: { return "пятое"; }
                                            case Gender.Plural: { return (anim == Animation.Inanimate) ? "пятые" : "пятых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 6:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "шесть";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return (anim == Animation.Inanimate) ? "шестой" : "шестого"; }
                                            case Gender.F: { return "шестую"; }
                                            case Gender.FM: { return "шестое"; }
                                            case Gender.Plural: { return (anim == Animation.Inanimate) ? "шестые" : "шестых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 7:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "семь";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return (anim == Animation.Inanimate) ? "седьмой" : "седьмого"; }
                                            case Gender.F: { return "седьмую"; }
                                            case Gender.FM: { return "седьмое"; }
                                            case Gender.Plural: { return (anim == Animation.Inanimate) ? "седьмые" : "седьмых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 8:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "восемь";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return (anim == Animation.Inanimate) ? "восьмой" : "восьмого"; }
                                            case Gender.F: { return "восьмую"; }
                                            case Gender.FM: { return "восьмое"; }
                                            case Gender.Plural: { return (anim == Animation.Inanimate) ? "восьмые" : "восьмых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            case 9:
                                {
                                    if (numType == NumeralType.Cardinal)
                                    {
                                        return "девять";
                                    }
                                    else if (numType == NumeralType.Ordinal)
                                    {
                                        switch (gend)
                                        {
                                            case Gender.M: { return (anim == Animation.Inanimate) ? "девятый" : "девятого"; }
                                            case Gender.F: { return "девятую"; }
                                            case Gender.FM: { return "девятое"; }
                                            case Gender.Plural: { return (anim == Animation.Inanimate) ? "девятые" : "девятых"; }
                                            default: { return ""; }
                                        }
                                    }
                                    return "";
                                }
                            default: return "";
                        }
                    }
                case Case.Instrumental:
                    {
                        {
                            switch (num)
                            {
                                case 1:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "одним"; }
                                                case Gender.F: { return "одной"; }
                                                case Gender.FM: { return "одним"; }
                                                case Gender.Plural: { return "одними"; }
                                                default: { return ""; }
                                            }
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "первым"; }
                                                case Gender.F: { return "первой"; }
                                                case Gender.FM: { return "первым"; }
                                                case Gender.Plural: { return "первыми"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 2:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "двумя";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "вторым"; }
                                                case Gender.F: { return "второй"; }
                                                case Gender.FM: { return "вторым"; }
                                                case Gender.Plural: { return "вторыми"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 3:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "тремя";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "третьим"; }
                                                case Gender.F: { return "третьей"; }
                                                case Gender.FM: { return "третьим"; }
                                                case Gender.Plural: { return "третьими"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 4:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "четырьмя";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "четвёртым"; }
                                                case Gender.F: { return "четвёртой"; }
                                                case Gender.FM: { return "четвёртым"; }
                                                case Gender.Plural: { return "четвертыми"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 5:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "пятью";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "пятым"; }
                                                case Gender.F: { return "пятой"; }
                                                case Gender.FM: { return "пятым"; }
                                                case Gender.Plural: { return "пятыми"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 6:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "шестью";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "шестым"; }
                                                case Gender.F: { return "шестой"; }
                                                case Gender.FM: { return "шестым"; }
                                                case Gender.Plural: { return "шестыми"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 7:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "семью";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "седьмым"; }
                                                case Gender.F: { return "седьмой"; }
                                                case Gender.FM: { return "седьмым"; }
                                                case Gender.Plural: { return "седьмыми"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 8:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "восьмью";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "восьмым"; }
                                                case Gender.F: { return "восьмой"; }
                                                case Gender.FM: { return "восьмым"; }
                                                case Gender.Plural: { return "восьмыми"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 9:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "девятью";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "девятым"; }
                                                case Gender.F: { return "девятой"; }
                                                case Gender.FM: { return "девятым"; }
                                                case Gender.Plural: { return "девятыми"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                default: return "";
                            }
                        }
                    }
                case Case.Prepositional:
                    {
                        {
                            switch (num)
                            {
                                case 1:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "одном"; }
                                                case Gender.F: { return "одной"; }
                                                case Gender.FM: { return "одном"; }
                                                case Gender.Plural: { return "одних"; }
                                                default: { return ""; }
                                            }
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "первом"; }
                                                case Gender.F: { return "первой"; }
                                                case Gender.FM: { return "первом"; }
                                                case Gender.Plural: { return "первых"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 2:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "двух";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "втором"; }
                                                case Gender.F: { return "второй"; }
                                                case Gender.FM: { return "втором"; }
                                                case Gender.Plural: { return "вторых"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 3:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "трёх";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "третьем"; }
                                                case Gender.F: { return "третьей"; }
                                                case Gender.FM: { return "третьем"; }
                                                case Gender.Plural: { return "третьих"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 4:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "четырёх";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "четвёртом"; }
                                                case Gender.F: { return "четвёртой"; }
                                                case Gender.FM: { return "четвёртом"; }
                                                case Gender.Plural: { return "четвёртых"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 5:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "пяти";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "пятом"; }
                                                case Gender.F: { return "пятой"; }
                                                case Gender.FM: { return "пятом"; }
                                                case Gender.Plural: { return "пятых"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 6:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "шести";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "шестом"; }
                                                case Gender.F: { return "шестой"; }
                                                case Gender.FM: { return "шестом"; }
                                                case Gender.Plural: { return "шестых"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 7:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "семи";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "седьмом"; }
                                                case Gender.F: { return "седьмой"; }
                                                case Gender.FM: { return "седьмом"; }
                                                case Gender.Plural: { return "седьмых"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 8:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "восьми";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "восьмом"; }
                                                case Gender.F: { return "восьмой"; }
                                                case Gender.FM: { return "восьмом"; }
                                                case Gender.Plural: { return "восьмых"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                case 9:
                                    {
                                        if (numType == NumeralType.Cardinal)
                                        {
                                            return "девяти";
                                        }
                                        else if (numType == NumeralType.Ordinal)
                                        {
                                            switch (gend)
                                            {
                                                case Gender.M: { return "девятом"; }
                                                case Gender.F: { return "девятой"; }
                                                case Gender.FM: { return "девятом"; }
                                                case Gender.Plural: { return "девятых"; }
                                                default: { return ""; }
                                            }
                                        }
                                        return "";
                                    }
                                default: return "";
                            }
                        }
                    }
                default: return "";
            }
        }
        /// <summary>
        /// Возвращает значение прописью в интервале от 10 до 19
        /// </summary>
        /// <param name="num">Значения единичного разряда</param> // от 0 до 9
        /// <param name="gend">пол</param>
        /// <param name="pdz">падеж</param>
        /// <param name="numType">тип числительного</param>
        /// <param name="anim">одушевленность</param>
        /// <returns></returns>
        private string GetTeens(int num, Gender gend, Case pdz, NumeralType numType, Animation anim)
        {
            string text = "";
            switch (num)
            {
                case 0: text = "десят"; break;
                case 1: text = "одиннадцат"; break;
                case 2: text = "двенадцат"; break;
                default:
                    {
                        text = GetUnits(num, Gender.M, Case.Nominative, NumeralType.Cardinal, Animation.Inanimate);
                        text = (num > 3) ? text.Remove(text.Length - 1) + "надцат" : text + "надцат"; break;
                    }
            }
            if (numType == NumeralType.Cardinal)
            {
                switch (pdz)
                {
                    case Case.Nominative:
                        {
                            text += "ь";
                            break;
                        }
                    case Case.Genitive:
                        {
                            text += "и";
                            break;
                        }
                    case Case.Dative:
                        {
                            text += "и";
                            break;
                        }
                    case Case.Accusative:
                        {
                            text += "ь";
                            break;
                        }
                    case Case.Instrumental:
                        {
                            text += "ью";
                            break;
                        }
                    case Case.Prepositional:
                        {
                            text += "и";
                            break;
                        }
                    default: return "";
                }
            }
            else if (numType == NumeralType.Ordinal)
            {
                switch (pdz)
                {
                    case Case.Nominative:
                        {
                            switch (gend)
                            {
                                case Gender.M: { text += "ый"; break; }
                                case Gender.F: { text += "ая"; break; }
                                case Gender.FM: { text += "ое"; break; }
                                case Gender.Plural: { text += "ые"; break; }
                                default: { break; }
                            }
                            break;
                        }
                    case Case.Genitive:
                        {
                            switch (gend)
                            {
                                case Gender.M: { text += "ого"; break; }
                                case Gender.F: { text += "ой"; break; }
                                case Gender.FM: { text += "ого"; break; }
                                case Gender.Plural: { text += "ых"; break; }
                                default: { break; }
                            }
                            break;
                        }
                    case Case.Dative:
                        {
                            switch (gend)
                            {
                                case Gender.M: { text += "ому"; break; }
                                case Gender.F: { text += "ой"; break; }
                                case Gender.FM: { text += "ому"; break; }
                                case Gender.Plural: { text += "ым"; break; }
                                default: { break; }
                            }
                            break;
                        }
                    case Case.Accusative:
                        {
                            switch (gend)
                            {
                                // одушевленность (м.р. - ого / с.р - ый)
                                case Gender.M: { text += (this._animate == Animation.Inanimate) ? "ый" : "ого"; break; }
                                case Gender.F: { text += "ую"; break; }
                                case Gender.FM: { text += "ое"; break; }
                                case Gender.Plural: { text += (this._animate == Animation.Inanimate) ? "ые" : "ых"; break; }
                                default: { break; }
                            }
                            break;
                        }
                    case Case.Instrumental:
                        {
                            switch (gend)
                            {
                                case Gender.M: { text += "ым"; break; }
                                case Gender.F: { text += "ой"; break; }
                                case Gender.FM: { text += "ым"; break; }
                                case Gender.Plural: { text += "ыми"; break; }
                                default: { break; }
                            }
                            break;
                        }
                    case Case.Prepositional:
                        {
                            switch (gend)
                            {
                                case Gender.M: { text += "ом"; break; }
                                case Gender.F: { text += "ой"; break; }
                                case Gender.FM: { text += "ом"; break; }
                                case Gender.Plural: { text += "ых"; break; }
                                default: { break; }
                            }
                            break;
                        }
                    default: return "";
                }
            }
            return text;
        }
        /// <summary>
        /// Возвращает значение прописью для десятков от 2 до 9
        /// </summary>
        /// <param name="num">Значения разряда десятков</param>
        /// <param name="gend">пол</param>
        /// <param name="pdz">падеж</param>
        /// <param name="numType">тип числительного</param>
        /// <param name="anim">одушевленность</param>
        /// <returns></returns>
        private string GetDecades(int num, Gender gend, Case pdz, NumeralType numType, Animation anim)
        {
            string text = ""; // основа (два-дцать)
            string suff = "десят"; // дополнение (пять - десят)
            switch (num)
            {
                case 0: { return ""; }
                case 1: { text = ""; break; }
                case 2: { text = "двадцат"; break; }
                case 3: { text = "тридцат"; break; }
                case 4: { text = "сорок"; break; }
                case 9: { text = "девяност"; break; }
                default:
                    {
                        text = GetUnits(num, Gender.M, Case.Nominative, NumeralType.Cardinal, anim);
                        text = text.Remove(text.Length - 1, 1);
                        break;
                    }
            }
            if (numType == NumeralType.Cardinal)
            {
                switch (pdz)
                {
                    case Case.Nominative:
                        {
                            if ((num == 3) || (num == 2)) { text += "ь"; break; }
                            if (num == 4) break;
                            if (num == 9) { text += "о"; break; }
                            else { text += "ь" + suff; } // сем ь десят
                            break;
                        }
                    case Case.Genitive:
                        {
                            if ((num == 3) || (num == 2)) { text += "и"; break; }
                            if ((num == 4) || (num == 9)) { text += "а"; break; }
                            else
                            {
                                text += "и" + suff + "и"; // пят и десят и
                            }
                            break;
                        }
                    case Case.Dative:
                        {
                            if ((num == 3) || (num == 2)) { text += "и"; break; }
                            if ((num == 4) || (num == 9)) { text += "а"; break; }
                            else
                            {
                                text += "и" + suff + "и"; // пят и десят и
                            }
                            break;
                        }
                    case Case.Accusative:
                        {
                            if ((num == 3) || (num == 2)) { text += "ь"; break; }
                            if (num == 4) break;
                            if (num == 9) { text += "о"; break; }
                            else
                            {
                                text += "ь" + suff; // пят ь десят // восем ь десят
                            }
                            break;
                        }
                    case Case.Instrumental:
                        {
                            if ((num == 3) || (num == 2)) { text += "ью"; break; }
                            if ((num == 4) || (num == 9)) { text += "а"; break; }
                            else
                            {
                                text += "ью" + suff + "ью"; // пят ью десят ью // восем ью десят ью
                            }
                            break;
                        }
                    case Case.Prepositional:
                        {
                            if ((num == 3) || (num == 2)) { text += "и"; break; }
                            if ((num == 4) || (num == 9)) { text += "а"; break; }
                            else
                            {
                                text += "и" + suff + "и"; // пят и десят и // восем ью десят ью
                            }
                            break;
                        }
                    default: return "";
                }
            }
            else if (numType == NumeralType.Ordinal)
            {
                switch (num)
                {
                    case 0: { return ""; }
                    case 1: { text = "десят"; break; }
                    case 2: { text = "двадцат"; break; }
                    case 3: { text = "тридцат"; break; }
                    case 4: { text = "сороков"; break; }
                    case 9: { text = "девяност"; break; }
                    default:
                        {
                            text = GetUnits(num, Gender.Plural, Case.Genitive, NumeralType.Cardinal, anim) + "десят";
                            break;
                        }
                }
                switch (pdz)
                {
                    case Case.Nominative:
                        {
                            switch (this._gender)
                            {
                                case Gender.M: { text += (num == 4) ? "ой" : "ый"; break; }
                                case Gender.F: { text += (num == 4) ? "ая" : "ая"; break; }
                                case Gender.FM: { text += (num == 4) ? "ой" : "ое"; break; }
                                case Gender.Plural: { text += (num == 4) ? "ые" : "ые"; break; }
                                default: { break; }
                            }
                            break;
                        }
                    case Case.Genitive:
                        {
                            switch (this._gender)
                            {
                                case Gender.M: { text += "ого"; break; }
                                case Gender.F: { text += "ой"; break; }
                                case Gender.FM: { text += "ого"; break; }
                                case Gender.Plural: { text += "ых"; break; }
                                default: { break; }
                            }
                            break;
                        }
                    case Case.Dative:
                        {
                            switch (this._gender)
                            {
                                case Gender.M: { text += "ому"; break; }
                                case Gender.F: { text += "ой"; break; }
                                case Gender.FM: { text += "ому"; break; }
                                case Gender.Plural: { text += "ым"; break; }
                                default: { break; }
                            }
                            break;
                        }
                    case Case.Accusative:
                        {
                            switch (this._gender)
                            {
                                // одушевленность (м.р. - ого / с.р - ый)
                                case Gender.M: { text += (this._animate == Animation.Inanimate) ? ((num == 4) ? "ой" : "ый") : "ого"; break; }
                                case Gender.F: { text += "ую"; break; }
                                case Gender.FM: { text += "ое"; break; }
                                case Gender.Plural: { text += (this._animate == Animation.Inanimate) ? "ые" : "ых"; break; }
                                default: { break; }
                            }
                            break;
                        }
                    case Case.Instrumental:
                        {
                            switch (this._gender)
                            {
                                case Gender.M: { text += "ым"; break; }
                                case Gender.F: { text += "ой"; break; }
                                case Gender.FM: { text += "ым"; break; }
                                case Gender.Plural: { text += "ыми"; break; }
                                default: { break; }
                            }
                            break;
                        }
                    case Case.Prepositional:
                        {
                            switch (this._gender)
                            {
                                case Gender.M: { text += "ом"; break; }
                                case Gender.F: { text += "ой"; break; }
                                case Gender.FM: { text += "ом"; break; }
                                case Gender.Plural: { text += "ых"; break; }
                                default: { break; }
                            }
                            break;
                        }
                    default: return "";
                }
            }
            return text;
        }
        /// <summary>
        /// Возвращает значение прописью для сотен от 1 до 9
        /// </summary>
        /// <param name="num">Значения разряда сотен</param>
        /// <param name="gend">пол</param>
        /// <param name="pdz">падеж</param>
        /// <param name="numType">тип числительного</param>
        /// <param name="anim">одушевленность</param>
        /// <returns></returns>
        private string GetCenturies(int num, Gender gend, Case pdz, NumeralType numType, Animation anim)
        {
            if (num == 0) return "";
            if (numType == NumeralType.Cardinal)
            {
                switch (pdz)
                {
                    case Case.Nominative:
                        {
                            switch (num)
                            {
                                case 1: { return "сто"; }
                                case 2: { return "двести"; }
                                case 3: { return "триста"; }
                                case 4: { return "четыреста"; }
                                default:
                                    {
                                        return GetUnits(num, Gender.M, Case.Nominative, NumeralType.Cardinal, anim) + "сот";
                                    }
                            }
                        }
                    case Case.Genitive:
                        {
                            return (num == 1) ? "ста" : GetUnits(num, gend, Case.Genitive, NumeralType.Cardinal, anim) + "сот";
                        }
                    case Case.Dative:
                        {
                            return (num == 1) ? "ста" : GetUnits(num, gend, Case.Dative, NumeralType.Cardinal, anim) + "стам";
                        }
                    case Case.Accusative:
                        {
                            switch (num)
                            {
                                case 1: { return "сто"; }
                                case 2: { return "двести"; }
                                case 3: { return "триста"; }
                                case 4: { return "четыреста"; }
                                default:
                                    {
                                        return GetUnits(num, Gender.M, Case.Nominative, NumeralType.Cardinal, anim) + "сот";
                                    }
                            }
                        }
                    case Case.Instrumental:
                        {
                            return (num == 1) ? "стами" : GetUnits(num, gend, Case.Instrumental, NumeralType.Cardinal, anim) + "стами";
                        }
                    case Case.Prepositional:
                        {
                            return (num == 1) ? "ста" : GetUnits(num, gend, Case.Prepositional, NumeralType.Cardinal, anim) + "стах";
                        }

                    case Case.None:
                        break;
                    default: return "";
                }
            }
            else if (numType == NumeralType.Ordinal)
            {
                string cent = GetUnits(num, gend, Case.Nominative, NumeralType.Cardinal, anim);
                // получаем основу
                cent = ((num == 1) ? "" : GetUnits(num, Gender.Plural, Case.Genitive, NumeralType.Cardinal, Animation.Inanimate)) + "сот";
                // получаем окончание
                switch (pdz)
                {
                    case Case.Nominative:
                        {
                            switch (gend)
                            {
                                case Gender.M: { cent += "ый"; break; }
                                case Gender.F: { cent += "ая"; break; }
                                case Gender.FM: { cent += "ое"; break; }
                                case Gender.Plural: { cent += "ые"; break; }
                            }
                            break;
                        }
                    case Case.Genitive:
                        {
                            switch (gend)
                            {
                                case Gender.M: { cent += "ого"; break; }
                                case Gender.F: { cent += "ой"; break; }
                                case Gender.FM: { cent += "ого"; break; }
                                case Gender.Plural: { cent += "ых"; break; }
                            }
                            break;
                        }
                    case Case.Dative:
                        {
                            switch (gend)
                            {
                                case Gender.M: { cent += "ому"; break; }
                                case Gender.F: { cent += "ой"; break; }
                                case Gender.FM: { cent += "ому"; break; }
                                case Gender.Plural: { cent += "ым"; break; }
                            }
                            break;
                        }
                    case Case.Accusative:
                        {
                            switch (gend)
                            {
                                case Gender.M: { cent += (anim == Animation.Inanimate) ? "ый" : "ого"; break; }
                                case Gender.F: { cent += "ой"; break; }
                                case Gender.FM: { cent += "ого"; break; }
                                case Gender.Plural: { cent += (anim == Animation.Inanimate) ? "ые" : "ых"; break; }
                            }
                            break;
                        }
                    case Case.Instrumental:
                        {
                            switch (gend)
                            {
                                case Gender.M: { cent += "ым"; break; }
                                case Gender.F: { cent += "ой"; break; }
                                case Gender.FM: { cent += "ым"; break; }
                                case Gender.Plural: { cent += "ыми"; break; }
                            }
                            break;
                        }
                    case Case.Prepositional:
                        {
                            switch (gend)
                            {
                                case Gender.M: { cent += "ом"; break; }
                                case Gender.F: { cent += "ой"; break; }
                                case Gender.FM: { cent += "ом"; break; }
                                case Gender.Plural: { cent += "ых"; break; }
                            }
                            break;
                        }
                    default: return "";
                }
                return cent;
            }
            return "";
        }
        /// <summary>
        /// Возвращает окончание для номинала
        /// </summary>
        /// <param name="splitDigits"></param>
        /// <param name="triada"></param>
        /// <returns></returns>
        private string GetEndNominal(List<int> splitDigits, int triada, Gender gend, Case pdz, NumeralType numType, Animation anim)
        {
            #region окончание для номиналов 10^n (тысяч- миллион-)
            if (numType == NumeralType.Cardinal)
            {
                if (splitDigits[1] != 1) // единицы (1 тысяча/миллион, 2 тысячи/миллиона - 9 тысяч/миллионов)
                {
                    switch (pdz)
                    {
                        case Case.Nominative:
                            {
                                switch (splitDigits[0])
                                {
                                    case 1: return (triada == 1) ? "а" : "";     // тысяч-а    миллион-
                                    case 2: return (triada == 1) ? "и" : "а";    // тысяч-и    миллион-а
                                    case 3: return (triada == 1) ? "и" : "а";
                                    case 4: return (triada == 1) ? "и" : "а";
                                    default: return (triada == 1) ? "" : "ов";  // тысяч-    миллион-ов
                                }
                            }
                        case Case.Genitive:
                            {
                                switch (splitDigits[0])
                                {
                                    case 1: return (triada == 1) ? "и" : "а";    // тысяч-а    миллион-
                                    default: return (triada == 1) ? "" : "ов";   // тысяч-    миллион-ов
                                }
                            }
                        case Case.Dative:
                            {
                                switch (splitDigits[0])
                                {
                                    case 1: return (triada == 1) ? "е" : "у";   // тысяч-а    миллион-
                                    default: return (triada == 1) ? "ам" : "ам";  // тысяч-    миллион-ов
                                }
                            }
                        case Case.Accusative:
                            {
                                switch (splitDigits[0])
                                {
                                    case 1: return (triada == 1) ? "у" : "";    // тысяч-а    миллион-
                                    default: return (triada == 1) ? "и" : "а";  // тысяч-    миллион-ов
                                }
                            }
                        case Case.Instrumental:
                            {
                                switch (splitDigits[0])
                                {
                                    case 1: return (triada == 1) ? "ей" : "ом";    // тысяч-а    миллион-
                                    default: return (triada == 1) ? "ами" : "ами";   // тысяч-    миллион-ов
                                }
                            }
                        case Case.Prepositional:
                            {
                                switch (splitDigits[0])
                                {
                                    case 1: return (triada == 1) ? "е" : "е";    // тысяч-а    миллион-
                                    default: return (triada == 1) ? "ах" : "ах";  // тысяч-    миллион-ов
                                }
                            }
                        default: return "";
                    }
                }
                else // 11, 12, .., 19 (тысяч/миллионов)
                {
                    switch (pdz)
                    {
                        case Case.Nominative:
                            {
                                return (triada == 1) ? "" : "ов";  // тысяч-    миллион-ов                            
                            }
                        case Case.Genitive:
                            {
                                return (triada == 1) ? "" : "ов";   // тысяч-    миллион-ов                            
                            }
                        case Case.Dative:
                            {
                                return (triada == 1) ? "ам" : "ам";  // тысяч-    миллион-ов                            
                            }
                        case Case.Accusative:
                            {
                                return (triada == 1) ? "" : "ов";  // тысяч-    миллион-ов                            
                            }
                        case Case.Instrumental:
                            {
                                return (triada == 1) ? "ами" : "ами";   // тысяч-    миллион-ов                            
                            }
                        case Case.Prepositional:
                            {
                                return (triada == 1) ? "ах" : "ах";  // тысяч-    миллион-ов
                            }
                        default: return "";
                    }
                }
            }
            else if (numType == NumeralType.Ordinal)
            {
                // тысячный / миллионная / миллиардное / трилионные
                switch (pdz)
                {
                    case Case.Nominative:
                        {
                            switch (gend)
                            {
                                case Gender.M: { return "ный"; }
                                case Gender.F: { return "ная"; }
                                case Gender.FM: { return "ное"; }
                                case Gender.Plural: { return "ные"; }
                                default: { return ""; }
                            }
                        }
                    case Case.Genitive:
                        {
                            switch (gend)
                            {
                                case Gender.M: { return "ного"; }
                                case Gender.F: { return "ной"; }
                                case Gender.FM: { return "ного"; }
                                case Gender.Plural: { return "ных"; }
                                default: { return ""; }
                            }
                        }
                    case Case.Dative:
                        {
                            switch (gend)
                            {
                                case Gender.M: { return "ному"; }
                                case Gender.F: { return "ной"; }
                                case Gender.FM: { return "ному"; }
                                case Gender.Plural: { return "ным"; }
                                default: { return ""; }
                            }
                        }
                    case Case.Accusative:
                        {
                            switch (gend)
                            {
                                case Gender.M: { return (anim == Animation.Inanimate) ? "ный" : "ного"; }
                                case Gender.F: { return "ную"; }
                                case Gender.FM: { return "ное"; }
                                case Gender.Plural: { return (anim == Animation.Inanimate) ? "ные" : "ных"; }
                                default: { return ""; }
                            }
                        }
                    case Case.Instrumental:
                        {
                            switch (gend)
                            {
                                case Gender.M: { return "ным"; }
                                case Gender.F: { return "ной"; }
                                case Gender.FM: { return "ным"; }
                                case Gender.Plural: { return "ными"; }
                                default: { return ""; }
                            }
                        }
                    case Case.Prepositional:
                        {
                            switch (gend)
                            {
                                case Gender.M: { return "ном"; }
                                case Gender.F: { return "ной"; }
                                case Gender.FM: { return "ном"; }
                                case Gender.Plural: { return "ных"; }
                                default: { return ""; }
                            }
                        }
                    default: return "";
                }
            }
            return "";
            #endregion
        }
        /// <summary>
        ///  Возвращает значение именного названия тысячи (10^3*n)
        /// </summary>
        /// <param name="triad">номер триады</param>
        /// <returns></returns>
        private static string GetNominal(int triad)
        {
            switch (triad)
            {
                #region Именные названия степеней тысячи (КОРОТКАЯ СИСТЕМА)
                case 0: return ""; // 10^0
                case 1: return "тысяч"; // (10)-3; 
                case 2: return "миллион"; // (10)-6; 
                case 3: return "миллиард"; // (10)-9; //case 3: return "биллион"; // (10)-9; 
                case 4: return "триллион"; // (10)-12; 
                case 5: return "квадриллион"; // (10)-15; 
                case 6: return "квинтиллион"; // (10)-18; 
                case 7: return "секстиллион"; // (10)-21; 
                case 8: return "септиллион"; // (10)-24; 
                case 9: return "октиллион"; // (10)-27; 
                case 10: return "нониллион"; // (10)-30; 
                case 11: return "дециллион"; // (10)-33; 
                case 12: return "ундециллион"; // (10)-36; 
                case 13: return "додециллион"; // (10)-39; 
                case 14: return "тредециллион"; // (10)-42; 
                case 15: return "кваттуордециллион"; // (10)-45; 
                case 16: return "квиндециллион"; // (10)-48; 
                case 17: return "седециллион"; // (10)-51; 
                case 18: return "септдециллион"; // (10)-54; 
                case 19: return "октодециллион"; // (10)-57; 
                case 20: return "новемдециллион"; // (10)-60; 
                case 21: return "вигинтиллион"; // (10)-63; 
                case 22: return "анвигинтиллион"; // (10)-66; 
                case 23: return "дуовигинтиллион"; // (10)-69; 
                case 24: return "тревигинтиллион"; // (10)-72; 
                case 25: return "кватторвигинтиллион"; // (10)-75; 
                case 26: return "квинвигинтиллион"; // (10)-78; 
                case 27: return "сексвигинтиллион"; // (10)-81; 
                case 28: return "септемвигинтиллион"; // (10)-84; 
                case 29: return "октовигинтиллион"; // (10)-87; 
                case 30: return "новемвигинтиллион"; // (10)-90; 
                case 31: return "тригинтиллион"; // (10)-93; 
                case 32: return "антригинтиллион"; // (10)-96; 
                case 33: return "дуотригинтиллион"; // (10)-99;
                default: return "зиллион"; //Console.WriteLine("Error: {0}", triad); 
                    #endregion
            }
        }
        /// <summary>
        /// Возвращает значение прописью для триады чисел
        /// </summary>
        /// <param name="n">триада чисел</param>
        /// <param name="triada">номер триады</param>
        /// <param name="isOrdinal">порядковое числительное</param>
        /// <returns></returns>
        private string GetTriadValue(int n, int triada, bool isOrdinal = false)
        {
            if (n == 0) { return ""; }
            List<int> splitDigits = new List<int>();
            string Nominal = "", end = "", name = "";
            for (int i = 0; i < 3; i++)
            { splitDigits.Add(n % 10); n = n / 10; } // Заполняем список чисел
            #region номинал 10^n 
            if (triada > 0)
            {
                Nominal = GetNominal(triada);
                end = GetEndNominal(splitDigits, triada, _gender, _case, (isOrdinal) ? NumeralType.Ordinal : NumeralType.Cardinal, _animate);
            }
            #endregion
            #region десятки и единицы
            if (!isOrdinal)
            {
                #region сотни
                if (splitDigits[2] != 0)
                {
                    name = GetCenturies(splitDigits[2], (isFraction) ? Gender.F : Gender.M, _case, NumeralType.Cardinal, this._animate) + " ";
                }
                #endregion              
                switch (splitDigits[1])
                {
                    case 0:
                        {
                            name += GetUnits(splitDigits[0], (triada == 1) || (isFraction) ? ((triada <= 1) ? Gender.F : Gender.M) : Gender.M, _case, NumeralType.Cardinal, _animate); // тысяч-а (ж.р.) // милион (м.р.)

                            break;
                        }
                    case 1: { name += GetTeens(splitDigits[0], (isFraction) ? Gender.F : _gender, _case, NumeralType.Cardinal, _animate); break; }
                    default:
                        {
                            name += GetDecades(splitDigits[1], (isFraction) ? Gender.F : _gender, _case, NumeralType.Cardinal, _animate) + " " +
                                  GetUnits(splitDigits[0], (triada == 1) || (isFraction) ? Gender.F : Gender.M, _case, NumeralType.Cardinal, _animate); // двадцать однА тысяча
                            break;
                        }
                }

                return name.Trim() + " " + Nominal.Trim() + end;
            }
            #endregion
            #region только сотни
            else
            {
                string cent = "";
                if ((splitDigits[1] != 0) || (splitDigits[0] != 0))
                {

                    #region сотни
                    if (splitDigits[2] != 0)
                    {
                        cent = GetCenturies(splitDigits[2], this._gender, Case.Nominative, NumeralType.Cardinal, this._animate);
                    }
                    #endregion
                    switch (splitDigits[1])
                    {
                        case 0:
                            {
                                name += (triada == 0) ?
                                    GetUnits(splitDigits[0], _gender, _case, NumeralType.Ordinal, _animate)// милион (м.р.)
                                    : ((splitDigits[0] == 1) ? "" : GetUnits(splitDigits[0], Gender.Plural, Case.Genitive, NumeralType.Cardinal, Animation.Inanimate));
                                return cent + " " + name.Trim() + Nominal.Trim() + end;
                            }
                        case 1:
                            {
                                name += (triada == 0) ? GetTeens(splitDigits[0], _gender, _case, _numeralType, _animate)
                                    : GetTeens(splitDigits[0], Gender.Plural, Case.Genitive, NumeralType.Cardinal, _animate);
                                return cent + " " + name.Trim() + Nominal.Trim() + end;
                            }
                        default:
                            {
                                cent = (triada == 0) ? GetCenturies(splitDigits[2], _gender, _case, NumeralType.Cardinal, Animation.Inanimate) :
                                GetCenturies(splitDigits[2], Gender.Plural, Case.Genitive, NumeralType.Cardinal, Animation.Inanimate);

                                if (splitDigits[0] == 0)
                                {

                                    name += (triada == 0) ? GetDecades(splitDigits[1], _gender, _case, NumeralType.Ordinal, _animate) :
                                   GetDecades(splitDigits[1], Gender.Plural, Case.Genitive, NumeralType.Cardinal, _animate);
                                    return cent + " " + name.Trim() + " " + Nominal.Trim() + end;
                                }
                                else
                                {
                                    name += (triada == 0)
                                        ?
                                        GetDecades(splitDigits[1], Gender.Plural, Case.Nominative, NumeralType.Cardinal, _animate) + " " +  // сто шестьдесят девятая
                                        GetUnits(splitDigits[0], _gender, _case, NumeralType.Ordinal, _animate)
                                        :
                                        GetDecades(splitDigits[1], Gender.Plural, Case.Genitive, NumeralType.Cardinal, _animate) + " " + // ста шестидесятидевяти тысячная
                                        GetUnits(splitDigits[0], Gender.Plural, Case.Genitive, NumeralType.Cardinal, _animate);
                                    return cent + " " + name.Trim() + " " + Nominal.Trim() + end;
                                }

                            }
                    }
                }
                else
                {
                    if (splitDigits[2] != 0)
                    {
                        cent = (triada == 0) ? GetCenturies(splitDigits[2], _gender, _case, NumeralType.Ordinal, _animate) + " "
                             : GetCenturies(splitDigits[2], Gender.Plural, Case.Genitive, NumeralType.Cardinal, _animate);
                    }
                }
                return cent + " " + name.Trim() + " " + Nominal.Trim() + end;
            }
            #endregion
        }
        /// <summary>
        /// Проверка формата входной строки
        /// </summary>
        /// <param name="number"></param>
        private void CheckArgumentFormat(ref string number)
        {
            if (number.Trim() == "") throw new ArgumentException("Значение не может быть пустым");
            foreach (Char sim in number)
            {
                if (Char.IsLetter(sim)) throw new FormatException("Неправильный формат числа"); // буквы
                if (Char.IsWhiteSpace(sim)) throw new FormatException("Пробельные символы не допускаются в записи числа"); // пробелы
            }
            if (number[0] == '-') { number = number.Replace("-", ""); isNegative = true; }
            if (number[0] == '+') { number = number.Replace("+", ""); isNegative = false; }
            number = number.Replace(",", ".");
            if (number.Split('.').Length > 2) throw new FormatException("Неправильный формат числа"); // более одной запятой или точки
        }
        #region int/fract part
        /// <summary>
        /// возвращает слово "целая/целых" в зависимости от аргумента
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string GetEndIntPart(string num)
        {
            string text = "цел", endOne = "", endMore = "";
            switch (_case)
            {
                case Case.Nominative: { endOne = "ая"; endMore = "ых"; break; }
                case Case.Genitive: { endOne = "ой"; endMore = "ых"; break; }
                case Case.Dative: { endOne = "ой"; endMore = "ым"; break; }
                case Case.Accusative: { endOne = "ую"; endMore = "ых"; break; }
                case Case.Instrumental: { endOne = "ой"; endMore = "ыми"; break; }
                case Case.Prepositional: { endOne = "ой"; endMore = "ых"; break; }
            }
            switch (num.Length)
            {
                case 0: { return ""; }
                case 1: { text += (num[0] == '1') ? endOne : endMore; break; }
                default: { text += ((num[num.Length - 2] != '1') && (num[num.Length - 1] == '1')) ? endOne : endMore; break; }
            }
            return text;
        }
        private string GetEndFractPart(string num)
        {
            string text = "цел", endOne = "", endMore = "", pre = "", end = "";
            switch (_case)
            {
                case Case.Nominative: { endOne = "ая"; endMore = "ых"; break; }
                case Case.Genitive: { endOne = "ой"; endMore = "ых"; break; }
                case Case.Dative: { endOne = "ой"; endMore = "ым"; break; }
                case Case.Accusative: { endOne = "ую"; endMore = "ых"; break; }
                case Case.Instrumental: { endOne = "ой"; endMore = "ыми"; break; }
                case Case.Prepositional: { endOne = "ой"; endMore = "ых"; break; }
            }
            switch (num.Length)
            {
                case 0: { return ""; }
                case 1: { text = "десят"; end = (num[num.Length - 1] == '1') ? endOne : endMore; break; }
                case 2: { text = "сот"; end = ((num[num.Length - 1] == '1') && (num[num.Length - 2] != '1')) ? endOne : endMore; break; }
                default:
                    {
                        string countNum = "1";
                        for (int i = 0; i < num.Length - 1; i++) { countNum += "0"; }
                        text = GetNominal(countNum.Length / 3);
                        switch (countNum.Length % 3)
                        {
                            case 1: { pre += "десяти"; break; }
                            case 2: { pre += "сто"; break; }
                        }
                        end = "н" + (((num[num.Length - 1] == '1') && (num[num.Length - 2] != '1')) ? endOne : endMore);
                        break;
                    }
            }
            return pre + text + end;
        }
        #endregion
        /// <summary>
        /// Возвращает целое число прописью
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string GetStringValue(string number)
        {
            string text = "";
            if ((number == "0") || (number.Replace("0", "") == "")) { return GetZero(); }
            List<string> triads = new List<string>();
            int len = number.Length; // запоминаем начальную длину (количество цифр)
            #region заполнение триад
            for (int i = 0; i < len; i += 3)
            {
                if (number.Length >= 3)
                {
                    triads.Add(number.Substring(number.Length - 3, 3)); // добавляем триаду цифр
                    number = number.Remove(number.Length - 3); // убираем из аргумента полученную триаду
                }
                else { triads.Add(number); } // добавляем остаток
            }
            #endregion
            #region обработка триад
            int ordinalTriad = 0; // номер первой (с младшей правой стороны) непустой триады
            if (_numeralType == NumeralType.Ordinal)
            {
                for (int i = 0; i < triads.Count; i++)
                {
                    if (triads[i] == "000") continue;
                    else { ordinalTriad = i; break; }// только в этой триаде происходит склонение в порядковых числительных. Следующие до них не склоняются
                }
                // Запоминаем род и падеж
                Gender gend = _gender;
                Case pdz = _case;
                // Устанавливаем им.падеж и м.р. для неизменной части числительного
                _case = Case.Nominative;
                _gender = Gender.M;
                for (int i = triads.Count - 1; i >= 0; i--)
                {
                    if (i == ordinalTriad)
                    {
                        // Восстанавливаем падеж и род для изменяемой части числительного
                        _case = pdz;
                        _gender = gend;
                        text += GetTriadValue(Int32.Parse(triads[i]), i, true) + " ";
                    }
                    else // обрабатываем триады как обычные количественные
                    { text += GetTriadValue(Int32.Parse(triads[i]), i, false) + " "; }
                }
            }
            else if (_numeralType == NumeralType.Cardinal)
            {
                for (int i = triads.Count - 1; i >= 0; i--)
                {
                    text += GetTriadValue(Int32.Parse(triads[i]), i, false) + " "; // Количественное числительное
                }
            }
            #endregion
            return text.Replace("  ", " ").Trim();
        }
        /// <summary>
        /// Возвращает значения числа прописью (до одного зиллиарда)
        /// </summary>
        /// <param name="number">Число</param>
        /// <returns></returns>
        public string GetNumeralRecipe(string number)
        {
            string text = "";
            // Проверяем аргумент
            CheckArgumentFormat(ref number);
            if (!number.Contains("."))
            {
                text = GetStringValue(number);
            }
            else
            {
                isFraction = true;
                string intPart = number.Split('.')[0], fractPart = number.Split('.')[1];
                text = GetStringValue(intPart) + " " + GetEndIntPart(intPart) + " ";

                text += GetStringValue(fractPart) + " " + GetEndFractPart(fractPart);
                isFraction = false;
            }
            return ((isNegative) ? "минус " : "") + text;
        }
    }
}
