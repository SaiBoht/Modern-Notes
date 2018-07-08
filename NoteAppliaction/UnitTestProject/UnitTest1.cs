using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using ClientAppliaction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestfulAPI.Controllers;
using RestfulAPI.DAL;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        Mock<IRepository> _clientRepository;
        Mock<IDBRepository> _apiRepository;
        List<Note> notes;
        List<RestfulAPI.Models.Note> apiNotes;

        [TestInitialize]
        public void SetupContext()
        {
            /*
            ApplicationForm app = new ApplicationForm();
            NotesController api = new NotesController();
            */

            _clientRepository = new Mock<IRepository>();
            _apiRepository = new Mock<IDBRepository>();
            notes = new List<Note>{
                new Note { Id = 1, Name = "title1", Text = "Content1" },
                new Note { Id = 2, Name = "title2", Text = "Content2" },
                new Note { Id = 3, Name = "title3", Text = "Content3" } };
            apiNotes = new List<RestfulAPI.Models.Note>{
                new RestfulAPI.Models.Note { Id = 1, Name = "title1", Text = "Content1" },
                new RestfulAPI.Models.Note { Id = 2, Name = "title2", Text = "Content2" },
                new RestfulAPI.Models.Note { Id = 3, Name = "title3", Text = "Content3" } };

        }



        [TestMethod]
        public async Task Save_newFile_successAsync()
        {
            //setup
            var app = new ApplicationForm(_clientRepository.Object);
            _clientRepository.Setup(x => x.SaveNewNote("title", "content")).ReturnsAsync(true).Verifiable();
            _clientRepository.Setup(x => x.GetNotes()).ReturnsAsync(notes).Verifiable();

            //turn off message boxes to not interrupt testing
            app.mbOption = false;


            //Act
            await app.Note_SaveAsync(-1, "title", "content");

            //Assert
            _clientRepository.Verify();
            Assert.AreEqual(app.notes, notes);
            Assert.AreEqual(app.note.Name, "title");
            Assert.AreEqual(app.note.Text, "content");
            Assert.AreEqual(app.mbShown, false);

        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public async Task Save_newFile_failedAsync()
        {
            //setup
            var app = new ApplicationForm(_clientRepository.Object);
            _clientRepository.Setup(x => x.SaveNewNote("title", "content")).ThrowsAsync(new Exception()).Verifiable();
            _clientRepository.Setup(x => x.GetNotes()).ReturnsAsync(notes).Verifiable();
            //turn off message boxes to not interrupt testing
            app.mbOption = false;

            //Act
            await app.Note_SaveAsync(-1, "title", "content");

            //Assert
            Assert.AreEqual(app.notes, notes);
            _clientRepository.Verify(x => x.SaveNewNote("title", "content"));
            Assert.AreEqual(app.note.Name, "title");
            Assert.AreEqual(app.note.Text, "content");
            Assert.AreEqual(app.mbShown, true);
        }


        [TestMethod]
        public async Task Save_existingFile_successAsync()
        {
            //setup
            var app = new ApplicationForm(_clientRepository.Object);

            _clientRepository.Setup(x => x.SaveNote(1, "title", "content")).ReturnsAsync(true).Verifiable();
            _clientRepository.Setup(x => x.GetNotes()).ReturnsAsync(notes).Verifiable();
            
            //turn off message boxes to not interrupt testing
            //turn off message boxes to not interrupt testing
            app.mbOption = false;

            //Act
            await app.Note_SaveAsync(1, "title", "content");

            //Assert
            _clientRepository.Verify();
            Assert.AreEqual(app.notes, notes);
            Assert.AreEqual(app.note.Name, "title");
            Assert.AreEqual(app.note.Text, "content");
            Assert.AreEqual(app.mbShown, false);
        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public async Task Save_exsistingFile_failedAsync()
        {
            //setup
            var app = new ApplicationForm(_clientRepository.Object);

            _clientRepository.Setup(x => x.SaveNote(1, "title", "content")).ThrowsAsync(new Exception()).Verifiable();
            _clientRepository.Setup(x => x.GetNotes()).ReturnsAsync(notes).Verifiable();

            //turn off message boxes to not interrupt testing
            app.mbOption = false;

            //Act
            await app.Note_SaveAsync(1, "title", "content");

            //Assert
            _clientRepository.Verify();
            Assert.AreEqual(app.notes, notes);
            Assert.AreEqual(app.note.Name, "title");
            Assert.AreEqual(app.note.Text, "content");
            Assert.AreEqual(app.mbShown, true);
        }


        [TestMethod]
        public async Task Delete_exsistingFile_successAsync()
        {
            //setup
            var app = new ApplicationForm(_clientRepository.Object);
            app.note.Name = "name";
            app.note.Text = "text";

            _clientRepository.Setup(x => x.DeleteNote(1)).ReturnsAsync(true).Verifiable();
            _clientRepository.Setup(x => x.GetNotes()).ReturnsAsync(notes).Verifiable();

            //turn off message boxes to not interrupt testing
            app.mbOption = false;

            //Act
            await app.Note_deleteAsync(1);

            //Assert
            _clientRepository.Verify();
            Assert.AreEqual(app.notes, notes);
            Assert.AreEqual(app.note.Name, null);
            Assert.AreEqual(app.note.Text, null);
            Assert.AreEqual(app.mbShown, false);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public async Task Delete_exsistingFile_failedAsync()
        {
            //setup
            var app = new ApplicationForm(_clientRepository.Object);
            app.note.Name = "name";
            app.note.Text = "text";


            _clientRepository.Setup(x => x.DeleteNote(1)).ThrowsAsync(new Exception()).Verifiable();

            //turn off message boxes to not interrupt testing
            app.mbOption = false;

            //Act
            await app.Note_deleteAsync(1);

            //Assert
            Assert.AreEqual(app.note.Name, "name");
            Assert.AreEqual(app.note.Text, "text");
            Assert.AreEqual(app.mbShown, true);
        }

        [TestMethod]
        public async Task Delete_nonExsistingFile_failedAsync()
        {
            //setup
            var app = new ApplicationForm(_clientRepository.Object);
            app.note.Name = "name";
            app.note.Text = "text";

            //turn off message boxes to not interrupt testing
            app.mbOption = false;


            //Act
            await app.Note_deleteAsync(-1);

            //Assert
            Assert.AreEqual(app.note.Name, "name");
            Assert.AreEqual(app.note.Text, "text");
            Assert.AreEqual(app.mbShown, false);
        }

        [TestMethod]
        public async Task Get_exsistingNote_successAsync()
        {
            //setup
            var app = new ApplicationForm(_clientRepository.Object);
            _clientRepository.Setup(x => x.GetNotes()).ReturnsAsync(notes).Verifiable();

            //turn off message boxes to not interrupt testing
            app.mbOption = false;


            //Act
            List<Note> result = await app.GetNotesAsync();

            //Assert
            _clientRepository.Verify();
            Assert.AreEqual(app.notes, notes);
            Assert.AreEqual(app.notes, result);
            Assert.AreEqual(app.mbShown, false);
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public async Task Get_exsistingNote_failedAsync()
        {
            //setup
            var app = new ApplicationForm(_clientRepository.Object);
            _clientRepository.Setup(x => x.GetNotes()).ThrowsAsync(new Exception()).Verifiable();

            //turn off message boxes to not interrupt testing
            app.mbOption = false;


            //Act
            List<Note> result = await app.GetNotesAsync();

            //Assert
            _clientRepository.Verify();
            //Assert.AreNotEqual(app.notes, notes);
            Assert.IsTrue(app.notes.Count == 0);
            Assert.AreEqual(app.notes, result);
            Assert.AreEqual(app.mbShown, false);
        }








        [TestMethod]
        public async Task API_SaveNewNote_Success()
        {
            //setup
            var controller = new NotesController(_apiRepository.Object);
            _apiRepository.Setup(x => x.saveNote(It.IsAny<RestfulAPI.Models.Note>())).Returns(Task.FromResult(Task.CompletedTask)).Verifiable();

            //act
            IHttpActionResult result = await controller.PostNote(apiNotes[1]);

            //assert
            _apiRepository.Verify();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<RestfulAPI.Models.Note>));
        }

        [TestMethod]
        public async Task API_SaveNewNote_Failed()
        {
            //setup
            var controller = new NotesController(_apiRepository.Object);
            _apiRepository.Setup(x => x.saveNote(apiNotes[1])).ThrowsAsync(new Exception()).Verifiable();

            //act
            IHttpActionResult result = await controller.PostNote(apiNotes[1]);

            //assert
            _apiRepository.Verify();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }


        [TestMethod]
        public async Task API_SaveEditNote_Success()
        {
            //setup
            var controller = new NotesController(_apiRepository.Object);
            _apiRepository.Setup(x => x.editNote(It.IsAny<RestfulAPI.Models.Note>()))
                .Returns(Task.FromResult(Task.CompletedTask))
                .Verifiable();
            _apiRepository.Setup(x => x.GetNote(2))
                .ReturnsAsync(apiNotes[1])
                .Verifiable();

            //act
            IHttpActionResult result = await controller.PutNote(2, apiNotes[1]);

            //assert
            _apiRepository.Verify();
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
        }

        [TestMethod]
        public async Task API_SaveEditNote_Failed()
        {
            //setup
            var controller = new NotesController(_apiRepository.Object);

            //act
            IHttpActionResult result = await controller.PutNote(1, apiNotes[1]);

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }


        [TestMethod]
        public async Task API_SaveEditNote_Failed_SavingError()
        {
            //setup
            var controller = new NotesController(_apiRepository.Object);
            _apiRepository.Setup(x => x.editNote(It.IsAny<RestfulAPI.Models.Note>()))
                .ThrowsAsync(new Exception())
                .Verifiable();
            _apiRepository.Setup(x => x.GetNote(2))
                .ReturnsAsync(apiNotes[1])
                .Verifiable();

            //act
            IHttpActionResult result = await controller.PutNote(2, apiNotes[1]);

            //assert
            _apiRepository.Verify();
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }


        /*
        [Ignore]
        [TestMethod]
        public async Task API_GetNote()
        {
            //GetNote is not in use currently
        }
        */

        [TestMethod]
        public async Task API_GetNotes()
        {
            //setup
            var controller = new NotesController(_apiRepository.Object);
            _apiRepository.Setup(x => x.GetNotes())
                .ReturnsAsync(apiNotes)
                .Verifiable();

            //act
            List<RestfulAPI.Models.Note> result = await controller.GetNotesAsync();

            //assert
            _apiRepository.Verify();
            Assert.IsInstanceOfType(result, typeof(List<RestfulAPI.Models.Note>));
            Assert.AreEqual(result, apiNotes);
        }

        [TestMethod]
        public async Task API_DeleteNote_Success()
        {
            //setup
            var controller = new NotesController(_apiRepository.Object);
            _apiRepository.Setup(x => x.DeleteNote(It.IsAny<RestfulAPI.Models.Note>()))
                .Returns(Task.FromResult(Task.CompletedTask))
                .Verifiable();
            _apiRepository.Setup(x => x.GetNote(2))
                .ReturnsAsync(apiNotes[1])
                .Verifiable();

            //act
            IHttpActionResult result = await controller.DeleteNote(2);

            //assert
            _apiRepository.Verify();
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<RestfulAPI.Models.Note>));
        }
        [TestMethod]
        public async Task API_DeleteNote_Failed()
        {
            //setup
            var controller = new NotesController(_apiRepository.Object);

            //act
            IHttpActionResult result = await controller.DeleteNote(2);

            //assert
            _apiRepository.Verify();
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
