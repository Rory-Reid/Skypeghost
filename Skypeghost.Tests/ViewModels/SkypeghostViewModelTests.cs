namespace Skypeghost.Tests.ViewModels
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Skypeghost.Models;
    using Skypeghost.ViewModels;

    [TestClass]
    public class SkypeghostViewModelTests
    {
        private Mock<ISkypeghostModel> mockSkypeghostModel = new Mock<ISkypeghostModel>();

        [TestMethod]
        public void PasteClipboardDataCommand_WhenExecuted_CallsModelGetPasteData()
        {
            // Arrange
            var sut = this.CreateSut();

            // Act
            sut.PasteClipboardData.Execute(null);

            // Assert
            this.mockSkypeghostModel.Verify(x => x.GetLatestClipboardData(), Times.Once);
        }

        private SkypeghostViewModel CreateSut()
        {
            return new SkypeghostViewModel(this.mockSkypeghostModel.Object);
        }
    }
}
