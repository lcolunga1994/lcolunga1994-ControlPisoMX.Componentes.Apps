//namespace ProlecGE.ControlPisoMX.BFWeb.Components.Cores.Residential.Queries
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Text;
//    using System.Threading;
//    using System.Threading.Tasks;
//    using MediatR;
//    using Residential.Models;

//    public class ResidentialCoreTestResultQuery : IRequest<ResidentialCoreTestResultModel?>
//    {
//        #region Constructor

//        public ResidentialCoreTestResultQuery(string testCode)
//        {
//            TestCode = testCode;
//        }

//        #endregion

//        #region Properties

//        public string TestCode { get; internal set; }

//        #endregion
//    }

//    public class ResidentialCoreTestResultQueryHandler : IRequestHandler<ResidentialCoreTestResultQuery, ResidentialCoreTestResultModel?>
//    {
//        #region Fields

//        private readonly ControlPisoMX.Cores.IMicroservice cores;

//        #endregion

//        #region Constructor

//        public ResidentialCoreTestResultQueryHandler(ControlPisoMX.Cores.IMicroservice cores)
//        {
//            this.cores = cores;
//        }

//        #endregion

//        #region Methods

//        public async Task<ResidentialCoreTestResultModel?> Handle(
//            ResidentialCoreTestResultQuery request,
//            CancellationToken cancellationToken)
//        {
//            ResidentialCoreTestResultModel? coreTestResult = null;

//            ControlPisoMX.Cores.Models.ResidentialCoreTestResultModel? residentialCoreTestResult = await cores.GetResidentialCoreTestResultAsync(request.TestCode).ConfigureAwait(false);

//            if (residentialCoreTestResult != null)
//            {
//                coreTestResult = new ResidentialCoreTestResultModel(
//                    residentialCoreTestResult.Tag,
//                    residentialCoreTestResult.TestCode,
//                    residentialCoreTestResult.Status,
//                    residentialCoreTestResult.CorrectedWatts,
//                    residentialCoreTestResult.NewWatts,
//                    residentialCoreTestResult.CurrentPercentage,
//                    residentialCoreTestResult.Color,
//                    residentialCoreTestResult.Warnings,
//                    residentialCoreTestResult.TotalCores,
//                    residentialCoreTestResult.TestedCores,
//                    residentialCoreTestResult.TotalTests,
//                    residentialCoreTestResult.CoreSizes,
//                    residentialCoreTestResult.DefectConcept
//                    );
//            }

//            return coreTestResult;
//        }
            
//        #endregion
//    }
//}
