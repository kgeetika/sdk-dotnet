namespace AuthorizeNet.Api.Controllers.Test
{
    using System;
    using System.Collections.Generic;
    using AuthorizeNet.Api.Contracts.V1;
    using AuthorizeNet.Api.Controllers;
    using AuthorizeNet.Api.Controllers.Bases;
    using AuthorizeNet.Util;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ARBCreateSubscriptionTest : ApiCoreTestBase 
	{

	    [ClassInitialize]
        public new static void SetUpBeforeClass(TestContext context)
        {
		    ApiCoreTestBase.SetUpBeforeClass(context);
	    }

	    [ClassCleanup]
        public new static void TearDownAfterClass()
        {
		    ApiCoreTestBase.TearDownAfterClass();
	    }

	    [TestInitialize]
	    public new void SetUp() 
		{
		    base.SetUp();
	    }

	    [TestCleanup]
	    public new void TearDown() 
		{
		    base.TearDown();
	    }

        [TestMethod]
	    public void MockARBCreateSubscriptionTest()
	    {
		    //define all mocked objects as final
            var mockController = GetMockController<ARBCreateSubscriptionRequest, ARBCreateSubscriptionResponse>();
            var mockRequest = new ARBCreateSubscriptionRequest
                {
                    merchantAuthentication = new merchantAuthenticationType {name = "mocktest", Item = "mockKey", ItemElementName = ItemChoiceType.transactionKey},
                    subscription = ArbSubscriptionOne,
                };
            var mockResponse = new ARBCreateSubscriptionResponse
                {
                    refId = "1234",
                    sessionToken = "sessiontoken",
                    subscriptionId = "1234",
                };

		    var errorResponse = new ANetApiResponse();
		    var results = new List<String>();
            const messageTypeEnum messageTypeOk = messageTypeEnum.Ok;

            SetMockControllerExpectations<ARBCreateSubscriptionRequest, ARBCreateSubscriptionResponse, ARBCreateSubscriptionController>(
                mockController.MockObject, mockRequest, mockResponse, errorResponse, results, messageTypeOk);
            mockController.MockObject.Execute(AuthorizeNet.Environment.CUSTOM);
            //mockController.MockObject.Execute();
            // or var controllerResponse = mockController.MockObject.ExecuteWithApiResponse(AuthorizeNet.Environment.CUSTOM);
            var controllerResponse = mockController.MockObject.GetApiResponse();
            Assert.IsNotNull(controllerResponse);

            Assert.IsNotNull(controllerResponse.subscriptionId);
            LogHelper.info(Logger, "ARBCreateSubscription: Details:{0}", controllerResponse.subscriptionId);
	    }
    }
}
