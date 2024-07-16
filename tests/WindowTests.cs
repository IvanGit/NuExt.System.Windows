using System.Windows;
using System.Windows.Threading;

namespace NuExt.System.Windows.Tests
{
    [Apartment(ApartmentState.STA)]
    public class WindowTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            Dispatcher.CurrentDispatcher.InvokeShutdown();//to prevent InvalidComObjectException
        }

        [Test]
        public async Task WindowPlacementTest()
        {
            var window = new Window();
            var tcs = new TaskCompletionSource<bool>();
            bool isSourceInitialized = false;
            window.SourceInitialized += (sender, e) =>
            {
                Assert.That(isSourceInitialized, Is.False);
                var placement = window.GetPlacement();
                Assert.That(placement, Is.Not.Null);
                bool result = window.SetPlacement(placement);
                Assert.That(result, Is.EqualTo(true));

                var placementStr = window.GetPlacementAsJson();
                Assert.That(placementStr, Is.Not.Null.Or.Empty);
                result = window.SetPlacement(placementStr);
                Assert.That(result, Is.EqualTo(true));

                var placementStr2 = window.GetPlacementAsJson();
                Assert.That(placementStr2, Is.EqualTo(placementStr));

                tcs.SetResult(true);
                isSourceInitialized = true;
            };
            window.Show();
            await tcs.Task;
            window.Close();
            Assert.Pass();
        }
    }
}