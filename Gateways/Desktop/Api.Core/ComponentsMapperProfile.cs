namespace ProlecGE.ControlPisoMX.BFWeb.Components
{
    using AutoMapper;

    public class ComponentsMapperProfile : Profile
    {
        public ComponentsMapperProfile()
        {
            //Núcleos
            CreateMap<ControlPisoMX.Cores.Models.CoreTestDefectConceptModel,
                Cores.Residential.Models.CoreTestDefectConceptModel>()
                .DisableCtorValidation();

            CreateMap<Cores.Residential.Models.CoreTestDefectConceptModel,
                ControlPisoMX.Cores.Models.CoreTestDefectConceptModel>()
                .DisableCtorValidation();

            CreateMap<Cores.Residential.Models.ResidentialCoreTestResultModel,
                ControlPisoMX.Cores.Models.ResidentialCoreTestResultModel>()
                .DisableCtorValidation();

            CreateMap<ControlPisoMX.Cores.Models.ResidentialCoreTestResultModel,
                Cores.Residential.Models.ResidentialCoreTestResultModel>()
                .DisableCtorValidation();

            //Ensamble -- Se debe crear un proyecto para poner estos modelos (BFWeb.Components.Api.Assembly.Abstractions)
            //CreateMap<ControlPisoMX.ERP.Models.ItemVoltageDesignModel,
            //    Models.ItemVoltageDesignModel>()
            //    .DisableCtorValidation();

            //CreateMap<ControlPisoMX.ERP.Models.ItemVoltageLimitModel,
            //    Models.CoreVoltageLimitModel>()
            //    .DisableCtorValidation();

            //CreateMap<ControlPisoMX.ERP.Models.ItemModel,
            //    Models.ItemModel>()
            //    .DisableCtorValidation();

            //CreateMap<ControlPisoMX.ERP.Models.PositionModel,
            //    Models.PositionModel>()
            //    .DisableCtorValidation();

            //CreateMap<ControlPisoMX.ERP.Models.MaterialModel,
            //    Models.MaterialModel>()
            //    .DisableCtorValidation();

            //CreateMap<ControlPisoMX.ERP.Models.AccessoryModel,
            //    Models.AccessoryModel>()
            //    .DisableCtorValidation();
        }
    }
}