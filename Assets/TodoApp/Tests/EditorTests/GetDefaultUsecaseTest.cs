using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LiteDB;
using NUnit.Framework;
using TodoApp.Domain.Todo;
using TodoApp.Usecase.Todo;
using TodoApp.Usecase.Todo.DTO;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace TodoApp.Tests.EditorTests
{
    public class TestRepository : ITodoListRepository, IDisposable
    {
        private readonly LiteDatabase db;

        public TestRepository()
        {
            var path = Path.Combine(Application.temporaryCachePath, "test.db");
            this.db = new LiteDatabase(path);
        }

        public Task CreateTodoList(TodoList todolist)
        {
            var col = this.db.GetCollection<TodoList>();
            col.Insert(todolist);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<TodoList>> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<TodoList> Find()
        {
            var col = db.GetCollection<TodoList>();
            var one = col.FindOne(v => v.name == "TestTodoList");
            await Task.CompletedTask;
            return one;
        }

        public Task<Todo> CreateTask(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Todo> UpdateTask(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Todo DeleteTask(TodoId todoId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            db?.Dispose();
            File.Delete(Path.Combine(Application.temporaryCachePath, "test.db"));
        }
    }

    public class GetDefaultUsecaseTest
    {
        private TestRepository repo;

        [SetUp]
        public void SetUp()
        {
            this.repo = new TestRepository();
            this.repo.CreateTodoList(new TodoList("TestTodoList"));
        }

        [TearDown]
        public void TearDown()
        {
            this.repo.Dispose();
        }
        
        // UnityのNUnitはasyncにできないので仕方なく以下のような形でテストをしている.
        [UnityTest]
        public IEnumerator GetDefaultUseCase()
        {
            var target = new GetDefaultUseCase(this.repo);
            var task = target.GetDefaultTodoList();
            while (!task.IsCompleted)
            {
                yield return null;
            }
            Assert.That(task.Result.name, Is.EqualTo("TestTodoList"));
        }
    }
}