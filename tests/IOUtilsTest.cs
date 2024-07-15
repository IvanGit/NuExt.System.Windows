using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuExt.System.Windows.Tests
{
    public class IOUtilsTest
    {
        [Test]
        public void SmartEndTrimTest()
        {
            var originalFileName = "This name too long.txt";
            var fileName = IOUtils.SmartTrimFileName(originalFileName, 12);
            Assert.That(fileName, Is.EqualTo("This.txt"));
            fileName = IOUtils.SmartTrimFileName(originalFileName, 13);
            Assert.That(fileName, Is.EqualTo("This name.txt"));
            fileName = IOUtils.SmartTrimFileName(originalFileName, 14);
            Assert.That(fileName, Is.EqualTo("This name.txt"));

            originalFileName = "This_name_too_long.txt";
            fileName = IOUtils.SmartTrimFileName(originalFileName, 12);
            Assert.That(fileName, Is.EqualTo("This.txt"));
            fileName = IOUtils.SmartTrimFileName(originalFileName, 13);
            Assert.That(fileName, Is.EqualTo("This_name.txt"));
            fileName = IOUtils.SmartTrimFileName(originalFileName, 14);
            Assert.That(fileName, Is.EqualTo("This_name.txt"));

            originalFileName = "This-name-too-long.txt";
            fileName = IOUtils.SmartTrimFileName(originalFileName, 12);
            Assert.That(fileName, Is.EqualTo("This.txt"));
            fileName = IOUtils.SmartTrimFileName(originalFileName, 13);
            Assert.That(fileName, Is.EqualTo("This-name.txt"));
            fileName = IOUtils.SmartTrimFileName(originalFileName, 14);
            Assert.That(fileName, Is.EqualTo("This-name.txt"));

            originalFileName = "This@name@too@long.txt";
            fileName = IOUtils.SmartTrimFileName(originalFileName, 12);
            Assert.That(fileName, Is.EqualTo("This@nam.txt"));
            fileName = IOUtils.SmartTrimFileName(originalFileName, 13);
            Assert.That(fileName, Is.EqualTo("This@name.txt"));
            fileName = IOUtils.SmartTrimFileName(originalFileName, 14);
            Assert.That(fileName, Is.EqualTo("This@name@.txt"));
        }

        [Test]
        public void ClearFileNameTest()
        {
            var originalFileName = "This:name:too:long.txt";
            var fileName = IOUtils.ClearFileName(originalFileName, 12);
            Assert.That(fileName, Is.EqualTo("This.txt"));
            fileName = IOUtils.ClearFileName(originalFileName, 13);
            Assert.That(fileName, Is.EqualTo("This_name.txt"));
            fileName = IOUtils.ClearFileName(originalFileName, 14);
            Assert.That(fileName, Is.EqualTo("This_name.txt"));

            originalFileName = "This?name?too?long.txt";
            fileName = IOUtils.ClearFileName(originalFileName, 12);
            Assert.That(fileName, Is.EqualTo("This.txt"));
            fileName = IOUtils.ClearFileName(originalFileName, 13);
            Assert.That(fileName, Is.EqualTo("This_name.txt"));
            fileName = IOUtils.ClearFileName(originalFileName, 14);
            Assert.That(fileName, Is.EqualTo("This_name.txt"));

            originalFileName = "This*name*too*long.txt";
            fileName = IOUtils.ClearFileName(originalFileName, 12);
            Assert.That(fileName, Is.EqualTo("This.txt"));
            fileName = IOUtils.ClearFileName(originalFileName, 13);
            Assert.That(fileName, Is.EqualTo("This_name.txt"));
            fileName = IOUtils.ClearFileName(originalFileName, 14);
            Assert.That(fileName, Is.EqualTo("This_name.txt"));

            originalFileName = "This@name@too@long.txt";
            fileName = IOUtils.ClearFileName(originalFileName, 12);
            Assert.That(fileName, Is.EqualTo("This@nam.txt"));
            fileName = IOUtils.ClearFileName(originalFileName, 13);
            Assert.That(fileName, Is.EqualTo("This@name.txt"));
            fileName = IOUtils.ClearFileName(originalFileName, 14);
            Assert.That(fileName, Is.EqualTo("This@name@.txt"));
        }
    }
}
