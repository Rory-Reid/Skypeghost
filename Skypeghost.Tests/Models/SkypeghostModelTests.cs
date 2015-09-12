namespace Skypeghost.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Skypeghost.DALs;
    using Skypeghost.Models;

    [TestClass]
    public class SkypeghostModelTests
    {
        private Mock<IClipboardAccessor> mockClipboardAccessor = new Mock<IClipboardAccessor>();

        [TestMethod]
        public void GetLatestClipboardData_Always_CallsAccessorGetClipboardData()
        {
            // Arrange
            var sut = this.CreateSut();

            // Act
            sut.GetLatestClipboardData();

            // Assert
            this.mockClipboardAccessor.Verify(x => x.GetClipboardData(), Times.Once);
        }

        private SkypeghostModel CreateSut()
        {
            return new SkypeghostModel(this.mockClipboardAccessor.Object);
        }
    }
}
