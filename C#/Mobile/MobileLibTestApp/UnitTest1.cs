using NUnit.Framework;
using Moq;

namespace TekTutor
{
    public class MobileTest
    {
        private Mobile mobile;
        private Mock<ICamera> mockedCamera;

        [SetUp]
        public void Setup()
        {
            mockedCamera = new Moq.Mock<ICamera>();  //Mocking
            mobile = new Mobile(mockedCamera.Object);
        }

        [Test]
        public void TestPowerOnWhenCameraOnWorksNormally()
        {
            //Stubbing - hard coding the response of the dependent method
            mockedCamera.Setup(camera => camera.on()).Returns(true);

            bool actualResponse = mobile.powerOn(); //Act - tes5ting

            //Assert.IsTrue(actualResponse); //Asserting - verifying the actual behavior
            mockedCamera.Verify(camera => camera.on(), Times.Once());

        }

        [Test]
        public void TestPowerOnWhenCameraOnMalfunctions()
        {
            //Stubbing - hard coding the response of the dependent method
            mockedCamera.Setup(camera => camera.on()).Returns(false);

           bool actualResponse = mobile.powerOn(); //Act - tes5ting

           Assert.IsFalse(actualResponse); //Asserting - verifying the actual behavior

            mockedCamera.Verify(camera => camera.on(), Times.Once());

        }



    }
}