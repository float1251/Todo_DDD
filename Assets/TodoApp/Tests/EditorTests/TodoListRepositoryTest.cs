using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using LiteDB;
using NUnit.Framework;
using TodoApp.Domain.Todo;
using TodoApp.Infrastructure.Todo;
using UnityEngine;
using UnityEngine.TestTools;

namespace TodoApp.Tests.EditorTests
{
    public static class TestUtility
    {
        public static string GetTestDBPath()
        {
            return Application.temporaryCachePath + "/test.db";
        }
    }

    public class TodoListRepositoryTest
    {
        private TodoRepository repo;

        [SetUp]
        public void SetUp()
        {
            var db = new LiteDatabase(TestUtility.GetTestDBPath());
            TodoModel Create(int n) => new TodoModel() {id = System.Guid.NewGuid().ToString(), name = $"test_{n}"};
            var col = db.GetCollection<TodoModel>();
            col.Insert(Create(0));
            col.Insert(Create(1));
            col.Insert(Create(2));
            db.Dispose();

            this.repo = new TodoRepository(TestUtility.GetTestDBPath());
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(TestUtility.GetTestDBPath());
            this.repo?.Dispose();
        }

        [Test]
        public void LiteDBListTodo()
        {
            // db直接テストしたいので、disposeする
            this.repo.Dispose();
            this.repo = null;
            using var db = new LiteDatabase(TestUtility.GetTestDBPath());
            TodoModel Create(int n) => new TodoModel {id = System.Guid.NewGuid().ToString(), name = $"test_{n}"};
            var targetTodo = Create(4);
            var col = db.GetCollection<TodoModel>();
            col.Insert(targetTodo);

            var res = col.FindAll();
            Assert.That(res.Count(), Is.EqualTo(4));
            var d = col.FindById(targetTodo.id);
            Assert.That(d, Is.Not.Null);
            Assert.That(d.id, Is.EqualTo(targetTodo.id));
        }

        [UnityTest]
        public IEnumerator FindAll()
        {
            var task = this.repo.FindAll();
            while (!task.IsCompleted) yield return null;
            var res = task.Result;
            Assert.That(res.Count(), Is.EqualTo(3));
        }

        [UnityTest]
        public IEnumerator CreateTask()
        {
            var task = this.repo.CreateTask("test_task");
            while (!task.IsCompleted) yield return null;
            var res = task.Result;
            Assert.That(res.name, Is.EqualTo("test_task"));
            var task1 = this.repo.FindAll();
            while (!task1.IsCompleted) yield return null;
            Assert.That(task1.Result.FirstOrDefault(v => v.name == "test_task"), Is.Not.Null);
        }
    }
}