using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rottytooth.Rot8000;

namespace Rottytooth.Rot8000.Tests
{
    [TestClass]
    public class ConversionTests
    {
        [TestMethod]
        public void FromRomanCharacters()
        {
            ReturnsToSame("test");
        }

        [TestMethod]
        public void RomanWithPunctuationAndWhitespace()
        {
            ReturnsToSame("Here is someething ??? +-=\r\n`~!@#$%&*(+_)\r(\telseee for you WITH punc/tuat.ion;");
        }

        [TestMethod]
        public void SurrogatePairChars()
        {
            for (int i = char.MinValue; i <= Rotator.BMP_SIZE; i++)
            {
                char c = (char)i;

                if (char.IsLowSurrogate(c) || char.IsHighSurrogate(c))
                {
                    ReturnsToSame(c.ToString());
                }
            }
        }

        [TestMethod]
        public void OldSurrogatePairFails()
        {
            ReturnsToSame("安");
            ReturnsToSame(@"安全靶点百度安全联姻TP-LINK 安全技术受热捧百度杀毒用户数破2000万360再度恶意拦截百度走进武汉大学鼓励大学生互联网安全创新2013全民双十一抢货，谁来为电脑加速？百度杀毒：双十一网购需警惕“吸血鬼”木马百度拦截DNS劫持木马，双重手段保网民安全");
        }

        /// <summary>
        /// The examples posted to the Hacker News thread way back
        /// </summary>
        [TestMethod]
        public void PreviousFails()
        {
            ReturnsToSame("Λ̊1");
            ReturnsToSame("𝄞");
            ReturnsToSame("한글");
            ReturnsToSame("한글:똼軠:霜激:矼傠:壜ㆀ:㦼በ:᪜ㆀ:㦼በ");
            ReturnsToSame("こんにちは。元気ですかᄳᅳᅋᅁᅏტ㈣䳷ᅇᄹᄫტこんにちは。ጃ⷗ですか。");
        }

        private void ReturnsToSame(string test)
        {
            string firstConversion = Rotator.Rotate(test);
            string secondConversion = Rotator.Rotate(firstConversion);
            Assert.AreEqual(secondConversion, test);
        }
    }
}
