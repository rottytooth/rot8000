using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rottytooth.Rot8000;

namespace Rottytooth.Rot8000.Tests
{
    [TestClass]
    public class MappingsTests
    {
        /// <summary>
        /// Make sure it's an even-numbered list; otherwise the conversion is not reversable
        /// </summary>
        [TestMethod]
        public void MappingsIsEven()
        {
            Assert.IsTrue(Rotator.Mappings.Count % 2 == 0);
        }

        /// <summary>
        /// Does it match what's previously live?
        /// </summary>
        [TestMethod]
        public void MatchesPreviousIteration()
        {
            Assert.AreEqual(
                Rotator.Rotate(@"安全靶点百度安全联姻TP-LINK 安全技术受热捧百度杀毒用户数破2000万360再度恶意拦截百度走进武汉大学鼓励大学生互联网安全创新2013全民双十一抢货，谁来为电脑加速？百度杀毒：双十一网购需警惕“吸血鬼”木马百度拦截DNS劫持木马，双重手段保网民安全"),
                "흟촾ᮐ穀흟촾ѭ헑籝籙簶籕籒籗籔 흟촾쾭穀ﰊ簻簹簹簹짝簼簿簹쵣穀ᆉᏴ퓽휼⌼캇퓽휼쩨ѭͪ흟촾췱簻簹簺簼촾쾢켗짖ᅀ笶ယ쨐喇Ԫ칶ᐸ等穀筄쾢켗짖ͪᅆᬚཿ鯷퀎ౙὖ鯸Ẇ穀籍籗籜캁Ẇ笶쾢ᗦ쮳ͪ흟촾");
        }

        /// <summary>
        /// Another specific example from what's previously live
        /// </summary>
        [TestMethod]
        public void MatchesPreviousIterationLatin()
        {
            Assert.AreEqual(
                Rotator.Rotate(@"HNEre is asdioja doij !~12213123123 12312 3123123"),
                "籑籗籎类籮 籲籼 籪籼籭籲籸米籪 籭籸籲米 簪粇簺簻簻簺簼簺簻簼簺簻簼 簺簻簼簺簻 簼簺簻簼簺簻簼");
        }

        // FIXME: add a complete set of tests for previously live data
    }
}
