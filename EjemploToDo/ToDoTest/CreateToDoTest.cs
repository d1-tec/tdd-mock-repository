using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToDo;
using Moq;

namespace ToDoTest
{
    [TestClass]
    public class CreateToDoTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidToDoException))]
        public void WeCannotHaveANullItemOnTheToDoList()
        {
            // Le "inyecto" (Googlear inyeccion de dependencias)
            // un repositorio en memoria
            ToDoHandler todoHandler = new ToDoHandler(new RepositoryInList());
            todoHandler.CreateToDo(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidToDoException))]
        public void WeCannotHaveAnEmptyItemOnTheToDoList()
        {
            var repoMock = new Mock<IRepository>();

            ToDoHandler toDoHandler = new ToDoHandler(repoMock.Object);
            toDoHandler.CreateToDo("");
        }

        [TestMethod]
        public void WeAddAValidToDoItem()
        {
            // Arrange o Setup
            // Preparar el contexto que necesito para la prueba

            // Config del Mock
            var repoMock = new Mock<IRepository>();
            repoMock.Setup(x => x.Add("Pagar Antel")).Verifiable();
            repoMock.Setup(x => x.Count()).Returns(1);

            ToDoHandler toDoHandler = new ToDoHandler(repoMock.Object);

            // Act o Exercise
            // Ejecutar o ejercitar el metodo que quiero testear
            toDoHandler.CreateToDo("Pagar Antel");

            // Assert o Verify
            // Validar si la prueba es o no exitosa
            int amountOfItems = toDoHandler.AmountOfItems();
            repoMock.Verify();
            Assert.AreEqual(1, amountOfItems);

            // Opcionalmente puede haber un Teardown
            // Para "limpiar" el contexto inicial
        }

        // Triangulation
        // Si no me animo a generalizar una solucion puedo
        // seguir agregando casos de prueba
        [TestMethod]
        public void InitiallyWeShouldNotHaveItemsOnTheList()
        {
            var repoMock = new Mock<IRepository>(MockBehavior.Strict);

            // repoMock.Setup(x => x.Count()).Returns(0);

            ToDoHandler toDoHandler = new ToDoHandler(repoMock.Object);

            Assert.AreEqual(0, toDoHandler.AmountOfItems());
        }
    }
}
