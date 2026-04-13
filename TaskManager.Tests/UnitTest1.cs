using Xunit;
using CloudBackend.Models;

namespace TaskManager.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void NewTask_ShouldNotBeCompleted()
        {
            // 1. Tworzenie obiektu
            var task = new CloudTask();

            // 2. Nadanie nazwy
            task.Name = "Przetestować bezpiecznik";

            // 3. Weryfikacja (Asercja)
            Assert.False(task.IsCompleted);
        }
    }
}