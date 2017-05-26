using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuSpin.Fw.Extensions
{
    public static class StringExtensions
    {
        #region GET TAGGED STRINGS

        public static string[] GetTaggedStrings(this string inputString, string startTag, string endTag)
        {
            int[] startPositions;
            return GetTaggedStrings(inputString, startTag, endTag, new string[0], out startPositions);
        }

        public static string[] GetTaggedStrings(this string inputString, string startTag, string endTag, string[] excludeStringPaterns, out int[] startPositions)
        {
            string tempStr = inputString;

            int startTagPos = inputString.IndexOf(startTag);
            int endTagPos;

            System.Collections.ArrayList al = new System.Collections.ArrayList();
            System.Collections.ArrayList startPosit = new System.Collections.ArrayList();

            while (startTagPos != -1)
            {
                endTagPos = inputString.IndexOf(endTag, startTagPos + startTag.Length);

                if (endTagPos != -1)
                {
                    string findedWord = inputString.Substring(startTagPos + startTag.Length, endTagPos - startTagPos - startTag.Length);

                    bool doExclude = false;
                    foreach (string exclStrPatern in excludeStringPaterns)
                    {
                        if (exclStrPatern == findedWord)
                        {
                            doExclude = true;
                            break;
                        }
                    }
                    if (!doExclude)
                    {
                        al.Add(findedWord);
                        startPosit.Add(startTagPos + startTag.Length);
                    }

                    startTagPos = inputString.IndexOf(startTag, endTagPos + 1);
                }
                else
                {
                    break;
                }
            }

            object resultAray = al.ToArray(typeof(string));
            startPositions = (int[])startPosit.ToArray(typeof(int));

            return (string[])resultAray;
        }
        #endregion
    }
}
