namespace ConsoleApplication23
{
    using System;

    using QI4N.Framework;
    using QI4N.Framework.Bootstrap;
    using QI4N.Framework.Runtime;

    internal class Program
    {
        private static void Main()
        {
            var f = new ApplicationAssemblyFactory();

            ApplicationAssembly app = f.NewApplicationAssembly();

            LayerAssembly domainLayer = CreateDomainLayer(app);

            
            // Instantiate the Application Model.

        }

        private static LayerAssembly CreatePersistenceLayer(ApplicationAssembly app)
        {
            throw new NotImplementedException();
        }

        private static LayerAssembly CreateMessagingLayer(ApplicationAssembly app)
        {
            throw new NotImplementedException();
        }

        private static LayerAssembly CreateDomainLayer(ApplicationAssembly app)
        {
            LayerAssembly layer = app.NewLayerAssembly();

            ModuleAssembly peopleModule = CreatePeopleModule(layer);
            return layer;


        }

        private static ModuleAssembly CreatePeopleModule(LayerAssembly layer)
        {
            ModuleAssembly module = layer.NewModuleAssembly();

            module
                .AddEntities()
                .Include<CarEntity>()
                .VisibleIn(Visibility.Layer);
            
            module
                .AddServices()
                .Include<ManufacturerRepositoryService>()
                .VisibleIn( Visibility.Layer );
            
            module
                .AddValues();
            
            module
                .AddTransients()
                .Include<PersonComposite>()
                .WithMixin<RandomFooMixin>();

            return module;


        }
    }
}