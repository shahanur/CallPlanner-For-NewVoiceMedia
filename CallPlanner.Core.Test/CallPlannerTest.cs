using System;
using System.Security;
using CallPlanner.Core.Entities;
using CallPlanner.Core.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using Rhino.Mocks;

namespace CallPlanner.Core.Test
{
    [TestFixture]
    public class CallPlannerTest
    {
        private IAssignerManager _assignerManager;
        private IOriginatorDataProvider _originatorDataProvider;
        private IPrinter _printer;
        private IOriginatorService _originatorService;
        private CallPlanner _callPlanner;

        [SetUp]
        public void Initialise()
        {
            _assignerManager = MockRepository.GenerateMock<IAssignerManager>();
            _originatorDataProvider = MockRepository.GenerateMock<IOriginatorDataProvider>();
            _printer = MockRepository.GenerateMock<IPrinter>();
            _originatorService = MockRepository.GenerateMock<IOriginatorService>();
            _callPlanner = new CallPlanner(_assignerManager,_printer,_originatorDataProvider);
        }

        [TearDown]
        public void TearDown()
        {
            _assignerManager = null;
            _originatorDataProvider = null;
            _printer = null;
            _originatorService = null;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_AssignerManagerIsNull_ThrowsNullException()
        {
            //Arrange

            //Act
            _callPlanner = new CallPlanner(null, _printer, _originatorDataProvider);
        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_PrinterIsNull_ThrowsNullException()
        {
            //Arrange

            //Act
            _callPlanner = new CallPlanner(_assignerManager, null, _originatorDataProvider);
        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_OriginatorDataProviderIs_Null_ThrowsNullException()
        {
            //Arrange

            //Act
            _callPlanner = new CallPlanner(_assignerManager, _printer, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Plan_InteractionIs_Null_ThrowsNullException()
        {
            //Arrange

            //Act
            _callPlanner.Plan(null);
        }

        [Test]
        public void Plan_InteractionIsValid_ShouldReturnTrue()
        {
            //Arrange
            var interaction = MockRepository.GenerateMock<Interaction>();
            interaction.Stub(iina => iina.InteractionType).Return(CpEnumerators.InteractionType.Call);
            interaction.Stub(iina => iina.Input).Return("1234");

            var originator = MockRepository.GenerateMock<Originator>();
            originator.Stub(o => o.Email).Return("bob@test.com");
            originator.Stub(o => o.Id).Return("1");
            originator.Stub(o => o.Name).Return("Bob");
            originator.Stub(o => o.PhoneNumber).Return("1234");

            var originatorResponse = MockRepository.GenerateMock<OriginatorResponse>();
            originatorResponse.Stub(or => or.ResponseNumber).Return(2);
            originatorResponse.Stub(or => or.ResponseMessage).Return("some response message");
            originatorResponse.Stub(or => or.ResponseType).Return(ResponseTypeEnumerator.ResponseType.Even);


            _originatorDataProvider.Expect(odp => odp.Provide(interaction)).IgnoreArguments().Return(originator);
            _printer.Expect(p => p.Write("something has printed"));
            _originatorService.Expect(o => o.GetOriginatorSpecificData(interaction)).IgnoreArguments().Return(originatorResponse);
            _assignerManager.Expect(am => am.PerformAssingment(originatorResponse, _printer)).IgnoreArguments().Return(true);
            
            
            //Act
            var result = _callPlanner.Plan(interaction);

            //Assert
            result.Should().BeTrue();
        }

        [Test]
        public void Plan_InteractionIsNotValid_ShouldReturnFalse()
        {
            //Arrange
            var interaction = MockRepository.GenerateMock<Interaction>();

            var originator = MockRepository.GenerateMock<Originator>();
            originator.Stub(o => o.Email).Return("bob@test.com");
            originator.Stub(o => o.Id).Return("1");
            originator.Stub(o => o.Name).Return("Bob");
            originator.Stub(o => o.PhoneNumber).Return("1234");

            var originatorResponse = MockRepository.GenerateMock<OriginatorResponse>();
            originatorResponse.Stub(or => or.ResponseNumber).Return(2);
            originatorResponse.Stub(or => or.ResponseMessage).Return("some response message");
            originatorResponse.Stub(or => or.ResponseType).Return(ResponseTypeEnumerator.ResponseType.Even);


            _originatorDataProvider.Expect(odp => odp.Provide(interaction)).IgnoreArguments().Return(originator);
            _printer.Expect(p => p.Write("something has printed"));
            _originatorService.Expect(o => o.GetOriginatorSpecificData(interaction)).IgnoreArguments().Return(originatorResponse);
            _assignerManager.Expect(am => am.PerformAssingment(originatorResponse, _printer)).IgnoreArguments().Return(false);


            //Act
            var result = _callPlanner.Plan(interaction);

            //Assert
            result.Should().BeFalse();
        }
    }
}
