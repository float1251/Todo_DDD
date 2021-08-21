using NUnit.Framework;
using TodoApp.Domain.Todo;

namespace TodoApp.Tests.EditorTests
{
    public class TodoDomainTest
    {
        [Test]
        public void TaskId()
        {
            var id = new TaskId();
            var id2 = new TaskId();
            Assert.That(id.id, Is.Not.EqualTo(id2.id));
        }
    }
}


