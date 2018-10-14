using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpeechServicesToolkit.STT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechServicesToolkit.TTS.Tests
{
    [TestClass]
    public class RecorderTests
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void TestRecorder()
        {
            var recorder = new Recorder();
            recorder.Record();

            Assert.IsTrue(true);
        }
    }
}
